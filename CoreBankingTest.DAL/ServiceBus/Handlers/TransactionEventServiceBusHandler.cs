using CoreBankingTest.Core.Events;
using CoreBankingTest.DAL.ServiceBus;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CoreBankingTest.Infrastructure.ServiceBus.Handlers
{
    public class TransactionEventServiceBusHandler : BaseMessageHandler<MoneyTransferedEvent>
    {
        public TransactionEventServiceBusHandler(
            IServiceBusClientFactory clientFactory,
            ServiceBusConfiguration config,
            ILogger<TransactionEventServiceBusHandler> logger,
            IMediator mediator)
            : base(clientFactory, config.TransactionTopicName, "fraud-detection", logger, mediator)
        {
        }
    }
}