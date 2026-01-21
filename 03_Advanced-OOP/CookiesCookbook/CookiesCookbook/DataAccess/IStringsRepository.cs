namespace CookiesCookbook.DataAccess;

public interface IStringsRepository
{
    List<string> Read(string filePath);
    public void Write(string filePath, List<string> strings);
}