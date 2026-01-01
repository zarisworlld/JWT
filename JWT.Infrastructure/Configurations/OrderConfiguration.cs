using JWT.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Infrastructure.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.PayablePrice)
                .HasPrecision(18, 2)
                .IsRequired();
            builder.Property(o => o.DiscountPrice)
                .HasPrecision(18, 2);
            builder.HasMany(o => o.OrderItems).WithOne(oi => oi.Order).HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
