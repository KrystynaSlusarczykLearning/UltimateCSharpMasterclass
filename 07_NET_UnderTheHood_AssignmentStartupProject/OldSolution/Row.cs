namespace CsvDataAccess.OldSolution;

public class Row
{
    private Dictionary<string, object> _data;

    public Row(Dictionary<string, object> data)
    {
        _data = data;
    }

    public object GetAtColumn(string columnName)
    {
        return _data[columnName];
    }
}