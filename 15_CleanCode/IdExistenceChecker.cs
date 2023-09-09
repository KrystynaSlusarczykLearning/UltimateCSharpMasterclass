using System.Text.Json;

public class IdExistenceChecker
{
    private const string Txt = "txt";
    private const string Json = "json";

    public void CheckIfIdExistsInFile(int id, FileIdentity fileIdentity)
    {
        var filePath = fileIdentity.AsPath();
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File does not exist under path: " + filePath);
            return;
        }

        if (fileIdentity.Extension != Txt && fileIdentity.Extension != Json)
        {
            Console.WriteLine("Unsupported file extension: " + fileIdentity.Extension);
            return;
        }

        var idsFromFile = ReadIdsFromFile(fileIdentity);
        bool isIdPresentInFile = idsFromFile.Contains(id);
        PrintResult(isIdPresentInFile, id, filePath);
    }

    private void PrintResult(bool isIdPresentInFile, int id, string filePath)
    {
        var status = isIdPresentInFile ? "" : "not ";
        Console.WriteLine($"Id {id} has {status}been found in the file {filePath}.");
    }

    private static List<int> ReadIdsFromFile(FileIdentity fileIdentity)
    {
        var fileContent = File.ReadAllText(fileIdentity.AsPath());

        return fileIdentity.Extension == Txt ?
            ReadIdsFromText(fileContent) :
            ReadIdsFromJson(fileContent);
    }

    private static List<int> ReadIdsFromText(string fileContent)
    {
        List<int> numbers = new List<int>();
        return fileContent
            .Split(',')
            .Select(fileId => int.Parse(fileId))
            .ToList();
    }

    private static List<int> ReadIdsFromJson(string fileContent)
    {
        return JsonSerializer.Deserialize<List<int>>(fileContent);
    }
}

public struct FileIdentity
{
    public string Directory { get; }
    public string Name { get; }
    public string Extension { get; }

    public FileIdentity(string directory, string name, string extension)
    {
        Directory = directory;
        Name = name;
        Extension = extension;
    }

    public string AsPath()
    {
        return Directory + "/" + Name + "." + Extension;
    }
}
