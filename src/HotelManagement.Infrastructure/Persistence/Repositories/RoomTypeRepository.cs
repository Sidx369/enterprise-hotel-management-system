using HotelManagement.Domain.Entities;
using HotelManagement.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace HotelManagement.Infrastructure.Persistence.Repositories;

/// <summary>
/// Entity Framework Core implementation of the RoomType repository.
/// </summary>
public sealed class RoomTypeRepository : IRoomTypeRepository
{
    private readonly HotelManagementDbContext _dbContext;

    public RoomTypeRepository(
        HotelManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<RoomType?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.RoomTypes
            .SingleOrDefaultAsync(
            roomType => roomType.Id == id,
            cancellationToken);
    }

    public async Task<IReadOnlyList<RoomType>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.RoomTypes
            .AsNoTracking()
            .OrderBy(roomType => roomType.Name)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<RoomType>> FindAsync(
        Expression<Func<RoomType, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        return await _dbContext.RoomTypes
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(
        RoomType entity,
        CancellationToken cancellationToken= default)
    {
        ArgumentNullException.ThrowIfNull(entity);

        await _dbContext.RoomTypes.AddAsync(
            entity,
            cancellationToken);
    }

    public void Update(RoomType entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        _dbContext.RoomTypes.Update(entity);
    }

    public void Remove(RoomType entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        _dbContext.RoomTypes.Remove(entity);
    }

    public async Task<bool> ExistsAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.RoomTypes
            .AnyAsync(
            roomType => roomType.Id == id,
            cancellationToken);
    }

    public async Task<RoomType?> GetByNameAsync(
        string name,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        name = name.Trim();

        return await _dbContext.RoomTypes
            .SingleOrDefaultAsync(
            roomType => roomType.Name == name,
            cancellationToken);
    }

    public async Task<bool> ExistsByNameAsync(
        string name,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        name = name.Trim();

        return await _dbContext.RoomTypes
            .AnyAsync(
            roomType => roomType.Name == name,
            cancellationToken);
    }
}
