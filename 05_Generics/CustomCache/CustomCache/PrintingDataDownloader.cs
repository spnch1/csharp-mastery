namespace CustomCache;

public class PrintingDataDownloader(IDataDownloader dataDownloader) : IDataDownloader
{
    public string DownloadData(string resourceId)
    {
        var data = dataDownloader.DownloadData(resourceId);
        Console.WriteLine("Data is ready!");
        return data;
    }
}