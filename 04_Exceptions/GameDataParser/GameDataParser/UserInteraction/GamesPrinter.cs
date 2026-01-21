using GameDataParser.Model;

namespace GameDataParser.UserInteraction;

public class GamesPrinter(IUserInteraction userInteraction) : IGamesPrinter
{
    public void Print(IEnumerable<Game> games)
    {
        Console.WriteLine("Loaded games are:");
        foreach (var game in games)
            Console.WriteLine($"{game.Title}, released in {game.ReleaseYear}, rating: {game.Rating}");
    }
}