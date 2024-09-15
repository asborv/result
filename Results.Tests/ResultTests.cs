namespace Results.Tests;

using Results;
using Xunit;

public class ResultTests
{
    [Fact]
    public void SuccessIsOk()
    {
        var result = Result<int, Exception>.Ok(42);
        Assert.True(result.IsOk);
    }

    [Fact]
    public void SuccessIsNotErr()
    {
        var result = Result<int, Exception>.Ok(42);
        Assert.False(result.IsErr);
    }

    [Fact]
    public void FailureIsNotOk()
    {
        var result = Result<int, Exception>.Err(new Exception());
        Assert.False(result.IsOk);
    }

    [Fact]
    public void FailureIsErr()
    {
        var result = Result<int, Exception>.Err(new Exception());
        Assert.True(result.IsErr);
    }

    [Fact]
    public void SuccessUnwrap()
    {
        var result = Result<int, Exception>.Ok(42);
        Assert.Equal(42, result.Unwrap());
    }

    [Fact]
    public void FailureUnwrap()
    {
        var exception = new Exception();
        var result = Result<int, Exception>.Err(exception);
        Assert.Throws<Exception>(() => result.Unwrap());
    }

    [Fact]
    public void SuccessMap()
    {
        var result = Result<int, Exception>.Ok(42);
        var mapped = result.Map(x => x * 2);
        Assert.Equal(84, mapped.Unwrap());
    }

    [Fact]
    public void FailureMap()
    {
        var exception = new Exception();
        var result = Result<int, Exception>.Err(exception);
        var mapped = result.Map(x => x * 2);
        Assert.Throws<Exception>(() => mapped.Unwrap());
    }

    [Fact]
    public void TryInvokeSuccess()
    {
        var result = new Func<int>(() => 42).TryInvoke<int, Exception>();
        Assert.True(result.IsOk);
        Assert.Equal(42, result.Unwrap());
    }

    [Fact]
    public void TryInvokeFailure()
    {
        var exception = new Exception();
        var result = new Func<int>(() => throw exception).TryInvoke<int, Exception>();

        Assert.True(result.IsErr);
        Assert.Equal(exception, ((Err<int, Exception>)result).Error);
    }

    public static Result<int, Exception> Divide(int dividend, int divisor) =>
        divisor == 0 ? new DivideByZeroException() : dividend / divisor;
}
