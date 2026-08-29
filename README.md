# 🛠️ TecnoGas Hogar - Portal de Solicitudes de Servicio Técnico

**Evaluación Continua 1 - Ciclo 2026-2**  
*Aplicación web .NET 10 MVC con Entity Framework Core, SQLite, Git/GitHub y despliegue preparado para Render.*

---

## 📌 Descripción del Proyecto

**TecnoGas Hogar** es una empresa peruana dedicada al mantenimiento e instalación de artefactos a gas en el hogar (cocinas, termas a gas, etc.). Este prototipo reemplaza el registro manual por WhatsApp y papel con un portal web interno para registrar las solicitudes de servicio de los clientes y consultarlas en tiempo real.

---

## 🚀 Tecnologías Utilizadas

- **Framework:** .NET 10 (ASP.NET Core MVC)
- **Base de Datos:** SQLite (`tecnogas.db`)
- **ORM:** Entity Framework Core 10 (`Microsoft.EntityFrameworkCore.Sqlite`)
- **Diseño & UI:** Bootstrap 5, Bootstrap Icons, HTML5, CSS3
- **Control de Versiones:** Git & GitHub (Estrategia Git Flow con Pull Requests)
- **Contenedorización:** Docker (Dockerfile multi-stage)
- **Despliegue:** Render Web Service

---

## 🗄️ Modelo de Datos y Cadena de Conexión

### Entidad `SolicitudServicio`
- `Id` (int, Clave Primaria Autoincremental)
- `Cliente` (string, Requerido)
- `Telefono` (string, Requerido)
- `Distrito` (string, Requerido)
- `TipoServicio` (string, Requerido: *Instalación, Mantenimiento, Revisión, Fuga*)
- `Descripcion` (string, Opcional)
- `FechaRegistro` (DateTime, Autogenerado)

### Cadena de Conexión (`appsettings.json`)
```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=tecnogas.db"
}
```

> **Nota:** La aplicación ejecuta `context.Database.Migrate()` en `Program.cs` de forma automática al iniciar, garantizando que la base de datos `tecnogas.db` y sus tablas se creen automáticamente tanto en entorno local como en el contenedor desplegado en Render.

---

## 🌿 Estructura de Ramas y Pull Requests en Git

El desarrollo del proyecto se realizó mediante ramas de características (*features*) integradas progresivamente a la rama `develop` mediante Pull Requests y finalmente consolidadas en `main`:

- **`main`**: Rama principal de producción lista para despliegue.
- **`develop`**: Rama de integración de desarrollo.
- **`feature/modelo-sqlite`**: Configuración de EF Core, Modelo y Migraciones (PR #1).
- **`feature/registro-solicitud`**: Implementación del formulario de registro Insert (PR #2).
- **`feature/listado-solicitudes`**: Implementación de la tabla de consulta Select (PR #3).

---

## 💻 Instrucciones para Ejecutar Localmente

### Requisitos Previos
- .NET 10 SDK instalado.

### Pasos
1. Clonar el repositorio:
   ```bash
   git clone https://github.com/david-Abrigo/evaluacion20262.git
   cd evaluacion20262
   ```

2. Restaurar paquetes y compilar:
   ```bash
   dotnet restore
   dotnet build
   ```

3. Ejecutar la aplicación:
   ```bash
   dotnet run
   ```
   Navega a `http://localhost:5000` en tu navegador.

---

## 🐳 Despliegue en Render (Web Service)

### Opción A: Despliegue con Docker (Recomendado)
1. En **Render.com**, crea un nuevo **Web Service**.
2. Conecta tu repositorio de GitHub `david-Abrigo/evaluacion20262` y selecciona la rama `main`.
3. En **Environment**, selecciona **Docker**.
4. Render detectará automáticamente el `Dockerfile` del proyecto.
5. Haz clic en **Create Web Service**.

### Opción B: Despliegue Nativo .NET en Render
- **Environment:** `.NET`
- **Build Command:** `dotnet publish -c Release -o out`
- **Start Command:** `dotnet out/evaluacion20262.dll`

---

## 🌐 Entregables de la Evaluación

- **Repositorio GitHub:** [https://github.com/david-Abrigo/evaluacion20262](https://github.com/david-Abrigo/evaluacion20262)
- **Pull Requests Visibles:**
  - PR #1: `feature/modelo-sqlite` -> `develop`
  - PR #2: `feature/registro-solicitud` -> `develop`
  - PR #3: `feature/listado-solicitudes` -> `develop`