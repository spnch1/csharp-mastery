namespace GameDataParser;

public class App(
    IUserInteraction userInteraction,
    IJsonParser jsonParser,
    ILogger logger)
{
    public void Run()
    {
        try
        {
            string filePath = userInteraction.ParseFileName();

            List<Game> games = jsonParser.ParseJson(filePath);

            userInteraction.PrintGames(games);
        }
        catch (Exception ex)
        {
            userInteraction.ShowError(ex.Message);
            Console.WriteLine("Sorry! The application has experienced an unexpected " +
                              "error and will have to be closed.");
            logger.Log(ex);
        }
        finally
        {
            Console.Write("Press any key to exit. . .");
            Console.ReadKey(true);
        }
    }
}