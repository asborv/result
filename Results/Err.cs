namespace Results;

public class Err<T, E> : Result<T, E>
{
    public E Error { get; }

    internal Err(E error)
    {
        Error = error;
    }

    public override bool IsOk => false;
    public override bool IsErr => true;
}
