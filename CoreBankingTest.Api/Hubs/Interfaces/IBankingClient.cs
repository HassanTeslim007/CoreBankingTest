

using CoreBankingTest.Api.Hubs.Models;

namespace CoreBankingTest.Api.Hubs.Interfaces
{
    public interface IBankingClient
    {
        // Transaction notifications
        Task ReceiveTransactionNotification(TransactionNotification notification);
        Task ReceiveBalanceUpdate(BalanceUpdate update);

        // System alerts
        Task ReceiveSystemAlert(SystemAlert alert);

        // Fraud detection
        Task ReceiveFraudAlert(FraudAlert alert);

        // Connection management
        Task ConnectionStateChanged(ConnectionState state);
    }
}
