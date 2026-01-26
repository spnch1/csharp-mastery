namespace QuoteFinder;

public interface IQuoteDataFetcher
{
    Task<IEnumerable<string>> FetchDataFromAllPagesAsync(int pageCount, int quoteCount);
}