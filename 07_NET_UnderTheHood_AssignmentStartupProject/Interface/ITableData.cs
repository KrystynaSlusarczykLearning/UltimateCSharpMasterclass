namespace CsvDataAccess.Interface;

public interface ITableData
{
    IEnumerable<string> Columns { get; }
    int RowCount { get; }
    object GetValue(string columnName, int rowIndex);
}