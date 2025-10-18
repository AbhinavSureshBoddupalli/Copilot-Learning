using Microsoft.AspNetCore.Mvc;
using HRPortalAPI.DTOs;
using HRPortalAPI.Models;
using HRPortalAPI.Services;

namespace HRPortalAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeResponse>>> GetAllEmployees()
    {
        var employees = await _employeeService.GetAllEmployeesAsync();
        var response = employees.Select(e => MapToResponse(e));
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EmployeeResponse>> GetEmployee(int id)
    {
        var employee = await _employeeService.GetEmployeeByIdAsync(id);
        if (employee == null)
        {
            return NotFound(new { message = $"Employee with ID {id} not found" });
        }

        return Ok(MapToResponse(employee));
    }

    [HttpPost]
    public async Task<ActionResult<EmployeeResponse>> CreateEmployee(CreateEmployeeRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.FirstName) || string.IsNullOrWhiteSpace(request.LastName))
        {
            return BadRequest(new { message = "First name and last name are required" });
        }

        if (string.IsNullOrWhiteSpace(request.Email))
        {
            return BadRequest(new { message = "Email is required" });
        }

        var employee = new Employee
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Phone = request.Phone,
            Department = request.Department,
            Position = request.Position,
            DateOfJoining = request.DateOfJoining,
            Salary = request.Salary,
            EmployeeType = request.EmployeeType,
            Status = "Active"
        };

        var createdEmployee = await _employeeService.CreateEmployeeAsync(employee);
        return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.Id }, MapToResponse(createdEmployee));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<EmployeeResponse>> UpdateEmployee(int id, UpdateEmployeeRequest request)
    {
        var existingEmployee = await _employeeService.GetEmployeeByIdAsync(id);
        if (existingEmployee == null)
        {
            return NotFound(new { message = $"Employee with ID {id} not found" });
        }

        // Update only provided fields
        if (request.FirstName != null) existingEmployee.FirstName = request.FirstName;
        if (request.LastName != null) existingEmployee.LastName = request.LastName;
        if (request.Email != null) existingEmployee.Email = request.Email;
        if (request.Phone != null) existingEmployee.Phone = request.Phone;
        if (request.Department != null) existingEmployee.Department = request.Department;
        if (request.Position != null) existingEmployee.Position = request.Position;
        if (request.DateOfJoining.HasValue) existingEmployee.DateOfJoining = request.DateOfJoining.Value;
        if (request.Salary.HasValue) existingEmployee.Salary = request.Salary.Value;
        if (request.EmployeeType != null) existingEmployee.EmployeeType = request.EmployeeType;
        if (request.Status != null) existingEmployee.Status = request.Status;

        var updatedEmployee = await _employeeService.UpdateEmployeeAsync(id, existingEmployee);
        return Ok(MapToResponse(updatedEmployee!));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        var result = await _employeeService.DeleteEmployeeAsync(id);
        if (!result)
        {
            return NotFound(new { message = $"Employee with ID {id} not found" });
        }

        return NoContent();
    }

    private static EmployeeResponse MapToResponse(Employee employee)
    {
        return new EmployeeResponse(
            employee.Id,
            employee.FirstName,
            employee.LastName,
            employee.Email,
            employee.Phone,
            employee.Department,
            employee.Position,
            employee.DateOfJoining,
            employee.Salary,
            employee.EmployeeType,
            employee.Status,
            employee.CreatedAt,
            employee.UpdatedAt
        );
    }
}
