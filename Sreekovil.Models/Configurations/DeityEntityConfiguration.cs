using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sreekovil.Models.Models;

namespace Sreekovil.Models.Configurations
{
    public class DeityEntityConfiguration : IEntityTypeConfiguration<Deity>
    {
        public void Configure(EntityTypeBuilder<Deity> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Temple).WithMany(p => p.Deities).HasForeignKey(p => p.TempleId);
        }
    }
}
