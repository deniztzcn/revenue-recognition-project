using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RevenueRecognition.Models.Domain;

namespace RevenueRecognition.Data.Configurations;

public class SoftwareLicenseConfiguration: IEntityTypeConfiguration<SoftwareLicense>
{
    public void Configure(EntityTypeBuilder<SoftwareLicense> builder)
    {
        builder.HasKey(sl => sl.SoftwareId);

        builder.Property(sl => sl.Category).HasMaxLength(100).IsRequired();
        builder.Property(sl => sl.Price).IsRequired();
        builder.Property(sl => sl.Name).HasMaxLength(100).IsRequired();
        builder.Property(sl => sl.Description).HasMaxLength(100).IsRequired();
    }
}