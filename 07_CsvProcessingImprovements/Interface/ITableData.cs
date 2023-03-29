namespace CsvDataAccess.Interface;

public interface ITableData
{
    IEnumerable<string> Columns { get; }
    int RowCount { get; }
    public object GetValue(string columnName, int rowIndex);
}