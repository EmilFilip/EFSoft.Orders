namespace EFSoft.Orders.Application.Commands.Handlers;

public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommandParameters>
{
    private readonly IOrdersRepository _ordersRepository;
    private readonly IOrderProductsRepository _orderProductsRepository;
    private readonly IServiceBus _serviceBus;

    public CreateOrderCommandHandler(
        IOrdersRepository ordersRepository,
        IOrderProductsRepository orderProductsRepository,
        IServiceBus serviceBus)
    {
        _ordersRepository = ordersRepository ?? throw new ArgumentNullException(nameof(ordersRepository));
        _orderProductsRepository = orderProductsRepository ?? throw new ArgumentNullException(nameof(orderProductsRepository));
        _serviceBus = serviceBus ?? throw new ArgumentNullException(nameof(serviceBus));
    }

    public async Task HandleAsync(
        CreateOrderCommandParameters command)
    {
        var order = OrderModel.CreateNew(
            description: command.Description,
            customerId: command.CustomerId);

        await _ordersRepository.CreateOrderAsync(order);

        var orderProducts = new List<OrderProductModel>();

        foreach (var orderProduct in command.OrderProducts)
        {
            var newOrderProduct = OrderProductModel.CreateNew(
                orderId: order.OrderId,
                productId: orderProduct.ProductId,
                quantity: orderProduct.Quantity);

            orderProducts.Add(newOrderProduct);
        }

        await _orderProductsRepository.CreateOrderProductsAsync(orderProducts);

        foreach (var orderProduct in orderProducts)
        {
            await _serviceBus.SendToTopicAsync<OrderPlaced>(
                message: new
                {
                    CustomerId = command.CustomerId,
                    ProductId = orderProduct.ProductId,
                    Quantity = orderProduct.Quantity
                },
                topicName: TopicNames.Orders);
        }
    }
}
