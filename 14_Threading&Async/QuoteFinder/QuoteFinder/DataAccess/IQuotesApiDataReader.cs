using System.Text.Json;
using QuoteFinder.DTOs;

namespace QuoteFinder.DataAccess;

public interface IQuotesApiDataReader : IDisposable
{
    Task<string> ReadAsync(int page, int quotesPerPage);
    
}