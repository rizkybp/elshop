using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CoreApplication.Entities;

namespace Infrastucture.Configurations
{
   public  class NasabahConfiguration : IEntityTypeConfiguration<Nasabah>
    {
        public void Configure(EntityTypeBuilder<Nasabah> builder)
        {
            builder
                .HasKey(e => e.id);
            builder
                .Property(e => e.id)
                .UseIdentityColumn();
            
                
            
        }
    }
}
