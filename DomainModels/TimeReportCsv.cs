using CsvHelper.Configuration.Attributes;

public class TimeReportCsv
{
    [Index(0)]
    public string Date { get; set; }

    [Index(1)]
    public string HoursWorked { get; set; }

    [Index(2)]
    public string EmployeeId { get; set; }

    [Index(3)]
    public string JobGroup { get; set; }
}
