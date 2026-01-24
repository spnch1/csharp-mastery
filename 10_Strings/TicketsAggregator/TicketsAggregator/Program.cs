using TicketsAggregator.App;
using TicketsAggregator.FileAccess;

const string targetDirectory = "../../../Data/Tickets";

try
{
    var app = new TicketsAggregatorApp(
        targetDirectory,
        new FileWriter(
            new ConsoleUserInteractor()),
        new DocumentsFromPdfsReader());
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"An error occured. Sorry! Exception message: {ex.Message}");
}
finally
{
    Console.WriteLine("Press any key to exit. . .");
    Console.ReadKey(true);
}