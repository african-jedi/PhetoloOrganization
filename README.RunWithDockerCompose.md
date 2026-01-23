# Running the Math28 Application with Docker Compose

## Prerequisites

- **Docker Desktop** installed and running on your system
- At least 2GB of free disk space for Docker images and volumes

## Quick Start

### Start the Application

To start all services (database, cache, backend API, frontend, and health check UI):

```bash
cd Deployment/Docker-Compose
docker-compose up --build
```

The `--build` flag rebuilds all container images, ensuring the latest code is included.

**Available Services:**
- **Frontend** (Angular): http://localhost:4200
- **Backend API** (ASP.NET Core): http://localhost:5138
- **Health Check UI**: http://localhost:5148
- **Database** (PostgreSQL): localhost:5432
- **Cache** (Redis): localhost:6379

### Stop the Application

To gracefully stop all running containers:

```bash
docker-compose down
```

To remove containers and volumes (note: this will delete data):

```bash
docker-compose down -v
```

## Docker Compose Architecture

| Service | Image | Port | Purpose |
|---------|-------|------|---------|
| db | postgres:17 | 5432 | PostgreSQL Database |
| cache | redis:latest | 6379 | Redis Cache |
| backend | Custom .NET | 5138 (external) / 8080 (internal) | ASP.NET Core API |
| frontend | Custom Node | 4200 | Angular Development Server |
| healthcheck | Custom .NET | 5148 | Health Check UI |

## Configuration

Environment variables are automatically passed to containers via `docker-compose.yml`. Key configurations:

- **Database Connection**: `Host=db;Port=5432;Database=Phetolo.Math28DB`
- **Redis Cache**: `cache:6379`
- **Angular Health Check**: `http://frontend:4200`

## Troubleshooting

### Port Already in Use
If ports are already in use, modify the port mappings in `docker-compose.yml`:
```yaml
ports:
  - "5139:8080"  # Change external port from 5138 to 5139
```

### Container Fails to Start
Check logs for the specific service:
```bash
docker-compose logs backend
docker-compose logs frontend
docker-compose logs db
```

### Health Checks Failing
The application may take 30-60 seconds to fully initialize. Services report degraded status while dependencies are starting. This is normal.

## Development Notes

- **Hot Reload**: Changes to Angular frontend code are automatically reflected (watch mode enabled)
- **Database Migrations**: Automatically applied on backend startup
- **Docker Network**: All containers run on the same internal network and can communicate using service names (e.g., `backend:8080`)


