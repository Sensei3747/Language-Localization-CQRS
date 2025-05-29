using ThoughtApp.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ThoughtApp.Infrastructure.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(user => user.Id);
        builder.Property(user => user.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();
        builder.Property(user => user.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(user => user.PasswordHash)
            .IsRequired()
            .HasMaxLength(256);

        builder.HasIndex(user => user.Name).IsUnique();
    }
}