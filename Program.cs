using System.Globalization;
using Microsoft.EntityFrameworkCore;
using PayrollSystemAPI.Data;

var builder = WebApplication.CreateBuilder(args);


CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-GB");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-GB");

// Add services to the container.
builder.Services.AddControllers();

// Configure the database context
builder.Services.AddDbContext<PayrollReportContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Build the app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.MapControllers();

app.Run();
