using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RevenueRecognition.Models.Domain;

namespace RevenueRecognition.Data.Configurations;

public class SoftwareVersionConfiguration: IEntityTypeConfiguration<SoftwareVersion>
{
    public void Configure(EntityTypeBuilder<SoftwareVersion> builder)
    {
        builder.HasKey(sv => sv.SoftwareLicenseId);

        builder.Property(sv => sv.Version).HasMaxLength(100).IsRequired();
        builder.Property(sv => sv.ReleaseNotes).HasMaxLength(100).IsRequired();
        builder.Property(sv => sv.ReleaseDate).IsRequired();

        builder.HasOne(sv => sv.SoftwareLicense)
            .WithMany(sl => sl.SoftwareVersions)
            .HasForeignKey(sv => sv.SoftwareLicenseId);


    }
}