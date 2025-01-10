namespace EFSoft.Orders.Domain.Models;

public class OrderDomainModel
{
    public OrderDomainModel(Guid orderId)
    {
        OrderId = orderId;
    }

    public OrderDomainModel(
        Guid orderId,
        string description)
    {
        OrderId = orderId;
        Description = description;
    }

    public OrderDomainModel(
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

    public static OrderDomainModel CreateNew(
        string description,
        Guid customerId)
    {
        return new OrderDomainModel(
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
        List<OrderProductDomainModel> orderProducts)
    {
        OrderProducts = orderProducts;
    }

    public Guid OrderId { get; set; }

    public Guid CustomerId { get; set; }

    public string Description { get; set; }

    public OrderStatus OrderStatus { get; set; }

    public IEnumerable<OrderProductDomainModel> OrderProducts { get; set; }
}
