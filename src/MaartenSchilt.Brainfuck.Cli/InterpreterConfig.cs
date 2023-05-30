namespace MaartenSchilt.Brainfuck.Cli;

public class InterpreterConfig
{
    public static readonly InterpreterConfig Default = new(30000);

    public int DataSize { get; set; }

    public InterpreterConfig(int dataSize)
    {
        DataSize = dataSize;
    }
}
