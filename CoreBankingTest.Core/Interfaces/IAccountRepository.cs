using CoreBankingTest.Core.Models;

namespace CoreBankingTest.Core.Interfaces
{
    public interface IAccountRepository
    {
        AccountModel GetById(int id);
        IEnumerable<AccountModel> GetAll();
        void Add(AccountModel account);
    }
}
