using MediatR;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Application.Command.Transactions.CreateTransactionCommand;
using Warehouse.Application.Command.Transactions.DeleteTransactionCommand;
using Warehouse.Application.Command.Transactions.UpdateTransactionCommand;
using Warehouse.Application.Queries.Transactions.GetTransaction;
using Warehouse.Application.Queries.Transactions.ListTransactions;
using Warehouse.Contracts.Transactions;

namespace Warehouse.Api.Controllers;
[Route("[controller]")]
[ApiController]
public class TransactionsController : ApiController
{
    private readonly ISender _mediator;

    public TransactionsController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTransaction(
       CreateTransactionRequest request)
    {
        var _transactionType = ToDto(request.TransactionType);

        var command = new CreateTransactionCommand(
                            request.ProductId,
                            request.TransactionQuantity,
                            _transactionType,
                            request.Date,
                            request.WarehouseSizeId,
                            request.Sector,
                            request.Rack,
                            request.WorkerId);

        var createTransactionResult = await _mediator.Send(command);

        return createTransactionResult.Match(
            transaction => CreatedAtAction(
                nameof(GetTransaction),
                new { TransactionId = transaction.Id },
                new CommandTransactionResponse(
                    transaction.Id,
                    transaction.ProductId,
                    transaction.Quantity,
                    transaction.Type.ToString(),
                    transaction.Date,
                    transaction.WarehouseRackId,
                    transaction.WorkerId)),
            Problem);
    }

    [HttpGet("{TransactionId:guid}")]
    public async Task<IActionResult> GetTransaction(Guid TransactionId)
    {
        var query = new GetTransactionQuery(TransactionId);

        var getTransactionResult = await _mediator.Send(query);

        return getTransactionResult.Match(
            transaction => Ok(new QueryTransactionResponse(
                    transaction.Id,
                    transaction.Products.Name,
                    transaction.Products.Type.ToString(),
                    transaction.Products.Id,
                    transaction.Quantity,
                    transaction.Type.ToString(),
                    transaction.Date,
                    transaction.WarehouseRacks.WarehousesSize.Name,
                    transaction.WarehouseRacks.Sector,
                    transaction.WarehouseRacks.Rack,
                    transaction.Workers.FirstName,
                    transaction.Workers.LastName,
                    transaction.Workers.Role.ToString(),
                    transaction.Workers.Id)),
            Problem);
    }

    [HttpGet]
    public async Task<IActionResult> ListTransactions()
    {
        var command = new ListTransactionsQuery();

        var listTransactionsResult = await _mediator.Send(command);

        return listTransactionsResult.Match(
            transactions => Ok(transactions.ConvertAll(transaction => new QueryTransactionResponse(
                    transaction.Id,
                    transaction.Products.Name,
                    transaction.Products.Type.ToString(),
                    transaction.Products.Id,
                    transaction.Quantity,
                    transaction.Type.ToString(),
                    transaction.Date,
                    transaction.WarehouseRacks.WarehousesSize.Name,
                    transaction.WarehouseRacks.Sector,
                    transaction.WarehouseRacks.Rack,
                    transaction.Workers.FirstName,
                    transaction.Workers.LastName,
                    transaction.Workers.Role.ToString(),
                    transaction.Workers.Id))),
            Problem);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTransaction(UpdateTransactionRequest request)
    {
        var _transactionType = ToDto(request.TransactionType);

        var command = new UpdateTransactionCommand(
                            request.TransactionId,
                            request.ProductId,
                            request.TransactionQuantity,
                            _transactionType,
                            request.Date,
                            request.WarehouseSizeId,
                            request.WarehouseRackId,
                            request.Sector,
                            request.Rack,
                            request.WorkerId);

        var updateTransactionResult = await _mediator.Send(command);

        return updateTransactionResult.Match(
                transaction => Ok(new CommandTransactionResponse(
                    transaction.Id,
                    transaction.ProductId,
                    transaction.Quantity,
                    transaction.Type.ToString(),
                    transaction.Date,
                    transaction.WarehouseRackId,
                    transaction.WorkerId)),
            Problem);
    }

    [HttpDelete("{TransactionId:guid}")]
    public async Task<IActionResult> DeleteTransaction(Guid TransactionId)
    {
        var command = new DeleteTransactionCommand(TransactionId);

        var deleteTransactionResult = await _mediator.Send(command);

        return deleteTransactionResult.Match(
            _ => NoContent(),
            Problem);
    }
    private static Domain.Transactions.TransactionType ToDto(Contracts.Transactions.TransactionType transactionType)
    {
        return transactionType switch
        {
            Contracts.Transactions.TransactionType.In => Domain.Transactions.TransactionType.In,
            Contracts.Transactions.TransactionType.Out => Domain.Transactions.TransactionType.Out,
            _ => throw new InvalidOperationException(),
        };
    }
}
