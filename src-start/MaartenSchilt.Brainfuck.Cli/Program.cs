using MaartenSchilt.Brainfuck.Cli;

if (args.Length == 0)
{
    Console.WriteLine("...");
    return;
}

var path = args[0];

if (!File.Exists(path))
{
    Console.WriteLine("File not found: " + path);
    return;
}

Console.WriteLine("File: " + path);

try
{
    var program = await File.ReadAllTextAsync(path);

    var config = InterpreterConfig.Default;
    var interpreter = new Interpreter(config);

    Console.WriteLine();
    Console.WriteLine("Program:");
    Console.WriteLine(program);
    Console.WriteLine();
    Console.WriteLine("Output:");

    var result = interpreter.Execute(program, Console.Out);

    Console.WriteLine();

    if (result.Success)
        Console.WriteLine("Program completed.");
    else
        Console.WriteLine("Execution error: " + result.ErrorMessage);
}
catch (Exception ex)
{
    Console.WriteLine("Unexpected exception: " + ex.Message);
}