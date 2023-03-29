namespace TicketsDataAggregator.FileAccess;

public interface IFileWriter
{
    void Write(
        string content, params string[] pathParts);
}
