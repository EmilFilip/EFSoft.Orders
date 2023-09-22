namespace EFSoft.Orders.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;

    }

    [HttpGet]
    [ProducesResponseType(typeof(GetOrderQueryResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get()
    {
        return Ok("The Orders Microservice is working fine");
    }

    [HttpGet]
    [Route("{orderId:guid}")]
    [ProducesResponseType(typeof(GetOrderQueryResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(Guid orderId)
    {
        var results = await _mediator.Send(new GetOrderQuery(orderId));

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
        var results = await _mediator.Send(new GetCustomerOrdersQuery(customerId));

        if (results == null)
        {
            return NotFound();
        }

        return Ok(results);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Post([FromBody] CreateOrderCommand parameters)
    {
        await _mediator.Send(parameters);

        return Ok();
    }

    [HttpPut()]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Put([FromBody] UpdateOrderCommand parameters)
    {
        await _mediator.Send(parameters);

        return Ok();
    }
}