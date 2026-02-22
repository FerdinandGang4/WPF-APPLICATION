namespace BankingApp.Models;

public enum UserRole
{
    Customer = 0,
    Admin = 1,
}

public enum AccountType
{
    Checking = 0,
    Savings = 1,
    Business = 2,
    Credit = 3,
}

public enum AccountStatus
{
    Active = 0,
    Frozen = 1,
    Closed = 2,
}

public enum TransactionType
{
    Deposit = 0,
    Withdrawal = 1,
    TransferIn = 2,
    TransferOut = 3,
    Fee = 4,
    Interest = 5,
}

public enum TransferStatus
{
    Pending = 0,
    Completed = 1,
    Failed = 2,
    Reversed = 3,
}
