using MediatR;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Application.Command.WarehouseRacks.CreateWarehouseRack;
using Warehouse.Application.Command.WarehouseRacks.DeleteWarehouseRack;
using Warehouse.Application.Command.WarehouseRacks.UpdateWarehouseRack;
using Warehouse.Application.Queries.WarehouseRacks.GetWarehouseRack;
using Warehouse.Application.Queries.WarehouseRacks.ListWarehouseRacks;
using Warehouse.Contracts.WarehousesRacks;

namespace Warehouse.Api.Controllers;
[Route("[controller]")]
[ApiController]
public class WarehouseRacksController : ApiController 
{
    private readonly ISender _mediator;
    
    public WarehouseRacksController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("WarehouseRack")]
    public async Task<IActionResult> CreateWarehouseRack(
        CreateWarehouseRackRequest request)
    {
        var command = new CreateWarehouseRackCommand(request.Sector, request.Rack, request.Quantity, request.WarehouseSizeId);

        var createWarehouseRackResult = await _mediator.Send(command);

        return createWarehouseRackResult.Match(
            warehouseRack => CreatedAtAction(
                nameof(GetWarehouseRack),
                new { WarehouseRackId = warehouseRack.Id },
                new WarehouseRackResponse(
                    warehouseRack.Id,
                    warehouseRack.Sector,
                    warehouseRack.Rack,
                    warehouseRack.Quantity,
                    warehouseRack.WarehouseSizeId)),
            Problem);
    }

    [HttpGet("{warehouseRackId:guid}")]
    public async Task<IActionResult> GetWarehouseRack(Guid warehouseRackId)
    {
        var query = new GetWarehouseRackQuery(warehouseRackId);

        var getWarehouseRackResult = await _mediator.Send(query);

        return getWarehouseRackResult.Match(
            warehouseRack => Ok(new WarehouseRackResponse(
                warehouseRack.Id,
                warehouseRack.Sector,
                warehouseRack.Rack,
                warehouseRack.Quantity,
                warehouseRack.WarehouseSizeId)),
            Problem);
    }
    
    [HttpGet("WarehouseRacks")]
    public async Task<IActionResult> ListWarehouseRacksWarehouseRacks()
    {
        var command = new ListWarehouseRacksQuery();

        var listWarehouseRacksResult = await _mediator.Send(command);

        return listWarehouseRacksResult.Match(
            warehouseRacks => Ok(warehouseRacks.ConvertAll(warehouseRack => new WarehouseRackResponse(
                warehouseRack.Id,
                warehouseRack.Sector,
                warehouseRack.Rack,
                warehouseRack.Quantity,
                warehouseRack.WarehouseSizeId))),
            Problem);
    }

    [HttpPut("WarehouseRack")]
    public async Task<IActionResult> UpdateWarehouseRack(UpdateWarehouseRackRequest request)
    {
        var command = new UpdateWarehouseRackCommand(
            request.Id,
            request.Sector,
            request.Rack,
            request.Quantity,
            request.WarehouseSizeId);

        var updateWarehouseRackResult = await _mediator.Send(command);

        return updateWarehouseRackResult.Match(
            warehouseRack => Ok(new WarehouseRackResponse(
                warehouseRack.Id,
                warehouseRack.Sector,
                warehouseRack.Rack,
                warehouseRack.Quantity,
                warehouseRack.WarehouseSizeId)),
            Problem);
    }

    [HttpDelete("{WarehouseRackId:guid}")]
    public async Task<IActionResult> DeleteWarehouseRack(Guid WarehouseRackId)
    {
        var command = new DeleteWarehouseRackCommand(WarehouseRackId);

        var deleteWarehouseRackResult = await _mediator.Send(command);

        return deleteWarehouseRackResult.Match(
            _ => NoContent(),
            Problem);
    }
}