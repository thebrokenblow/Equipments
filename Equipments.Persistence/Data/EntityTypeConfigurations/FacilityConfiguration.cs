using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.Data.EntityTypeConfigurations;

/// <summary>
/// Конфигурация сущности Facility для базы данных
/// </summary>
public class FacilityConfiguration : IEntityTypeConfiguration<Facility>
{
    /// <summary>
    /// Настраивает сущность Facility для Entity Framework
    /// </summary>
    /// <param name="builder">Построитель для конфигурации сущности</param>
    public void Configure(EntityTypeBuilder<Facility> builder)
    {
        builder
            .ToTable("facilities");

        builder
            .HasKey(facility => facility.Id);

        builder
            .Property(facility => facility.Id)
            .HasColumnName("id");

        builder
            .Property(facility => facility.Name)
            .HasColumnName("name")
            .IsRequired();

        builder
            .HasMany(facility => facility.Equipment)
            .WithOne(equipment => equipment.Facility)
            .HasForeignKey(equipment => equipment.FacilityId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}