namespace CSharpNow;

public class NullableExample
{
    public class Person(string givenName, string surName, string middleName = null)
    {
        public string GivenName { get; } = givenName;
        public string SurName { get; } = surName;
        public string MiddleName { get; } = middleName;
    }

    public static void Test(Person person)
    {
        if (person is null) { return; }
        Console.WriteLine(person.GivenName);
    }
}
