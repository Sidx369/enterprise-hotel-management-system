using HotelManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Domain.Interfaces
{
    public interface IHotelRepository : IRepository<Hotel>
    {
        Task<Hotel?> GetByIdWithRoomsAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        //Not required as hotel names are not unique
        Task<bool> ExistsByNameAsync(
            string name,
            CancellationToken cancellationToken= default);
    }
}
