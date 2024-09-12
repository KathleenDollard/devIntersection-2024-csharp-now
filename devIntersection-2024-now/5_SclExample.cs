namespace CSharpNow;

public class SclExample
{

    public void Add(CliSymbol symbol)
    {
        if (symbol is CliArgument argument)
        {
            Add(argument);
        }
        else if (symbol is CliOption option)
        {
            Add(option);
        }
        else if (symbol is CliCommand command)
        {
            Add(command);
        }
        else if (symbol is CliValueSymbol valueSymbol)
        {
            OtherSymbols.Add(valueSymbol);
        }
    }

    public void Add(CliArgument argument) => Arguments.Add(argument);
    public void Add(CliOption option) => Options.Add(option);
    public void Add(CliCommand command) => Subcommands.Add(command);

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private List<CliArgument> _arguments;
    public IList<CliArgument> Arguments => _arguments ??= new();
    private List<CliOption> _options;
    public IList<CliOption> Options => _options ??= new();
    private List<CliValueSymbol> _otherValueSymbols;
    public IList<CliValueSymbol> OtherSymbols => _otherValueSymbols ??= new();
    private List<CliCommand> _subcommands;
    public IList<CliCommand> Subcommands => _subcommands ??= new();
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.


    public class CliSymbol { }
    public class CliCommand : CliSymbol { }
    public class CliValueSymbol : CliSymbol { }
    public class CliOption : CliValueSymbol { }
    public class CliArgument : CliValueSymbol { }
}
