using HRPortalAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

// Register services as Singletons for in-memory storage
builder.Services.AddSingleton<IEmployeeService, EmployeeService>();
builder.Services.AddSingleton<ICompanyPolicyService, CompanyPolicyService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
