using System.Runtime.CompilerServices;

namespace DistilledResult.Tests;

public class ResultTests
{
    [Test]
    public async Task SuccessfulResultHasExpectedState()
    {
        var result = Result<string, string>.Ok("test");

        await Assert.That(result.Success).IsTrue();
        await Assert.That(result.Failure).IsFalse();
        await Assert.That(result.Value).IsNotNull();
        await Assert.That(result.Error).IsNull();
    }

    [Test]
    public async Task FailedResultHasExpectedState()
    {
        var result = Result<string, string>.Fail("test");

        await Assert.That(result.Success).IsFalse();
        await Assert.That(result.Failure).IsTrue();
        await Assert.That(result.Value).IsNull();
        await Assert.That(result.Error).IsNotNull();
    }

    [Test]
    public async Task OkThrowsOnNullValue()
    {
        var exception = Assert.Throws<ArgumentNullException>(() => Result<string, string>.Ok(null!));

        await Assert.That(exception.ParamName).IsEqualTo("value");
    }

    [Test]
    public async Task FailThrowsOnNullError()
    {
        var exception = Assert.Throws<ArgumentNullException>(() => Result<string, string>.Fail(null!));

        await Assert.That(exception.ParamName).IsEqualTo("error");
    }

    [Test]
    public void SuccessCheckInfersCorrectNullability()
    {
        var resultOk = Result<string, string>.Ok("test");
        var resultFail = Result<string, string>.Ok("test");

        // No CS8602 warnings/errors should be present.

        if (resultOk.Success)
        {
            _ = resultOk.Value.Length;
        }
        else
        {
            _ = resultOk.Error.Length;
        }

        if (resultFail.Success)
        {
            _ = resultFail.Value.Length;
        }
        else
        {
            _ = resultFail.Error.Length;
        }
    }

    [Test]
    public void FailureCheckInfersCorrectNullability()
    {
        var resultOk = Result<string, string>.Ok("test");
        var resultFail = Result<string, string>.Ok("test");

        // No CS8602 warnings/errors should be present.

        if (resultOk.Failure)
        {
            _ = resultOk.Error.Length;
        }
        else
        {
            _ = resultOk.Value.Length;
        }

        if (resultFail.Failure)
        {
            _ = resultFail.Error.Length;
        }
        else
        {
            _ = resultFail.Value.Length;
        }
    }

    [Test]
    public void ImplicitConversionFromValueWorks()
    {

        // No CS0029 errors should be present.

        Result<int, string> result = 42;
        _ = result;
    }

    [Test]
    public void ImplicitConversionFromErrorWorks()
    {

        // No CS0029 errors should be present.

        Result<int, string> result = "test";
        _ = result;
    }

    [Test]
    public async Task ImplicitConversionFromValueThrowsOnNull()
    {
        var exception = Assert.Throws<ArgumentNullException>(() =>
        {
            Result<string, Exception> result = (string)null!;
            _ = result;
        });

        await Assert.That(exception.ParamName).IsEqualTo("value");
    }

    [Test]
    public async Task ImplicitConversionFromErrorThrowsOnNull()
    {
        var exception = Assert.Throws<ArgumentNullException>(() =>
        {
            Result<string, Exception> result = (Exception)null!;
            _ = result;
        });

        await Assert.That(exception.ParamName).IsEqualTo("error");
    }

    [Test]
    public async Task ExpectedLayoutSize()
    {
        // 12 = sizeof(int) + sizeof(int) + sizeof(bool) + padding
        await Assert.That(Unsafe.SizeOf<Result<int, int>>()).IsEqualTo(12);
    }

    [Test]
    public async Task ExpectedUnitLayoutSize()
    {
        // 8 = sizeof(Unit) + sizeof(int) + sizeof(bool) + padding
        await Assert.That(Unsafe.SizeOf<Unit>()).IsEqualTo(1);
        await Assert.That(Unsafe.SizeOf<Result<int, Unit>>()).IsEqualTo(8);
    }
}
