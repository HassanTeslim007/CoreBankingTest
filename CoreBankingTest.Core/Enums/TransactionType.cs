using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBankingTest.Core.Enums
{
    public enum TransactionType
    {
        Deposit = 1,
        Withdrawal = 2,
        TransferIn = 3,
        TransferOut = 4,
        Interest = 5
    }
}
