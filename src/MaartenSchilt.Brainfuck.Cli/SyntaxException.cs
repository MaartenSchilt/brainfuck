namespace MaartenSchilt.Brainfuck.Cli;

internal class SyntaxException : Exception
{
    public SyntaxException(string message) : base(message)
    {
    }
}
