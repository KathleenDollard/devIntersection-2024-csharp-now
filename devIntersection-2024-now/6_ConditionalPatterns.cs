internal class ConditionalPatterns
{
    // Aside, fix warnings in the following signature
    public static void CompareToNull(string s = null, string s2 = null)
    {
        // These are almost always the same: Watch out for NaN and implicit equality operators
        if (s is null) { Console.WriteLine("s is null"); }
        if (s == null) { Console.WriteLine("s equals null"); }
        if (s is not null) { Console.WriteLine("s is not null"); }
        if (s != null) { Console.WriteLine("s not equals null"); }
    }

    public static void SomeIntegerPatterns(int a)
    {
        // These are almost always the same: Watch out for NaN and implicit equality operators
        if (a is 3) { Console.WriteLine("s is 3"); }
        if (a is not 3) { Console.WriteLine("s is not 3"); }
        //if (a is 3 ^ 2) { Console.WriteLine("s is null"); } // not a pattern
        if (a is 3 or 4) { Console.WriteLine("a is 3 or 4"); }
        if (a is not 3 or 4) { Console.WriteLine("a is not 3 or it is 4"); } // dumb pattern because 4 was already not 3
        if (a is not 3 and not 4) { Console.WriteLine("a is and 3 and it is not 4"); }
        if (a is not (3 or 4)) { Console.WriteLine("a is neither 3 or 4"); }

        if (a > 3) { Console.WriteLine("a is greater than 3"); }
        var message = a switch
        {
            > 3 and < 7 => "a is greater than 3 and less than 7",
            _ => ""
        };
        Console.WriteLine(message);
    }
}
