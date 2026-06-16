# Employee Department Report API

A small ASP.NET Core (.NET 8) Web API that serves an employee list and a
per-department headcount report from an in-memory data store. Built for the
[first-stage .NET developer coding test](#assignment) described at the bottom of
this file.

## Tech stack

- **.NET 8** / ASP.NET Core Web API (controllers + attribute routing)
- **Swashbuckle.AspNetCore** for Swagger / OpenAPI
- **xUnit** for unit testing
- In-memory data store (no database)

## Project structure

```
EmployeeDepartmentReport.sln
├── src/
│   └── EmployeeDepartmentReport.Api/
│       ├── Controllers/
│       │   ├── EmployeesController.cs   # GET /api/employees
│       │   └── ReportController.cs      # GET /api/report/headcount
│       ├── Models/
│       │   └── Employee.cs              # Id, FullName, Department, JoinDate
│       ├── Services/
│       │   ├── IEmployeeService.cs      # Abstraction (enables testing & DI)
│       │   └── EmployeeService.cs       # In-memory seed data + reporting logic
│       └── Program.cs                   # DI, Swagger, routing
└── tests/
    └── EmployeeDepartmentReport.Tests/
        └── HeadcountReportTests.cs      # Verifies the headcount report
```

The HTTP/reporting logic lives in `EmployeeService` behind the `IEmployeeService`
interface. Controllers stay thin and simply delegate to the service, which keeps
the report logic easy to unit-test in isolation.

## Prerequisites

- [.NET SDK 8.0+](https://dotnet.microsoft.com/download)

Verify with:

```bash
dotnet --version
```

## Build & run

From the repository root:

```bash
# Restore + build
dotnet build

# Run the API
dotnet run --project src/EmployeeDepartmentReport.Api
```

By default the API listens on `http://localhost:5162` (see
`src/EmployeeDepartmentReport.Api/Properties/launchSettings.json`). To pin a
specific URL:

```bash
dotnet run --project src/EmployeeDepartmentReport.Api --urls http://localhost:5199
```

Browsing to the root (`/`) redirects to the Swagger UI.

## Endpoints

| Method | Route                    | Description                          |
| ------ | ------------------------ | ------------------------------------ |
| GET    | `/api/employees`         | Returns the full employee list.      |
| GET    | `/api/report/headcount`  | Returns the headcount per department.|

### Examples

```bash
curl http://localhost:5162/api/employees
curl http://localhost:5162/api/report/headcount
```

`GET /api/report/headcount` returns a JSON object keyed by department name
(ordered by descending headcount, then by name):

```json
{
  "Sales": 4,
  "HR": 3,
  "IT": 3
}
```

## API documentation (Swagger)

Swagger/OpenAPI is enabled in every environment. With the app running:

- **Swagger UI:** `http://localhost:5162/swagger`
- **OpenAPI JSON:** `http://localhost:5162/swagger/v1/swagger.json`

XML documentation comments are surfaced in the Swagger UI so each endpoint is
described inline.

## Run the unit tests

```bash
dotnet test
```

`HeadcountReportTests` verifies the report contract:

- each department (`Sales`, `HR`, `IT`) has the expected headcount,
- the report covers exactly three departments, and
- the headcounts sum to the total number of seeded employees.

## Design notes

- **Async:** service methods are `async`-friendly (`Task`-returning) so the API
  is ready to swap the in-memory store for a real async data source without
  changing the controllers.
- **Singleton data store:** the seed data is immutable and shared across
  requests, so `EmployeeService` is registered as a singleton.
- **Deterministic report order:** departments are ordered by descending
  headcount, then by name, giving stable, readable output.

---

## Assignment

<details>
<summary>Original coding-test brief</summary>

### First-Stage .NET Developer Coding Test

**Time:** 2 hours
**Language/Framework:** C# (.NET Core 6+)
**Deliverable:** GitHub repo (or ZIP) containing your solution and a brief README

#### Task: Employee Department Report

Build a small ASP.NET Core Web API that provides a headcount report per department.

**1. Data Model**

```csharp
public class Employee
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Department { get; set; }
    public DateTime JoinDate { get; set; }
}
```

**2. In-Memory Data Store** — Seed the application with at least 10 employees
across 3 departments in Startup or Program.

**3. Endpoints**

- `GET /api/employees` – Returns the full employee list.
- `GET /api/report/headcount` – Returns a JSON object with department headcounts.

```json
{
  "Sales": 4,
  "HR": 3,
  "IT": 3
}
```

**4. Implementation Details**

- Use .NET Core Web API with attribute routing.
- Implement async methods.
- No database—use an in-memory list.
- Write one unit test (xUnit or NUnit) that verifies the headcount report.
- Add Swagger/OpenAPI support to document your endpoints.

#### Evaluation Criteria

- **Correctness:** Endpoints return the expected data.
- **Code Quality:** Clean structure and naming.
- **Async Usage:** Proper use of async/await.
- **Testing:** Presence and quality of the unit test.
- **Documentation:** Clear README with instructions.

</details>
