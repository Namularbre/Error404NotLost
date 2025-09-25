using Error404NotLost_DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Error404NotLost_BLL.Services
{
    public class UserService
    {
        private readonly Error404NotLostDbContext _context;

        public UserService(Error404NotLostDbContext context)
        {
            _context = context;
        }

        public async Task<List<IdentityUser>> GetUsers()
            => await _context.Users.ToListAsync();

        public async Task<IdentityUser?> GetUserById(string id)
            => await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

        public async Task DeleteUserById(string id)
        {
            IdentityUser? user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
