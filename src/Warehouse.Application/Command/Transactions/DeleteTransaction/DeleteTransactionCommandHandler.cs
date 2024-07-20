using ErrorOr;
using MediatR;
using Warehouse.Application.Common;

namespace Warehouse.Application.Command.Transactions.DeleteTransactionCommand;
public class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand, ErrorOr<Deleted>>
{
    private readonly ITransactionsRepository _transactionsRepository;
    private readonly IWarehouseRacksRepository _warehouseRacksRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTransactionCommandHandler(ITransactionsRepository transactionsRepository, IWarehouseRacksRepository warehouseRacksRepository, IUnitOfWork unitOfWork)
    {
        _transactionsRepository = transactionsRepository;
        _warehouseRacksRepository = warehouseRacksRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Deleted>> Handle(DeleteTransactionCommand command, CancellationToken cancellationToken)
    {
        var transaction = await _transactionsRepository.GetByIdAsync(command.Id);

        if (transaction is null)
        {
            return Error.NotFound(description: "Transaction not found");
        }

        var warehouseRack = await _warehouseRacksRepository.GetByIdAsync(command.Id);

        if (warehouseRack is null)
        {
            return Error.NotFound(description: "WarehouseRack not found");
        }

        await _transactionsRepository.RemoveTransactionAsync(transaction);
        await _warehouseRacksRepository.RemoveWarehouseRackAsync(warehouseRack);
        await _unitOfWork.CommitChangesAsync();

        return Result.Deleted;
    }
}