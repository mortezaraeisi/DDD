using Microsoft.EntityFrameworkCore;
using OrderProduct.Domain.Entities.Customers;
using OrderProduct.Domain.Entities.Orders;
using OrderProduct.Domain.Entities.Products;

namespace OrderProduct.Persistence.Contexts;

public class OrderProductDbContext : DbContext
{
    public DbSet<Customer> Customers { set; get; } = default!;
    public DbSet<Order> Orders { set; get; } = default!;
    public DbSet<OrderItem> OrderItems { set; get; } = default!;
    public DbSet<Product> Products { set; get; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderProductDbContext).Assembly);
    }
}