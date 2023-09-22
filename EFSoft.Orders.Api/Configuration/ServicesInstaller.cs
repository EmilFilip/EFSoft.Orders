namespace EFSoft.Orders.Api.Configuration;

[ExcludeFromCodeCoverage]
public static class ServicesInstaller
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
                    options.UseSqlServer(configuration.GetConnectionString("OrdersConnectionString"), sqlServeroptions =>
                    {
                        sqlServeroptions.EnableRetryOnFailure();
                    });
                })
             .AddScoped<IOrdersRepository, OrdersRepository>()
             .AddScoped<IOrderProductsRepository, OrderProductsRepository>();
    }
}
