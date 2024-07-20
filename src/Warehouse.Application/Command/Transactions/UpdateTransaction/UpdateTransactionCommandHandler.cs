using ErrorOr;
using MediatR;
using Warehouse.Application.Common;
using Warehouse.Domain.Transactions;
using Warehouse.Domain.Warehouses;

namespace Warehouse.Application.Command.Transactions.UpdateTransactionCommand;
public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand, ErrorOr<Transaction>>
{
    private readonly ITransactionsRepository _transactionsRepository;
    private readonly IWarehouseRacksRepository _warehouseRacksRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTransactionCommandHandler(ITransactionsRepository transactionsRepository, IWarehouseRacksRepository warehouseRacksRepository, IUnitOfWork unitOfWork)
    {
        _transactionsRepository = transactionsRepository;
        _warehouseRacksRepository = warehouseRacksRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Transaction>> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
    {
        var warehouseRack = new WarehouseRack(
            id: request.WarehouseRackId,
            sector: request.Sector,
            rack: request.Rack,
            quantity: request.TransactionQuantity,
            warehouseSizeId: request.WarehouseSizeId);

        var transaction = new Transaction(
            id: request.TransactionId,
            quantity: request.TransactionQuantity,
            type: request.TransactionType,
            date: request.Date,
            productId: request.ProductId,
            warehouseRackId: warehouseRack.Id,
            workerId: request.WorkerId);

        await _transactionsRepository.UpdateTransactionAsync(transaction);
        await _warehouseRacksRepository.UpdateWarehouseRackAsync(warehouseRack);
        await _unitOfWork.CommitChangesAsync();

        return transaction;
    }
}

