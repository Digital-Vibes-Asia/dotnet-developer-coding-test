namespace EmployeeDepartmentReport.Api.Models;

/// <summary>
/// Represents a single employee held in the in-memory data store.
/// </summary>
public class Employee
{
    /// <summary>Unique identifier for the employee.</summary>
    public int Id { get; set; }

    /// <summary>The employee's full name.</summary>
    public string FullName { get; set; } = string.Empty;

    /// <summary>The department the employee belongs to (e.g. "Sales").</summary>
    public string Department { get; set; } = string.Empty;

    /// <summary>The date the employee joined the company.</summary>
    public DateTime JoinDate { get; set; }
}
