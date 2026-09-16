# Distilled Result

A minimal, allocation-free implementation of the result pattern for .NET. `Result<TValue, TError>` holds either a success value or an error, never both and never neither.

The main use case is avoiding exceptions as control flow. Take a method like this:

```csharp
async Task<Order> UpdateOrderAsync(UpdateOrderPayload payload)
{
    var order = await _orders.UpdateAsync(payload);

    if (order is null)
    {
        throw new OrderNotFoundException();
    }

    if (order.Status == OrderStatus.Cancelled)
    {
        throw new OrderCancelledException();
    }

    return order;
}
```

We can refactor this method with `Result<TValue, TError>`, where `TValue` is `Order` and `TError` is an `OrderError` enum, so it would look like this:

```csharp
using DistilledResult;

public enum OrderError
{
    NotFound,
    Cancelled
}

async Task<Result<Order, OrderError>> UpdateOrderAsync(UpdateOrderPayload payload)
{
    var order = await _orders.UpdateAsync(payload);

    if (order is null)
    {
        return OrderError.NotFound;
    }

    if (order.Status == OrderStatus.Cancelled)
    {
        return OrderError.Cancelled;
    }

    return order;
}
```

An implicit conversion lets you return either an `Order` or an `OrderError` directly. It wraps whichever one comes back into a `Result<Order, OrderError>`, so the method still reads as a sequence of guard clauses rather than something built around the wrapper type.

This means callers don't need a try/catch to handle failure, checking `Success` or `Failure` is enough, and the compiler enforces it before either side is touched. It can be consumed like this:

```csharp
app.MapPut("/orders", async (UpdateOrderPayload payload) =>
{
    var result = await UpdateOrderAsync(payload);

    if (result.Success)
    {
        return Results.Ok(result.Value);
    }
    else
    {
        return result.Error switch
        {
            OrderError.NotFound => Results.NotFound(),
            OrderError.Cancelled => Results.Conflict("order was cancelled"),
            _ => Results.Problem()
        };
    }
});
```

That's essentially the entire surface of this library:
- return a value or an error from a method
- check which one it is via `Success` or `Failure`
- consume the value or the error

A few details the examples above don't show:
- `Success` / `Failure` narrow `Value` / `Error` to non-null via `[MemberNotNullWhen]`.
- `TValue` and `TError` are constrained to `notnull` — a nullable type argument is rejected
  at compile time, so that narrowing can't be defeated by a null success value or error.
- Use `Unit` wherever there's nothing to carry, as `TValue` or as `TError`.
- If `TValue` and `TError` are the same type, the implicit conversions become ambiguous. Instead, build
  the result with `Result.Ok` or `Result.Fail` explicitly instead.

## Install

```
dotnet add package DistilledResult
```

## Supported targets

`netstandard2.0`, `net8.0`, `net10.0`.

## Building

```
dotnet restore
dotnet test
dotnet build
```
