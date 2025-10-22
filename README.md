# Bus Ticket Reservation System

[![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?style=for-the-badge&logo=dotnet)](https://dotnet.microsoft.com/)
[![Angular](https://img.shields.io/badge/Angular-18+-DD0031?style=for-the-badge&logo=angular)](https://angular.io/)
[![TypeScript](https://img.shields.io/badge/TypeScript-5.0-3178C6?style=for-the-badge&logo=typescript)](https://www.typescriptlang.org/)
[![SQLite](https://img.shields.io/badge/SQLite-3-003B57?style=for-the-badge&logo=sqlite)](https://www.sqlite.org/)
[![xUnit](https://img.shields.io/badge/xUnit-65%2B%20Tests-5E2C8C?style=for-the-badge)](https://xunit.net/)

A full‑stack Bus Ticket Reservation System built with .NET 9 (Backend) and Angular 18 (Frontend). The project follows Clean Architecture and Domain‑Driven Design (DDD) principles and includes real‑time seat availability via SignalR.

---

## Table of Contents

- [Project Overview](#project-overview)
- [Features](#features)
- [Architecture](#architecture)
- [Technology Stack](#technology-stack)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
  - [Backend Setup](#backend-setup)
  - [Frontend Setup](#frontend-setup)
  - [Database & Migrations](#database--migrations)
- [API Endpoints](#api-endpoints)
- [Testing](#testing)
- [Troubleshooting](#troubleshooting)
- [Project Statistics](#project-statistics)
- [Contributing](#contributing)
- [License](#license)
- [Author](#author)
- [Acknowledgments](#acknowledgments)

---

## Project Overview

This system allows users to search for buses between cities on a given date, view seat layouts with availability, select seats, and book tickets. Real‑time updates are provided using SignalR to reflect seat availability immediately.

Key goals:
- Clean Architecture and DDD
- Reliable booking transactions with conflict handling
- Real-time seat updates via SignalR
- Frontend: Angular SPA with responsive UI

---

## Features

- Search buses by source, destination, and journey date
- View visual seat layout with availability
- Book seats with passenger details (email, phone, etc.)
- Real-time seat availability updates (SignalR)
- Booking confirmations and basic booking lifecycle
- SQLite (default) for easy local development
- Swagger API documentation
- 65+ unit tests (xUnit) with high coverage

---

## Architecture

Clean Architecture / DDD with these high-level layers:

- BusReservation.Domain — Entities, Value Objects, Domain Services, Aggregates
- BusReservation.Application — Use cases, services, DTOs
- BusReservation.Infrastructure — EF Core DbContext, repositories, migrations
- BusReservation.API — ASP.NET Core Web API controllers, SignalR hubs
- Frontend — Angular app (components, services, models)
- BusReservation.Tests — xUnit tests

Common patterns used: Repository, Unit of Work (DbContext), Dependency Injection, Domain Events, Value Objects.

---

## Technology Stack

- Backend: .NET 9, C#, ASP.NET Core Web API
- ORM: Entity Framework Core (SQLite by default, can be switched to PostgreSQL)
- Realtime: SignalR
- Frontend: Angular 18, TypeScript, RxJS
- Testing: xUnit, Moq
- Database: SQLite (Backend/BusReservation.API/BusReservation.db by default)

---

## Prerequisites

- .NET 9 SDK
- Node.js 18+ and npm
- Angular CLI (optional for global use)
- Git
- (Optional) Visual Studio 2022 or VS Code

---

## Getting Started

Clone the repository:

```bash
git clone https://github.com/khanramjan/bus-reservation.git
cd bus-reservation
```

### Backend Setup

1. Open a terminal in the Backend directory (or repository root if structured differently):

```bash
cd Backend
dotnet restore
```

2. Update connection string in `appsettings.json` if needed. Default uses SQLite:

```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=BusReservation.db"
}
```

3. Apply migrations and create the database:

```bash
# From repository root or Backend folder
dotnet ef database update --project BusReservation.Infrastructure --startup-project BusReservation.API
```

4. Run the API:

```bash
cd BusReservation.API
# Set environment for development (PowerShell)
$env:ASPNETCORE_ENVIRONMENT="Development"
dotnet run
```

Note: The console will show the actual listening ports (commonly http://localhost:5000 or https://localhost:7000).

Swagger UI will be available at: `http://localhost:5000/swagger` (or check the running port).

### Frontend Setup

1. Open a terminal in the Frontend folder:

```bash
cd Frontend
npm install
```

2. Configure API URL if needed in `src/environments/environment.ts`:

```typescript
export const environment = {
  production: false,
  apiUrl: 'http://localhost:5000/api',
  hubUrl: 'http://localhost:5000/booking-hub'
};
```

3. Run Angular dev server:

```bash
npm start
# or
ng serve
```

Open the app in the browser at: `http://localhost:4200`.

---

## Database & Seed Data

- The project includes seed data: ~527 schedules (spanning Oct 22 - Nov 13, 2025) and approx. 4,800+ seats total (40 seats per bus).
- SQLite database file location: `Backend/BusReservation.API/BusReservation.db`.
- To reset the DB:

```bash
rm Backend/BusReservation.API/BusReservation.db
dotnet ef database update --project BusReservation.Infrastructure --startup-project BusReservation.API
```

To change to PostgreSQL, update the DbContext provider and connection string and install `Npgsql.EntityFrameworkCore.PostgreSQL`.

---

## API Endpoints (examples)

- Search buses
  - POST /api/schedules/search
  - Body:
    ```json
    {
      "source": "Dhaka",
      "destination": "Chittagong",
      "journeyDate": "2025-11-13"
    }
    ```
- Get seat layout
  - GET /api/schedules/{scheduleId}/seats
- Create booking
  - POST /api/bookings
  - Body:
    ```json
    {
      "scheduleId": "guid",
      "passengerName": "John Doe",
      "phoneNumber": "01712345678",
      "email": "john@example.com",
      "seatNumbers": ["A1", "A2"],
      "boardingPoint": "Dhaka Station",
      "droppingPoint": "Chittagong Terminal"
    }
    ```
- Get routes
  - GET /api/routes
- Get buses
  - GET /api/buses

Responses include booking confirmation, booking reference, status, and messages for conflicts (e.g., seat already taken).

---

## Real-time (SignalR)

- Hub URL (default): `http://localhost:5000/booking-hub`
- Frontend connects to the hub to receive seat availability updates.

---

## Testing

Run backend tests:

```bash
cd Backend/BusReservation.Tests
dotnet test --logger "console;verbosity=detailed"
```

To collect coverage (example with coverlet):

```bash
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
```

Project includes 65+ unit tests across booking, search, and validation logic.

---

## Troubleshooting

- API exits immediately: ensure no conflicting dotnet processes are running. On Windows PowerShell:

```powershell
Get-Process dotnet | Stop-Process -Force
$env:ASPNETCORE_ENVIRONMENT="Development"
dotnet run
```

- SQLite locked / migration errors:
  - Ensure the DB file is not opened by another process.
  - Remove DB and reapply migrations:
    ```bash
    rm Backend/BusReservation.API/BusReservation.db
    dotnet ef database update --project BusReservation.Infrastructure --startup-project BusReservation.API
    ```

- Frontend npm issues:
  - Clear node modules and reinstall:
    ```bash
    rm -rf node_modules package-lock.json
    npm cache clean --force
    npm install
    npm start
    ```

- CORS issues:
  - Ensure CORS policy allows `http://localhost:4200` in `Program.cs`:
    ```csharp
    builder.Services.AddCors(options =>
    {
      options.AddPolicy("AllowAngular", policy =>
      {
        policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
      });
    });
    ```

- SignalR not connecting:
  - Verify hub URL in frontend, ensure API is running and no firewall blocks WebSockets.

---

## Project Statistics

- Backend: ~8,000 lines (C#)
- Frontend: ~5,000 lines (TypeScript/HTML/CSS)
- Unit Tests: 65+
- Test Coverage: ~88%
- Database Records: 527 schedules
- Routes: 8
- Total Seats: ~4,800+
- API Endpoints: 15+

---

## Contributing

Contributions are welcome. Suggested workflow:
1. Fork the repository
2. Create a feature branch: `git checkout -b feat/my-change`
3. Implement changes and tests
4. Open a PR with a clear description

Please follow existing coding patterns and include tests for new behavior.

---

## License

This project is created for educational purposes. See LICENSE file for details (if available).

---

## Author

Khan Ramjan  
GitHub: https://github.com/khanramjan  
Email: khanramjan@example.com

---

## Acknowledgments

Thanks to the .NET, Angular, Entity Framework, and xUnit communities for their excellent tooling and documentation.

---

If you'd like, I can also:
- Add a short CONTRIBUTING.md and CODE_OF_CONDUCT.md,
- Generate a smaller Quick Start section (one‑command start for dev),
- Or open a PR updating the README directly in your repository. Let me know which you'd prefer.
```
