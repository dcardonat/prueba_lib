namespace Libellus.Web.Areas.GestionMatricula.Models.CancelacionMatricula
{
    using Libellus.Mensajes;
    using PagedList;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    /// <summary>
    /// Clase para representar el view model de cancelación de matrícula.
    /// </summary>
    public class CancelacionMatriculaViewModel
    {
        /// <summary>
        /// Obtiene o establece el identificador de matricula.
        /// </summary>
        public int IdMatricula { get; set; }

        /// <summary>
        /// Obtiene o establece la observación.
        /// </summary>
        [MaxLength(1000)]
        [Display(Name = "Observaciones")]
        public string Observacion { get; set; }

        /// <summary>
        /// Obtiene o establece la salida ocupacional.
        /// </summary>
        [Display(Name = "Salida ocupacional")]
        public string SalidaOcupacional { get; set; }

        /// <summary>
        /// Obtiene  o establece el identificador del motivo.
        /// </summary>
        [Display(Name = "Motivo de retiro")]
        public int IdMotivo { get; set; }

        /// <summary>
        /// Obtiene  o establece el identificador del motivo.
        /// </summary>
        [Display(Name = "Motivo de retiro")]
        public int IdMotivoSalidaOcupacional { get; set; }

        /// <summary>
        /// Obtiene o establece listado de motivos.
        /// </summary>
        public IEnumerable<SelectListItem> MotivosRetiro { get; set; }
    }
}