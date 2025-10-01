using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.Data.EntityTypeConfigurations;

public class FacilityConfiguration : IEntityTypeConfiguration<Facility>
{
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