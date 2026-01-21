using GameDataParser.Model;

namespace GameDataParser.UserInteraction;

public interface IGamesPrinter
{
    void Print(IEnumerable<Game> games);
}