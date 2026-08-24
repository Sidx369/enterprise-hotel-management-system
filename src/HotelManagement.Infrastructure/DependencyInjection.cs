using HotelManagement.Domain.Interfaces;
using HotelManagement.Infrastructure.Persistence;
using HotelManagement.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Infrastructure;

/// <summary>
/// Registers Infrastructure services.
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<HotelManagementDbContext>(
            options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString(
                        "DefaultConnection"));
            });

        services.AddScoped<IHotelRepository, HotelRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
