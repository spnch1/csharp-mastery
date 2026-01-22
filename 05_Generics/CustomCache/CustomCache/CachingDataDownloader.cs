namespace CustomCache;

public class CachingDataDownloader(IDataDownloader dataDownloader) : IDataDownloader
{
    private readonly Cache<string, string> _cache = new();

    public string DownloadData(string resourceId) =>
        _cache.GetOrAdd(resourceId, dataDownloader.DownloadData);
}