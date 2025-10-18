namespace HRPortalAPI.DTOs;

public record CreateEmployeeRequest(
    string FirstName,
    string LastName,
    string Email,
    string Phone,
    string Department,
    string Position,
    DateTime DateOfJoining,
    decimal Salary,
    string EmployeeType
);

public record UpdateEmployeeRequest(
    string? FirstName,
    string? LastName,
    string? Email,
    string? Phone,
    string? Department,
    string? Position,
    DateTime? DateOfJoining,
    decimal? Salary,
    string? EmployeeType,
    string? Status
);

public record EmployeeResponse(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    string Phone,
    string Department,
    string Position,
    DateTime DateOfJoining,
    decimal Salary,
    string EmployeeType,
    string Status,
    DateTime CreatedAt,
    DateTime UpdatedAt
);
