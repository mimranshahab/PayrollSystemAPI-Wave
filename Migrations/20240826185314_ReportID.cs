using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayrollSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class ReportID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "reportId",
                table: "TimeReports",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "reportId",
                table: "TimeReports");
        }
    }
}
