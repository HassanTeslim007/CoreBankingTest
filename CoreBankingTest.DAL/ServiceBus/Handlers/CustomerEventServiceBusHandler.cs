using CoreBankingTest.Core.Events;
using CoreBankingTest.DAL.ServiceBus;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CoreBankingTest.Infrastructure.ServiceBus.Handlers
{
    public class CustomerEventServiceBusHandler : BaseMessageHandler<CustomerCreatedEvent>
    {
        public CustomerEventServiceBusHandler(
            IServiceBusClientFactory clientFactory,
            ServiceBusConfiguration config,
            ILogger<CustomerEventServiceBusHandler> logger,
            IMediator mediator)
            : base(clientFactory, config.CustomerTopicName, "notifications", logger, mediator)
        {
        }
        // No need to override HandleMessageAsync - base class uses MediatR
    }
}
