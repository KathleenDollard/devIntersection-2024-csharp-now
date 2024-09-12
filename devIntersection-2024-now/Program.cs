using CSharpNow;

ConditionalPatterns.SomeIntegerPatterns(4);

// InterpolatedStrings("Joe", null, new DateOnly(2017, 1, 15), 31_415_926.536m);
NullableExample.Usage();

RawString();

static void InterpolatedStrings(string name, string? middleName, DateOnly hireDate, decimal pay)
{
    InterpolatedStringExamples.OutputString(name);
    InterpolatedStringExamples.OutputStringTernary(name, middleName);
    InterpolatedStringExamples.OutputStringFormatted(name, hireDate);
    InterpolatedStringExamples.OutputStringWidths(name, hireDate);
    InterpolatedStringExamples.OutputCultureSpecific(name, hireDate, pay);
}

static void RawString()
{
    Console.WriteLine(RawStringLiteral.NormalEscaping());
    Console.WriteLine(RawStringLiteral.Verbatim());
    Console.WriteLine(RawStringLiteral.Raw());
    Console.WriteLine(RawStringLiteral.InterpolatedRaw("world"));
}

