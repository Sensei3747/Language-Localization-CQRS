namespace ThoughtApp.Domain.Users;

public interface IUserRepository
{
    void Add(User user);
    Task<User?> GetByName(string name);
    Task<User?> GetById(long id); 
}