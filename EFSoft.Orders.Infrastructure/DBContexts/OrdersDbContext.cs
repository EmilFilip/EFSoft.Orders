namespace EFSoft.Orders.Infrastructure.DBContexts;

public class OrdersDbContext : DbContext
{
    public OrdersDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderProduct> OrderProducts { get; set; }
}
