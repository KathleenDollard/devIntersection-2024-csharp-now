namespace CSharpNow;

public class InterpolatedStringExamples
{
    public static void OutputString(string name)
    {
        Console.WriteLine($"Output:   Hello, {name}");
        Console.WriteLine();
    }

    public static void OutputStringTernary(string name,
                                           string? middleName = null)
    {
        // The following will fail, but analyzers (Ctl.) will fix (first add a line break after Hello
        //Console.WriteLine($"Ternary:  Hello, {name}{string.IsNullOrWhiteSpace(middleName) ? "" : " " + middleName}");
        Console.WriteLine("Fix this!");
        Console.WriteLine();
    }

    public static void OutputStringFormatted(string name, DateOnly hireDate)
    {
        Console.WriteLine($"Formatted:Hello {name}, you were hired {hireDate:yyyy-MM-dd}");
        Console.WriteLine();
    }

    public static void OutputStringWidths(string name, DateOnly hireDate)
    {
        const int nameWidth = -15;
        const int dateWidth = 15;
        Console.WriteLine($"Widths:   Hello {name,nameWidth}{hireDate,dateWidth:o}");
        Console.WriteLine();
    }

    public static void OutputCultureSpecific(string name, DateOnly hireDate, decimal pay)
    {
        var cultures = new System.Globalization.CultureInfo[]
            {
            System.Globalization.CultureInfo.GetCultureInfo("en-US"),
            System.Globalization.CultureInfo.GetCultureInfo("en-GB"),
            System.Globalization.CultureInfo.GetCultureInfo("nl-NL"),
            System.Globalization.CultureInfo.InvariantCulture
            };
        var number = 31_415_926.536;
        foreach (var culture in cultures)
        {
            var cultureSpecificMessage = string.Create(culture, $"{hireDate,23}{number,20:N3}");
            Console.WriteLine($"Culture:     {culture.Name,-10}{cultureSpecificMessage}");
        }
        Console.WriteLine();
    }
}
