namespace CSharpNow;

/* Nullable
 
  Lazy instantiation requires nullable.

  In this case, their may be empty lists (no write), but the lists will always be read.

  Current main has an additional bool internal property for HasOptions, etc. that if
  consistently used will check the internal list and delay instantiation. There are scenarios
  where these collections will not be read publicly (which will always instantiate the list).

  If we had an Option type (a type that had a value or no value), I would use it. I hesitate
  to create one for this micro-optimization scenario. 

  So, I audited. All of these properties are being accessed on every run. To be fair, I wrote most 
  of this code and the original authors had better discipline in this, except perhaps for arguments.
  The original decision was valid, but I do not want to leave complexity in place that requires 
  discipline to have value. 
*/

public class SclExampleNullable
{
    public SclExampleNullable()
    {
        _arguments = new();
        _options = new();
        _subcommands = new();
        _otherValueSymbols = new();
    }
    public void Add(CliSymbol symbol)
    {
        var _ = symbol switch
        {
            CliArgument argument => AddArgument(argument),
            CliOption option => AddOption(option),
            CliCommand command => AddSubCommand(command),
            CliValueSymbol valueSymbol => AddOtherSymbol(valueSymbol),
            _ => throw new InvalidOperationException("Unexpected symbol type"),
        };
    }

    public void Add(CliArgument argument) => AddArgument(argument);
    public void Add(CliOption option) => AddOption(option);
    public void Add(CliCommand command) => AddSubCommand(command);

    private List<CliArgument> _arguments;
    public IEnumerable<CliArgument> Arguments => _arguments;
    private Discard AddArgument(CliArgument argument)
    {
        _arguments.Add(argument);
        return Discard.Empty;
    }

    private List<CliOption> _options;
    public IEnumerable<CliOption> Options => _options;
    private Discard AddOption(CliOption option)
    {
        _options.Add(option);
        return Discard.Empty;
    }

    private List<CliValueSymbol> _otherValueSymbols;
    public IEnumerable<CliValueSymbol> OtherSymbols => _otherValueSymbols;
    private Discard AddOtherSymbol(CliValueSymbol valueSymbol)
    {
        _otherValueSymbols.Add(valueSymbol);
        return Discard.Empty;
    }

    private List<CliCommand> _subcommands;
    public IEnumerable<CliCommand> Subcommands => _subcommands;
    private Discard AddSubCommand(CliCommand subcommand)
    {
        _subcommands.Add(subcommand);
        return Discard.Empty;
    }

    public class CliSymbol { }
    public class CliCommand : CliSymbol { }
    public class CliValueSymbol : CliSymbol { }
    public class CliOption : CliValueSymbol { }
    public class CliArgument : CliValueSymbol { }
}

