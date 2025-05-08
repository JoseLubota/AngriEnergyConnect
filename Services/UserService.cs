using AngriEnergyConnect.Data;
using AngriEnergyConnect.Model;
using Microsoft.EntityFrameworkCore;

namespace AngriEnergyConnect.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(AppDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _httpContextAccessor = contextAccessor;
        }
        public async Task<List<User>> GetAllAsync() => await _context.Users.ToListAsync();

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> LoginAsync(string email, string password)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.email == email && u.password == password);

            if(user != null)
            {
                _httpContextAccessor.HttpContext.Session.SetInt32("UserID",user.userID);
                _httpContextAccessor.HttpContext.Session.SetString("accountType", user.accountType);
                return true;
            }

            return false;
        }
    }
}
