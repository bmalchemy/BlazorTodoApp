# Blazor TodoApp Solution

A full-stack Blazor Server app for managing todos, backed by PostgreSQL, with unit tests. Migrated from SQLite for better scalability.

## Structure
- **TodoApp/**: The main Blazor web project (server-side rendering, EF Core for DB ops).
- **TodoApp.Tests/**: xUnit tests for app logic and DbContext.

## Prerequisites
- .NET 8 SDK
- PostgreSQL 17 (via Postgres.app on macOS)
- Visual Studio Code or Visual Studio (with C# extensions)

## Quick Start
1. Clone the repo: `git clone https://github.com/bmalchemy/BlazorTodoApp.git`
2. Restore: `dotnet restore`
3. Update connection string in `TodoApp/appsettings.json` (e.g., `Host=localhost;Database=MyBlazorAppDb;Username=brandonm;Password=`)
4. Run migrations: `cd TodoApp && dotnet ef database update`
5. Start the app: `dotnet run --project TodoApp`
6. Open http://localhost:5xxx (port varies) and add todos!

## Run Tests
dotnet test TodoApp.Tests

## Deployment Notes
- App: Deploy to Azure App Service (with PostgreSQL Flexible Server).
- Tests: Integrate with GitHub Actions for CI.

## Contributing
- Branch from `main`: `git checkout -b feature/new-todo-feature`
- See `TodoApp/README.md` for app-specific details.

## License
MIT (or whatever you prefer).