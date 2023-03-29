public class Names
{
    public List<string> All { get; } = new List<string>();
    private readonly NamesValidator _namesValidator = new NamesValidator();

    public void AddNames(List<string> stringsFromFile)
    {
        foreach (var name in stringsFromFile)
        {
            AddName(name);
        }
    }

    public void AddName(string name)
    {
        if (_namesValidator.IsValid(name))
        {
            All.Add(name);
        }
    }
}