using HotelManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Domain.ValueObjects
{
    public sealed class Money : ValueObject
    {
        public Money(decimal amount, string currency)
        {
            if(amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            if (string.IsNullOrWhiteSpace(currency))
                throw new ArgumentException("Currency cannot be empty.", nameof(currency));

            Amount = amount;
            Currency = currency.Trim().ToUpperInvariant();
        }

        public decimal Amount { get; }

        public string Currency { get; }

        public Money Add(Money other)
        {
            EnsureSameCurrency(other);
            return new Money(Amount + other.Amount, Currency);
        }

        public Money Subtract(Money other)
        {
            EnsureSameCurrency(other);
            return new Money(Amount - other.Amount, Currency);
        }

        private void EnsureSameCurrency(Money other)
        {
            if(Currency != other.Currency)
            {
                throw new InvalidOperationException(
                    "Money operations required the same currency.");
            }
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Amount;
            yield return Currency;
        }
    }
}
