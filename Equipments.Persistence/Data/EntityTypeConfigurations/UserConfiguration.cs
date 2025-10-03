using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.Data.EntityTypeConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .ToTable("users");

        builder
            .HasKey(user => user.Id);

        builder
            .Property(user => user.Id)
            .HasColumnName("id");

        builder
            .Property(user => user.Password)
            .HasColumnName("password")
            .IsRequired();
    }
}