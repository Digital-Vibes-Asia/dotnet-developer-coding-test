using EmployeeDepartmentReport.Api.Models;

namespace EmployeeDepartmentReport.Api.Services;

/// <summary>
/// Provides read access to employee data and department reporting.
/// </summary>
public interface IEmployeeService
{
    /// <summary>Gets the full list of employees.</summary>
    Task<IReadOnlyList<Employee>> GetEmployeesAsync();

    /// <summary>
    /// Gets the number of employees in each department, keyed by department name.
    /// Departments are ordered by descending headcount, then by name.
    /// </summary>
    Task<IReadOnlyDictionary<string, int>> GetHeadcountByDepartmentAsync();
}
