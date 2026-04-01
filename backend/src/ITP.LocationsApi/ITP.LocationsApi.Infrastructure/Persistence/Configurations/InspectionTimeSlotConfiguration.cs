using ITP.LocationsApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ITP.LocationsApi.Infrastructure.Persistence.Configurations
{
    public class InspectionTimeSlotConfiguration : IEntityTypeConfiguration<InspectionTimeSlot>
    {
        public void Configure(EntityTypeBuilder<InspectionTimeSlot> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.SlotStartTime).IsRequired();

            builder.Property(x => x.SlotEndTime).IsRequired();
        }
    }
}
