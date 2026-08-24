# File Inventory

Legend

- ✅ Complete
- 🔄 In Progress
- ⏳ Pending

---

# Repository

| File | Status |
|------|--------|
| README.md | ✅ |
| .gitignore | ✅ |
| Directory.Build.props | ✅ |
| Directory.Packages.props | ✅ |

---

# Documentation

| File | Status |
|------|--------|
| Architecture.md | ✅ |
| CodingStandards.md | ✅ |
| Progress.md | ✅ |
| Files.md | ✅ |
| Database.md | ⏳ |
| API.md | ⏳ |
| Deployment.md | ⏳ |
| Testing.md | ⏳ |

---

# Domain

## Common

| File | Status |
|------|--------|
| BaseEntity.cs | ✅ |
| IDomainEvent.cs | ✅ |
| AggregateRoot.cs | ✅ Updated |
| AuditableEntity.cs | ✅ |
| ValueObject.cs | ✅ |
| Guard.cs | ✅ |

---

## Value Objects

| File | Status |
|------|--------|
| Address.cs | ✅ |
| Money.cs | ✅ |
| HotelDetails.cs | ✅ |
| PersonName.cs | ✅ |
| BookingPeriod.cs | ✅ |

---

## Entities

| File | Status |
|------|--------|
| Hotel.cs | ✅ |
| RoomType.cs | ✅ |
| Room.cs | ✅ |
| Customer.cs | ✅ |
| Booking.cs | ✅ |

---

## Enums

| File | Status |
|------|--------|
| BookingStatus.cs | ✅ |
| RoomStatus.cs | ✅ |
| UserRole.cs | ✅ |

---

## Errors

| File | Status |
|------|--------|
| DomainErrors.cs | ✅ |

---

## Events

| File | Status |
|------|--------|
| BookingCreatedDomainEvent.cs | ✅ |

---

## Exceptions

| File | Status |
|------|--------|
| DomainException.cs | ✅ |
| BookingException.cs | ✅ |

---

## Repository Interfaces

| File | Status |
|------|--------|
| IRepository.cs | ✅ |
| IHotelRepository.cs | ✅ |
| IRoomRepository.cs | ✅ |
| IRoomTypeRepository.cs | ✅ |
| ICustomerRepository.cs | ✅ |
| IBookingRepository.cs | ✅ |
| IUnitOfWork.cs | ✅ |

---

# Application

## Common

### Exceptions

| File | Status |
|------|--------|
| NotFoundException.cs | ✅ |
| ConcurrencyException.cs | ✅ |

---

### Models

| File | Status |
|------|--------|
| AddressModel.cs | ✅ |

---

### Pagination

| File | Status |
|------|--------|
| PagedResult.cs | ✅ |
| PagingParameters.cs | ✅ |

---

## Features

### Hotels

#### Contracts

| File | Status |
|------|--------|
| HotelFilter.cs | ✅ |
| CreateHotelRequest.cs | ✅ |
| UpdateHotelRequest.cs | ✅ |
| HotelResponse.cs | ✅ |
| IHotelRequest.cs | ✅ |

---

#### Interfaces

| File | Status |
|------|--------|
| IHotelService.cs | ✅ |

---

#### Mapping

| File | Status |
|------|--------|
| HotelMappingProfile.cs | ✅ |

---

#### Services

| File | Status |
|------|--------|
| HotelService.cs | ✅ |

---

#### Validators

| File | Status |
|------|--------|
| HotelValidationExtensions.cs | ✅ |
| CreateHotelRequestValidator.cs | ✅ |
| UpdateHotelRequestValidator.cs | ✅ |

---

- Others
| File | Status |
|------|--------|
| CreateRoomDto.cs | ⏳ |
| UpdateRoomDto.cs | ⏳ |
| RoomDto.cs | ⏳ |
| RoomFilter.cs | ⏳ |
| CreateCustomerDto.cs | ⏳ |
| UpdateCustomerDto.cs | ⏳ |
| CustomerDto.cs | ⏳ |
| CustomerFilter.cs | ⏳ |
| CreateBookingDto.cs | ⏳ |
| BookingDto.cs | ⏳ |
| ConfirmBookingRequest.cs | ⏳ |
| CancelBookingRequest.cs | ⏳ |
| CheckInBookingRequest.cs | ⏳ |
| CheckOutBookingRequest.cs | ⏳ |

---

# Infrastructure

| File | Status |
|------|--------|
| DependencyInjection.cs | ✅ |

---

## Persistence

| File | Status |
|------|--------|
| HotelManagementDbContext.cs | ✅ |
| UnitOfWork.cs | ✅ |

---

### Configurations

| File | Status |
|------|--------|
| HotelConfiguration.cs | ✅ |

---

### Repositories

| File | Status |
|------|--------|
| HotelRepository.cs | ✅ |

---

# API

Pending

---

# Tests

Pending