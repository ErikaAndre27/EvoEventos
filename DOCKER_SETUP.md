# 🐳 Setup de Docker - EvoEventos

---

## ✅ **Requisitos previos**

### **1. Docker Desktop**

- Instalar desde: https://www.docker.com/products/docker-desktop
- Abre Docker Desktop y espera a que esté listo (onda verde)

**Nota:** La BD, Backend y Frontend corren EN Docker. No necesitas SQL Server instalado en tu PC.

---

## 🚀 **Ejecutar Docker Compose**

### **Primer inicio (limpio):**

```bash
cd C:\ruta\a\EvoEventos
docker-compose up
```

### **Inicios posteriores:**

```bash
docker-compose up
```

**Espera a ver estos logs:**

```
✔ Container evoeventos-database Created
✔ Container evoeventos-backend Created
✔ Container evoeventos-frontend Created
```

**El Backend mostrará:**

```
Application started. Press Ctrl+C to shut down.
```

**El Frontend mostrará:**

```
VITE v7.x.x  ready in xxx ms
```

---

## 🌐 **Acceder a la aplicación**

| Servicio        | URL                                      | Usuario     | Contraseña      |
| --------------- | ---------------------------------------- | ----------- | --------------- |
| Frontend        | http://localhost:5173                    | (según app) | (según app)     |
| Backend API     | http://localhost:8080                    | -           | -               |
| Backend Swagger | http://localhost:8080/swagger/index.html | -           | -               |
| SQL Server      | localhost:1433                           | sa          | EvoEventos2024! |

---

## 💾 **Sobre la Base de Datos**

### **¿Dónde se guardan los datos?**

- En un volumen Docker llamado `sqlserver_data`
- Docker gestiona automáticamente dónde se almacena en tu PC
- Los datos **persisten** aunque hagas `docker-compose down`

### **¿Cómo acceder a la BD directamente?**

Opción 1: Con SQL Server Management Studio (SSMS)

- Servidor: `localhost` o `localhost\SQLEXPRESS`
- Usuario: `sa`
- Contraseña: `EvoEventos2024!`
- Database: `EvoEventos`

Opción 2: Con sqlcmd en terminal

```bash
sqlcmd -S localhost -U sa -P EvoEventos2024!
> SELECT 1
```

### **¿Cómo resetear la BD (eliminar todos los datos)?**

```bash
docker-compose down -v
docker-compose up
```

**Advertencia:** El flag `-v` elimina volúmenes (toda la BD se borra)

---

## 🛑 **Detener los contenedores**

```bash
# Solo parar (puedes reiniciar después)
docker-compose stop

# Parar y eliminar contenedores (datos persisten)
docker-compose down

# Parar, eliminar contenedores Y DATOS
docker-compose down -v
```

---

## 🔧 **Información técnica**

### **Servicios en Docker:**

```
Backend (.NET)
├─ Puerto: 8080/8081
├─ Conecta a: database:1433 (nombre de servicio Docker)
└─ Variables: JWT, Connection String (en docker-compose.yml)

Frontend (React + Vite)
├─ Puerto: 5173
├─ Conecta a: http://backend:8080/api
└─ Hot-reload: cambios en src/ se reflejan al instante

Database (SQL Server 2022)
├─ Puerto: 1433
├─ Usuario: sa
├─ Contraseña: EvoEventos2024!
└─ Volumen: sqlserver_data (datos persisten)
```

### **Red virtual de Docker:**

- Todos los contenedores están en `evoeventos-network`
- Se comunican entre sí usando nombres de servicio (DNS interno)
- **NO necesitas IPs ni localhost** para hablar entre contenedores

---

## 📝 **Desarrollo en tiempo real**

### **Frontend (Hot-reload):**

- Cambios en `Codigo/EvoEventosFrontend/src/` se reflejan **inmediatamente**
- No necesitas reconstruir nada

### **Backend (Recompilación):**

- Los cambios en código requieren reconstruir la imagen:

```bash
docker-compose up --build backend
```

---

## 🛑 **Detener**

```bash
# Detener
docker-compose stop

# Detener y eliminar
docker-compose down
```
