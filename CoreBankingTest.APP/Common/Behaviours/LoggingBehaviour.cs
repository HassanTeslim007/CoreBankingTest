using CoreBankingTest.APP.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CoreBankingTest.APP.Common.Behaviours
{
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
          where TRequest : IRequest
          where TResponse : Result
    {
        private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;

        public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
          var requestName = typeof(TRequest).Name;

            _logger.LogInformation("Handling command {CommandName} with Payload {@Request}", requestName, request);

            var timer = System.Diagnostics.Stopwatch.StartNew();
            var response = await next();
            timer.Stop();

            _logger.LogInformation("Command {CommandName} handled in {EllapsedMilliseconds}ms", requestName, timer.ElapsedMilliseconds);

            return response;
        }
    }
}
