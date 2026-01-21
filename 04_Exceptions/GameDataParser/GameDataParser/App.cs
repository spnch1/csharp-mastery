namespace GameDataParser;

public class App(
    IUserInteraction userInteraction,
    IGameJsonParser gameJsonParser,
    ILogger logger,
    IGamesPrinter gamesPrinter)
{
    public void Run()
    {
        try
        {
            string filePath = userInteraction.ParseFileName();

            List<Game> games = gameJsonParser.ParseJson(filePath);

            gamesPrinter.Print(games);
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