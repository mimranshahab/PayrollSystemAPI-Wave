
public class TimeReport
{
    public int Id { get; set; }
    public int reportId { get; set; }
    public DateTime Date { get; set; }
    public double HoursWorked { get; set; }
    public string EmployeeId { get; set; }
    public Employee Employee { get; set; }
}