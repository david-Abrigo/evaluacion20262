using System;
using System.ComponentModel.DataAnnotations;

namespace evaluacion20262.Models
{
    public class SolicitudServicio
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del cliente es obligatorio.")]
        [Display(Name = "Cliente")]
        public string Cliente { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono de contacto es obligatorio.")]
        [Display(Name = "Teléfono")]
        [Phone(ErrorMessage = "Ingrese un número de teléfono válido.")]
        public string Telefono { get; set; } = string.Empty;

        [Required(ErrorMessage = "El distrito es obligatorio.")]
        [Display(Name = "Distrito")]
        public string Distrito { get; set; } = string.Empty;

        [Required(ErrorMessage = "El tipo de servicio es obligatorio.")]
        [Display(Name = "Tipo de Servicio")]
        public string TipoServicio { get; set; } = string.Empty; // Instalación, Mantenimiento, Revisión, Fuga

        [Display(Name = "Descripción del problema o requerimiento")]
        public string? Descripcion { get; set; }

        [Display(Name = "Fecha de Registro")]
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}
