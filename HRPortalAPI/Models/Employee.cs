namespace HRPortalAPI.Models;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public DateTime DateOfJoining { get; set; }
    public decimal Salary { get; set; }
    public string EmployeeType { get; set; } = string.Empty; // Full-time, Part-time, Contract
    public string Status { get; set; } = "Active"; // Active, Inactive, On Leave
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
