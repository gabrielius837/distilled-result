# Distilled Result

[![NuGet version](https://img.shields.io/nuget/v/DistilledResult.svg)](https://www.nuget.org/packages/DistilledResult)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![CI](https://github.com/gabrielius837/distilled-result/actions/workflows/ci.yml/badge.svg)](https://github.com/gabrielius837/distilled-result/actions/workflows/ci.yml)

A minimal, allocation-free implementation of the result pattern for .NET. `Result<TValue, TError>` is a struct that holds either a success value or an error, never both and never neither. It lets code avoid exceptions for control flow. Extension methods add a functional style on top.

## Install

```
dotnet add package DistilledResult
```

## The `Result` type

There is a single type, `Result<TValue, TError>`, generic over both the success value and the error. When one side has nothing meaningful to carry, use `Unit` as `TValue` or `TError` in its place. A result can be built in three ways:

```csharp
// through the constructor, which overloads on Success and Failure
var byCtorSuccess = new Result<int, string>(5);
var byCtorFailure = new Result<int, string>("failed");

// through the static Ok and Fail methods
var byOk = Result.Ok<int, string>(5);
var byFail = Result.Fail<int, string>("failed");

// through an implicit conversion, wherever the target type is already known
Result<int, string> Divide(int a, int b) =>
    b == 0 ? "cannot divide by zero" : a / b;

Result<int, string> implicitAssign = 5;
```

`Value` and `Error` properties are nullable, since a result holds only one of them. Reading the wrong one does not throw: it just returns `default`. Checking `Success` or `Failure` flags lets the compiler infer which one is set, so it narrows that property to non-null for the rest of the branch:

```csharp
var result = Result.Ok<string, string>("test");

var value = result.Value;   // string?
var error = result.Error;   // string?

if (result.Success)
{
    var success = result.Value;   // string, narrowed to non-null
    var stillMaybe = result.Error;   // string?, still nullable
}
else
{
    var stillMaybe = result.Value;   // string?, still nullable
    var failure = result.Error;   // string, narrowed to non-null
}
```

`Failure` narrows the same way, just with `Value` and `Error` swapped:

```csharp
if (result.Failure)
{
    var failure = result.Error;   // string, narrowed to non-null
    var stillMaybe = result.Value;   // string?, still nullable
}
else
{
    var stillMaybe = result.Error;   // string?, still nullable
    var success = result.Value;   // string, narrowed to non-null
}
```

## Functional extensions

The functional style hides branching: instead of checking a result, the code composes operations on it. The first failure ends the chain and returns its error. Each method has overloads for a plain result, a `Task` and a `ValueTask`, with a synchronous or asynchronous delegate and up to three extra arguments, so it chains easily. All of the extensions live in a single namespace:

```csharp
using DistilledResult.FunctionalResultExtensions;
```

| Method | What it does |
| --- | --- |
| `Map` | Transforms the success value and leaves the error unchanged. |
| `MapError` | Transforms the error and leaves the success value unchanged. |
| `Bind` | Chains a step that can itself fail. |
| `Iter` | Runs a side effect on the success value and returns the result unchanged. |
| `IterError` | Runs a side effect on the error and returns the result unchanged. |
| `DefaultValue` | Returns the success value or a fallback value on failure. |
| `DefaultWith` | Returns the success value or a fallback computed from the error. |
| `Match` | Reduces a result to a single value by handling both cases. |

## Examples

The same two methods are written three ways: with exceptions, procedurally with `Result` and as a chain. The exception types and the helper methods that load and save data are not shown.

### Transfer funds

Validate the command, load both accounts, check the balance and persist the transfer.

**Exceptions**

```csharp
public async Task<Transferred> Handle(TransferCommand command, CancellationToken ct)
{
    if (command.From == command.To)
    {
        throw new SameAccountException();
    }

    var from = await Load(command.From, ct) ?? throw new AccountNotFoundException(command.From);
    var to = await Load(command.To, ct) ?? throw new AccountNotFoundException(command.To);
    if (from.Balance < command.Amount)
    {
        throw new InsufficientFundsException();
    }

    await Persist(new TransferPlan(from, to, command.Amount), ct);

    return new Transferred(command.From, command.To, command.Amount);
}
```

The signature doesn't say what can go wrong. The caller has to know about three exception types.

**Procedural**

```csharp
public async Task<Result<Transferred, TransferError>> Handle(TransferCommand command, CancellationToken ct)
{
    if (command.From == command.To)
    {
        return TransferError.SameAccount;
    }

    var from = await Load(command.From, ct);
    var to = await Load(command.To, ct);
    if (from is null || to is null)
    {
        return TransferError.NotFound;
    }

    if (from.Balance < command.Amount)
    {
        return TransferError.InsufficientFunds;
    }

    await Persist(new TransferPlan(from, to, command.Amount), ct);

    return new Transferred(command.From, command.To, command.Amount);
}
```

The possible errors are now part of the return type (`TransferError` is an enum) and nothing is thrown.

**Functional**

```csharp
public Task<Result<Transferred, TransferError>> Handle(TransferCommand command, CancellationToken ct) =>
    EnsureDifferentAccounts(command)
        .Bind(LoadAccounts, ct)
        .Bind(EnsureFunds)
        .Bind(Save, ct)
        .Map(ToResponse, command);
```

<details>
<summary>The steps of the chain</summary>

```csharp
private static Result<TransferCommand, TransferError> EnsureDifferentAccounts(TransferCommand command) =>
    command.From == command.To ? TransferError.SameAccount : command;

private async Task<Result<TransferPlan, TransferError>> LoadAccounts(TransferCommand command, CancellationToken ct)
{
    var from = await Load(command.From, ct);
    var to = await Load(command.To, ct);

    return from is null || to is null
        ? TransferError.NotFound
        : new TransferPlan(from, to, command.Amount);
}

private static Result<TransferPlan, TransferError> EnsureFunds(TransferPlan plan) =>
    plan.From.Balance < plan.Amount ? TransferError.InsufficientFunds : plan;

private async Task<Result<TransferPlan, TransferError>> Save(TransferPlan plan, CancellationToken ct)
{
    await Persist(plan, ct);

    return plan;
}

private static Transferred ToResponse(TransferPlan plan, TransferCommand command) =>
    new(command.From, command.To, command.Amount);
```

</details>

`Bind` chains the steps that can fail and `Map` turns the plan into the response. `ct` and `command` go in as extra arguments.

### Cancel an order

Find the order, refuse if it has shipped, mark it cancelled, save it and publish an event.

**Exceptions**

```csharp
public async Task<Cancelled> Cancel(int id, CancellationToken ct)
{
    var order = await Find(id, ct) ?? throw new OrderNotFoundException();
    if (order.Shipped)
    {
        throw new OrderAlreadyShippedException();
    }

    var cancelled = order with { Cancelled = true };
    await Save(cancelled, ct);
    Publish(cancelled);

    return new Cancelled(cancelled.Id);
}
```

**Procedural**

```csharp
public async Task<Result<Cancelled, OrderError>> Cancel(int id, CancellationToken ct)
{
    var order = await Find(id, ct);
    if (order is null)
    {
        return OrderError.NotFound;
    }

    if (order.Shipped)
    {
        return OrderError.AlreadyShipped;
    }

    var cancelled = order with { Cancelled = true };
    await Save(cancelled, ct);
    Publish(cancelled);

    return new Cancelled(cancelled.Id);
}
```

**Functional**

```csharp
public Task<Result<Cancelled, OrderError>> Cancel(int id, CancellationToken ct) =>
    FindOrder(id, ct)
        .Bind(EnsureNotShipped)
        .Map(MarkCancelled)
        .Bind(SaveOrder, ct)
        .Iter(Publish)
        .Map(ToResponse);
```

<details>
<summary>The steps of the chain</summary>

```csharp
private async Task<Result<Order, OrderError>> FindOrder(int id, CancellationToken ct) =>
    await Find(id, ct) is { } order ? order : OrderError.NotFound;

private static Result<Order, OrderError> EnsureNotShipped(Order order) =>
    order.Shipped ? OrderError.AlreadyShipped : order;

private static Order MarkCancelled(Order order) => order with { Cancelled = true };

private async Task<Result<Order, OrderError>> SaveOrder(Order order, CancellationToken ct)
{
    await Save(order, ct);

    return order;
}

private static Cancelled ToResponse(Order order) => new(order.Id);
```

</details>

Steps that can fail are chained with `Bind`; steps that cannot are `Map`; `Iter` publishes the event without changing the result.
