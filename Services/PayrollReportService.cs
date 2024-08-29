using Microsoft.EntityFrameworkCore;
using PayrollSystemAPI.Utils;
using PayrollSystemAPI.Data;

public class PayrollReportService 
{
    private readonly PayrollReportContext _dbcontext;
    private readonly Utils _utils;

    public PayrollReportService(PayrollReportContext DBcontext)
    {
        _dbcontext = DBcontext;
        _utils = new Utils();
    }

    public async Task<PayrollReport> GetPayrollReport()
    {
        var employeeReports = new List<EmployeeReport>();

        var employees = await _dbcontext.Employees.Include(e => e.TimeReports).ToListAsync();

        foreach (var employee in employees)
        {
            var payPeriods = employee.TimeReports
                .GroupBy(tr => new { employee.EmployeeId,  startdate = _utils.GetPayPeriod(tr.Date).StartDate })
                .Select(g => new EmployeeReport
                {
                    EmployeeId = g.Key.EmployeeId,
                    PayPeriod = _utils.GetPayPeriod(g.Key.startdate),
                    AmountPaid = (decimal)g.Sum(tr => tr.HoursWorked * _utils.GetHourlyRate(employee.JobGroup))
                })
                .OrderBy(tr => tr.EmployeeId)
                .ThenBy(tr => tr.PayPeriod.StartDate)
                .ToList();           

            employeeReports.AddRange(payPeriods);
        }

        return new PayrollReport { EmployeeReports = employeeReports };
    }    
}
