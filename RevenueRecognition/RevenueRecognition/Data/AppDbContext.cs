using Microsoft.EntityFrameworkCore;
using RevenueRecognition.Models.Domain;

namespace RevenueRecognition.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<IndividualClient> IndividualClients { get; set; }
    public DbSet<CompanyClient> CompanyClients { get; set; }
    public DbSet<SoftwareLicense> SoftwareLicenses { get; set; }
    public DbSet<SoftwareVersion> SoftwareVersions { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<AppUser> AppUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>()
            .HasKey(c => c.ClientId);
        
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Client>()
            .HasDiscriminator<string>("ClientType")
            .HasValue<IndividualClient>("Individual")
            .HasValue<CompanyClient>("Company");
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}