namespace TicketsAggregator.FileAccess;

internal interface IDocumentsReader
{
    IEnumerable<string> Read(string targetDirectory);
}