using TicketsAggregator.App;

namespace TicketsAggregator.FileAccess;

internal class FileWriter(IUserInteractor userInteractor) : IFileWriter
{
    public void Write(string content, params string[] pathParts)
    {
        var resultPath = Path.Combine(pathParts);
        File.WriteAllText(resultPath, content);
        userInteractor.ShowMessage($"Results saved to {resultPath}");
    }
}