# Employee Skills Management

## Technology

- .NET 8
- Blazor Server
- Entity Framework Core
- SQL Server

---

## Prerequisites

- Visual Studio 2022/2026
- .NET 8 SDK
- SQL Server LocalDB

---

## Configure Connection String

Edit appsettings.json

```json
"ConnectionStrings": {
  "DefaultConnection":
  "Server=(localdb)\\MSSQLLocalDB;Database=EmployeeSkillsDb;Trusted_Connection=True;TrustServerCertificate=True"
}
```

---

## Apply Migration

```
dotnet ef database update
```

---

## Run

```
dotnet run
```

Open

```
https://localhost:7011
```

---

## Features

- Employee CRUD
- Skill Management
- Many-to-Many Relationship
- Validation
- Delete Confirmation

---

## Design Decisions

Employee and Skill have a many-to-many relationship using EF Core.

Skills are seeded during application startup.

Validation is implemented using Data Annotations.

---

## Future Improvements

- Search
- Pagination
- Unit Tests
- Authentication