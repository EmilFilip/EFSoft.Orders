namespace EFSoft.Orders.Application.Commands.CreateOrder;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(e => e.CustomerId)
            .NotNull().WithMessage("CustomerId cannot be null")
            .NotEmpty().WithMessage("CustomerId cannot be empty");
        RuleFor(e => e.OrderProducts)
            .Must(collection => collection == null || collection.All(item => !string.IsNullOrEmpty(item.ToString())))
            .WithMessage("Please specify at least one OrderProduct");
    }
}
