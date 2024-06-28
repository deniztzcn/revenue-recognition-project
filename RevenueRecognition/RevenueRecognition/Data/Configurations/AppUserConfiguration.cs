using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RevenueRecognition.Models.Domain;

namespace RevenueRecognition.Data.Configurations;

public class AppUserConfiguration: IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.HasKey(u => u.IdUser);
        
        builder
            .Property(x => x.Username)
            .HasMaxLength(200)
            .IsRequired();
        
        builder
            .Property(x => x.Password)
            .HasMaxLength(200)
            .IsRequired();
        builder
            .Property(x => x.Type)
            .HasMaxLength(200)
            .IsRequired();
    }
}