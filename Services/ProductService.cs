using AngriEnergyConnect.Model;
using Microsoft.EntityFrameworkCore;
using AngriEnergyConnect.Data;

namespace AngriEnergyConnect.Services
{
    public class ProductService
    {
        // Allow service to connect to database
        private readonly AppDbContext _context;

        // Class constructor 
        public ProductService(AppDbContext context)
        {
            _context = context;
        }
        //---------------------------------------------------------------------------------------------//
        // Retrieves all data from table product
        //---------------------------------------------------------------------------------------------//
        public async Task <List<Product>> GetAllAsync() => await _context.Products.ToListAsync();
        //---------------------------------------------------------------------------------------------//
        // Retrieves data from table projeduct sorted bt User IDs
        //---------------------------------------------------------------------------------------------//
        public async Task<List<Product>> GetBtUserIdAsync(int userId)
        {
             return await _context.Products
                .Where(p => p.userID == userId)
                .ToListAsync();

        }
        //---------------------------------------------------------------------------------------------//
        // Insert new data into table product
        //---------------------------------------------------------------------------------------------//
        public async Task AddAsync (Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

    }
}
//--------------------------------...END OF FILE...-------------------------------------------------------------//
