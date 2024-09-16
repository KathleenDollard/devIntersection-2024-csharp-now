namespace CSharpNow;

public class RawStringLiteral
{
    //{
    //  "number": 42,
    //  "text": "Hello, world",
    //  "nested": { "flag": true }
    //}

    public static string NormalEscaping()
        => "{\r\n  \"number\": 42,\r\n  \"text\": \"Hello, world\",\r\n  \"nested\": { \"flag\": true }\r\n}";

    public static string Verbatim()
        => @"{
  ""number"": 42,
  ""text"": ""Hello, world"",
  ""nested"": { ""flag"": true }
}";

    public static string Raw()
        => """
        {
          "number": 42,
          "text": "Hello, world",
          "nested": { "flag": true }
        }
        """;

    public static string InterpolatedRaw(string name)
    => $$"""
        {
          "number": 42,
          "text": "Hello, {{name}}",
          "nested": { "flag": true }
        }
        """;
}
