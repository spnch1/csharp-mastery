namespace QuoteFinder.DataAccess;

public class QuotesApiDataReader : IQuotesApiDataReader
{
    private readonly HttpClient _httpClient = new();

    public async Task<string> ReadAsync(int page, int quotesPerPage)
    {
        var endpoint = $"http://api.quotable.io/quotes?limit={quotesPerPage}&page={page}";

        var response = await _httpClient.GetAsync(endpoint);
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadAsStringAsync();;
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}