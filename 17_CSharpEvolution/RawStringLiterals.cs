namespace _17_CSharpEvolution;

class RawStringLiterals
{
    public void Example()
    {

        string jsonEscape = "{\n  \"name\": \"Alice\",\n  \"age\": 25\n}";

        string jsonVerbatim = @"{
  ""name"": ""Alice"",
  ""age"": 25
}";

        string jsonRawStringLiteral = """
{
  "name": "Alice",
  "age": 25
}
""";

        string tricky = """" Triple double quotes incoming: """ """";

        string code = """
class Example
{
    static void Main()
    {
        Console.WriteLine("Hello, world!");
    }
}
""";

    }
}
