using CoreBankingTest.APP.Common.Interfaces;
using CoreBankingTest.APP.Common.Models;
using CoreBankingTest.Core.Interfaces;
using CoreBankingTest.Core.ValueObjects;
using MediatR;

namespace CoreBankingTest.APP.Customers.Commands.CreateCustomer;

public record CreateCustomerCommand : ICommand<CustomerId>
{
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string PhoneNumber { get; init; } = string.Empty;
    public string BVN { get; init; } = string.Empty;
    public string Address { get; init; } = string.Empty;
    public DateTime DateOfBirth { get; init; }
}