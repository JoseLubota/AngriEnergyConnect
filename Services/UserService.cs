using AngriEnergyConnect.Data;
using AngriEnergyConnect.Model;
using Microsoft.EntityFrameworkCore;

namespace AngriEnergyConnect.Services
{
    public class UserService
    {
        // Allow service to connect to database
        private readonly AppDbContext _context;

        // Allow service to connect to the system context
        private readonly IHttpContextAccessor _httpContextAccessor;

        // Class constructor 
        public UserService(AppDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _httpContextAccessor = contextAccessor;
        }
        //---------------------------------------------------------------------------------------------//
        // Retrieves all data from table user
        //---------------------------------------------------------------------------------------------//
        public async Task<List<User>> GetAllAsync() => await _context.Users.ToListAsync();

        //---------------------------------------------------------------------------------------------//
        // Insert new data into table product
        //---------------------------------------------------------------------------------------------//
        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
        //---------------------------------------------------------------------------------------------------------------//
        // Check if email and password exist in the table and set userID and accountype in session context
        //---------------------------------------------------------------------------------------------------------------//
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
//--------------------------------...END OF FILE...-------------------------------------------------------------//
