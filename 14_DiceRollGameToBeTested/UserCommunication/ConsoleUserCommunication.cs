namespace UserCommunication;

public class ConsoleUserCommunication : IUserCommunication
{
    public int ReadInteger(string prompt)
    {
        int result;
        do
        {
            Console.WriteLine(prompt);
        }
        while (!int.TryParse(Console.ReadLine(), out result));
        return result;
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}
