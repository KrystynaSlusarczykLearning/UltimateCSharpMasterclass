namespace _17_CSharpEvolution;

class PrimaryConstructors
{
    public void Example()
    {
        var logger = new Logger(Severity.Information, new LogsRepository());

        //will not work - severity is not a member
        //Console.WriteLine(logger.severity);

        //works fine - for records, properties are created
        var item = new Item(1, "Tahini", 12.99m);
        Console.WriteLine(item.Name);

    }
}
public class Logger(
    Severity severity,
    ILogsRepository logsRepository)
{
    public void Print(string message)
    {
        Console.WriteLine($"[{severity}] {message}");
    }

    public void SaveLog(string message)
    {
        logsRepository.Save(severity, message);
    }
}

public record Item(
    int Id,
    string Name,
    decimal Price);

public enum Severity
{
    Information,
    Warning,
    Error
}

public interface ILogsRepository
{
    void Save(Severity severity, string message);
}

public class LogsRepository : ILogsRepository
{
    public void Save(Severity severity, string message)
    {
        //save the logs 
    }
}