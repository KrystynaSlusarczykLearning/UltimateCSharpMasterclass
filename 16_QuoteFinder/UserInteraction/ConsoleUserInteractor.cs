namespace _16_QuoteFinder.UserInteraction;

public class ConsoleUserInteractor : IUserInteractor
{
    public void ShowMessage(string message) => Console.WriteLine(message);

    public string ReadSingleWord(string message)
    {
        string result;
        do
        {
            Console.WriteLine(message);
            result = Console.ReadLine();
        }
        while (!IsValidWord(result));
        return result;
    }

    private bool IsValidWord(string input)
    {
        return
            input is not null &&
            input.All(char.IsLetter);
    }

    public int ReadInteger(string message)
    {
        int result;
        do
        {
            Console.WriteLine(message);
        }
        while (!int.TryParse(Console.ReadLine(), out result));
        return result;
    }

    public bool ReadBool(string message)
    {
        Console.WriteLine($"{message} ('y' for 'yes', anything else for 'no')");
        var input = Console.ReadLine();
        return input == "y";
    }
}
