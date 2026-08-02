using HotelManagement.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Domain.Common
{
    public static class Guard
    {
        public static void AgainstNull<T>(T? value, string parameterName)
        {
            if (value is null)
                throw new ArgumentNullException(parameterName);
        }

        public static void AgainstNullOrWhiteSpace(string? value, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new DomainException($"{parameterName} cannot be empty.");
            }
        }

        public static void AgainstNegative(decimal value, string parameterName)
        {
            if (value < 0)
            {
                throw new DomainException($"{parameterName} cannot be negative.");
            }
        }

        public static void AgainstNegative(int value, string parameterName)
        {
            if (value < 0)
            {
                throw new DomainException($"{parameterName} cannot be negative.");
            }
        }

        public static void AgainstOutOfRange(
        int value,
        int minimum,
        int maximum,
        string parameterName)
        {
            if (value < minimum || value > maximum)
            {
                throw new DomainException(
                    $"{parameterName} must be between {minimum} and {maximum}.");
            }
        }

        public static void AgainstMaxLength(
            string value,
            int maxLength,
            string parameterName)
        {
            if (value.Length > maxLength)
                throw new DomainException($"{parameterName} cannot exceed {maxLength} characters.");
        }

        public static void AgainstInvalidEmail(
            string? email,
            string parameterName)
        {
            if (string.IsNullOrWhiteSpace(email))
                return;

            try
            {
                _ = new System.Net.Mail.MailAddress(email);
            }
            catch
            {
                throw new DomainException(
                    $"{parameterName} is not a valid email address.");
            }
        }

        public static void AgainstEmptyGuid(
            Guid value,
            string parameterName)
        {
            if (value == Guid.Empty)
                throw new DomainException($"{parameterName} cannot be an empty Guid.");
        }
    }
}
