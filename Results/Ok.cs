namespace Results;

public sealed class Ok<T, E> : Result<T, E> where E : Exception
{
    public T Value { get; }

    internal Ok(T v) { Value = v; }

    public override bool IsOk => true;
    public override bool IsErr => false;
    public override Ok<U, E> Map<U>(Func<T, U> f) => new(f(Value));
    public override T Unwrap() => Value;

    public static implicit operator Ok<T, E>(T v) => new(v);
    public static implicit operator T(Ok<T, E> ok) => ok.Value;

}
