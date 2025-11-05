// CoreBanking.Core/Events/MoneyTransferredEvent.cs
using CoreBankingTest.Core.Common;
using CoreBankingTest.Core.Entities;
using CoreBankingTest.Core.ValueObjects;

namespace CoreBanking.Core.Events;

public record MoneyTransferedEvent : DomainEvent
{
    public TransactionId TransactionId { get; }
    public AccountNumber SourceAccountNumber { get; }
    public AccountNumber DestinationAccount { get; }
    public Money Amount { get; }
    public string Reference { get; }
    public DateTime TransferDate { get; }

    public MoneyTransferedEvent(
        TransactionId transactionId,
        AccountNumber sourceAccountNumber,
        AccountNumber destinationAccount,
        Money amount,
        string reference)
    {
        TransactionId = transactionId;
        SourceAccountNumber = sourceAccountNumber;
        DestinationAccount = destinationAccount;
        Amount = amount;
        Reference = reference;
        TransferDate = DateTime.UtcNow;
    }
}