using ThoughtApp.Domain.Type;
using ThoughtApp.Domain.Languages;

namespace ThoughtApp.Domain.Thoughts;

public interface IThoughtRepository
{
    Task AddAsync(Thought thought);
    Task<Thought?> GetById(long id);
    Task<List<Thought?>> GetThoughts(long? userId = null, Types? type = null, Language? language = null);
    Task UpdateAsync(long id, Thought thought);
    Task DeleteById(long id);
}