using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sreekovil.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sreekovil.Models.Configurations
{
    public class OfferingPreBookingEntityConfiguration : IEntityTypeConfiguration<OfferingPreBooking>
    {
        public void Configure(EntityTypeBuilder<OfferingPreBooking> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Temple).WithMany(p => p.OfferingPreBookings).HasForeignKey(p => p.TempleId);
            builder.HasOne(p => p.Offering).WithMany(p => p.OfferingPreBookings).HasForeignKey(p => p.OfferingId);
        }
    }
}
