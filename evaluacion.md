**Evaluación Continua 1 -- Portal de Solicitudes de Servicio Técnico**

Ciclo 2026-2 · Aplicación web MVC con .NET, EF Core + SQLite, Git/GitHub y despliegue en Render

**Caso**

"TecnoGas Hogar" es una empresa peruana ficticia dedicada al mantenimiento e instalación de artefactos a gas en el hogar (cocinas, termas, terma a gas, etc.). Actualmente los técnicos reciben los pedidos de servicio por WhatsApp y los anotan en papel, lo que genera pérdida de información.

La empresa quiere validar un prototipo simple de portal interno donde el personal de atención pueda registrar las solicitudes de servicio que llegan de los clientes y luego consultarlas en una lista, antes de invertir en un sistema más completo.

El líder técnico ha pedido que el desarrollo se documente en GitHub usando ramas y merges (sin necesidad de generar conflictos esta vez), y que el demo quede publicado en Render para que el equipo pueda revisarlo desde cualquier navegador.

**Objetivo del reto**

Desarrollar una aplicación web en .NET 10 (MVC) con C#, usando VS Code y Git/GitHub para el control de versiones. La aplicación debe:

- Registrar una nueva solicitud de servicio (Insert) usando Entity Framework Core.

- Listar las solicitudes registradas (Select) consultando la base de datos.

- Persistir la información en una base de datos SQLite.

- Reflejar el desarrollo en ramas separadas por funcionalidad, integradas mediante Pull Requests y merges.

- Quedar publicada y accesible en Render.

- NOMBRE REPOSITORIO evaluacion20262

**Restricciones (para mantenerlo simple)**

- Solo se trabajan las 2 operaciones ya vistas en clase: Insert y Select (no Update ni Delete).

- No se requiere autenticación ni manejo de usuarios.

- Validaciones simples: solo campos obligatorios con DataAnnotations.

- No es necesario generar ni resolver conflictos de merge en esta evaluación.

- Docker: Debe usarlo para el despliegue en Render si les resulta más cómodo, tal como lo trabajaron en clase.

**Modelo de datos sugerido**

Entidad SolicitudServicio:

<table style="width:96%;">
<colgroup>
<col style="width: 96%" />
</colgroup>
<tbody>
<tr>
<td><p>public class SolicitudServicio</p>
<p>{</p>
<p>public int Id { get; set; }</p>
<p>[Required] public string Cliente { get; set; }</p>
<p>[Required] public string Telefono { get; set; }</p>
<p>[Required] public string Distrito { get; set; }</p>
<p>[Required] public string TipoServicio { get; set; } // Instalación, Mantenimiento, Revisión, Fuga</p>
<p>public string Descripcion { get; set; }</p>
<p>public DateTime FechaRegistro { get; set; } = DateTime.Now;</p>
<p>}</p></td>
</tr>
</tbody>
</table>

Cadena de conexión sugerida (appsettings.json):

<table style="width:96%;">
<colgroup>
<col style="width: 96%" />
</colgroup>
<tbody>
<tr>
<td><p>"ConnectionStrings": {</p>
<p>"DefaultConnection": "Data Source=tecnogas.db"</p>
<p>}</p></td>
</tr>
</tbody>
</table>

**Preguntas de la evaluación (5 × 4 puntos = 20 puntos)**

Cada pregunta se evalúa con los criterios indicados. La pregunta 4 (ramas y merge en Git) se revisa con mayor detalle porque es el punto central de esta evaluación.

|  |  |
|----|:--:|
| **Pregunta 1 --- Modelo de datos y configuración de SQLite con EF Core** | **4 puntos** |

Crea el proyecto .NET 10 MVC, define la entidad SolicitudServicio, configura el DbContext con el proveedor SQLite y genera/aplica la migración inicial para crear la base de datos y la tabla.

| **Criterio** | **Puntos** |
|----|:--:|
| Entidad SolicitudServicio con atributos y tipos de datos correctos | 1 |
| DbContext y cadena de conexión SQLite correctamente configurados | 1 |
| Migración generada y aplicada sin errores (BD y tabla creadas) | 1 |
| Proyecto compila y ejecuta correctamente | 1 |

