namespace CSharpNow;

/// <summary>
/// Allows internal methods to return a meaningless value to allow switch 
/// expressions. Prohibited in public APIs to avoid type loading issues.
/// </summary>
internal struct Discard
{
    internal static Discard Empty => new Discard();
}
