using System.Security.Cryptography;

namespace Results;

public abstract class Result<T, E> where E : Exception
{
    public static Success Ok(T v) => new(v);
    public static Failure Err(E error) => new(error);

    public abstract bool IsOk { get; }
    public abstract bool IsErr { get; }
    public abstract Result<T, E> Map(Func<T, T> f);
    public abstract Result<T, E> MapFailure(Func<E, E> f);
    public abstract T Unwrap();

    public sealed class Success : Result<T, E>
    {
        public T Value { get; }

        internal Success(T v) { Value = v; }

        public override bool IsOk => true;
        public override bool IsErr => false;
        public override Success Map(Func<T, T> f) => new(f(Value));
        public override Success MapFailure(Func<E, E> _) => this;
        public override T Unwrap() => Value;
    }

    public sealed class Failure : Result<T, E>
    {
        public E Error { get; }

        internal Failure(E error) { Error = error; }

        public override bool IsOk => false;
        public override bool IsErr => true;
        public override Failure Map(Func<T, T> _) => this;
        public override Failure MapFailure(Func<E, E> f) => new(f(Error));
        public override T Unwrap() => throw Error;
    }
}
