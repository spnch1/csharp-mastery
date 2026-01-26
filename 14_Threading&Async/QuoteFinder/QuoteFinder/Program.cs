using QuoteFinder;
using QuoteFinder.DataAccess;
using QuoteFinder.UserInteraction;

var userInteractor = new ConsoleUserInteractor();
var quoteApiDataReader = new QuotesApiDataReader();
var quoteDataFetcher = new QuoteDataFetcher(quoteApiDataReader);
var quoteDataProcessor = new QuoteDataProcessor(userInteractor);

try
{
    var word = userInteractor.ReadSingleWord(
        "What word are you looking for?");
    var numberOfPages = userInteractor.ReadInteger(
        "How many pages do you want to read?");
    var quotesPerPage = userInteractor.ReadInteger(
        "How many quotes per page?");
    var shallProcessInParallel = userInteractor.ReadBool(
        "Shall process pages in parallel?");

    userInteractor.ShowMessage("Fetching data. . .");
    var data =
        await quoteDataFetcher.FetchDataFromAllPagesAsync(numberOfPages, quotesPerPage);
    await quoteDataProcessor.ProcessAsync(data, word, shallProcessInParallel, userInteractor);
    
    userInteractor.ShowMessage("Data fetched successfully!");
}
catch (Exception ex)
{
    userInteractor.ShowMessage("Exception thrown: " + ex.Message);
}
finally
{
    Console.WriteLine("Press any key to exit. . .");
    Console.ReadKey(true);
}
