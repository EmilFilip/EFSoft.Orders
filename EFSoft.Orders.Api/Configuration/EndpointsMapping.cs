namespace EFSoft.Orders.Api.Configuration;

public class EndpointsMapping : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/order").WithTags("Orders");

        _ = group.MapGet("{orderId:guid}", GetOrderEndpoint.Get);

        _ = group.MapGet("get-customer-orders/{customerId:guid}", GetCustomerOrdersEndpoint.GetCustomerOrders);

        _ = group.MapPost("", CreateOrderEndpoint.Post);

        _ = group.MapPut("", UpdateOrderEndpoint.Put);

        _ = group.MapPut("status", UpdateOrderStatusEndpoint.Put);
    }
}
