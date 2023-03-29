using CsvDataAccess.CsvReading;

namespace CsvDataAccess.Interface;

public interface ITableDataBuilder
{
    ITableData Build(CsvData csvData);
}