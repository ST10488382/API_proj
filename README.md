# RaceDay Web API

A RESTful backend service built with .NET 8 and Entity Framework Core for managing sports events, user registrations, event categories, and race results.

##  Tech Stack & Prerequisites
* **Framework:** .NET 8.0 Web API
* **Database:** SQL Server / LocalDB
* **Documentation:** Swagger / OpenAPI
* **CI/CD:** GitHub Actions

##  How to Run
1. Clone the repository:
   ```bash
   git clone [https://github.com/ST10488382/API_proj.git](https://github.com/ST10488382/API_proj.git)
   dotnet restore
   dotnet run
   ## Part 3 Implementation & System Updates

### Key API & Architectural Changes
- **JWT & Claim Resolution**: Updated `EventsController` to dynamically resolve user identities using `ClaimTypes.NameIdentifier` with a fallback mechanism.
- **Role-Based Authorization**: Added `[Authorize(Roles = "Organiser")]` attributes to restrict event mutation endpoints (Create, Update, Delete) strictly to authenticated organisers.
- **Frontend Integration**: Integrated Web API endpoints with the MVC frontend client, aligning property casing and standardizing HTTP response payloads.

### CI/CD Pipeline Integration
- Implemented an automated GitHub Actions workflow (`.github/workflows/main.yml`) that dynamically restores dependencies and compiles all `.csproj` project files on every push.
<img width="1313" height="440" alt="workflow screenshot" src="https://github.com/user-attachments/assets/be26d9f5-37a6-4bc5-bad8-1ff9e2ae4aa2" />

<img width="1332" height="359" alt="image" src="https://github.com/user-attachments/assets/c5eee932-4816-4d83-9fa4-c6b261e08d95" />
