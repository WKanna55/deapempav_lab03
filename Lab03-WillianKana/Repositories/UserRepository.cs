using Lab03_WillianKana.Data;
using Lab03_WillianKana.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lab03_WillianKana.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext _context) : base(_context)
    {
        this._context = _context;
    }

    public async Task<User> GetByUser(string user)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Username == user || u.Email == user);
    }

    public bool IsAvailableUser(string user)
    {
        return !_context.Users.Any(u => u.Username == user || u.Email == user);
    }

    public async Task<User> Update(User userParams, string password = null)
    {
        var user = await _context.Users.FindAsync(userParams.Id);
        
        if (user == null) return null;
        
        user.Username = userParams.Username;
        user.Email = userParams.Email;

        if (!string.IsNullOrEmpty(password))
        {
            user.Password = password;
        }
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        
        return user;
    }
}