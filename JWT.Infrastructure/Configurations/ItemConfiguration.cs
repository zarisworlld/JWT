using JWT.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Infrastructure.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Title)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(i => i.Price)
                .HasPrecision(18, 2)
                .IsRequired();
        }
    }
}
