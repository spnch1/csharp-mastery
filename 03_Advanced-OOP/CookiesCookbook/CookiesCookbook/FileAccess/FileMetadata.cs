namespace CookiesCookbook.FileAccess;

public class FileMetadata(string name, FileFormat format)
{
    public string Name => name;
    public FileFormat Format => format;

    public string ToPath() => $"{Name}.{Format.AsFileExtension()}";
}