namespace EFSoft.Orders.Application.Queries.GetOrder;

public class GetOrderQueryValidator : AbstractValidator<GetOrderQuery>
{
    public GetOrderQueryValidator()
    {
        RuleFor(e => e.OrderId)
            .NotNull().WithMessage("OrderId cannot be null")
            .NotEmpty().WithMessage("OrderId cannot be empty");
    }
}
