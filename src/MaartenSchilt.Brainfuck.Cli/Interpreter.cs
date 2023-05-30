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
        try
        {
            var commandPointer = 0;

            var data = new byte[config.DataSize];
            var dataPointer = 0;

            var loops = PreProcessLoops(program);

            while (commandPointer < program.Length)
            {
                var command = program[commandPointer];

                switch (command)
                {
                    case '>':
                        dataPointer++;

                        if (dataPointer == data.Length)
                            dataPointer = 0;

                        break;
                    case '<':
                        dataPointer--;

                        if (dataPointer < 0)
                            dataPointer = data.Length - 1;

                        break;
                    case '+':
                        data[dataPointer]++;
                        break;
                    case '-':
                        data[dataPointer]--;
                        break;                    
                    case '[':
                        if (data[dataPointer] == 0)
                            commandPointer = loops[commandPointer];
                        break;
                    case ']':
                        if (data[dataPointer] != 0)
                            commandPointer = loops[commandPointer];
                        break;
                    case '.':
                        outputWriter.Write((char)data[dataPointer]);
                        break;
                    case ',':
                        data[dataPointer] = (byte)Console.ReadKey(true).KeyChar;
                        break;
                }

                commandPointer++;
            }

            return ExecutionResult.ForSuccess();
        }
        catch (Exception ex)
        {
            return ExecutionResult.ForError(ex.Message);
        }
    }

    private static Dictionary<int, int> PreProcessLoops(string program)
    {
        var loops = new Dictionary<int, int>();
        var stack = new Stack<int>();

        for (var i = 0; i < program.Length; i++)
        {
            if (program[i] == '[')
            {
                stack.Push(i);
            }
            else if (program[i] == ']')
            {
                if (stack.Count == 0)
                    throw new SyntaxException($"Found a ']' without a matching '[' at position {i}.");

                var open = stack.Pop();
                loops[open] = i;
                loops[i] = open;
            }
        }

        if (stack.Count != 0)
            throw new SyntaxException($"Found a '[' without a matching ']' at position {stack.Pop()}.");

        return loops;
    }
}
