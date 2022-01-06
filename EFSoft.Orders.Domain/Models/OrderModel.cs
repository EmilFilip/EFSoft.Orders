namespace EFSoft.Orders.Domain.Models;

public class OrderModel
{
    public OrderModel(
        Guid orderId,
        Guid customerId,
        string description,
        OrderStatus orderStatus)
    {
        OrderId = orderId;
        CustomerId = customerId;
        Description = description;
        OrderStatus = orderStatus;
    }

    public static OrderModel CreateNew(
        string description,
        Guid customerId)
    {
        return new OrderModel(
            orderId: Guid.NewGuid(),
            customerId: customerId,
            description: description,
            orderStatus: OrderStatus.Open);
    }

    public void SetOrderStatus(
        OrderStatus orderStatus)
    {
        OrderStatus = orderStatus;
    }

    public void Update(
        string description)
    {
        Description = description;
    }

    public void LoadOrderProducts(
        List<OrderProductModel> orderProducts)
    {
        OrderProducts = orderProducts;
    }

    public Guid OrderId { get; set; }

    public Guid CustomerId { get; set; }

    public string Description { get; set; }

    public OrderStatus OrderStatus { get; set; }

    public List<OrderProductModel> OrderProducts { get; set; }
}
