# Employee Skills Management

A simple Employee & Skills Management application built with **.NET 8**, **Blazor Server**, **Entity Framework Core**, and **SQL Server**.

---

# Technology Stack

- .NET 8
- C#
- Blazor Server
- Entity Framework Core (Code First)
- SQL Server LocalDB

---

# Prerequisites

- Visual Studio 2026 (17.8 or later)
- .NET 8 SDK
- SQL Server LocalDB

---

# Clone Repository

```bash
git clone <https://github.com/DotNetTeam-Prem/Employee-Skills-Management-Application.git>
cd EmployeeSkills.Web
```

---

# Configure Connection String

Open **appsettings.json** and update the connection string if required.
json
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=EmployeeSkillsDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
  }

---

# Create / Update Database

Apply the Entity Framework Core migrations.

**bash**
dotnet ef database update
////The application also seeds the predefined skills automatically on startup.

# Build and Run
**bash**
dotnet build
dotnet run

////Open the application in your browser:
https://localhost:7011

# Features
- Employee CRUD (Create, Read, Update, Delete)
- Employee Search
- Delete Confirmation
- Employee Skills (Many-to-Many)
- Server-side Validation
- Seeded Skills
- Reusable Blazor Components

# Validation
The application validates:

1.First Name (Required)
2.Last Name (Required)
3.Date of Birth (Required and must be in the past)
4.Phone Number (Required with Regex validation)
5.At least one Skill must be selected

# Database
Database Used:

**SQL Server (LocalDB)**
Reason:
- Easy setup with Visual Studio
- Fully supported by Entity Framework Core
- Suitable for local development and assessment projects

# Project Structure
Components/
    Layout/
        MainLayout.razor
        NavMenu.razor
    Pages/
        Employee/
            EmployeeAdd.razor
            EmployeeEdit.razor
            Employees.razor
        Home.razor
    Shared/
        DatePicker.razor    
        EmployeeForm.razor
        FormButtons.razor
        SkillSelector.razor
        TextInput.razor
    _import.razor
    App.razor
    Routes.razor


Data/
    ApplicationDbContext.cs
    DbSeeder.cs

Helpers/
    TextHelper.cs

IServices/
    IEmployeeService.cs

Models/
    Employee.cs
    Skill.cs

ViewModels/
    EmployeeViewModel.cs

Services/
    EmployeeService.cs

Validation/
    PastDateAttribute.cs
