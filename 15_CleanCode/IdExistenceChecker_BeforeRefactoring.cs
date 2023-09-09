using System.Text.Json;

public class FileManager
{
    public void IdFinder(string name, string dir, string ex, int id)
    {
        var file = dir + "/" + name + "." + ex;
        if(!File.Exists(file))
        {
            Console.WriteLine("File does not exist under path: " + file);
            return;
        }

        List<int> numbers = new List<int>();
        if(ex == "txt")
        {
            //read the IDs from TXT file
            var txt = File.ReadAllText(file);
            var ids = txt.Split(',');
            foreach(var fileId in ids)
            {
                numbers.Add(int.Parse(fileId));
            }
        }
        else if(ex == "json")
        {
            //read the IDs from JSON file
            var txt = File.ReadAllText(file);
            numbers = JsonSerializer.Deserialize<List<int>>(txt);
        }
        else
        {
            Console.WriteLine("Unsupported file extension: " + ex);
            return;
        }

        foreach(var number in numbers)
        {
            if(number == id)
            {
                Console.WriteLine($"Id {id} has been found in the file {file}.");
                return;
            }
        }

        Console.WriteLine($"Id {id} has not been found in the file {file}.");
    }
}

