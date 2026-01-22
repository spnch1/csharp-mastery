namespace NetUnderTheHoodAssignment.OldSolution;

public class Row(Dictionary<string, object> data)
{
    public object GetAtColumn(string columnName) =>
        data[columnName];
}