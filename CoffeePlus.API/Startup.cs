using CoffeePlus.Data.Data;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Serilog;
using CoffeePlus.API.Repositories;

namespace CoffeePlus.API;

public class Startup
{
    private readonly IConfiguration _configuration;
    private readonly bool _inMemory;

    public Startup(IConfiguration configuration, bool inMemory)
    {
        _configuration = configuration;
        _inMemory = inMemory;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddOptions();
        var mongoClient = new MongoClient("mongodb+srv://recipe-backend-code:recipe-backend-code@cluster0.lb2t8cn.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0");

        services.AddDbContext<CoffeePlusDbContext>(options =>
            options.UseMongoDB(mongoClient, "coffeeplusDB"));

        services.AddEndpointsApiExplorer();
        services.AddMemoryCache();
        services.AddControllers();

        services.AddSwaggerGen();
        
        services.AddScoped<IProductRepository, ProductRepository>();
    }

    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        app.UseRouting();
        app.MapControllers();
    }
}