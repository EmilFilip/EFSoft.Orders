namespace EFSoft.Orders.Application.Commands.Parameters;

public class CreateOrderProductParameters
{
    public CreateOrderProductParameters(
         Guid productId,
         int quantity)
    {
        ProductId = productId;
        Quantity = quantity;
    }

    public Guid ProductId { get; set; }

    public int Quantity { get; set; }
}
