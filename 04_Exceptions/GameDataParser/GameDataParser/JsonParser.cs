using System.Text.Json;

namespace GameDataParser;

public class GameJsonParser : IGameJsonParser
{
    public List<Game> ParseJson(string filePath)
    {
        var jsonString = File.ReadAllText(filePath);
        
        try
        {
            return JsonSerializer.Deserialize<List<Game>>(jsonString) ??
                   throw new InvalidJsonException(filePath, jsonString);
        }
        catch (JsonException ex)
        {
            throw new InvalidJsonException(filePath, jsonString, ex);
        }
    }
}