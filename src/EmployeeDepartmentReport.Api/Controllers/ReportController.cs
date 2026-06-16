using EmployeeDepartmentReport.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDepartmentReport.Api.Controllers;

/// <summary>
/// Endpoints for department reporting.
/// </summary>
[ApiController]
[Route("api/report")]
[Produces("application/json")]
public class ReportController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public ReportController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    /// <summary>
    /// Returns the number of employees in each department,
    /// e.g. <c>{ "Sales": 4, "HR": 3, "IT": 3 }</c>.
    /// </summary>
    /// <response code="200">A map of department name to headcount.</response>
    [HttpGet("headcount")]
    [ProducesResponseType(typeof(IDictionary<string, int>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyDictionary<string, int>>> GetHeadcount()
    {
        var headcount = await _employeeService.GetHeadcountByDepartmentAsync();
        return Ok(headcount);
    }
}
