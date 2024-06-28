using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RevenueRecognition.Models.Domain;

namespace RevenueRecognition.Data.Configurations;

public class PaymentConfiguration: IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(p => p.PaymentId);

        builder.Property(p => p.Amount).IsRequired();
        builder.Property(p => p.PaymentDate).IsRequired();
        builder.Property(p => p.IsFinalPayment).IsRequired();

        builder.HasOne(p => p.Contract)
            .WithMany(c => c.Payments)
            .HasForeignKey(p => p.ContractId);
        
    }
}