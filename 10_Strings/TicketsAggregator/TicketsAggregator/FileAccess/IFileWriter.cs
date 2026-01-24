namespace TicketsAggregator.FileAccess;

internal interface IFileWriter
{
    void Write(string content, params string[] pathParts);
}