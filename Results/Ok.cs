namespace Results;

public class Ok<T, E> : Result<T, E>
{
    public T Value { get; }

    internal Ok(T value)
    {
        Value = value;
    }

    public override bool IsOk => true;
    public override bool IsErr => false;
}
