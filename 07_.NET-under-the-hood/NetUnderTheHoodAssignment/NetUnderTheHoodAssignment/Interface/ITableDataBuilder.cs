using NetUnderTheHoodAssignment.CsvReading;

namespace NetUnderTheHoodAssignment.Interface;

public interface ITableDataBuilder
{
    ITableData Build(CsvData csvData);
}