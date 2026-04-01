using ITP.LocationsApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITP.LocationsApi.Infrastructure.Persistence.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Address)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.City)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Phone)
                .HasMaxLength(20);

            builder.Property(x => x.Status)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(20);

            builder.HasMany<InspectionTimeSlot>()
                .WithOne(x => x.Location)
                .HasForeignKey(x => x.LocationId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed data
            builder.HasData(
                new Location
                {
                    Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234567890"),
                    Name = "ITP Bucuresti - Ozana",
                    Address = "Drumul Lunca Jariștei 39c, 032351 București",
                    City = "București",
                    Phone = "+40763649000",
                    Status = LocationStatus.Active
                },
                new Location
                {
                    Id = Guid.Parse("b2c3d4e5-f6a7-8901-bcde-f12345678901"),
                    Name = "ITP Bucuresti Ilioara",
                    Address = "Strada Ilioara 15, 077160 București",
                    City = "București",
                    Phone = "+0744329000",
                    Status = LocationStatus.Active
                }
            );
        }
    }
}
