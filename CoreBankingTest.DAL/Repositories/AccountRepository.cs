using CoreBankingTest.Core.Entities;
using CoreBankingTest.Core.Interfaces;
using CoreBankingTest.Core.Models;
using CoreBankingTest.Core.ValueObjects;

namespace CoreBankingTest.DAL.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly List<AccountModel> _accounts = new() { 
            new AccountModel { Id = 1, Name = "John Doe", Balance = 5000 },
            new AccountModel { Id = 2, Name = "Jane Smith", Balance = 7500, Currency = "USD" },
        };

        public Task<bool> AccountNumberExistsAsync(AccountNumber accountNumber)
        {
            throw new NotImplementedException();
        }

        public void Add(AccountModel account) => _accounts.Add(account);

        public Task AddAsync(Account account)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AccountModel> GetAll() => _accounts;

        public Task<Account> GetByAccountNumberAsync(Account account)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Account>> GetByCustomerIdAsync(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public AccountModel GetById(int id) => _accounts.FirstOrDefault(a => a.Id == id)!;

        public Task<Account> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
