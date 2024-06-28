using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RevenueRecognition.Models.Domain;

namespace RevenueRecognition.Data.Configurations;

public class DiscountConfiguration: IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {
        builder.HasKey(d => d.DiscountId);

        builder.Property(d => d.Description).HasMaxLength(100).IsRequired();
        builder.Property(d => d.DiscountValue).IsRequired();
        builder.Property(d => d.StartDate).IsRequired();
        builder.Property(d => d.EndDate).IsRequired();
    }
}