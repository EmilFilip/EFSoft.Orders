namespace EFSoft.Orders.Domain.Models;

public class OrderProductDomainModel
{
    public OrderProductDomainModel(
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

    public OrderProductDomainModel(
         Guid orderId,
         Guid productId,
         int quantity)
    {
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
    }

    public static OrderProductDomainModel CreateNew(
         Guid orderId,
         Guid productId,
         int quantity)
    {
        return new OrderProductDomainModel(
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
