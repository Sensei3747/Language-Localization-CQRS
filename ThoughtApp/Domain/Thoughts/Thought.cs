using ThoughtApp.Domain.Users;
using ThoughtApp.Domain.Languages;
using ThoughtApp.Domain.Type;

namespace ThoughtApp.Domain.Thoughts;

public class Thought
{
    public long Id { get; private set; }
    public string Content { get; set; }
    public long UserId { get; private set; }
    public User User { get; set; }
    public Types Type { get; set; }
    public Language Language { get; set; }

    private Thought() { }

    public Thought(string content, long userId, Types type, Language language)
    {
        Content = content;
        UserId = userId;
        Type = type;
        Language = language;
    }

    public static Thought Create(string content, long userId, Types type, Language language)
    {
        return new Thought(content, userId, type, language);
    }
    

}