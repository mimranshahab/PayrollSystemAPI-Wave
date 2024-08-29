using Microsoft.AspNetCore.Mvc;
using PayrollSystemAPI.Data;

namespace PayrollSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PayrollReportController : ControllerBase
    {
        private readonly PayrollReportContext _dbcontext;
        private readonly PayrollReportService _svc;

        public PayrollReportController(PayrollReportContext DBcontext)
        {
            _dbcontext = DBcontext;
            _svc = new PayrollReportService(_dbcontext);
        }

        [HttpGet("report")]
        public async Task<IActionResult> GetPayrollReport()
        {
            var report = new
            {
                payrollReport = await _svc.GetPayrollReport()
            };

            return Ok(report);
        }
    }
}
