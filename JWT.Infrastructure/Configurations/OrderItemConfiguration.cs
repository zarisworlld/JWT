using JWT.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Infrastructure.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItem");
            builder.HasOne(oi => oi.Order).WithMany().HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(oi => oi.Item).WithMany().HasForeignKey(oi => oi.ItemId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(oi => oi.SalesPrice)
                .HasPrecision(18, 2)
                .IsRequired();
            builder.Property(oi => oi.ItemDiscount)
                .HasPrecision(18, 2);

            builder.Property(oi => oi.Quantity)
                .HasColumnType("int")
                .IsRequired();
        }
    }
}
