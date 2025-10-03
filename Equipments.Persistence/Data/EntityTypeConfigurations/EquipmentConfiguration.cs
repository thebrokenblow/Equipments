using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.Data.EntityTypeConfigurations;

public class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
{
    public void Configure(EntityTypeBuilder<Equipment> builder)
    {
        builder
            .ToTable("equipments");

        builder
            .HasKey(equipment => equipment.Id);

        builder
            .HasIndex(equipment => equipment.Id)
            .IsUnique();

        builder
            .Property(equipment => equipment.Id)
            .HasColumnName("id");

        builder
            .Property(equipment => equipment.SerialNumber)
            .HasColumnName("serial_number")
            .IsRequired();

        builder
            .Property(equipment => equipment.CabinetNumber)
            .HasColumnName("cabinet_number")
            .IsRequired();

        builder
            .Property(equipment => equipment.TypeEquipmentId)
            .HasColumnName("type_equipment_id")
            .IsRequired();

        builder
            .Property(equipment => equipment.EmployeeId)
            .HasColumnName("employee_id")
            .IsRequired(false);

        builder
            .Property(equipment => equipment.ConclusionSpecialProject)
            .HasColumnName("conclusion_special_project")
            .IsRequired(false);

        builder
            .Property(equipment => equipment.ConclusionSpecResearch)
            .HasColumnName("conclusion_spec_research")
            .IsRequired(false);

        builder
            .Property(equipment => equipment.Note)
            .HasColumnName("note")
            .IsRequired(false);

        builder
            .Property(equipment => equipment.FacilityId)
            .HasColumnName("facility_id")
            .IsRequired();

        builder
            .HasOne(equipment => equipment.TypeEquipment)
            .WithMany(typeEquipment => typeEquipment.Equipments)
            .HasForeignKey(equipment => equipment.TypeEquipmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(equipment => equipment.Employee)
            .WithMany(employee => employee.Equipments)
            .HasForeignKey(equipment => equipment.EmployeeId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

        builder
            .HasOne(equipment => equipment.Facility)
            .WithMany(facility => facility.Equipment)
            .HasForeignKey(equipment => equipment.FacilityId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}