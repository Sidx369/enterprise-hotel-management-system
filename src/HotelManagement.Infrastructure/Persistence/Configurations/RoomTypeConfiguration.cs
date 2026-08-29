using HotelManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Infrastructure.Persistence.Configurations;

/// <summary>
/// EF Core persistence configuration for the RoomType aggregate.
/// </summary>
public sealed class RoomTypeConfiguration : 
    IEntityTypeConfiguration<RoomType>
{
    public void Configure(
        EntityTypeBuilder<RoomType> builder)
    {
        builder.ToTable("RoomTypes");

        builder.HasKey(roomType => roomType.Id);

        builder.Property(roomType => roomType.Id)
            .ValueGeneratedNever();

        builder.Property(roomType => roomType.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(roomType => roomType.Description)
            .HasMaxLength(500)
            .IsRequired(false);

        builder.Property(roomType => roomType.MaxOccupancy)
            .IsRequired();

        builder.Property(roomType => roomType.IsActive)
            .IsRequired();

        builder.Property(roomType => roomType.CreatedOnUtc)
            .IsRequired();

        builder.Property(roomType => roomType.LastModifiedOnUtc)
            .IsRequired(false);

        builder.Property(roomType => roomType.CreatedBy)
            .HasMaxLength(256)
            .IsRequired(false);

        builder.Property(roomType => roomType.LastModifiedBy)
            .HasMaxLength(256)
            .IsRequired(false);

        builder.Property(roomType => roomType.RowVersion)
            .IsRowVersion()
            .IsConcurrencyToken();
    }
}
