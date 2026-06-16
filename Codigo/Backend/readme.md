# EvoEventos - Backend

## Setup Inicial

1. **Copiar archivo de configuración:**
```bash
cp appsettings.Development.example.json appsettings.Development.json
```

2. **Editar `appsettings.Development.json`:**
   - Reemplaza `YOUR_PASSWORD` con tu contraseña de SQL Server
   - Reemplaza `YOUR_JWT_SECRET_KEY_32_BYTES` con tu clave JWT

**Nota:** No hagas commit del archivo `appsettings.Development.json` (está en `.gitignore`)

## Ejecución Normal (Sin Docker)

**Prerrequisitos:** .NET 8.0 SDK y SQL Server ejecutándose

```bash
dotnet restore
dotnet run
```

Accede a: `https://localhost:7208/swagger`

---

## Ejecución con Docker

**Prerrequisitos:** Docker instalado y SQL Server ejecutándose

**Para Docker, edita `appsettings.Development.json`:**
- Cambia `Server=localhost` por `Server=host.docker.internal,1433`

**Construir y ejecutar:**
```bash
docker build -t evoeventos:test .
docker run -d -p 8080:8080 -p 8081:8081 -e ASPNETCORE_ENVIRONMENT=Development --name evoeventos-test evoeventos:test
```

**Comandos útiles:**
```bash
docker ps                          # Ver contenedores en ejecución
docker logs -f evoeventos-test     # Ver logs en tiempo real
docker stop evoeventos-test        # Detener
docker restart evoeventos-test     # Reiniciar
docker rm -f evoeventos-test       # Eliminar contenedor
```

Accede a: `http://localhost:8080/swagger`

---

## Solución de Problemas

**Error de conexión a BD:**
- Verifica que SQL Server está ejecutándose
- En Docker: usa `host.docker.internal` en lugar de `localhost`

**El contenedor no inicia:**
```bash
docker logs -f evoeventos-test
```

**Puerto en uso:**
```bash
docker rm -f evoeventos-test
```