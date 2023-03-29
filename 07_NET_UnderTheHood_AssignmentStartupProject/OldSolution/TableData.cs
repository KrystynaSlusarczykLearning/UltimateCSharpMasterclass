using CsvDataAccess.Interface;

namespace CsvDataAccess.OldSolution;

public class TableData : ITableData
{
    private readonly List<Row> _rows;
    public int RowCount => _rows.Count;
    public IEnumerable<string> Columns { get; }

    public TableData(IEnumerable<string> columns, List<Row> rows)
    {
        _rows = rows;
        Columns = columns;
    }

    public object GetValue(string columnName, int rowIndex)
    {
        return _rows[rowIndex].GetAtColumn(columnName);
    }
}