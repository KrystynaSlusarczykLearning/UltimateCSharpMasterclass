using CsvDataAccess.CsvReading;
using CsvDataAccess.Interface;
using System.Diagnostics;

namespace CsvDataAccess.PerformanceTesting;

public static class TableDataPerformanceMeasurer
{
    public static TestResult Test(ITableDataBuilder tableDataBuiler, CsvData csvData)
    {
        var memoryBeforeLoadingTable = GC.GetTotalMemory(true);
        Stopwatch stopwatch = Stopwatch.StartNew();

        var tableData = tableDataBuiler.Build(csvData);

        stopwatch.Stop();

        var memoryAfterLoadingTable = GC.GetTotalMemory(true);
        var memoryIncreaseInBytes = memoryAfterLoadingTable - memoryBeforeLoadingTable;
        var timeOfBuildingTable = stopwatch.Elapsed;

        stopwatch.Restart();

        ReadAllData(tableData);

        stopwatch.Stop();

        var timeOfDataReading = stopwatch.Elapsed;

        return new TestResult(
            memoryIncreaseInBytes,
            timeOfBuildingTable,
            timeOfDataReading);
    }

    private static void ReadAllData(ITableData tableData)
    {
        foreach (var column in tableData.Columns)
        {
            ReadAllRowsInColumn(column, tableData);
        }
    }

    private static void ReadAllRowsInColumn(string columnName, ITableData tableData)
    {
        for (int i = 0; i < tableData.RowCount; ++i)
        {
            var result = tableData.GetValue(columnName, i);
        }
    }
}