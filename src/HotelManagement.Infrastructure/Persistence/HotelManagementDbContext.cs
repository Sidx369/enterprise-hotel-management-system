using HotelManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Infrastructure.Persistence;

/// <summary>
/// Entity Framework Core database context for the hotel management system.
/// </summary>
public sealed class HotelManagementDbContext : DbContext
{
    public HotelManagementDbContext(
        DbContextOptions<HotelManagementDbContext> options)
        : base(options)
    {
        
    }

    public DbSet<Hotel> Hotels => Set<Hotel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(HotelManagementDbContext).Assembly);
    }
}
