using EmployeeDepartmentReport.Api.Models;
using EmployeeDepartmentReport.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDepartmentReport.Api.Controllers;

/// <summary>
/// Endpoints for retrieving employee records.
/// </summary>
[ApiController]
[Route("api/employees")]
[Produces("application/json")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    /// <summary>Returns the full employee list.</summary>
    /// <response code="200">The list of employees.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Employee>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<Employee>>> GetEmployees()
    {
        var employees = await _employeeService.GetEmployeesAsync();
        return Ok(employees);
    }
}
