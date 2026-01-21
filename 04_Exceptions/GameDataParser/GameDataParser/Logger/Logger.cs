namespace GameDataParser.Logger;

public class Logger(string logFilePath) : ILogger
{
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
            File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
        }
        catch
        {
            Console.WriteLine("Logging failed!");
        }
    }
}