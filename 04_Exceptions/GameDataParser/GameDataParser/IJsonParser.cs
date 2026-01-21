namespace GameDataParser;

public interface IJsonParser
{
    List<Game> ParseJson(string filePath);
}