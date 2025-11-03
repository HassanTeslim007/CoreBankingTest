using CoreBankingTest.APP.Accounts.Queries.GetAccountDetails;
using CoreBankingTest.APP.Common.Interfaces;
using CoreBankingTest.APP.Common.Models;
using CoreBankingTest.APP.Customers.Queries.GetCustomers;
using CoreBankingTest.Core.Interfaces;
using CoreBankingTest.Core.ValueObjects;
using MediatR;

namespace CoreBankingTest.APP.Customers.Queries.GetCustomerDetails;

public record GetCustomerDetailsQuery : IQuery<CustomerDto>
{
    public Guid CustomerId { get; init; }
}

public class GetCustomerDetailsQueryHandler : IRequestHandler<GetCustomerDetailsQuery, Result<CustomerDto>>
{
    private readonly ICustomerRepository _customerRepository;
    public GetCustomerDetailsQueryHandler(ICustomerRepository customerRepository) { _customerRepository = customerRepository; }
    public async Task<Result<CustomerDto>> Handle(GetCustomerDetailsQuery request, CancellationToken cancellationToken)
    {
        CustomerId customerId = CustomerId.Create(request.CustomerId);
        var customer = await _customerRepository.GetByIdAsync(customerId);
        if (customer == null) return Result<CustomerDto>.Failure("Customer not found");
        var dto = new CustomerDto
        {
            CustomerId = customer.CustomerId,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Email = customer.Email,
            Phone = customer.PhoneNumber,
            DateRegistered = customer.DateCreated,
            IsActive = customer.IsActive
        };
        return Result<CustomerDto>.Success(dto);
    }
}