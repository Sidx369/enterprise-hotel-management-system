using HotelManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer?> GetByEmailAsync(
            string email,
            CancellationToken cancellationToken = default);

        Task<bool> EmailExistsAsync(
            string email,
            CancellationToken cancellationToken = default);
    }
}
