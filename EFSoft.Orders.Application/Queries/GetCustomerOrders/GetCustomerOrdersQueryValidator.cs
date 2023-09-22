namespace EFSoft.Orders.Application.Queries.GetCustomerOrders;

public class GetCustomerOrdersQueryValidator : AbstractValidator<GetCustomerOrdersQuery>
{
    public GetCustomerOrdersQueryValidator()
    {
        RuleFor(e => e.CustomerId)
            .NotNull().WithMessage("CustomerId cannot be null")
            .NotEmpty().WithMessage("CustomerId cannot be empty");
    }
}
