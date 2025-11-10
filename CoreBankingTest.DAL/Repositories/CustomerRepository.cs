using CoreBankingTest.Core.Entities;
using CoreBankingTest.Core.Interfaces;
using CoreBankingTest.Core.ValueObjects;
using CoreBankingTest.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace CoreBankingTest.DAL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BankingDbContext _context;

        public CustomerRepository(BankingDbContext context)
        {
            _context = context;
        }

        public async Task<Customer?> GetByIdAsync(CustomerId customerId, CancellationToken cancellationToken = default)
        {
            return await _context.Customers
                .Include(c => c.Accounts)
                .FirstOrDefaultAsync(c => c.CustomerId == customerId, cancellationToken);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Customers
                .Include(c => c.Accounts)
                .ToListAsync(cancellationToken);
        }

        public async Task AddAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            await _context.Customers.AddAsync(customer, cancellationToken);
        }

        public async Task UpdateAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            _context.Customers.Update(customer);
            await Task.CompletedTask;
        }

        public async Task<bool> ExistsAsync(CustomerId customerId, CancellationToken cancellationToken = default)
        {
            return await _context.Customers
                .AnyAsync(c => c.CustomerId == customerId, cancellationToken);
        }
    }
}
