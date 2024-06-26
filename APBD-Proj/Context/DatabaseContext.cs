using APBD_Proj.Models;
using Microsoft.EntityFrameworkCore;


namespace APBD_Proj.Context;

public class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost;Database=master;User Id=SA;Password=yourStrong(!)Password;TrustServerCertificate=True;");
    }
    
    public DbSet<Customers> Customers { get; set; }
    public DbSet<Companies> Companies { get; set; }
    public DbSet<Contracts> Contracts { get; set; }
    public DbSet<Discounts> Discounts { get; set; }
    public DbSet<Payments> Payments { get; set; }
    public DbSet<Software> Softwares { get; set; }
    public DbSet<Subscriptions> Subscriptions { get; set; }
    public DbSet<SubscriptionsPayments> SubscriptionsPayments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    
    
}