using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RevenueRecognition.Models.Domain;

namespace RevenueRecognition.Data.Configurations;

public class ContractConfiguration: IEntityTypeConfiguration<Contract>
{
    public void Configure(EntityTypeBuilder<Contract> builder)
    {
        builder.HasKey(c => c.ContractId);

        builder.Property(c => c.DiscountId);
        builder.Property(c => c.Price).IsRequired();
        builder.Property(c => c.IsSigned).IsRequired();
        builder.Property(c => c.PaymentStartDate).IsRequired();
        builder.Property(c => c.PaymentEndDate).IsRequired();
        builder.Property(c => c.AdditionalSupportEndDate);
        builder.Property(c => c.ContractStartDate).IsRequired();
        builder.Property(c => c.ContractEndDate).IsRequired();

        builder.HasOne(c => c.Client)
            .WithMany(c => c.Contracts)
            .HasForeignKey(c => c.ClientId);
        builder.HasOne(c => c.Discount)
            .WithMany(d => d.Contracts)
            .HasForeignKey(c => c.DiscountId);
        builder.HasOne(c => c.SoftwareLicense)
            .WithMany(sl => sl.Contracts)
            .HasForeignKey(c => c.SoftwareId);

    }
}