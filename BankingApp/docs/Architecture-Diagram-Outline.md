# One-Page Architecture Diagram Outline

Use this outline to create a single architecture diagram slide/page for interviews and technical reviews.

## 1) Diagram Goal
Show how a WPF banking client enforces MVVM separation, routes use-cases through services, applies domain rules, and persists data safely with auditing.

## 2) Recommended Layout (Left to Right)
1. **Presentation (WPF + MVVM)**
2. **Application Services (Use Cases)**
3. **Domain (Entities + Rules)**
4. **Infrastructure (EF Core/SQLite, Logging, Config)**
5. **Data Store (SQLite DB)**

Add a top bar for **Cross-Cutting Concerns** and a bottom strip for **Testing**.

## 3) Boxes and Labels
### A. Presentation Layer
- Views: `LoginView`, `DashboardView`, `TransactionsView`, `TransfersView`, `PayeesView`
- ViewModels: `LoginViewModel`, `DashboardViewModel`, `TransactionsViewModel`, `TransferViewModel`
- Mechanisms: `INotifyPropertyChanged`, `ICommand`, input validation, session timeout UX

### B. Application Layer
- Services:
  - `IAuthenticationService`
  - `IAccountService`
  - `ITransactionService`
  - `ITransferService`
  - `IPayeeService`
  - `IStatementService`
  - `IAdminService` (optional)
- Responsibilities: orchestration, validation flow, transaction boundaries, DTO mapping

### C. Domain Layer
- Entities: `User`, `CustomerProfile`, `Account`, `Transaction`, `Transfer`, `Payee`, `AuditLog`
- Rules:
  - No overdraft unless policy allows
  - Valid transfer endpoints
  - Immutable transaction history records
  - Role checks for admin actions

### D. Infrastructure Layer
- Repositories and EF Core DbContext
- SQLite provider
- Password hasher (PBKDF2/BCrypt)
- Structured logger
- Config provider
- Export adapters (CSV/PDF)

### E. Data Store
- SQLite database
- Tables aligned to domain entities
- Audit trail storage

## 4) Primary Flow Arrows
1. User action in View -> ViewModel Command
2. ViewModel -> Application Service
3. Service -> Domain validation/rules
4. Service -> Repository/DbContext
5. Repository -> SQLite
6. Result path back to ViewModel -> View

Use bidirectional arrows for request/response; highlight write paths (transfers, payee CRUD) in a different color.

## 5) Security and Reliability Callouts (Top Bar)
- Password hashing and salted verification
- Role-based access control
- Audit logging on auth/admin/high-risk operations
- Global exception handling
- Input validation and data masking

## 6) Testing Strip (Bottom)
- Unit tests: ViewModels, validators, services
- Mocked repositories and infrastructure interfaces
- Transfer atomicity and negative-balance tests
- Export format/date-range correctness tests

## 7) Suggested Visual Legend
- Blue: Presentation
- Green: Application services
- Orange: Domain rules
- Gray: Infrastructure
- Dark gray cylinder: Database
- Dashed lines: interface boundaries
- Shield icon: security controls

## 8) Optional Sequence Inset
Include a small "Transfer Funds" sequence inset:
1. `TransferViewModel.SubmitTransferCommand`
2. `ITransferService.ExecuteTransferAsync`
3. Validate balance + destination
4. Begin transaction scope
5. Debit source + credit destination
6. Persist transfer + audit log
7. Commit or rollback

## 9) Interview Talking Points (Use Beside Diagram)
- Why MVVM improves testability and maintainability
- How DI keeps services/repositories replaceable
- How atomic transfer logic prevents inconsistent balances
- Where logging/auditing supports production diagnostics and compliance
