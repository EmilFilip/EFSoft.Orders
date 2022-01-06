namespace EFSoft.Orders.Domain.Models;

public class OrderProductModel
{
    public OrderProductModel(
         Guid orderProductId,
         Guid orderId,
         Guid productId,
         int quantity)
    {
        OrderProductId = orderProductId;
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
    }

    public static OrderProductModel CreateNew(
         Guid orderId,
         Guid productId,
         int quantity)
    {
        return new OrderProductModel(
            orderProductId: Guid.NewGuid(),
            orderId: orderId,
            productId: productId,
            quantity: quantity);
    }

    public void UpdateQuantity(
       int quantity)
    {
        Quantity = quantity;
    }

    public Guid OrderProductId { get; set; }

    public Guid OrderId { get; set; }

    public Guid ProductId { get; set; }

    public int Quantity { get; set; }
}
