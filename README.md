# First-Stage .NET Developer Coding Test

## Overview & Duration

**Time:** 2 hours  
**Language/Framework:** C# (.NET Core 6+)  
**Deliverable:** GitHub repo (or ZIP) containing your solution and a brief README

## Task: Employee Department Report

Build a small ASP .NET Core Web API that provides a headcount report per department.

---

### 1. Data Model

```csharp
public class Employee
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Department { get; set; }
    public DateTime JoinDate { get; set; }
}
```

---

### 2. In-Memory Data Store

- Seed the application with at least 10 employees across 3 departments in Startup or Program.

---

### 3. Endpoints

- `GET /api/employees` – Returns the full employee list.
- `GET /api/report/headcount` – Returns a JSON object with department headcounts.

Example:
```json
{
  "Sales": 4,
  "HR": 3,
  "IT": 3
}
```

---

### 4. Implementation Details

- Use .NET Core Web API with attribute routing.
- Implement async methods.
- No database—use an in-memory list.
- Write one unit test (xUnit or NUnit) that verifies the headcount report.
- Add Swagger/OpenAPI support to document your endpoints.

---

### Evaluation Criteria

- **Correctness:** Endpoints return the expected data.
- **Code Quality:** Clean structure and naming.
- **Async Usage:** Proper use of async/await.
- **Testing:** Presence and quality of the unit test.
- **Documentation:** Clear README with instructions.

---

### Submission Instructions

1. Push your code to a GitHub repo or send a ZIP.
2. Include a README.md with:
   - How to build and run the API
   - How to execute the unit test
3. Share the link or file within 2 hours of receiving this test.

---

*This is a placeholder for the exercise details only. No solution is provided.*
