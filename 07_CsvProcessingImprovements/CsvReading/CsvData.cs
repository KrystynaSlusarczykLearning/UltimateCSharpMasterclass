namespace CsvDataAccess.CsvReading;

public class CsvData
{
    public string[] Columns { get; }
    public IEnumerable<string[]> Rows { get; }

    public CsvData(
        string[] columns,
        IEnumerable<string[]> rows)
    {
        Columns = columns;
        Rows = rows;
    }
}