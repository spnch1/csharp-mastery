namespace CsvDataAccess.CsvReading;

public class CsvData(
    string[] columns,
    IEnumerable<string[]> rows)
{
    public string[] Columns { get; } = columns;
    public IEnumerable<string[]> Rows { get; } = rows;
}