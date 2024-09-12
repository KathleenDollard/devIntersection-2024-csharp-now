namespace CSharpNow;

/* Overload Concerns and resiliency

 Resilient to:
    * New symbol types 
    * Work while symbols are being added
    * 
  
  Example: System.CommandLine current main (Sept. 2024) track parent by implementing ChildSymbolList that holds parent. Could
           also be implemented with an internal property that is set when the item is added, if we also expose the collections 
           as IEnumerable. Currently there are two ways to do a thing Command.Add(<CliOption>) and Command.Options.Add(<CliOption>)
 
- Overloads are not resilient to new types. Adding OtherSymbol without yet adding the type specific overload was recursive
- Following the pattern of the more specific overload for OtherSymbols would have worked, but still vulnerable
- A different approaches to Add for OtherSymbols is ugly and implies more difference than exists
- Directly accessing the underlying property or field would have repeated work, problematic if more work is added
- Removing all but the symbol overload would have resulted in unnecessary type tests - micro-optimization
- Consider the breaking change of having the properties return an IEnumerable to avoid two ways to do things
- Smallest change, have symbol and specific overloads call a new private method
- We really should handle the default case
*/


public class SclExampleOverloadAndPatterns
{

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

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private List<CliArgument> _arguments;
    public IEnumerable<CliArgument> Arguments => _arguments ??= new();
    private Discard AddArgument(CliArgument argument)
    {
        _arguments.Add(argument);
        return Discard.Empty;
    }

    private List<CliOption> _options;
    public IEnumerable<CliOption> Options => _options ??= new();
    private Discard AddOption(CliOption option)
    {
        _options.Add(option);
        return Discard.Empty;
    }

    private List<CliValueSymbol> _otherValueSymbols;
    public IEnumerable<CliValueSymbol> OtherSymbols => _otherValueSymbols ??= new();
    private Discard AddOtherSymbol(CliValueSymbol valueSymbol)
    {
        _otherValueSymbols.Add(valueSymbol);
        return Discard.Empty;
    }

    private List<CliCommand> _subcommands;
    public IEnumerable<CliCommand> Subcommands => _subcommands ??= new();
    private Discard AddSubCommand(CliCommand subcommand)
    {
        _subcommands.Add(subcommand);
        return Discard.Empty;
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    public class CliSymbol { }
    public class CliCommand : CliSymbol { }
    public class CliValueSymbol : CliSymbol { }
    public class CliOption : CliValueSymbol { }
    public class CliArgument : CliValueSymbol { }
}

