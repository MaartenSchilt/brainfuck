namespace MaartenSchilt.Brainfuck.Cli;

public class Interpreter
{
    private readonly InterpreterConfig config;

    public Interpreter(InterpreterConfig config)
    {
        this.config = config;
    }

    public ExecutionResult Execute(string program, TextWriter outputWriter)
    {
        // TODO: Implementation

        return ExecutionResult.ForSuccess();
    }
}
