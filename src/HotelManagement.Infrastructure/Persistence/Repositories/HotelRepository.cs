using HotelManagement.Domain.Entities;
using HotelManagement.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace HotelManagement.Infrastructure.Persistence.Repositories
{
    /// <summary>
    /// EF Core implementation of the Hotel repository.
    /// </summary>
    public sealed class HotelRepository : IHotelRepository
    {
        private readonly HotelManagementDbContext _dbContext;

        public HotelRepository(HotelManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Hotel?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Hotels
                .SingleOrDefaultAsync(
                hotel => hotel.Id == id,
                cancellationToken);
        }
        public async Task<IReadOnlyList<Hotel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Hotels
                .AsNoTracking()
                .OrderBy(hotel => hotel.CreatedOnUtc)
                .ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<Hotel>> FindAsync(Expression<Func<Hotel, bool>> predicate, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(predicate);

            return await _dbContext.Hotels
                .AsNoTracking()
                .Where(predicate)
                .ToListAsync(cancellationToken);
        }

        public async Task<Hotel?> GetByIdWithRoomsAsync(Guid id, CancellationToken cancellationToken = default)
        {
            /*
             * Hotel and Room are separate aggregate roots.
             *
             * Hotel currently has no Rooms navigation property, so EF Core
             * cannot Include Rooms here without changing the domain model.
             *
             * This method currently behaves as a normal Hotel lookup.
             *
             * Revisit this method when implementing the Room
             * persistence model and decide whether this method should:
             *
             * 1. Be removed from IHotelRepository, or
             * 2. Be replaced by an appropriate RoomRepository query.
             *
             * No aggregate relationship is being introduced here implicitly.
             */

            return await GetByIdAsync(
            id,
            cancellationToken);
        }

        public async Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(name);

            name = name.Trim();

            return await _dbContext.Hotels
                .AnyAsync(
                hotel => hotel.Details.Name == name,
                cancellationToken);
        }

        public async Task<IReadOnlyList<Hotel>> GetPagedAsync(string? name, string? city, bool? isActive, string? sortBy, bool descending, int skip, int take, CancellationToken cancellationToken = default)
        {
            if (skip < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(skip));
            }

            if (take <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(take));
            }

            IQueryable<Hotel> query = _dbContext.Hotels
                .AsNoTracking();
                        
            query = ApplyFilters(
                query,
                name,
                city,
                isActive);

            query = ApplySorting(
                query,
                sortBy,
                descending);

            return await query
                .Skip(skip)
                .Take(take)
                .ToListAsync(cancellationToken);
        }

        public async Task<int> CountAsync(string? name, string? city, bool? isActive, CancellationToken cancellationToken = default)
        {
            IQueryable<Hotel> query = _dbContext.Hotels;

            query = ApplyFilters(
                query,
                name,
                city,
                isActive);

            return await query.CountAsync(cancellationToken);
        }

        public async Task AddAsync(Hotel entity, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(entity);

            await _dbContext.Hotels.AddAsync(
                entity,
                cancellationToken);
        }

        public void Update(Hotel entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            _dbContext.Hotels.Update(entity);
        }

        public void Remove(Hotel entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            _dbContext.Hotels.Remove(entity);
        }

        public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Hotels
                .AnyAsync(
                hotel => hotel.Id == id,
                cancellationToken);
        }

        private static IQueryable<Hotel> ApplyFilters(
            IQueryable<Hotel> query,
            string? name,
            string? city,
            bool? isActive)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                name = name.Trim();

                query = query.Where(
                   hotel => hotel.Details.Name.Contains(name));
            }

            if (!string.IsNullOrWhiteSpace(city))
            {
                city = city.Trim();

                query = query.Where(
                    hotel => hotel.Details.Address.City.Contains(city));
            }

            if (isActive.HasValue)
            {
                query = query.Where(
                    hotel => hotel.IsActive == isActive.Value);
            }

            return query;
        }

        private static IQueryable<Hotel> ApplySorting(
            IQueryable<Hotel> query,
            string? sortBy,
            bool descending)
        {
            return sortBy?.ToLowerInvariant() switch
            {
                "name" => descending
                ? query.OrderByDescending(h => h.Details.Name)
                : query.OrderBy(h => h.Details.Name),

                "city" => descending
                ? query.OrderByDescending(h => h.Details.Address.City)
                : query.OrderBy(h => h.Details.Address.City),

                "starrating" => descending
                ? query.OrderByDescending(h => h.Details.StarRating)
                : query.OrderBy(h => h.Details.StarRating),

                "createdonutc" => descending
                ? query.OrderByDescending(h => h.CreatedOnUtc)
                : query.OrderBy(h => h.CreatedOnUtc),

                _ => descending
                    ? query.OrderByDescending(h => h.CreatedOnUtc)
                    : query.OrderBy(h => h.CreatedOnUtc)
            };
        }
    }
}
