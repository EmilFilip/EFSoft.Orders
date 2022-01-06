namespace EFSoft.Orders.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly ICommandExecutor _commandExecutor;
    private readonly IQueryExecutor _queryExecutor;

    public OrderController(
            ICommandExecutor commandExecutor,
            IQueryExecutor queryExecutor)
    {
        _commandExecutor = commandExecutor
            ?? throw new ArgumentNullException(nameof(commandExecutor));
        _queryExecutor = queryExecutor
            ?? throw new ArgumentNullException(nameof(queryExecutor));

    }

    [HttpGet]
    [Route("{orderId:guid}")]
    [ProducesResponseType(typeof(GetOrderQueryResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(Guid orderId)
    {
        var results = await _queryExecutor.ExecuteAsync<GetOrderQueryParameters, GetOrderQueryResult>(
         new GetOrderQueryParameters(orderId));

        if (results == null)
        {
            return NotFound();
        }

        return Ok(results);
    }

    [HttpGet]
    [Route("{customerId:guid}")]
    [ProducesResponseType(typeof(GetCustomerOrdersQueryResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCustomerOrders(Guid customerId)
    {
        var results = await _queryExecutor.ExecuteAsync<GetCustomerOrdersQueryParameters, GetCustomerOrdersQueryResult>(
         new GetCustomerOrdersQueryParameters(customerId));

        if (results == null)
        {
            return NotFound();
        }

        return Ok(results);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Post([FromBody] CreateOrderCommandParameters parameters)
    {
        await _commandExecutor.ExecuteAsync(parameters);

        return Ok();
    }

    [HttpPut()]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Put([FromBody] UpdateOrderCommandParameters parameters)
    {
        await _commandExecutor.ExecuteAsync(parameters);

        return Ok();
    }
}