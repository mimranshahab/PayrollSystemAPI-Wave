public class Employee
{
    public string EmployeeId { get; set; }
    public string JobGroup { get; set; }
    public ICollection<TimeReport> TimeReports { get; set; }
}