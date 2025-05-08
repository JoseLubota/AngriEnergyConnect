using AngriEnergyConnect.Model;
using Microsoft.EntityFrameworkCore;
using AngriEnergyConnect.Data;

namespace AngriEnergyConnect.Services
{
    public class ProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task <List<Product>> GetAllAsync() => await _context.Products.ToListAsync();

        public async Task<List<Product>> GetBtUserIdAsync(int userId)
        {
             return await _context.Products
                .Where(p => p.userID == userId)
                .ToListAsync();

        }

        public async Task AddAsync (Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

    }
}
