using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RevenueRecognition.Models.Domain;

namespace RevenueRecognition.Data.Configurations;

public class IndividualClientConfiguration : IEntityTypeConfiguration<IndividualClient>
{
    
    public void Configure(EntityTypeBuilder<IndividualClient> builder)
    {
        builder.Property(ic => ic.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(ic => ic.LastName).IsRequired().HasMaxLength(50);
        builder.Property(ic => ic.PESEL).IsRequired().HasMaxLength(11);
        
        builder.Property(ic => ic.PESEL).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

        builder.Property(ic => ic.Address).IsRequired().HasMaxLength(100);
        builder.Property(ic => ic.Email).IsRequired();
        builder.Property(ic => ic.PhoneNumber).IsRequired();
        builder.Property(ic => ic.IsDeleted).HasDefaultValue(false);
        builder.Property(ic => ic.RowVersion).IsRowVersion();
    }
}