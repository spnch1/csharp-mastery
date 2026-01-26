using QuoteFinder.DataAccess;

namespace QuoteFinder;

public class QuoteDataFetcher(IQuotesApiDataReader quotesApiDataReader) : IQuoteDataFetcher
{
    public async Task<IEnumerable<string>> FetchDataFromAllPagesAsync(int pageCount, int quoteCount)
    {
        List<Task<string>> tasks = [];
    
        using var quotesApiDataReader = new QuotesApiDataReader();
    
        for (var i = 0; i < pageCount; ++i)
        {
            tasks.Add(quotesApiDataReader.ReadAsync(i + 1, quoteCount));
        }

        return (await Task.WhenAll(tasks)).ToList();
    }
}