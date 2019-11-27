using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sreekovil.Models.Models;

namespace Sreekovil.Models.Configurations
{
    public class OfferingTransactionEntityConfiguration : IEntityTypeConfiguration<OfferingTransaction>
    {
        public void Configure(EntityTypeBuilder<OfferingTransaction> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Temple).WithMany(p => p.OfferingTransactions).HasForeignKey(p => p.TempleId);
            builder.Ignore(p => p.OfferingName).Ignore(p => p.StarSignName).Ignore(p => p.DeityName);
            builder.HasOne(p => p.Offering).WithMany(p => p.OfferingTransactions).HasForeignKey(p => p.OfferingId);
        }
    }
}
