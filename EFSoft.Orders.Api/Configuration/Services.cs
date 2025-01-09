namespace EFSoft.Orders.Api.Configuration;

[ExcludeFromCodeCoverage]
public static class Services
{
    public static IServiceCollection RegisterLocalServices(
                    this IServiceCollection services,
                    IConfiguration configuration)
    {
        return services
             .RegisterCqrs(typeof(GetOrderQuery).Assembly)
             .AddServiceBus()
             .AddDbContext<OrdersDbContext>(
                options =>
                {
                    _ = options.UseSqlServer(configuration.GetConnectionString("OrdersConnectionString"), sqlServeroptions =>
                    {
                        _ = sqlServeroptions.EnableRetryOnFailure();
                    });
                })
             .AddScoped<ICreateOrderProductRepository, CreateOrderProductRepository>()
             .AddScoped<ICreateOrderRepository, CreateOrderRepository>()
             .AddScoped<IGetCustomerOrdersRepository, GetCustomerOrdersRepository>()
             .AddScoped<IGetOrderProductsForOrderRepository, GetOrderProductsForOrderRepository>()
             .AddScoped<IGetOrderRepository, GetOrderRepository>()
             .AddScoped<IUpdateOrderProductsRepository, UpdateOrderProductsRepository>()
             .AddScoped<IUpdateOrderRepository, UpdateOrderRepository>()
             .AddScoped<IUpdateOrderStatusRepository, UpdateOrderStatusRepository>();
    }
}
