using Shouldly;

namespace MaartenSchilt.Brainfuck.Cli.Test;

public class BrainfuckInterpreterTest
{
    private readonly Interpreter interpreter;
    private readonly TextWriter textWriter;

    public BrainfuckInterpreterTest()
    {
        interpreter = new Interpreter(InterpreterConfig.Default);
        textWriter = new StringWriter();
    }

    [Fact]
    public void Execute_HelloWorld1()
    {
        // Arrange
        var program = ">+++++++++[<++++++++>-]<.>+++++++[<++++>-]<+.+++++++..+++.[-]>++++++++[<++++>-]<.>+++++++++++[<++++++++>-]<-.--------.+++.------.--------.[-]>++++++++[<++++>-]<+.[-]++++++++++.";

        // Act
        var result = interpreter.Execute(program, textWriter);

        // Assert
        result.Success.ShouldBe(true, result.ErrorMessage);

        var output = textWriter.ToString();
        output.ShouldBe("Hello world!\n");
    }

    [Fact]
    public void Execute_HelloWorld2()
    {
        // Arrange
        var program = "+[-->-[>>+>-----<<]<--<---]>-.>>>+.>>..+++[.>]<<<<.+++.------.<<-.>>>>+.";

        // Act
        var result = interpreter.Execute(program, textWriter);

        // Assert
        result.Success.ShouldBe(true, result.ErrorMessage);

        var output = textWriter.ToString();
        output.ShouldBe("Hello, World!");
    }

    [Fact]
    public void Execute_Fibonacci()
    {
        // Arrange
        var program = "+++++++++++>+>>>>++++++++++++++++++++++++++++++++++++++++++++>++++++++++++++++++++++++++++++++<<<<<<[>[>>>>>>+>+<<<<<<<-]>>>>>>>[<<<<<<<+>>>>>>>-]<[>++++++++++[-<-[>>+>+<<<-]>>>[<<<+>>>-]+<[>[-]<[-]]>[<<[>>>+<<<-]>>[-]]<<]>>>[>>+>+<<<-]>>>[<<<+>>>-]+<[>[-]<[-]]>[<<+>>[-]]<<<<<<<]>>>>>[++++++++++++++++++++++++++++++++++++++++++++++++.[-]]++++++++++<[->-<]>++++++++++++++++++++++++++++++++++++++++++++++++.[-]<<<<<<<<<<<<[>>>+>+<<<<-]>>>>[<<<<+>>>>-]<-[>>.>.<<<[-]]<<[>>+>+<<<-]>>>[<<<+>>>-]<<[<+>-]>[<+>-]<<<-]";

        // Act
        var result = interpreter.Execute(program, textWriter);

        // Assert
        result.Success.ShouldBe(true, result.ErrorMessage);

        var output = textWriter.ToString();
        output.ShouldBe("1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89");
    }

    [Fact]
    public void Execute_MultipleTimes()
    {
        // Arrange
        var program = "+[-->-[>>+>-----<<]<--<---]>-.>>>+.>>..+++[.>]<<<<.+++.------.<<-.>>>>+.";

        // Act
        var firstResult = interpreter.Execute(program, textWriter);
        var secondResult = interpreter.Execute(program, textWriter);

        // Assert
        firstResult.Success.ShouldBe(true, firstResult.ErrorMessage);
        secondResult.Success.ShouldBe(true, firstResult.ErrorMessage);

        var output = textWriter.ToString();
        output.ShouldBe("Hello, World!Hello, World!");
    }
}