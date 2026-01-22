namespace NetUnderTheHoodAssignment.CsvReading;

public interface ICsvReader
{
    CsvData Read(string filePath);
}