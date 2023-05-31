namespace UserCommunication;

public interface IUserCommunication
{
    int ReadInteger(string prompt);
    void ShowMessage(string message);
}
