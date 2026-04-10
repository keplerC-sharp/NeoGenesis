# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

NeoGenesis is a C# (.NET 10) console application for managing dinosaur records in a fictional park. It uses Entity Framework Core with Pomelo for MySQL as the database provider. This is a university project following layered architecture.

## Build & Run Commands

```bash
# Build
dotnet build App/App.csproj

# Run
dotnet run --project App/App.csproj

# Add a new EF Core migration
dotnet ef migrations add <MigrationName> --project App/App.csproj

# Apply migrations to the database
dotnet ef database update --project App/App.csproj
```

## Required Environment Variables

The app reads MySQL connection info from environment variables (no appsettings.json):

```
DB_HOST=localhost
DB_NAME=dinosaurs_db
DB_USER=root
DB_PASSWORD=<your_password>
```

## Architecture

Layered architecture with a single entity (`Dinosaur`):

- **Entities** (`App/Entities/`) — Domain models with data annotations
- **Data** (`App/Data/`) — `NeoGenesisContext` (EF Core DbContext, configures MySQL via env vars)
- **Repository** (`App/Repository/`) — CRUD data access (currently skeleton)
- **Service** (`App/Service/`) — Business logic and validation orchestration (currently skeleton)
- **Validators** (`App/Validators/`) — Field/uniqueness validation rules (currently skeleton)
- **LINKQ** (`App/LINKQ/`) — LINQ-based query service for filtering, grouping, sorting (currently skeleton)
- **Program.cs** — Entry point, currently just ensures DB creation

Note: The LINQ query folder is named `LINKQ` (not `LINQ`) in the actual codebase.

## Key Constraints

- Username and Email must be unique across dinosaurs
- Required fields: FirstName, LastName, Username, Email
- Age must be >= 0
- Database is MySQL (not SQL Server), using Pomelo EF Core provider
- No dependency injection container — classes are instantiated directly
- Solution file: `NeoGenesis.sln` (single project `App`)
