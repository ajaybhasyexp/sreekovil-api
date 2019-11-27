using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sreekovil.Models.Models;

namespace Sreekovil.Models.Configurations
{
    public class StarSignEntityConfiguration : IEntityTypeConfiguration<StarSign>
    {
        public void Configure(EntityTypeBuilder<StarSign> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}
