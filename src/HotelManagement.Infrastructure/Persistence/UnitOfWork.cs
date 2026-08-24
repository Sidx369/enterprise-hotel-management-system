using HotelManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Infrastructure.Persistence;

/// <summary>
/// EF Core implementation of the Unit of Work abstraction.
/// </summary>
public sealed class UnitOfWork : IUnitOfWork
{
    private readonly HotelManagementDbContext _dbContext;

    public UnitOfWork(HotelManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        return _dbContext.SaveChangesAsync(
            cancellationToken);
    }
}
