using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;

namespace CoffeePlus.Data.Data
{
    public class CoffeePlusDbContextFactory : IDesignTimeDbContextFactory<CoffeePlusDbContext>
    {
        public CoffeePlusDbContext CreateDbContext(string[] args)
        {
            var mongoClient = new MongoClient("mongodb+srv://recipe-backend-code:recipe-backend-code@cluster0.lb2t8cn.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0");

            var dbContextOptions =
                new DbContextOptionsBuilder<CoffeePlusDbContext>()
                    .UseMongoDB(mongoClient, "coffeeplusDB")
                    .Options;

            return new CoffeePlusDbContext(dbContextOptions);
        }
    }
}