# Copilot-Learning

## HR Portal API

A comprehensive .NET 9.0 Web API for managing HR operations, including employee management and company policies.

## Features

- **Employee Management**
  - Create, read, update, and delete employee records
  - Track employee details: personal info, department, position, salary, employment type
  - Monitor employee status (Active, Inactive, On Leave)
  
- **Company Policy Management**
  - Manage company policies with categories (Leave, Attendance, Code of Conduct, Benefits, etc.)
  - Set effective and expiry dates for policies
  - Define policy applicability (All, Department-specific, Position-specific)
  - Enable/disable policies as needed

- **RESTful API Design**
  - Standard HTTP methods (GET, POST, PUT, DELETE)
  - JSON request/response format
  - Proper HTTP status codes
  - OpenAPI/Swagger documentation

## Technology Stack

- .NET 9.0
- ASP.NET Core Web API
- In-memory data storage
- OpenAPI/Swagger for API documentation

## Getting Started

### Prerequisites

- .NET 9.0 SDK or later

### Running the Application

1. Navigate to the project directory:
   ```bash
   cd HRPortalAPI
   ```

2. Run the application:
   ```bash
   dotnet run
   ```

3. The API will be available at `http://localhost:5175`

4. Access OpenAPI documentation at `http://localhost:5175/openapi/v1.json`

### Building the Application

```bash
cd HRPortalAPI
dotnet build
```

## API Endpoints

### Employees

#### Get All Employees
```http
GET /api/employees
```

#### Get Employee by ID
```http
GET /api/employees/{id}
```

#### Create Employee
```http
POST /api/employees
Content-Type: application/json

{
  "firstName": "John",
  "lastName": "Doe",
  "email": "john.doe@company.com",
  "phone": "+1-555-0123",
  "department": "Engineering",
  "position": "Software Engineer",
  "dateOfJoining": "2024-01-15T00:00:00Z",
  "salary": 85000,
  "employeeType": "Full-time"
}
```

#### Update Employee
```http
PUT /api/employees/{id}
Content-Type: application/json

{
  "salary": 90000,
  "position": "Senior Software Engineer"
}
```

#### Delete Employee
```http
DELETE /api/employees/{id}
```

### Company Policies

#### Get All Policies
```http
GET /api/companypolicies
```

#### Get Policy by ID
```http
GET /api/companypolicies/{id}
```

#### Create Policy
```http
POST /api/companypolicies
Content-Type: application/json

{
  "title": "Annual Leave Policy",
  "description": "Employees are entitled to 20 days of paid annual leave per year.",
  "category": "Leave",
  "effectiveDate": "2024-01-01T00:00:00Z",
  "expiryDate": null,
  "applicableTo": "All"
}
```

#### Update Policy
```http
PUT /api/companypolicies/{id}
Content-Type: application/json

{
  "isActive": false
}
```

#### Delete Policy
```http
DELETE /api/companypolicies/{id}
```

## Project Structure

```
HRPortalAPI/
├── Controllers/          # API Controllers
│   ├── EmployeesController.cs
│   └── CompanyPoliciesController.cs
├── Models/              # Domain Models
│   ├── Employee.cs
│   └── CompanyPolicy.cs
├── DTOs/                # Data Transfer Objects
│   ├── EmployeeDTOs.cs
│   └── CompanyPolicyDTOs.cs
├── Services/            # Business Logic Services
│   ├── IEmployeeService.cs
│   ├── EmployeeService.cs
│   ├── ICompanyPolicyService.cs
│   └── CompanyPolicyService.cs
└── Program.cs           # Application Entry Point
```

## Data Models

### Employee
- ID (auto-generated)
- First Name
- Last Name
- Email
- Phone
- Department
- Position
- Date of Joining
- Salary
- Employee Type (Full-time, Part-time, Contract)
- Status (Active, Inactive, On Leave)
- Created At (timestamp)
- Updated At (timestamp)

### Company Policy
- ID (auto-generated)
- Title
- Description
- Category (Leave, Attendance, Code of Conduct, Benefits, etc.)
- Effective Date
- Expiry Date (optional)
- Is Active
- Applicable To (All, Department-specific, Position-specific)
- Created At (timestamp)
- Updated At (timestamp)

## Future Enhancements

- Database integration (SQL Server, PostgreSQL)
- Authentication and authorization
- Employee attendance tracking
- Leave management system
- Performance review management
- Department hierarchy management
- Reporting and analytics
- File upload for employee documents
- Email notifications