using System.Reflection;
using EmployeeDepartmentReport.Api.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// MVC controllers (attribute routing).
builder.Services.AddControllers();

// In-memory employee data store. Registered as a singleton because the
// seed data is immutable and shared across all requests (no database).
builder.Services.AddSingleton<IEmployeeService, EmployeeService>();

// Swagger / OpenAPI.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Employee Department Report API",
        Version = "v1",
        Description = "Returns the employee list and a per-department headcount report."
    });

    // Surface the XML doc comments (summaries, examples) in the Swagger UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        options.IncludeXmlComments(xmlPath);
    }
});

var app = builder.Build();

// Expose Swagger in every environment so the API is easy to explore.
app.UseSwagger();
app.UseSwaggerUI();

// Send the site root straight to the Swagger UI for convenience.
app.MapGet("/", () => Results.Redirect("/swagger"))
   .ExcludeFromDescription();

app.MapControllers();

app.Run();
