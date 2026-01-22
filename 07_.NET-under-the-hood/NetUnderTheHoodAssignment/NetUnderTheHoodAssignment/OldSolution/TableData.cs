using CsvDataAccess.Interface;

namespace CsvDataAccess.OldSolution;

public class TableData(IEnumerable<string> columns, List<Row> rows) : ITableData
{
    public int RowCount => rows.Count;
    public IEnumerable<string> Columns { get; } = columns;

    public object GetValue(string columnName, int rowIndex) =>
        rows[rowIndex].GetAtColumn(columnName);
}