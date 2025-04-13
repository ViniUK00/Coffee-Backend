using CoffeePlus.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace CoffeePlus.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CoffeePlusDbContext _context;

        public ProductRepository(CoffeePlusDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }

    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(string id);
        Task AddAsync(Product product);
        Task DeleteAsync(string id);
    }
}