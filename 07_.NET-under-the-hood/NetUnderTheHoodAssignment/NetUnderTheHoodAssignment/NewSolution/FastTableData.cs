using NetUnderTheHoodAssignment.Interface;

namespace NetUnderTheHoodAssignment.NewSolution;

public class FastTableData(IEnumerable<string> columns, List<FastRow> rows) : ITableData
{
    public int RowCount => rows.Count;
    public IEnumerable<string> Columns { get; } = columns;

    public object GetValue(string columnName, int rowIndex) =>
        rows[rowIndex].GetAtColumn(columnName);
}