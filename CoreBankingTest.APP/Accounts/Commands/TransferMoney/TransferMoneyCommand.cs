using CoreBankingTest.APP.Common.Interfaces;
using CoreBankingTest.APP.Common.Models;
using CoreBankingTest.Core.Interfaces;
using CoreBankingTest.Core.ValueObjects;
using CoreBankingTest.CORE.Interfaces;
using MediatR;

namespace CoreBankingTest.APP.Accounts.Commands.CreateAccount;

public record TransferMoneyCommand : ICommand<Guid>
{
    public AccountNumber SourceAccountNumber { get; init; } = new AccountNumber(string.Empty);
    public AccountNumber DestinationAccountNumber { get; init; } = new AccountNumber(string.Empty);
    public Money Amount { get; init; } = new Money(0, "NGN");
    public string Currency { get; init; } = "NGN";
    public string Reference { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
}

public class TransaferMoneyCommandHandler : IRequestHandler<TransferMoneyCommand, Result>
{
    private readonly IAccountRepository _accountRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TransaferMoneyCommandHandler(
    IAccountRepository accountRepository,
    ITransactionRepository transactionRepository,
    IUnitOfWork unitOfWork)
    {
        _accountRepository = accountRepository;
        _transactionRepository = transactionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(TransferMoneyCommand request, CancellationToken cancellationToken)
    {

        try
        {
            //Find Source and Destination Accounts
            var sourceAccount = await _accountRepository.GetByAccountNumberAsync(new AccountNumber(request.SourceAccountNumber));
            var destAccount = await _accountRepository.GetByAccountNumberAsync(new AccountNumber(request.DestinationAccountNumber));

            if (sourceAccount == null) return Result.Failure("Source account not found");
            if (destAccount == null) return Result.Failure("Destination account not found");

            //Execute Transafer using domain logic - this will now throw exceptions

            sourceAccount.Transfer(
                amount: request.Amount,
                destination: destAccount,
                reference: request.Reference,
                description: request.Description
                );

            //save changes
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
        catch (InvalidOperationException ex)
        {
            //Handle domain business rule violations
            return Result.Failure(ex.Message);

        }
        catch (ArgumentException ex)
        {
            //Handle argument validation errors
            return Result.Failure(ex.Message);
        }
        catch (Exception ex)
        {
            return Result.Failure($"An unexpected error occured: {ex.Message}");
        }
    }
}