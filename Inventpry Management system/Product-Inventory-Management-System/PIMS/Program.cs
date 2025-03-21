using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Data;
using Services.Helper;
using ServicesContracts;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MyDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnectionStrings")));
builder.Services.AddScoped<IProducts, ProductsServices>();
builder.Services.AddTransient<ExportExcel>();
builder.Host.ConfigureLogging(LoggingProvider =>
{
    LoggingProvider.ClearProviders();
    LoggingProvider.AddConsole();
    LoggingProvider.AddDebug();
    LoggingProvider.AddEventLog();

});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
