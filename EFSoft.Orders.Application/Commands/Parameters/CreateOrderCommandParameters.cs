namespace EFSoft.Orders.Application.Commands.Parameters;

public class CreateOrderCommandParameters : ICommand
{
    public CreateOrderCommandParameters(
         Guid customerId,
         string Description,
         IEnumerable<OrderProductModel> orderProducts)
    {
        CustomerId = customerId;
        Description = Description;
        OrderProducts = orderProducts;
    }

    public Guid CustomerId { get; set; }

    public string Description { get; set; }
    public IEnumerable<OrderProductModel> OrderProducts { get; set; }
}
