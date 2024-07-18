using MediatR;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Application.Command.Workers.CreateWorkerCommand;
using Warehouse.Application.Command.Workers.DeleteWorker;
using Warehouse.Application.Command.Workers.UpdateWorker;
using Warehouse.Application.Queries.Workers.GetWorker;
using Warehouse.Application.Queries.Workers.ListWorkers;
using Warehouse.Contracts.Workers;

namespace Warehouse.Api.Controllers;
[Route("[controller]")]
[ApiController]
public class AdministratorController : ApiController
{
    private readonly ISender _mediator;

    public AdministratorController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("Worker")]
    public async Task<IActionResult> CreateWorker(
    CreateWorkerRequest request)
    {
        var _workerRole = ToDto(request.Role);

        var command = new CreateWorkerCommand(request.FirstName, request.LastName, _workerRole);

        var createWorkerResult = await _mediator.Send(command);

        return createWorkerResult.Match(
            worker => CreatedAtAction(
                nameof(GetWorker),
                new { WorkerId = worker.Id },
                new WorkerResponse(worker.Id, worker.FirstName, worker.LastName, worker.Role.ToString())),
            Problem);
    }

    [HttpGet("{workerId:guid}")]
    public async Task<IActionResult> GetWorker(Guid workerId)
    {
        var query = new GetWorkerQuery(workerId);

        var getWorkerResult = await _mediator.Send(query);

        return getWorkerResult.Match(
            worker => Ok(new WorkerResponse(
                worker.Id,
                worker.FirstName,
                worker.LastName,
                worker.Role.ToString())),
            Problem);
    }

    [HttpGet("Workers")]
    public async Task<IActionResult> ListWorkers()
    {
        var command = new ListWorkersQuery();

        var listWorkersResult = await _mediator.Send(command);

        return listWorkersResult.Match(
            workers => Ok(workers.ConvertAll(worker => new WorkerResponse(
                worker.Id,
                worker.FirstName,
                worker.LastName,
                worker.Role.ToString()))),
            Problem);
    }

    [HttpPut("Worker")]
    public async Task<IActionResult> UpdateWorker(UpdateWorkerRequest request)
    {
        var _workerRole = ToDto(request.Role);

        var command = new UpdateWorkerCommand(
                            request.Id,
                            request.FirstName,
                            request.LastName,
                            _workerRole);

        var updateWorkerResult = await _mediator.Send(command);

        return updateWorkerResult.Match(
                worker => Ok(new WorkerResponse(
                    worker.Id,
                    worker.FirstName,
                    worker.LastName,
                    worker.Role.ToString())),
            Problem);
    }

    [HttpDelete("{workerId:guid}")]
    public async Task<IActionResult> DeleteWorker(Guid workerId)
    {
        var command = new DeleteWorkerCommand(workerId);

        var deleteWorkerResult = await _mediator.Send(command);

        return deleteWorkerResult.Match(
            _ => NoContent(),
            Problem);
    }
    private static Domain.Workers.WorkerRole ToDto(Contracts.Workers.WorkerRole workerRole)
    {
        return workerRole switch
        {
            Contracts.Workers.WorkerRole.Admin => Domain.Workers.WorkerRole.Admin,
            Contracts.Workers.WorkerRole.Regular => Domain.Workers.WorkerRole.Regular,
            _ => throw new InvalidOperationException(),
        };
    }
}
