namespace EFSoft.Orders.Application.Commands.UpdateOrder;

public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(e => e.CustomerId)
            .NotNull().WithMessage("CustomerId cannot be null")
            .NotEmpty().WithMessage("CustomerId cannot be empty");
        RuleFor(e => e.OrderId)
            .NotNull().WithMessage("OrderId cannot be null")
            .NotEmpty().WithMessage("OrderId cannot be empty");
    }
}
