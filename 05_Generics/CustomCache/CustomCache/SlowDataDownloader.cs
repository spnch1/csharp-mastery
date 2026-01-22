namespace CustomCache;

public class SlowDataDownloader : IDataDownloader
{
    public string DownloadData(string resourceId)
    {
        Thread.Sleep(500);
        return $"Some data for {resourceId}";
    }
}