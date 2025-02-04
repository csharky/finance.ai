namespace Finance.Ai.Domain.ValueObjects;

public class Result
{
    public bool IsSuccess { get; private set; }
    public string? Error { get; private set; }
    
    public static Result Success() => new Result { IsSuccess = true };
    public static Result Fail(string? error) => new Result { IsSuccess = false, Error = error };
}

public class Result<T>
{
    public T? Value { get; private init; }
    public string? Error { get; private init; }
    
    public bool IsSuccess { get; private init; } // Explicitly stores success/failure state

    public static Result<T> Success(T value) => new Result<T>
    {
        Value = value,
        Error = null,
        IsSuccess = true // Explicit success
    };

    public static Result<T> Fail(string error) => new Result<T>
    {
        Value = default, // Always set Value to default for failure
        Error = error,
        IsSuccess = false // Explicit failure
    };
}