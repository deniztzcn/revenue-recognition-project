using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RevenueRecognition.Models.Domain;

namespace RevenueRecognition.Data.Configurations;

public class CompanyClientConfiguration : IEntityTypeConfiguration<CompanyClient>
{
    public void Configure(EntityTypeBuilder<CompanyClient> builder)
    {
        builder.Property(cc => cc.CompanyName).IsRequired().HasMaxLength(100);
        builder.Property(cc => cc.KRS).IsRequired().HasMaxLength(10);
        
        builder.Property(cc => cc.KRS).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

        builder.Property(cc => cc.Address).IsRequired().HasMaxLength(100);
        builder.Property(cc => cc.Email).IsRequired().HasMaxLength(100);
        builder.Property(cc => cc.PhoneNumber).HasMaxLength(15);
        builder.Property(cc => cc.IsDeleted).HasDefaultValue(false);
        builder.Property(cc => cc.RowVersion).IsRowVersion();
    }
}