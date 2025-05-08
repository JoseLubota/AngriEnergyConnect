using Microsoft.EntityFrameworkCore;
using AngriEnergyConnect.Model;
using System.Security.Cryptography.X509Certificates;

namespace AngriEnergyConnect.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
