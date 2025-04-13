using System.Diagnostics;
using CoffeePlus.API;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


var isDevelopment = builder.Environment.IsDevelopment();


if (Debugger.IsAttached)
    builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
    
var startup = new Startup(builder.Configuration, isDevelopment);

startup.ConfigureServices(builder.Services);
var app = builder.Build();
startup.Configure(app, app.Environment);
Log.Information("Starting web host");
app.Run();