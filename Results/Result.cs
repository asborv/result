namespace Results;

public abstract class Result<T, E>
{
    public abstract bool IsOk { get; }
    public abstract bool IsErr { get; }

    public static Result<T, E> Ok(T value) => new Ok<T, E>(value);
    public static Result<T, E> Err(E error) => new Err<T, E>(error);
}
