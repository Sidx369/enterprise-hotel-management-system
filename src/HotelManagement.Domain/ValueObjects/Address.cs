using HotelManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace HotelManagement.Domain.ValueObjects
{
    public sealed class Address : ValueObject
    {
        public Address(
            string line1,
            string? line2,
            string city,
            string state,
            string country,
            string postalCode)
        {
            Line1 = line1.Trim();
            Line2 = line2?.Trim();
            City = city.Trim();
            State = state.Trim();
            Country = country.Trim();
            PostalCode = postalCode.Trim();
        }

        public string Line1 { get; }

        public string? Line2 { get; }

        public string City { get; }

        public string State { get; }

        public string Country { get; }

        public string PostalCode { get; }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Line1;
            yield return Line2;
            yield return City;
            yield return State;
            yield return Country;
            yield return PostalCode;
        }
    }
}
