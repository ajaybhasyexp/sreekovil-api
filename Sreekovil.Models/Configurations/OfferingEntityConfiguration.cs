using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sreekovil.Models.Models;

namespace Sreekovil.Models.Configurations
{
    public class OfferingEntityConfiguration : IEntityTypeConfiguration<Offering>
    {
        public void Configure(EntityTypeBuilder<Offering> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Ignore(p => p.DeityName);
            builder.HasOne(p => p.Temple).WithMany(p => p.Offerings).HasForeignKey(p => p.TempleId);
        }
    }
}
