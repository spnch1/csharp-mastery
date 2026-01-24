using UglyToad.PdfPig;

namespace TicketsAggregator.FileAccess;

internal class DocumentsFromPdfsReader : IDocumentsReader
{
    public IEnumerable<string> Read(string targetDirectory)
    {
        foreach (var file in Directory.GetFiles(targetDirectory, "*.pdf"))
        {
            using var document = PdfDocument.Open(file);
            if (document.NumberOfPages > 1)
            {
                throw new NotSupportedException(
                    "PDF has more than 1 page. This exceeds the application's scope of functionality.");
            }

            var page = document.GetPage(1);
            yield return page.Text;
        }
    }
}