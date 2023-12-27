namespace _16_QuoteFinder.DataAccess;

public interface IQuotesApiDataReader : IDisposable
{
    Task<string> ReadAsync(int page, int quotesPerPage);
}