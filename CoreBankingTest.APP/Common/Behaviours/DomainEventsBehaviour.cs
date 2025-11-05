
using CoreBankingTest.APP.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CoreBankingTest.APP.Common.Behaviours
{
    public class DomainEventsBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
          where TRequest : IRequest<TResponse>
    {
        private readonly IDomainEventDispatcher _dispatcher;
        private readonly ILogger<DomainEventsBehaviour<TRequest, TResponse>> _logger;

        public DomainEventsBehaviour(IDomainEventDispatcher dispatcher,
            ILogger<DomainEventsBehaviour<TRequest, TResponse>> logger)
        {
            _dispatcher = dispatcher;
            _logger = logger;
        }

        public async Task<TResponse> Handle(
            TRequest request, 
            RequestHandlerDelegate<TResponse> next, 
            CancellationToken cancellationToken)
        {
            _logger.LogInformation("Processing domain events for {RequestType}", typeof(TRequest).Name);
            var response = await next();
            //collect and persist domain events
            _logger.LogInformation("Handled {RequestType}", typeof(TRequest).Name);
            await _dispatcher.DispatchDomainEventsAsync(cancellationToken);
            return response;
        }

    }
}
