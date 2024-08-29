using Microsoft.AspNetCore.Mvc;
using PayrollSystemAPI.Data;


namespace PayrollSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimeReportController : ControllerBase
    {
        private readonly PayrollReportContext _dbcontext;
        private readonly TimeReportService _svc;

        public TimeReportController(PayrollReportContext context)
        {
            _dbcontext = context;
            _svc = new TimeReportService(_dbcontext);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadTimeReport(IFormFile file)
        {
            try
            {
                await _svc.UploadTimeReport(file);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}