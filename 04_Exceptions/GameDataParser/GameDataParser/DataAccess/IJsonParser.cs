using GameDataParser.Model;

namespace GameDataParser.DataAccess;

public interface IGameJsonParser
{
    List<Game> ParseJson(string filePath);
}