using System.Globalization;
using System.Text;
using TicketsAggregator.Extensions;
using TicketsAggregator.FileAccess;

namespace TicketsAggregator.App;

internal class TicketsAggregatorApp(string targetDirectory, IFileWriter fileWriter, IDocumentsReader documentsReader)
{
    private readonly Dictionary<string, CultureInfo> _domainToCultureMapping = new()
    {
        [".com"] = new CultureInfo("en-US"),
        [".fr"] = new CultureInfo("fr-FR"),
        [".jp"] = new CultureInfo("ja-JP"),
    };
    
    public void Run()
    {
        var stringBuilder = new StringBuilder();
        var ticketDocuments = documentsReader.Read(targetDirectory);

        foreach (var document in ticketDocuments)
        {
            var lines = ProcessDocument(document);
            stringBuilder.AppendLine(string.Join(Environment.NewLine, lines));
        }

        fileWriter.Write(
            stringBuilder.ToString(),
            targetDirectory, "aggregatedTickets.txt");
    }

    private IEnumerable<string> ProcessDocument(string document)
    {
        var split = document.Split(
            ["Title:", "Date:", "Time:", "Visit us:"],
            StringSplitOptions.None);

        var domain = split.Last().ExtractDomain();
        var ticketCulture = _domainToCultureMapping[domain];

        for (var i = 1; i < split.Length - 3; i += 3)
        {
            yield return BuildTicketData(split, i, ticketCulture);
        }
    }

    private static string BuildTicketData(string[] split, int i, CultureInfo ticketCulture)
    {
        var title = split[i];
        var dateString = split[i + 1];
        var timeString = split[i + 2];

        var date = DateOnly.Parse(dateString, ticketCulture);
        var time = TimeOnly.Parse(timeString, ticketCulture);

        var dateStringInvariant = date.ToString(CultureInfo.InvariantCulture);
        var timeStringInvariant = time.ToString(CultureInfo.InvariantCulture);

        var ticketData = $"{title,-40}| {dateStringInvariant} | {timeStringInvariant} ";
        return ticketData;
    }
}