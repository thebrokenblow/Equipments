using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.Data.EntityTypeConfigurations;

/// <summary>
/// Конфигурация сущности User для базы данных
/// </summary>
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    /// <summary>
    /// Настраивает сущность User для Entity Framework
    /// </summary>
    /// <param name="builder">Построитель для конфигурации сущности</param>
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