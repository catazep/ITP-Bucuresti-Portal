# Frontend Context

## Project Structure

NX monorepo with:
- `apps/itp-shell/` — Host app (Module Federation host)
- `apps/locations-mf/` — Locations microfrontend (Module Federation remote)
- `libs/ui/`, `libs/data-access/`, `libs/utils/` — Shared libraries

## Routing & Lazy Loading

```
/acasa      → Home (preloaded for SEO)
/itp        → Service info (preloaded for SEO)
/preturi    → Pricing (lazy loaded)
/locatii    → Locations picker (lazy loaded, Module Federation remote)
```

## Running Frontend

```bash
# Terminal 1: Host app
cd frontend
nx serve itp-shell --open

# Terminal 2 (separate window): Microfrontend remote
cd frontend
nx serve locations-mf
```

- Host runs on http://localhost:4200
- Remote runs on http://localhost:4201

---

*Additional context will be added here as each phase is completed.*
