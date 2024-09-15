namespace Results;

public static class ExtensionMethods
{
    public static Result<T, E> TryInvoke<T, E>(this Func<T> f) where E : Exception
    {
        try { return Result<T, E>.Ok(f()); }
        catch (E e) { return Result<T, E>.Err(e); }
    }

    public static Result<TResult, E> TryInvoke<T1, TResult, E>(this Func<T1, TResult> f, T1 arg)
        where E : Exception =>
        new Func<TResult>(() => f(arg)).TryInvoke<TResult, E>();

    public static Result<TResult, E> TryInvoke<T1, T2, TResult, E>(this Func<T1, T2, TResult> f, T1 arg1, T2 arg2)
        where E : Exception =>
        new Func<TResult>(() => f(arg1, arg2)).TryInvoke<TResult, E>();

    public static Result<TResult, E> TryInvoke<T1, T2, T3, TResult, E>(
        this Func<T1, T2, T3, TResult> f,
        T1 arg1,
        T2 arg2,
        T3 arg3)
        where E : Exception =>
        new Func<TResult>(() => f(arg1, arg2, arg3)).TryInvoke<TResult, E>();

    public static Result<TResult, E> TryInvoke<T1, T2, T3, T4, TResult, E>(
        this Func<T1, T2, T3, T4, TResult> f,
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4)
        where E : Exception =>
        new Func<TResult>(() => f(arg1, arg2, arg3, arg4)).TryInvoke<TResult, E>();
}
