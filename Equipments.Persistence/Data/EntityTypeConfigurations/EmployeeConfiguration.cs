using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.Data.EntityTypeConfigurations;

/// <summary>
/// Конфигурация сущности Employee для базы данных
/// </summary>
public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    /// <summary>
    /// Настраивает сущность Employee для Entity Framework
    /// </summary>
    /// <param name="builder">Построитель для конфигурации сущности</param>
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder
            .ToTable("employees");

        builder
            .HasKey(employee => employee.Id);

        builder
            .Property(employee => employee.Id)
            .HasColumnName("id");

        builder
            .Property(employee => employee.SurnameAndInitials)
            .HasColumnName("surname_and_initials")
            .IsRequired();

        builder
            .Property(employee => employee.SubdivisionName)
            .HasColumnName("subdivision_name")
            .IsRequired(false);

        builder
            .Property(employee => employee.Note)
            .HasColumnName("note")
            .IsRequired(false);

        builder
            .HasMany(employee => employee.Equipments)
            .WithOne(equipment => equipment.Employee)
            .HasForeignKey(equipment => equipment.EmployeeId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
    }
}