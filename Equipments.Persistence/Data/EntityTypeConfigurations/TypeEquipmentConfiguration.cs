using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.Data.EntityTypeConfigurations;

/// <summary>
/// Конфигурация сущности TypeEquipment для базы данных
/// </summary>
public class TypeEquipmentConfiguration : IEntityTypeConfiguration<TypeEquipment>
{
    /// <summary>
    /// Настраивает сущность TypeEquipment для Entity Framework
    /// </summary>
    /// <param name="builder">Построитель для конфигурации сущности</param>
    public void Configure(EntityTypeBuilder<TypeEquipment> builder)
    {
        builder
            .ToTable("type_equipments");

        builder
            .HasKey(typeEquipment => typeEquipment.Id);

        builder
            .Property(typeEquipment => typeEquipment.Id)
            .HasColumnName("id");

        builder
            .Property(typeEquipment => typeEquipment.Name)
            .HasColumnName("name")
            .IsRequired();

        builder
            .HasMany(typeEquipment => typeEquipment.Equipments)
            .WithOne(equipment => equipment.TypeEquipment)
            .HasForeignKey(equipment => equipment.TypeEquipmentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}