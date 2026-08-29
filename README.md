# 🛠️ TecnoGas Hogar - Portal Interno de Servicio Técnico

Sistema web para el registro, control y seguimiento de solicitudes de servicio técnico a domicilio para artefactos a gas (instalaciones, mantenimientos, revisiones y atención de fugas).

---

## 📌 Visión General del Sistema

El portal interno de **TecnoGas Hogar** digitaliza el proceso de capturar y consultar requerimientos de clientes. La plataforma permite al equipo de operaciones ingresar nuevas solicitudes y visualizarlas inmediatamente en una interfaz clara y centralizada.

---

## 🚀 Tecnologías y Arquitectura

- **Backend:** .NET 10 (ASP.NET Core MVC)
- **Persistencia de Datos:** SQLite con Entity Framework Core 10
- **Frontend & UI:** HTML5, CSS3, Bootstrap 5 & Bootstrap Icons
- **Estrategia de Ramificación:** Git Flow (`main`, `develop` y ramas de funcionalidades `feature/*`)
- **Contenedorización & Cloud:** Docker multi-etapa y despliegue en Render Web Service

---

## 🗄️ Estructura de Datos y Configuración

### Modelo `SolicitudServicio`
Representa el registro de atención técnica en la base de datos:
- `Id`: Identificador único (Clave Primaria).
- `Cliente`: Nombre o razón social del cliente.
- `Telefono`: Número de contacto.
- `Distrito`: Ubicación del servicio.
- `TipoServicio`: Categoria del trabajo (*Instalación, Mantenimiento, Revisión, Fuga*).
- `Descripcion`: Detalles específicos del requerimiento.
- `FechaRegistro`: Marca de tiempo automática de registro.

### Cadena de Conexión (`appsettings.json`)
```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=tecnogas.db"
}
```

---

## 🌿 Flujo de Trabajo y Control de Versiones

El código fuente sigue las mejores prácticas de integración continua mediante control de versiones:
- **`main`**: Rama estable de producción.
- **`develop`**: Rama de integración continua.
- **Ramas `feature/*`**: Ramas independientes para el desarrollo modular de componentes (persistencia, formularios y módulos de consulta) integradas a través de Pull Requests.

---

## 💻 Guía de Instalación y Ejecución Local

### Requisitos
- .NET 10.0 SDK instalado.

### Pasos de Ejecución
1. **Clonar el repositorio:**
   ```bash
   git clone https://github.com/david-Abrigo/evaluacion20262.git
   cd evaluacion20262
   ```

2. **Compilar y restaurar dependencias:**
   ```bash
   dotnet restore
   dotnet build
   ```

3. **Iniciar el servidor web local:**
   ```bash
   dotnet run
   ```
   Abre tu navegador en `http://localhost:5290` (o el puerto asignado en la consola).

---

## 🐳 Despliegue en la Nube (Docker & Render)

El proyecto incluye un `Dockerfile` optimizado en 3 etapas (*multi-stage build*) para su despliegue automatizado.

### Pasos para Despliegue en Render
1. Crear un **Web Service** en Render.com vinculado a este repositorio.
2. Seleccionar la rama principal `main`.
3. Seleccionar el entorno de ejecución **Docker**.
4. Confirmar la creación; las migraciones de base de datos se aplicarán automáticamente al iniciar el servicio.