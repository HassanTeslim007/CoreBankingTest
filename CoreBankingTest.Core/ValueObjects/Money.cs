using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBankingTest.Core.ValueObjects
{
    public record Money
    {
        public decimal Amount { get; }
        public string Currency { get; } = "NGN";

        public Money(decimal amount, string currency = "NGN")
        {
            if (amount < 0)
                throw new ArgumentException("Money amount cannot be negative");
            Amount = amount;
            Currency = currency;
        }

        public static Money operator +(Money a, Money b)
        {
            if (a.Currency != b.Currency)
                throw new InvalidOperationException("Cannot add different currencies");
            return new Money(a.Amount + b.Amount, a.Currency);
        }

        public static Money operator -(Money a, Money b)
        {
            if (a.Amount != b.Amount)
                throw new InvalidOperationException("Cannot subtract different currencies");
            return new Money(a.Amount - b.Amount, a.Currency);
        }

    }
}
