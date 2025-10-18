using HRPortalAPI.Models;

namespace HRPortalAPI.Services;

public class EmployeeService : IEmployeeService
{
    private readonly List<Employee> _employees = new();
    private int _nextId = 1;

    public Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        return Task.FromResult<IEnumerable<Employee>>(_employees);
    }

    public Task<Employee?> GetEmployeeByIdAsync(int id)
    {
        var employee = _employees.FirstOrDefault(e => e.Id == id);
        return Task.FromResult(employee);
    }

    public Task<Employee> CreateEmployeeAsync(Employee employee)
    {
        employee.Id = _nextId++;
        employee.CreatedAt = DateTime.UtcNow;
        employee.UpdatedAt = DateTime.UtcNow;
        _employees.Add(employee);
        return Task.FromResult(employee);
    }

    public Task<Employee?> UpdateEmployeeAsync(int id, Employee employee)
    {
        var existingEmployee = _employees.FirstOrDefault(e => e.Id == id);
        if (existingEmployee == null)
        {
            return Task.FromResult<Employee?>(null);
        }

        existingEmployee.FirstName = employee.FirstName;
        existingEmployee.LastName = employee.LastName;
        existingEmployee.Email = employee.Email;
        existingEmployee.Phone = employee.Phone;
        existingEmployee.Department = employee.Department;
        existingEmployee.Position = employee.Position;
        existingEmployee.DateOfJoining = employee.DateOfJoining;
        existingEmployee.Salary = employee.Salary;
        existingEmployee.EmployeeType = employee.EmployeeType;
        existingEmployee.Status = employee.Status;
        existingEmployee.UpdatedAt = DateTime.UtcNow;

        return Task.FromResult<Employee?>(existingEmployee);
    }

    public Task<bool> DeleteEmployeeAsync(int id)
    {
        var employee = _employees.FirstOrDefault(e => e.Id == id);
        if (employee == null)
        {
            return Task.FromResult(false);
        }

        _employees.Remove(employee);
        return Task.FromResult(true);
    }
}
