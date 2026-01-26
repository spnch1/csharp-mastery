using System.Text.Json;
using QuoteFinder.DTOs;
using QuoteFinder.UserInteraction;

namespace QuoteFinder;

public class QuoteDataProcessor(IUserInteractor userInteractor) : IQuoteDataProcessor
{
    private readonly Lock _locker = new Lock();
    
    public async Task ProcessAsync(
        IEnumerable<string> data,
        string? word,
        bool shallProcessInParallel)
    {
        if (shallProcessInParallel)
        {
            userInteractor.ShowMessage("Parallel processing started.");
            var tasks =
                data.Select(page => Task.Run(() =>
                    ProcessPage(page, word)));
        
            await Task.WhenAll(tasks);
        }
        else
        {
            userInteractor.ShowMessage("Sequential processing started.");
            foreach (var page in data)
            {
                ProcessPage(page, word);
            }
        }
    }
    
    private void ProcessPage(string page, string? word)
    {
        var root = JsonSerializer.Deserialize<RootDto>(page);

        var quoteWithWord = root?.Results
            .Where(q => ContainsWord(q.Content, word))
            .MinBy(q => q.Content.Length);

        lock (_locker)
        {
            userInteractor.ShowMessage(quoteWithWord is not null
                ? $"{quoteWithWord.Content} -- {quoteWithWord.Author}"
                : "No quote found on page.");
            userInteractor.ShowMessage(string.Empty);
        }
    }
    
    private static bool ContainsWord(string input, string? requiredWord)
    {
        var split = input.Split(
            [' ', '.', ',', '!', '?', ';', ':'],
            StringSplitOptions.RemoveEmptyEntries);

        return split.Any(s => string.Equals(
            s, requiredWord, StringComparison.OrdinalIgnoreCase));
    }
}