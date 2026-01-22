public class SlowDataDownloader : IDataDownloader
{
    private readonly Cache<string, string> _cache = new();

    public string DownloadData(string resourceId) =>
        _cache.GetOrAdd(resourceId, _ =>
        {
            Thread.Sleep(500);
            return $"Some data for {resourceId}";
        });
}