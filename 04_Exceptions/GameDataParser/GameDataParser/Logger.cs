namespace GameDataParser;

public class Logger : ILogger
{
    private const string LogFilePath = "log.txt";
    
    public void Log(Exception ex)
    {
        try
        {
            var logEntry = $"""

                            [{DateTime.Now}],
                            Exception message:
                            {ex.Message},
                            Stack trace:
                            {ex.StackTrace}                      

                            """;
            File.AppendAllText(LogFilePath, logEntry + Environment.NewLine);
        }
        catch
        {
            Console.WriteLine("Logging failed!");
        }
    }
}