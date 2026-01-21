namespace GameDataParser;

public interface IGamesPrinter
{
    void Print(IEnumerable<Game> games);
}