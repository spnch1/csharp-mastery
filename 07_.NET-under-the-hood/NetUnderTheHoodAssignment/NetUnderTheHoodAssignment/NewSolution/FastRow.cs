namespace NetUnderTheHoodAssignment.NewSolution;

public class FastRow(Dictionary<string, object> data)
{
    public object GetAtColumn(string columnName)
    {
        if (data.ContainsKey(columnName))
            return data[columnName];
        return null;
    }
}