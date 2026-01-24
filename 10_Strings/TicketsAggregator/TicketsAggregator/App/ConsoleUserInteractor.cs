namespace TicketsAggregator.App;

internal class ConsoleUserInteractor : IUserInteractor
{
    public void ShowMessage(string message) =>
        Console.WriteLine(message);
}