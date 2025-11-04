// CoreBanking.Core/Events/MoneyTransferredEvent.cs
using CoreBankingTest.Core.Common;
using CoreBankingTest.Core.Entities;
using CoreBankingTest.Core.Events;
using CoreBankingTest.Core.ValueObjects;

namespace CoreBanking.Core.Events;

public record MoneyTransferredEvent : DomainEvent
{
    public TransactionId TransactionId { get; }
    public AccountNumber SourceAccountNumber { get; }
    public AccountNumber DestinationAccount { get; }
    public Money Amount { get; }
    public string Reference { get; }
    public DateTime TransferDate { get; }

    public MoneyTransferredEvent(
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