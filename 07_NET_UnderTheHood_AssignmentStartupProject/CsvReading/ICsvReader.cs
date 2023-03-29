namespace CsvDataAccess.CsvReading;

public interface ICsvReader
{
    CsvData Read(string filePath);
}