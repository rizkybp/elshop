using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CoreApplication.Entities;

namespace Infrastucture.Configurations
{
    class TransaksiNasabahConfiguration : IEntityTypeConfiguration<TransaksiNasabah>
    {
        public void Configure(EntityTypeBuilder<TransaksiNasabah> builder)
        {
            builder
                .HasKey(e => e.Id);
            builder
                .Property(e => e.Id)
                .UseIdentityColumn();

            builder
                .HasOne(e => e.Nasabah)
                .WithMany()
                .HasForeignKey(d => d.NasabahId);
        }
    }
}
