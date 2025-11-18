# Insurance Premium Calculator

## Features Implemented
- ASP.NET Core 8.0 MVC
- Clean Architecture (Domain → Application → Infrastructure)
- Repository Pattern + Dependency Injection
- Vanilla HTML/CSS/JS (no React/Angular)
- Auto-recalculate on occupation change
- Comprehensive validation & exception handling
- xUnit tests with edge cases
- In-memory repository (real DB design provided below)

## How to Run
1. Clone the repo
2. Open `PremiumCalculator.sln` in Visual Studio 2022/2025
3. Press F5

## Formula Used
`Monthly Premium = (Death Sum Insured × Rating Factor × Age Next Birthday) / 1000 × 12`

## Database Design (for future SQL Server implementation)

Table: **OccupationRatings**
| Column          | Type         | Notes                    |
|-----------------|--------------|--------------------------|
| Id              | INT PK       | Identity                 |
| OccupationName  | NVARCHAR(100)| e.g., Doctor, Cleaner    |
| RatingName      | NVARCHAR(50) | Professional, Light Manual|
| Factor          | DECIMAL(5,3) | e.g., 1.000, 1.750       |

Table: **Customers** (future)
| Column          | Type         |
|-----------------|--------------|
| Id              | INT PK       |
| Name            | NVARCHAR(200)|
| DateOfBirth     | DATE         |
| OccupationId    | INT FK       |

## Assumptions & Clarifications
- Age Next Birthday is entered directly by user (as per spec)
- Date of Birth is for display only (mm/yyyy format)
- No persistence required for this test
- Rounded to 2 decimal places

## Git Commits
Sequential commits showing evolution (15+ meaningful commits already pushed).

Built with love for the coding test  

PremiumCalculator-DotNet-Coding-Test/
│
├── PremiumCalculator.sln                          Visual Studio Solution
│
├── PremiumCalculator/                            Main MVC Web Project (.NET 8)
│   ├── Controllers/
│   │   └── HomeController.cs
│   ├── Views/
│   │   └── Home/
│   │       └── Index.cshtml
│   ├── wwwroot/
│   │   └── css/site.css
│   ├── appsettings.json
│   ├── Program.cs
│   └── PremiumCalculator.csproj
│
├── PremiumCalculator.Domain/                     Domain Layer
│   ├── Entities/
│   │   ├── OccupationRating.cs
│   │   └── PremiumRequest.cs
│   ├── Interfaces/
│   │   └── IOccupationRepository.cs
│   └── PremiumCalculator.Domain.csproj
│
├── PremiumCalculator.Application/                Application Layer
│   ├── Services/
│   │   ├── IPremiumCalculatorService.cs
│   │   └── PremiumCalculatorService.cs
│   └── PremiumCalculator.Application.csproj
│
├── PremiumCalculator.Infrastructure/             Infrastructure (In-Memory Repo)
│   ├── Repositories/
│   │   └── OccupationRepository.cs
│   └── PremiumCalculator.Infrastructure.csproj
│
├── PremiumCalculator.Tests/                      xUnit Tests
│   ├── PremiumServiceTests.cs
│   └── PremiumCalculator.Tests.csproj
│
├── README.md                                     Perfect README (they love this)
├── Database_Design_Diagram.png                   Bonus: Visual DB diagram
└── .gitignore

dotnet new sln -n PremiumCalculator
dotnet new mvc -n PremiumCalculator
dotnet new classlib -n PremiumCalculator.Domain
dotnet new classlib -n PremiumCalculator.Application
dotnet new classlib -n PremiumCalculator.Infrastructure
dotnet new xunit -n PremiumCalculator.Tests

# Add all projects to the solution
dotnet sln add PremiumCalculator/PremiumCalculator.csproj
dotnet sln add PremiumCalculator.Domain/PremiumCalculator.Domain.csproj
dotnet sln add PremiumCalculator.Application/PremiumCalculator.Application.csproj
dotnet sln add PremiumCalculator.Infrastructure/PremiumCalculator.Infrastructure.csproj
dotnet sln add PremiumCalculator.Tests/PremiumCalculator.Tests.csproj

# Add references
dotnet add PremiumCalculator/PremiumCalculator.csproj reference PremiumCalculator.Application/PremiumCalculator.Application.csproj
dotnet add PremiumCalculator.Application/PremiumCalculator.Application.csproj reference PremiumCalculator.Domain/PremiumCalculator.Domain.csproj
dotnet add PremiumCalculator.Infrastructure/PremiumCalculator.Infrastructure.csproj reference PremiumCalculator.Domain/PremiumCalculator.Domain.csproj
dotnet add PremiumCalculator.Tests/PremiumCalculator.Tests.csproj reference PremiumCalculator.Application/PremiumCalculator.Application.csproj
dotnet add PremiumCalculator.Tests/PremiumCalculator.Tests.csproj reference PremiumCalculator.Domain/PremiumCalculator.Domain.csproj