namespace RomanNumberConverter.Shared;

public class Either<TValue, TError>
{
    public TValue? Value { get; }
    public TError? Error { get; }

    private Either(TValue? value, TError? error)
    {
        Value = value;
        Error = error;
    }
    
    public static Either<TValue, TError?> Right(TValue value)
    {
        return new Either<TValue, TError?>(value, default);
    }
    
    public static Either<TValue?, TError> Left(TError error)
    {
        return new Either<TValue?, TError>(default, error);
    }

    public override string? ToString()
    {
        return Error?.ToString() ?? Value!.ToString();
    }
}