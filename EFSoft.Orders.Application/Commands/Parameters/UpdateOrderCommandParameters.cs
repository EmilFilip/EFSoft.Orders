namespace EFSoft.Orders.Application.Commands.Parameters;

public class UpdateOrderCommandParameters : ICommand
{
    public UpdateOrderCommandParameters(
         Guid orderId,
         Guid customerId,
         string description,
         OrderStatus orderStatus,
         IEnumerable<OrderProductModel> orderProducts)
    {
        OrderId = orderId;
        CustomerId = customerId;
        Description = description;
        OrderStatus = orderStatus;
        OrderProducts = orderProducts;
    }

    public Guid OrderId { get; set; }

    public Guid CustomerId { get; set; }

    public string Description { get; set; }

    public OrderStatus OrderStatus { get; set; }

    public IEnumerable<OrderProductModel> OrderProducts { get; set; }
}
