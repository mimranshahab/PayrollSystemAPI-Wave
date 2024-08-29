using Microsoft.EntityFrameworkCore;

namespace PayrollSystemAPI.Data
{
    public class PayrollReportContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TimeReport> TimeReports { get; set; }

        public PayrollReportContext(DbContextOptions<PayrollReportContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey(e => e.EmployeeId);
            modelBuilder.Entity<TimeReport>().HasKey(tr => tr.Id);
        }
    }
}