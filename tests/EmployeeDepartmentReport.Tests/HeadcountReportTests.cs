using EmployeeDepartmentReport.Api.Services;

namespace EmployeeDepartmentReport.Tests;

/// <summary>
/// Verifies the per-department headcount report produced by <see cref="EmployeeService"/>.
/// </summary>
public class HeadcountReportTests
{
    private readonly EmployeeService _service = new();

    [Theory]
    [InlineData("Sales", 4)]
    [InlineData("HR", 3)]
    [InlineData("IT", 3)]
    public async Task GetHeadcountByDepartmentAsync_ReturnsExpectedCount_ForEachDepartment(
        string department, int expectedCount)
    {
        var headcount = await _service.GetHeadcountByDepartmentAsync();

        Assert.True(headcount.ContainsKey(department), $"Expected a '{department}' department.");
        Assert.Equal(expectedCount, headcount[department]);
    }

    [Fact]
    public async Task GetHeadcountByDepartmentAsync_CoversExactlyThreeDepartments()
    {
        var headcount = await _service.GetHeadcountByDepartmentAsync();

        Assert.Equal(3, headcount.Count);
    }

    [Fact]
    public async Task GetHeadcountByDepartmentAsync_TotalEqualsEmployeeCount()
    {
        var employees = await _service.GetEmployeesAsync();
        var headcount = await _service.GetHeadcountByDepartmentAsync();

        Assert.Equal(employees.Count, headcount.Values.Sum());
    }
}
