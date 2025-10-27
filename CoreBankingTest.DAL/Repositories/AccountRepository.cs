using CoreBankingTest.Core.Interfaces;
using CoreBankingTest.Core.Models;

namespace CoreBankingTest.DAL.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly List<AccountModel> _accounts = new() { 
            new AccountModel { Id = 1, Name = "John Doe", Balance = 5000 },
            new AccountModel { Id = 2, Name = "Jane Smith", Balance = 7500 },
        };
        public void Add(AccountModel account) => _accounts.Add(account);

        public IEnumerable<AccountModel> GetAll() => _accounts;

        public AccountModel GetById(int id) => _accounts.FirstOrDefault(a => a.Id == id)!;
    }
}
