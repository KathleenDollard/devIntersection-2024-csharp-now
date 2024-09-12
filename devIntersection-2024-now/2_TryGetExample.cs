namespace CSharpNow;

internal class TryGetExample
{
    private Dictionary<string, string?> keyValuePairs = new()
    {
        {"One", "Red" },
        {"Two", "Blue" },
        {"Three", "Green" },
        {"Four", "Purple" },
    };

    private (bool success, string? value) RetrieveViaTuples(string key)
    {
        if (this.keyValuePairs.ContainsKey(key))
        {
            var value = keyValuePairs
                .Where(x => x.Key == key)
                .FirstOrDefault()
                .Value;
            return (true, value);
        }
        return (false, null);
    }

    public void WriteViaTuple(string s)
    {
        var (success, value) = RetrieveViaTuples(s);
        // Oops something missing here
        Console.WriteLine(value);
    }

    public void WriteViaTryGet(string s)
    {
        if (keyValuePairs.TryGetValue(s, out var value))
        {
            Console.WriteLine(value);
            return;
        }
        Console.WriteLine("Value not found");
    }
}
