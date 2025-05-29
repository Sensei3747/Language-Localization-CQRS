using Microsoft.EntityFrameworkCore;
using ThoughtApp.Domain.Thoughts;
using ThoughtApp.Domain.Languages;
using ThoughtApp.Domain.Type;
using ThoughtApp.Infrastructure.Data;

public class ThoughtRepository : IThoughtRepository
{
    private readonly ApplicationDbContext _context;

    public ThoughtRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Thought thought)
    {
        if (thought == null)
        {
            throw new ArgumentNullException(nameof(thought), "Thought cannot be null.");
        }
        await _context.Set<Thought>().AddAsync(thought);
        await _context.SaveChangesAsync();
    }
    public async Task<Thought?> GetById(long id)
    {
        var thought = await _context.Set<Thought>().Where(thought => thought.Id == id).FirstOrDefaultAsync();
        return thought;
    }
    public async Task<List<Thought?>> GetThoughts(long? userId = null, Types? type = null, Language? language = null)
    {
        var query = _context.Set<Thought>().AsQueryable();
        if (userId.HasValue)
        {
            query = query.Where(thought => thought.UserId == userId);
        }
        if (type.HasValue)
        {
            query = query.Where(thought => thought.Type == type);
        }
        if (language.HasValue)
        {
            query = query.Where(thought => thought.Language == language);
        }
        return await query.ToListAsync();
    }
    public async Task UpdateAsync(long id, Thought thought)
    {
        var existing = await _context.Set<Thought>().FindAsync(id);
        if (existing != null)
        {
            _context.Entry(existing).CurrentValues.SetValues(thought);
            await _context.SaveChangesAsync();
        }
    }
    public async Task DeleteById(long id)
    {
        var thought = await _context.Set<Thought>().FindAsync(id);
        if (thought != null)
        {
            _context.Set<Thought>().Remove(thought);
            await _context.SaveChangesAsync();
        }
    }
}