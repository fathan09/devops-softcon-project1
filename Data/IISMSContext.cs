using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using IISMSBackend.Entities;

namespace IISMSBackend.Data;

public class IISMSContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public IISMSContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Sales> Sales { get; set; }
    public DbSet<SalesProduct> SalesProduct { get; set; }
    public DbSet<Inventory> Inventory { get; set; }
    public DbSet <Order> Orders {get; set;}
}