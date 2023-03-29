namespace GameDataParser.UserInteraction;

public interface IUserInteractor
{
    string ReadValidFilePath();
    void PrintMessage(string message);
    void PrintError(string message);
}