namespace EFSoft.Orders.Api.UpdateOrderStatus;

public class UpdateOrderStatusRequestValidator : AbstractValidator<UpdateOrderStatusRequest>
{
    public UpdateOrderStatusRequestValidator()
    {
        _ = RuleFor(e => e.OrderId)
            .Must(e => e == Guid.Empty).WithMessage("ProductId cannot be empty")
            .NotNull().WithMessage("ProductId cannot be null")
            .NotEmpty().WithMessage("ProductId cannot be empty");

        _ = RuleFor(e => e.OrderStatus).IsInEnum();
    }
}
