# Architecture

---

# Overview

This project follows **Clean Architecture** with a layered design that separates business rules from infrastructure concerns.

The architecture emphasizes:

- Separation of Concerns
- Dependency Inversion
- Testability
- Maintainability
- Scalability

---

# High Level Architecture

```
                HTTP

                  │

                  ▼

      ASP.NET Core Web API

                  │

                  ▼

        Application Layer

                  │

                  ▼

           Domain Layer

                  ▲

                  │

      Infrastructure Layer
```

---

# Dependency Rule

Dependencies always point inward.

```
API
 │
 ├──────────────┐
 │              │
 ▼              ▼
Application   Infrastructure
      \        /
       \      /
        ▼    ▼
        Domain
```

Project References:

| Project | References |
|----------|------------|
| Domain | None |
| Application | Domain |
| Infrastructure | Domain, Application |
| API | Application, Infrastructure |

---

# Runtime Flow

```
Client

↓

Controller

↓

Application Service

↓

Repository Interface

↓

Repository Implementation

↓

DbContext

↓

SQL Server
```

---

# Layers

## Domain

Contains:

- Entities
- Value Objects
- Enums
- Repository Interfaces
- Domain Exceptions

No external dependencies.

---

## Application

Contains:

- Business Services
- DTOs
- Validators
- Mapping
- Pagination
- Filtering
- Application Interfaces

Depends only on Domain.

---

## Infrastructure

Contains:

- EF Core
- Repository Implementations
- Authentication
- Authorization
- Caching
- Logging
- Persistence
- External Services

Depends on:

- Domain
- Application

---

## API

Contains:

- Controllers
- Middleware
- Dependency Injection
- Swagger
- Versioning
- Health Checks

---

# Design Principles

- SOLID
- DRY
- KISS
- Dependency Inversion
- Composition over Inheritance
- Rich Domain Model

---

# Design Patterns

This project intentionally demonstrates the following patterns:

- Repository
- Unit of Work
- Factory
- Strategy
- Builder
- Dependency Injection
- Options Pattern

Future:

- Specification
- Decorator
- Outbox Pattern

---

# Aggregate Roots

- Hotel
- Booking
- Customer

---

# Child Entities

- Room
- RoomType

---

# Value Objects

- Address
- Money

Future:

- Email
- PhoneNumber

---

# Cross Cutting Concerns

- Authentication
- Authorization
- Validation
- Logging
- Exception Handling
- Transactions
- Caching
- Auditing

---

# Coding Philosophy

Business rules belong inside the Domain Model.

Infrastructure provides technical implementations.

Controllers remain thin.

Application orchestrates use cases.

Persistence remains replaceable.
