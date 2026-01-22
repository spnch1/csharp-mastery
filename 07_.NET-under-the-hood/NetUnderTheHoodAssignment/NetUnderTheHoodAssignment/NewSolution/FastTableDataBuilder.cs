using NetUnderTheHoodAssignment.CsvReading;
using NetUnderTheHoodAssignment.Interface;

namespace NetUnderTheHoodAssignment.NewSolution;

public class FastTableDataBuilder : ITableDataBuilder
{
    public ITableData Build(CsvData csvData)
    {
        var resultRows = new List<FastRow>();

        foreach (var row in csvData.Rows)
        {
            var newRowData = new Dictionary<string, object>();

            for (var columnIndex = 0; columnIndex < csvData.Columns.Length; ++columnIndex)
            {
                var column = csvData.Columns[columnIndex];
                var valueAsString = row[columnIndex];
                object value = ConvertValueToTargetType(valueAsString);
                if (value is not null)
                    newRowData[column] = value;
            }

            resultRows.Add(new FastRow(newRowData));
        }

        return new FastTableData(csvData.Columns, resultRows);
    }
    
    private object ConvertValueToTargetType(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return null;
        }
        if (value == "TRUE")
        {
            return true;
        }
        if (value == "FALSE")
        {
            return false;
        }
        if (value.Contains(".") && decimal.TryParse(value, out var valueAsDecimal))
        {
            return valueAsDecimal;
        }
        if (int.TryParse(value, out var valueAsInt))
        {
            return valueAsInt;
        }
        return value;
    }
}
