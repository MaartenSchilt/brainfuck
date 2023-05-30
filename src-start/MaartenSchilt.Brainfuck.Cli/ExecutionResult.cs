namespace MaartenSchilt.Brainfuck.Cli;

public class ExecutionResult
{
    public bool Success { get; }

    public string? ErrorMessage { get; }

    public ExecutionResult(bool success, string? errorMessage)
    {
        Success = success;
        ErrorMessage = errorMessage;
    }

    public static ExecutionResult ForSuccess() => new(true, null);

    public static ExecutionResult ForError(string errorMessage) => new(false, errorMessage);
}
