namespace TicketsDataAggregator.FileAccess;

public class FileWriter : IFileWriter
{
    public void Write(
        string content, params string[] pathParts)
    {
        var resultPath = Path.Combine(pathParts);
        File.WriteAllText(resultPath, content);
        Console.WriteLine("Results saved to " + resultPath);
    }
}
