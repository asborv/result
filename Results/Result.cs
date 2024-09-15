namespace Results;

public abstract class Result<T, E> where E : Exception
{
    public static Ok<T, E> Ok(T v) => new(v);
    public static Err<T, E> Err(E error) => new(error);

    public abstract bool IsOk { get; }
    public abstract bool IsErr { get; }
    public abstract Result<U, E> Map<U>(Func<T, U> f);
    public abstract T Unwrap();
}
