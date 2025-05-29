using Microsoft.AspNetCore.Identity;
using ThoughtApp.Domain.Thoughts;

namespace ThoughtApp.Domain.Users;

public class User
{
    public User(string name, string password)
    {
        Name = name;
        PasswordHash = password;
    }
    public ICollection<Thought> Thoughts { get; private set; } = new List<Thought>();
    public long Id { get; private set; }
    public string Name { get; private set; }
    public string PasswordHash { get; private set; }

    private User() { }

    public static User Create(string name, string password)
    {
        var user = new User(name, password);
        return user;
    }
}