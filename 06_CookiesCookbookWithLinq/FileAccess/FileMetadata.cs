namespace CookieCookbook.FileAccess;

public class FileMetadata
{
    public string Name { get; }
    public FileFormat Format { get; }

    public FileMetadata(string name, FileFormat format)
    {
        Name = name;
        Format = format;
    }

    public string ToPath() => $"{Name}.{Format.AsFileExtension()}";
}
