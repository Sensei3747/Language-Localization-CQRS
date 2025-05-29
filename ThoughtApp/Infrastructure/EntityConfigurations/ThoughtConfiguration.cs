using ThoughtApp.Domain.Abstractions;
using ThoughtApp.Domain.Thoughts;
using ThoughtApp.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ThoughtApp.Infrastructure.EntityConfigurations;

public class ThoughtConfiguration : IEntityTypeConfiguration<Thought>
{
    public void Configure(EntityTypeBuilder<Thought> builder)
    {
        builder.ToTable("Thoughts");

        builder.HasKey(thought => thought.Id);

        builder.Property(thought => thought.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(thought => thought.Content)
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(thought => thought.Type)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(thought => thought.Language)
            .IsRequired();

        builder.HasOne(thought => thought.User)
               .WithMany(u => u.Thoughts)
               .HasForeignKey(thought => thought.UserId)
               .OnDelete(DeleteBehavior.Cascade);
        
    }
    
}
    