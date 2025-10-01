using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.Data.EntityTypeConfigurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
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
            .Property(employee => employee.LastName)
            .HasColumnName("last_name")
            .IsRequired();

        builder
            .Property(employee => employee.FirstName)
            .HasColumnName("first_name")
            .IsRequired();

        builder
            .Property(employee => employee.MiddleName)
            .HasColumnName("middle_name")
            .IsRequired(false);

        builder
            .HasMany(employee => employee.Equipments)
            .WithOne(equipment => equipment.Employee)
            .HasForeignKey(equipment => equipment.EmployeeId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
    }
}