namespace EFSoft.Orders.Application.Commands.Parameters;

public class CreateOrderCommandParameters : ICommand
{
    public CreateOrderCommandParameters(
         Guid customerId,
         string description,
         IEnumerable<CreateOrderProductParameters> orderProducts)
    {
        CustomerId = customerId;
        Description = description;
        OrderProducts = orderProducts;
    }

    public Guid CustomerId { get; set; }

    public string Description { get; set; }
    public IEnumerable<CreateOrderProductParameters> OrderProducts { get; set; }
}
