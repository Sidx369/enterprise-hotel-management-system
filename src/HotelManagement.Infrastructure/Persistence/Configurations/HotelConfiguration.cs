using HotelManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Infrastructure.Persistence.Configurations;

/// <summary>
/// EF Core persistence configuration for the Hotel aggregate.
/// </summary>
public sealed class HotelConfiguration : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
        builder.ToTable("Hotels");

        builder.HasKey(hotel  => hotel.Id);

        builder.Property(hotel => hotel.Id)
            .ValueGeneratedNever();

        builder.Property(hotel => hotel.RowVersion)
            .IsRowVersion()
            .IsConcurrencyToken();

        builder.Property(hotel => hotel.CreatedOnUtc)
            .IsRequired();

        builder.Property(hotel => hotel.LastModifiedOnUtc)
            .IsRequired(false);

        builder.OwnsOne(
            hotel => hotel.Details,
            details =>
            {
                details.Property(value => value.Name)
                    .HasColumnName("Name")
                    .HasMaxLength(200)
                    .IsRequired();

                details.Property(value => value.Description)
                    .HasColumnName("Description")
                    .HasMaxLength(1000);

                details.Property(value => value.Email)
                    .HasColumnName("Email")
                    .HasMaxLength(256);

                details.Property(value => value.PhoneNumber)
                    .HasColumnName("PhoneNumber")
                    .HasMaxLength(25);

                details.Property(value => value.StarRating)
                    .HasColumnName("StarRating")
                    .IsRequired();

                details.OwnsOne(
                    value => value.Address,
                    address =>
                    {
                        address.Property(value => value.Line1)
                            .HasColumnName("AddressLine1")
                            .HasMaxLength(200)
                            .IsRequired();

                        address.Property(value => value.Line2)
                            .HasColumnName("AddressLine2")
                            .HasMaxLength(200);

                        address.Property(value => value.City)
                            .HasColumnName("City")
                            .HasMaxLength(100)
                            .IsRequired();

                        address.Property(value => value.State)
                            .HasColumnName("State")
                            .HasMaxLength(100)
                            .IsRequired();

                        address.Property(value => value.Country)
                            .HasColumnName("Country")
                            .HasMaxLength(100)
                            .IsRequired();

                        address.Property(value => value.PostalCode)
                            .HasColumnName("PostalCode")
                            .HasMaxLength(20)
                            .IsRequired();
                    });
            });

        builder.Property(hotel => hotel.IsActive)
            .IsRequired();
    }
}
