# WPF Banking Application

A desktop banking simulation built with **WPF (.NET 8)** to demonstrate production-style architecture, security, and maintainable engineering practices.

## Project Summary
This project models core retail banking workflows in a standalone desktop application. It is intentionally designed as a portfolio-quality implementation that emphasizes clean architecture, MVVM separation, and testability.

## Key Features
- Authentication with hashed password support
- Role-based authorization (`Customer`, `Admin`)
- Multi-account dashboard and account detail views
- Transaction history with filtering, sorting, and search
- Internal/external transfer workflows with validation
- Payee management (CRUD)
- Statement export (CSV/PDF)
- Optional admin oversight and audit-log review

## Architecture At A Glance
The solution follows a layered design with strict MVVM boundaries:

- **Presentation Layer**: WPF XAML Views + ViewModels (`INotifyPropertyChanged`, `ICommand`)
- **Application Layer**: Use-case services for auth, accounts, transfers, and statements
- **Domain Layer**: Entities and business rules (validation, transfer invariants)
- **Infrastructure Layer**: SQLite/EF Core persistence, logging, configuration

See `docs/Architecture-Diagram-Outline.md` for a one-page architecture diagram blueprint.

## Non-Functional Focus
- Secure credential handling (PBKDF2/BCrypt)
- Async operations for UI responsiveness
- Structured logging and global exception handling
- Dependency injection and mockable services for unit testing
- UI virtualization for large transaction datasets

## Sample Acceptance Criteria
- Invalid login attempts are rejected and logged
- Transfers are atomic (both balances update, or none)
- Transaction filtering returns correct records
- Statement exports match selected date ranges

## Tech Stack
- **Framework**: WPF on .NET 8 (`net8.0-windows`)
- **Language**: C#
- **Pattern**: MVVM
- **Data (planned)**: SQLite + EF Core
- **Testing (planned)**: Unit tests for ViewModels/services with mocked dependencies

## Current Status
Core project scaffold is in place. The next implementation milestones are:
1. Domain entities and service interfaces
2. Authentication and account workflows
3. Transaction/transfer modules with persistence
4. Test suite and CI pipeline

## Future Enhancements
- Dark/Light theme support
- Scheduled transfers
- MSIX installer packaging
- CI/CD quality gates
