namespace GameDataParser;

public interface IGameJsonParser
{
    List<Game> ParseJson(string filePath);
}