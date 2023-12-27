using _16_QuoteFinder.Models;
using _16_QuoteFinder.UserInteraction;
using System.Text.Json;

namespace _16_QuoteFinder;

public class QuoteDataProcessor : IQuoteDataProcessor
{
    private readonly IUserInteractor _userInteractor;

    public QuoteDataProcessor(IUserInteractor userInteractor)
    {
        _userInteractor = userInteractor;
    }

    public async Task ProcessAsync(
        IEnumerable<string> data,
        string word,
        bool shallProcessInParallel)
    {
        if (shallProcessInParallel)
        {
            _userInteractor.ShowMessage(
                "Parallel processing started." + Environment.NewLine);
            var tasks = data.Select(
                page => Task.Run(() => ProcessPage(page, word)));

            await Task.WhenAll(tasks);
        }
        else
        {
            _userInteractor.ShowMessage(
                "Sequential processing started." + Environment.NewLine);
            foreach (var page in data)
            {
                ProcessPage(page, word);
            }
        }
    }

    private void ProcessPage(string pageJson, string word)
    {
        var root = JsonSerializer.Deserialize<Root>(pageJson);

        var quoteWithWord = root?.data
            .Where(quote => quote.quoteText.ContainsWord(word))
            .MinBy(quote => quote.quoteText.Length);

        if (quoteWithWord is not null)
        {
            _userInteractor.ShowMessage(
                $"{quoteWithWord.quoteText} -- {quoteWithWord.quoteAuthor}");
        }
        else
        {
            _userInteractor.ShowMessage("No quote found on this page.");
        }
        _userInteractor.ShowMessage(string.Empty);
    }
}