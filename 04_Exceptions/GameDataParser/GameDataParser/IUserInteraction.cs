namespace GameDataParser;

public interface IUserInteraction
{
    void ShowMessage(string message);
    void ShowError(string message);
    void PromptFileName();
    string ParseFileName();
    void PrintGames(IEnumerable<Game> games);
}