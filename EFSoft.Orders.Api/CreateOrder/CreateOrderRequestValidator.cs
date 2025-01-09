namespace EFSoft.Orders.Api.CreateOrder;

public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
{
    public CreateOrderRequestValidator()
    {
        _ = RuleFor(e => e.CustomerId)
            .Must(e => e == Guid.Empty).WithMessage("CustomerId cannot be empty")
            .NotNull().WithMessage("CustomerId cannot be null")
            .NotEmpty().WithMessage("CustomerId cannot be empty");

        _ = RuleFor(e => e.Description)
            .NotNull().WithMessage("Description cannot be null")
            .NotEmpty().WithMessage("Description cannot be empty");

        _ = RuleFor(e => e.OrderProducts)
            .Must(collection => collection?.Count() == 0)
            .WithMessage("OrderProducts cannot be null")
            .Must(collection => collection == null)
            .WithMessage("Please specify at least one OrderProduct");
    }
}
