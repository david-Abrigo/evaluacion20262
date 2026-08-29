using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using evaluacion20262.Data;
using evaluacion20262.Models;

namespace evaluacion20262.Controllers
{
    public class SolicitudesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SolicitudesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Solicitudes/Crear (Pregunta 2 - Formulario de registro)
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        // POST: Solicitudes/Crear (Pregunta 2 - Guardar solicitud en SQLite)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("Cliente,Telefono,Distrito,TipoServicio,Descripcion")] SolicitudServicio solicitud)
        {
            if (ModelState.IsValid)
            {
                solicitud.FechaRegistro = DateTime.Now;
                _context.Add(solicitud);
                await _context.SaveChangesAsync();
                TempData["MensajeExito"] = $"¡La solicitud para {solicitud.Cliente} ha sido registrada correctamente!";
                return RedirectToAction(nameof(Index));
            }

            return View(solicitud);
        }

        // GET: Solicitudes (Pregunta 3 - Listado de solicitudes)
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var solicitudes = await _context.Solicitudes
                .OrderByDescending(s => s.FechaRegistro)
                .ToListAsync();

            return View(solicitudes);
        }
    }
}
