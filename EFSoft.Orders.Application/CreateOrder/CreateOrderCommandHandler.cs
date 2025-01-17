namespace EFSoft.Orders.Application.CreateOrder;

public class CreateOrderCommandHandler(
    ICreateOrderRepository createOrderRepository,
    ICreateOrderProductRepository createOrderProductRepository,
    IServiceBus serviceBus) : ICommandHandler<CreateOrderCommand>
{
    public async Task Handle(
        CreateOrderCommand command,
        CancellationToken cancellationToken)
    {
        var order = OrderDomainModel.CreateNew(
            description: command.Description,
            customerId: command.CustomerId);

        //Insert a new order and new order product within the same db transaction
        await createOrderRepository.CreateOrderAsync(
            order,
            cancellationToken);

        var orderProducts = new List<OrderProductDomainModel>();

        foreach (var orderProduct in command.OrderProducts)
        {
            var newOrderProduct = OrderProductDomainModel.CreateNew(
                orderId: order.OrderId,
                productId: orderProduct.ProductId,
                quantity: orderProduct.Quantity);

            orderProducts.Add(newOrderProduct);
        }

        await createOrderProductRepository.CreateOrderProductAsync(
            orderProducts,
            cancellationToken);

        //foreach (var orderProduct in orderProducts)
        //{
        //    await serviceBus.SendToTopicAsync<OrderPlacedEvent>(
        //        message: new
        //        {
        //            command.CustomerId,
        //            orderProduct.ProductId,
        //            orderProduct.Quantity
        //        },
        //        topicName: TopicNames.Orders);
        //}
    }
}
