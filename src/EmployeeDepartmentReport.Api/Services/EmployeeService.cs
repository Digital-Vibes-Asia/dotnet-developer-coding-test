using EmployeeDepartmentReport.Api.Models;

namespace EmployeeDepartmentReport.Api.Services;

/// <summary>
/// In-memory implementation of <see cref="IEmployeeService"/>.
/// The data set is seeded once at construction; no external database is used.
/// </summary>
public class EmployeeService : IEmployeeService
{
    private readonly IReadOnlyList<Employee> _employees;

    public EmployeeService()
    {
        _employees = SeedEmployees();
    }

    /// <inheritdoc />
    public Task<IReadOnlyList<Employee>> GetEmployeesAsync()
        => Task.FromResult(_employees);

    /// <inheritdoc />
    public Task<IReadOnlyDictionary<string, int>> GetHeadcountByDepartmentAsync()
    {
        IReadOnlyDictionary<string, int> headcount = _employees
            .GroupBy(employee => employee.Department)
            .OrderByDescending(group => group.Count())
            .ThenBy(group => group.Key, StringComparer.OrdinalIgnoreCase)
            .ToDictionary(group => group.Key, group => group.Count());

        return Task.FromResult(headcount);
    }

    /// <summary>Seeds 10 employees across 3 departments (Sales, HR, IT).</summary>
    private static IReadOnlyList<Employee> SeedEmployees() => new List<Employee>
    {
        // Sales (4)
        new() { Id = 1, FullName = "Alice Johnson", Department = "Sales", JoinDate = new DateTime(2019, 3, 12) },
        new() { Id = 2, FullName = "Brian Smith",   Department = "Sales", JoinDate = new DateTime(2020, 7, 1) },
        new() { Id = 3, FullName = "Carla Mendes",  Department = "Sales", JoinDate = new DateTime(2021, 1, 19) },
        new() { Id = 4, FullName = "David Okafor",  Department = "Sales", JoinDate = new DateTime(2022, 11, 5) },

        // HR (3)
        new() { Id = 5, FullName = "Emma Williams", Department = "HR", JoinDate = new DateTime(2018, 6, 23) },
        new() { Id = 6, FullName = "Farah Khan",    Department = "HR", JoinDate = new DateTime(2020, 2, 14) },
        new() { Id = 7, FullName = "Grace Lee",     Department = "HR", JoinDate = new DateTime(2023, 4, 9) },

        // IT (3)
        new() { Id = 8,  FullName = "Henry Nguyen", Department = "IT", JoinDate = new DateTime(2017, 9, 30) },
        new() { Id = 9,  FullName = "Isla Petrov",  Department = "IT", JoinDate = new DateTime(2021, 8, 17) },
        new() { Id = 10, FullName = "Jamal Brooks", Department = "IT", JoinDate = new DateTime(2022, 5, 28) },
    };
}
