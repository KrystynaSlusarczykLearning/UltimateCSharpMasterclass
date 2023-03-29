using CsvDataAccess.CsvReading;
using CsvDataAccess.Interface;

public class ContentEqualityChecker
{
    public static bool IsEqual(
        ITableDataBuilder leftTableDataBuiler,
        ITableDataBuilder rightTableDataBuiler,
        CsvData csvData)
    {
        var leftData = leftTableDataBuiler.Build(csvData);
        var rightData = rightTableDataBuiler.Build(csvData);

        if (leftData.Columns.Count() != rightData.Columns.Count())
        {
            PrintColumnCountIsDifferent(leftData, rightData);

            return false;
        }

        if (leftData.RowCount != rightData.RowCount)
        {
            PrintRowCountIsDifferent(leftData, rightData);

            return false;
        }

        foreach (var column in leftData.Columns)
        {
            for (int i = 0; i < leftData.RowCount; ++i)
            {
                if(!IsRowContentEqual(leftData, rightData, column, i))
                {
                    return false;
                }                
            }
        }

        return true;
    }

    private static bool IsRowContentEqual(
        ITableData leftData,
        ITableData rightData, 
        string column, 
        int rowIndex)
    {
        var leftValue = leftData.GetValue(column, rowIndex);
        var rightValue = rightData.GetValue(column, rowIndex);

        if (leftValue is null && rightValue is null)
        {
            return true;
        }

        if ((leftValue is null && rightValue is not null) ||
            (leftValue is not null && rightValue is null))
        {
            PrintRowContentIsNotEqual(column, rowIndex, leftValue, rightValue);

            return false;
        }

        if (!leftValue.Equals(rightValue))
        {
            PrintRowContentIsNotEqual(column, rowIndex, leftValue, rightValue);

            return false;
        }

        return true;
    }

    private static void PrintColumnCountIsDifferent(
        ITableData leftData,
        ITableData rightData)
    {
        Console.WriteLine(
            $"Column count is not equal. " +
            $"Left: {leftData.Columns.Count()}, " +
            $"Right: {rightData.Columns.Count()}");
    }

    private static void PrintRowCountIsDifferent(
        ITableData leftData,
        ITableData rightData)
    {
        Console.WriteLine(
            $"Row count is not equal. " +
            $"Left: {leftData.RowCount}, " +
            $"Right: {rightData.RowCount}");
    }

    private static void PrintRowContentIsNotEqual(
        string column, 
        int rowIndex,
        object leftValue,
        object rightValue)
    {
        Console.WriteLine(
            $"Row content is not equal " +
            $"for column {column} and row number {rowIndex}. " +
            $"Left: {leftValue}, " +
            $"Right: {rightValue}");
    }
}