# ITP Bucuresti Portal

Demo: **ITP (Inspectie Tehnica Periodica)** platform — vehicle technical inspection system. Learning project for Angular + .NET Core skill refresh.

## Repository
GitHub: [catazep/itp-bucuresti-portal](https://github.com/catazep/itp-bucuresti-portal)

## Stack
- **Frontend:** Angular 17+, NX monorepo, Module Federation (Webpack), NgRx
- **Backend:** .NET 8, Clean Architecture (Domain/Application/Infrastructure/Presentation)
- **Messaging:** MassTransit + RabbitMQ (Docker), Saga + Outbox patterns
- **Auth:** JWT + ASP.NET Identity
- **Database:** SQL Server LocalDB (each service has its own DB)
- **ORM:** Entity Framework Core 8, Code First

## Top-level Folders
- `/backend` — .NET solution (ITP.sln)
- `/frontend` — Angular NX monorepo

## Coding Conventions
- **C#:** PascalCase classes/methods, camelCase locals, `Async` suffix on async methods
- **Angular:** Standalone components, signals preferred over RxJS where possible
- **Commits:** Conventional commits (`feat:`, `fix:`, `chore:`, `docs:`)
- **Secrets:** Never commit connection strings — use `appsettings.Development.json` (gitignored)

---

*This file describes current state only. Details on services, folder structure, and patterns will be added as they are built.*
