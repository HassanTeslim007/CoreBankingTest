using CoreBankingTest.Core.Entities;
using CoreBankingTest.Core.Models;
using CoreBankingTest.Core.ValueObjects;

namespace CoreBankingTest.Core.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account> GetByIdAsync(Guid id);
        Task<Account> GetByAccountNumberAsync(Account account);
        Task<IEnumerable<Account>> GetByCustomerIdAsync(Guid customerId);
        Task AddAsync(Account account);
        Task UpdateAsync(Account account);
        Task<bool> AccountNumberExistsAsync(AccountNumber accountNumber);
        AccountModel GetById(int id);
        IEnumerable<AccountModel> GetAll();
        void Add(AccountModel account);
    }
}
