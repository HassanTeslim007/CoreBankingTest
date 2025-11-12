

namespace CoreBankingTest.APP.Common.Interfaces
{
    public interface IResilienceService
    {
        Task<T> ExecuteWithResilienceAsync<T>(Func<CancellationToken, Task<T>> operation, String operationName, CancellationToken cancellationToken = default);

        Task<HttpResponseMessage> ExecuteHttpCallWithResilienceAsync(Func<CancellationToken, Task<HttpResponseMessage>> httpOperation, String operationName, CancellationToken cancellationToken = default);
    }
}