|                                                       |              |
|-------------------------------------------------------|:------------:|
| **Pregunta 2 --- Registro de una solicitud (Insert)** | **4 puntos** |

Crea la vista y el controlador para registrar una nueva solicitud (formulario con Cliente, Teléfono, Distrito, Tipo de servicio y Descripción) y guárdala en SQLite usando EF Core.

| **Criterio** | **Puntos** |
|----|:--:|
| Formulario con los campos solicitados y validaciones básicas (Required) | 1 |
| Inserción correcta del registro en SQLite (Add + SaveChanges) | 1 |
| Mensaje de confirmación o redirección luego de guardar | 1 |
| Manejo simple de errores de validación (ModelState) | 1 |

|                                                    |              |
|----------------------------------------------------|:------------:|
| **Pregunta 3 --- Listado de solicitudes (Select)** | **4 puntos** |

Crea una vista que consulte y muestre en una tabla todas las solicitudes registradas en la base de datos SQLite.

| **Criterio** | **Puntos** |
|----|:--:|
| Consulta correcta a la base de datos (LINQ / ToListAsync) | 1 |
| Todos los campos se muestran correctamente en la vista | 1 |
| Presentación clara (por ejemplo, ordenado por fecha de registro) | 1 |
| El listado refleja los datos insertados en la Pregunta 2 | 1 |

|                                                         |              |
|---------------------------------------------------------|:------------:|
| **Pregunta 4 --- Ramas, commits y merge en Git/GitHub** | **4 puntos** |

Todo el trabajo debe quedar reflejado en GitHub usando, como mínimo, la siguiente estructura de ramas:

- main

- develop

- feature/modelo-sqlite → Pregunta 1

- feature/registro-solicitud → Pregunta 2

- feature/listado-solicitudes → Pregunta 3

Flujo esperado:

1.  Crear el proyecto base y hacer merge a develop.

2.  Implementar cada funcionalidad en su propia rama feature/.

3.  Abrir un Pull Request de cada rama feature hacia develop.

4.  Hacer merge de cada Pull Request a develop.

5.  Al finalizar, hacer merge de develop a main.

Commits descriptivos, por ejemplo: "feat: configurar EF Core con SQLite", "feat: implementar registro de solicitudes", "feat: implementar listado de solicitudes". Evitar mensajes como "avance", "update" o "cambios".

| **Criterio** | **Puntos** |
|----|:--:|
| Estructura de ramas completa y correctamente nombrada | 1 |
| Commits descriptivos que reflejan el avance real del desarrollo | 1 |
| Pull Request visible en GitHub por cada rama feature, con merge a develop | 1 |
| Merge final de develop a main, con historial ordenado (git log \--graph o red de GitHub) | 1 |

*Nota: en esta pregunta se revisa directamente el historial del repositorio (ramas, commits y Pull Requests), no solo si el código funciona.*

|                                          |              |
|------------------------------------------|:------------:|
| **Pregunta 5 --- Publicación en Render** | **4 puntos** |

Publica la aplicación en Render como Web Service, de modo que sea accesible mediante una URL pública, con el registro y el listado de solicitudes funcionando sobre la base de datos SQLite en el entorno desplegado. Pueden usar Docker para el despliegue si lo prefieren, tal como lo trabajaron en clase.

| **Criterio** | **Puntos** |
|----|:--:|
| Aplicación desplegada y accesible mediante URL pública de Render | 1 |
| Funcionalidad de registro (Insert) operativa en el entorno desplegado | 1 |
| Funcionalidad de listado (Select) operativa en el entorno desplegado | 1 |
| Configuración del despliegue (variables de entorno / Dockerfile si aplica) documentada en el README | 1 |

**Entregables**

- URL del repositorio en GitHub (con ramas, Pull Requests y merges visibles).

- URL de la aplicación publicada en Render.
