using System.ComponentModel.DataAnnotations;

namespace Libellus.Web.Areas.GestionMatricula.Models.DatosGeneralesEstudiante
{
    /// <summary>
    /// Representa el modelo para la vista de estado del estudiante.
    /// </summary>
    public class DatosEstadoViewModel
    {
        /// <summary>
        /// Obtiene el estado del estudiante.
        /// </summary>
        [Display(Name = "Estado del estudiante")]
        public string EstadoEstudiante { get; set; }

        /// <summary>
        /// Obtiene el estado de la salida ocupacional del estudiante.
        /// </summary>
        [Display(Name = "Estado de la salida ocupacional")]
        public string EstadoSalidaOcupacional { get; set; }

        /// <summary>
        /// Obtiene la fecha de la ultima actualizacion del estudiante.
        /// </summary>
        [Display(Name = "Fecha de última actualización")]
        public string FechaActualizacion { get; set; }

        /// <summary>
        /// Obtiene la fecha de creacion del estudiante.
        /// </summary>
        [Display(Name = "Fecha de creación")]
        public string FechaCreacion { get; set; }

        /// <summary>
        /// Obtiene el horario del estudiante.
        /// </summary>
        [Display(Name = "Horario")]
        public string Horario { get; set; }

        /// <summary>
        /// Obtiene la salida ocupacional del estudiante.
        /// </summary>
        [Display(Name = "Salida ocupacional")]
        public string SalidaOcupacional { get; set; }
    }
}