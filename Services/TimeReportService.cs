using CsvHelper;
using Microsoft.EntityFrameworkCore;
using PayrollSystemAPI.Utils;
using System.Globalization;
using PayrollSystemAPI.Data;

public class TimeReportService
{
    private readonly PayrollReportContext _dbcontext;
    private readonly Utils _utils;

    public TimeReportService(PayrollReportContext DBcontext)
    {
        _dbcontext = DBcontext;
        _utils = new Utils();
    }

    public async Task UploadTimeReport(IFormFile file)
    {
        if (file == null || file.Length == 0)
            throw new Exception("File is empty.");

        var reportId = _utils.ExtractReportId(file.FileName);
        if (await _dbcontext.TimeReports.AnyAsync(tr => tr.reportId == reportId))
            throw new Exception("Report with this ID already exists.");

        using (var reader = new StreamReader(file.OpenReadStream()))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<TimeReportCsv>().ToList();
            var employeesDict = new Dictionary<int, Employee>();
            var timeReportsDict = new Dictionary<int, TimeReport>();

            foreach (var record in records)
            {
                if (!employeesDict.TryGetValue(int.Parse(record.EmployeeId), out var employee))
                {
                    employee = await _dbcontext.Employees
                        .Include(e => e.TimeReports)
                        .FirstOrDefaultAsync(e => e.EmployeeId == record.EmployeeId);

                    if (employee == null)
                    {
                        employee = new Employee
                        {
                            EmployeeId = record.EmployeeId,
                            JobGroup = record.JobGroup,
                            TimeReports = new List<TimeReport>()
                        };
                        _dbcontext.Employees.Add(employee);
                    }

                    employeesDict.Add(int.Parse(record.EmployeeId), employee);
                }

                var timeReport = new TimeReport
                {
                    reportId = reportId,
                    Date = DateTime.Parse(record.Date),
                    HoursWorked = double.Parse(record.HoursWorked),
                    EmployeeId = record.EmployeeId
                };

                employee.TimeReports.Add(timeReport);
            }

            await _dbcontext.SaveChangesAsync();
        }
    }    
}


