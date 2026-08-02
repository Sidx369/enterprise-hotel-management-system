# Coding Standards

---

# Purpose

This document defines the coding standards followed throughout the Enterprise Hotel Management System.

The primary goals are:

- Maintainability
- Consistency
- Readability
- Testability
- Performance

Every project in this solution follows these standards.

---

# General Principles

- Follow SOLID principles.
- Follow Clean Architecture.
- Prefer composition over inheritance.
- Keep methods small and focused.
- Avoid duplicated code.
- Make invalid states impossible whenever practical.

---

# Naming Conventions

## Projects

HotelManagement.Domain

HotelManagement.Application

HotelManagement.Infrastructure

HotelManagement.API

---

## Classes

Use PascalCase.

Good

Hotel

BookingService

BookingRepository

Bad

hotel

booking_service

---

## Interfaces

Prefix with I.

IBookingRepository

IUnitOfWork

ICurrentUserService

---

## Methods

Use verbs.

CreateBookingAsync()

CancelBookingAsync()

GetAvailableRoomsAsync()

Avoid

Booking()

Data()

Run()

---

## Properties

PascalCase.

RoomNumber

CheckInDate

BookingStatus

---

## Private Fields

Use underscore prefix.

```csharp
private readonly IBookingRepository _bookingRepository;
```

---

## Constants

PascalCase.

```csharp
public const int MaxRoomCapacity = 8;
```

---

# File Structure

One public type per file.

Example

```
Hotel.cs

Booking.cs

Room.cs
```

Never:

```
Hotel.cs

Room.cs

Booking.cs
```

---

# Namespace Style

Use file-scoped namespaces.

```csharp
namespace HotelManagement.Domain.Entities;
```

Avoid block namespaces.

---

# Nullable Reference Types

Always enabled.

Never disable nullable annotations.

Good

```csharp
string? Description
```

Bad

```csharp
#pragma warning disable
```

---

# Implicit Usings

Enabled globally.

Remove unnecessary using statements.

---

# XML Documentation

Public APIs should include XML comments where they improve discoverability.

Internal implementation details generally do not require XML documentation.

---

# File Layout

Every file will use the same order:

```csharp
using ...

namespace ...

/// XML Docs

public sealed class ...

Fields

Constants

Properties

Constructors

Public Methods

Private Methods
```

---

# Exception Handling

Throw specific exceptions.

Good

BookingException

ValidationException

NotFoundException

Avoid

Exception

---

# Async Programming

Always use asynchronous APIs for:

- Database
- File IO
- Network IO

Method names end with Async.

Example

```csharp
GetBookingAsync()
```

Avoid synchronous EF Core methods.

---

# Dependency Injection

Constructor injection only.

Never use Service Locator.

Never inject IServiceProvider into business services.

---

# Repository Pattern

Repositories only access persistence.

Business logic belongs in Application or Domain.

Repositories should never contain business rules.

---

# Services

Services orchestrate business operations.

Services should not know EF Core implementation details.

---

# DTOs

Never expose entities directly from controllers.

Always map:

Entity

↓

DTO

---

# Validation

All request validation uses FluentValidation.

Controllers should not contain validation logic.

---

# Logging

Use structured logging.

Good

```csharp
_logger.LogInformation(
    "Booking {BookingId} created for customer {CustomerId}",
    booking.Id,
    booking.CustomerId);
```

Avoid string concatenation.

---

# Transactions

Only Application Services coordinate transactions.

Repositories must never begin transactions.

---

# HTTP Status Codes

200 OK

201 Created

204 No Content

400 Bad Request

401 Unauthorized

403 Forbidden

404 Not Found

409 Conflict

422 Validation Error

500 Internal Server Error

---

# Pagination

Every list endpoint supports:

PageNumber

PageSize

Sorting

Filtering

---

# Security

Never store passwords.

Use ASP.NET Identity password hashing.

Never log:

Passwords

JWTs

Connection Strings

Secrets

---

# EF Core

Use AsNoTracking() for read-only queries.

Avoid lazy loading.

Prefer explicit Include() when necessary.

---

# Testing

Use xUnit.

Use FluentAssertions.

Mock external dependencies.

---

# Pull Request Checklist

- Builds successfully
- Tests pass
- No warnings
- Naming conventions followed
- Documentation updated
- Progress.md updated