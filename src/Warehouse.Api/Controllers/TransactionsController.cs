using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Warehouse.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TransactionsController : ApiController
{
    private readonly ISender _mediator;

    public TransactionsController(ISender mediator)
    {
        _mediator = mediator;
    }
}
