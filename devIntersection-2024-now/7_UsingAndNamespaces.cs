using static System.Console;
using PersonTuple = (string FirstName, string LastName);

namespace CSharpNow;

public class UsingAndNamespaces
{
    // See the project file for managing global usings..
    public static void Test()
    {
        PersonTuple person = ("Kathleen", "Dollard");
        WriteLine(person);
    }
}
