# Enterprise Hotel Management System (.NET 10)

> An enterprise-grade Hotel Management System built using **ASP.NET Core Web API (.NET 10)** following **Clean Architecture**, **SOLID Principles**, and modern enterprise development practices.

---

# Project Goals

This project is designed to demonstrate senior-level backend engineering skills by implementing a production-quality Hotel Management System.

The objective is not simply to build CRUD APIs, but to showcase:

- Enterprise Architecture
- Domain-Driven Design (Lightweight)
- Clean Code
- SOLID Principles
- Scalable Project Structure
- Security Best Practices
- Performance Optimizations
- Testability
- Maintainability

---

# Technology Stack

| Technology | Version |
|------------|----------|
| .NET | 10 |
| ASP.NET Core Web API | 10 |
| Entity Framework Core | Latest |
| SQL Server | Latest |
| JWT Authentication | ✓ |
| FluentValidation | ✓ |
| Serilog | ✓ |
| Swagger/OpenAPI | ✓ |
| Docker | ✓ |
| xUnit | ✓ |
| Moq | ✓ |
| FluentAssertions | ✓ |

---

# Planned Features

- Hotels
- Rooms
- Room Types
- Customers
- Bookings
- Authentication
- Authorization
- Pagination
- Filtering
- Sorting
- Health Checks
- API Versioning
- Global Exception Handling
- Logging
- Seed Data
- Optimistic Concurrency
- Transactions
- Caching
- Docker Support

---

# Architecture

The solution follows **Clean Architecture**.

```
Presentation (API)

↓

Application

↓

Domain

↑

Infrastructure
```

---

# Project Structure

```
src/

    HotelManagement.Domain

    HotelManagement.Application

    HotelManagement.Infrastructure

    HotelManagement.API

tests/

    HotelManagement.Domain.Tests

    HotelManagement.Application.Tests

    HotelManagement.Infrastructure.Tests

    HotelManagement.API.Tests

docs/

docker/

scripts/
```

---

# Current Status

See:

```
docs/Progress.md
```

---

# Documentation

| Document | Purpose |
|----------|---------|
| Architecture.md | System Architecture |
| CodingStandards.md | Coding Guidelines |
| Progress.md | Current Sprint |
| Files.md | File Inventory |
| Database.md | Database Design |
| API.md | API Documentation |
| Testing.md | Testing Strategy |
| Deployment.md | Deployment Guide |
| adr | Architecture Decision Records |

---

# License

MIT