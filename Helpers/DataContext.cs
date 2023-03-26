namespace backend.Helpers;

using Microsoft.EntityFrameworkCore;
using backend.Entities;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to mysql with connection string from app settings
        var connectionString = Configuration.GetConnectionString("WebApiDatabase");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Address> Address { get; set; }
    public DbSet<ComputerModel> ComputerModel { get; set; }
    public DbSet<Configuration> ItemConfiguration { get; set; }
    public DbSet<DefaultConfiguration> DefaultConfiguration { get; set; }
    public DbSet<Item> Item { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<OrderItem> OrderItem { get; set; }
    public DbSet<Payment> Payment { get; set; }
    public DbSet<Series> Series { get; set; }


}