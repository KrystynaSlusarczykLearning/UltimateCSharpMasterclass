using _16_QuoteFinder;
using _16_QuoteFinder.DataAccess;
using _16_QuoteFinder.UserInteraction;
using System.Diagnostics;

var userInteractor = new ConsoleUserInteractor();
try
{
    string word = userInteractor.ReadSingleWord(
        "What word are you looking for?");
    int numberOfPages = userInteractor.ReadInteger(
        "How many pages do you want to read?");
    int quotesPerPage = userInteractor.ReadInteger(
        "How many quotes per page?");
    bool shallProcessInParallel = userInteractor.ReadBool(
        "Shall process pages in parallel?");

    using var quotesApiDataReader = new QuotesApiDataReader();
    var quoteDataFetcher = new QuoteDataFetcher(quotesApiDataReader);

    userInteractor.ShowMessage("Fetching data...");
    IEnumerable<string> data = await quoteDataFetcher.FetchDataFromAllPagesAsync(
        numberOfPages, quotesPerPage);
    userInteractor.ShowMessage("Data is ready.");

    Stopwatch stopwatch = Stopwatch.StartNew();
    var quoteDataProcessor = new QuoteDataProcessor(userInteractor);
    await quoteDataProcessor.ProcessAsync(data, word, shallProcessInParallel);
    stopwatch.Stop();
    userInteractor.ShowMessage("Processing took: " + stopwatch.ElapsedMilliseconds);
}
catch(Exception ex)
{
    userInteractor.ShowMessage("Exception thrown: " + ex.Message);
}
Console.WriteLine("Program is finished.");
Console.ReadKey();
