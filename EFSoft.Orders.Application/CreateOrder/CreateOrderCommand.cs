namespace EFSoft.Orders.Application.CreateOrder;

public sealed record CreateOrderCommand(
         Guid CustomerId,
         string Description,
         IEnumerable<OrderCreateDto> OrderProducts) : ICommand;
