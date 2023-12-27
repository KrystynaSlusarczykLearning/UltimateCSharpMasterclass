namespace _16_QuoteFinder.UserInteraction;

public interface IUserInteractor
{
    void ShowMessage(string message);
    bool ReadBool(string message);
    int ReadInteger(string message);
    string ReadSingleWord(string message);
}