IDataDownloader dataDownloader = new SlowDataDownloader();

try
{
    Console.WriteLine(dataDownloader.DownloadData("id1"));
    Console.WriteLine(dataDownloader.DownloadData("id2"));
    Console.WriteLine(dataDownloader.DownloadData("id3"));
    Console.WriteLine(dataDownloader.DownloadData("id1"));
    Console.WriteLine(dataDownloader.DownloadData("id3"));
    Console.WriteLine(dataDownloader.DownloadData("id1"));
    Console.WriteLine(dataDownloader.DownloadData("id2"));
}
catch
{
    Console.WriteLine("Sorry!");
}
finally
{
    Console.Write("Press any key to exit. . .");
    Console.ReadKey(true);
}