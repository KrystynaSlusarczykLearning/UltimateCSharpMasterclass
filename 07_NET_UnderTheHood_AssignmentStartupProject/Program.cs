using CsvDataAccess.CsvReading;
using CsvDataAccess.Interface;
using CsvDataAccess.OldSolution;
using CsvDataAccess.NewSolution;
using CsvDataAccess.PerformanceTesting;

string filePath = "sampleData.csv";
var csvData = new CsvReader().Read(filePath);

ITableDataBuilder tableDataBuiler = new TableDataBuilder();

//JIT-ting the Test method
var _ = TableDataPerformanceMeasurer.Test(
    tableDataBuiler, csvData);

var testResult = TableDataPerformanceMeasurer.Test(
    tableDataBuiler, csvData);

Console.WriteLine("Test results for old code:");
Console.WriteLine("Memory increase in bytes: " +
    string.Format("{0:n0}", testResult.MemoryIncreaseInBytes));
Console.WriteLine($"Time of loading the CSV was " +
    $"{testResult.TimeOfBuildingTable}.");
Console.WriteLine($"Time of reading the CSV was " +
    $"{testResult.TimeOfDataReading}.");

ITableDataBuilder fastTableDataBuiler = new FastTableDataBuilder();

//TODO uncomment when new code is ready
//var testResultForNewCode = TableDataPerformanceMeasurer.Test(
//    fastTableDataBuiler, csvData);

//Console.WriteLine();
//Console.WriteLine("Test results for new code:");
//Console.WriteLine("Memory increase in bytes: " +
//    string.Format("{0:n0}", testResultForNewCode.MemoryIncreaseInBytes));
//Console.WriteLine($"Time of loading the CSV was " +
//    $"{testResultForNewCode.TimeOfBuildingTable}.");
//Console.WriteLine($"Time of reading the CSV was " +
//    $"{testResultForNewCode.TimeOfDataReading}.");

//Console.WriteLine();
//Console.WriteLine("Checking if results are the same...");
//var areEqual = ContentEqualityChecker.IsEqual(
//    tableDataBuiler, 
//    fastTableDataBuiler, 
//    csvData);

//if(areEqual)
//{
//    Console.WriteLine("Results are the same.");
//}
//else
//{
//    Console.WriteLine("Results are different.");
//}

Console.WriteLine("Done. Press any key to close.");
Console.ReadKey();
