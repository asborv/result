namespace Results;

public sealed class Err<T, E> : Result<T, E> where E : Exception
{
    public E Error { get; }

    internal Err(E error) { Error = error; }

    public override bool IsOk => false;
    public override bool IsErr => true;
    public override Err<U, E> Map<U>(Func<T, U> _) => new(Error);
    public override T Unwrap() => throw Error;

    public static implicit operator Err<T, E>(E e) => new(e);
    public static implicit operator E(Err<T, E> e) => e.Error;
}
