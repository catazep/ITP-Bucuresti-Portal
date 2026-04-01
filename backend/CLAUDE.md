# Backend Context

## Solution Structure

ITP.sln contains:
- `ITP.LocationsApi.*` (4 projects: Domain, Application, Infrastructure, Presentation)
- `ITP.MainApi.*` (4 projects: Domain, Application, Infrastructure, Presentation)
- `ITP.Contracts` (shared event/message contracts)

## Clean Architecture Layers

```
Presentation  (Controllers, middleware, Program.cs)
   ↓
Application   (CQRS handlers, validators, interfaces)
   ↓
Infrastructure  (EF Core, repositories, MassTransit config)
   ↓
Domain        (Entities, value objects — NO dependencies)
```

**Rule:** Never skip layers. Always request through Application.

## Running Services

- **LocationsApi:** https://localhost:7001/swagger
- **MainApi:** https://localhost:7002/swagger
- **RabbitMQ UI:** http://localhost:15672 (user: `itp` / `itp123`)

Start RabbitMQ: `cd backend && docker-compose up -d`

---

*Additional context will be added here as each phase is completed.*
