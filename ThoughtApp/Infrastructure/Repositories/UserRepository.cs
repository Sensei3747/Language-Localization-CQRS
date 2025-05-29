using ThoughtApp.Domain.Users;
using ThoughtApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ThoughtApp.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user), "User cannot be null.");
        }
        _context.Set<User>().Add(user);
    }

    public async Task<User?> GetByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name), "Name cannot be null.");
        }
        var user = await _context.Set<User>().Where(user => user.Name == name).FirstOrDefaultAsync();
        return user;
    }

    public async Task<User?> GetById(long id)
    {
        var user = await _context.Set<User>().Where(user => user.Id == id).FirstOrDefaultAsync();
        return user;
    }
}