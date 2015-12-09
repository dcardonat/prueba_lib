namespace Libellus.Web.Areas.Administracion.Models.AnioLectivo
{
    using Libellus.Mensajes;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AnioLectivoViewModel
    {
        /// <summary>
        /// Año para el cual se realiza la configuracion.
        /// </summary>
        [Display(Name = "Año")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [RegularExpression(@"\d+", ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1004")]
        public Int16 Anio { get; set; }

        /// <summary>
        /// Obtiene o establece el estado del año.
        /// </summary>
        public bool Cerrado { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de cierre del año escolar.
        /// </summary>
        [Display(Name = "Fecha de cierre")]
        public string FechaCierre { get; set; }

        /// <summary>
        /// Fecha de inicio escolar del año lectivo.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [Display(Name = "Fecha de inicio")]
        public string FechaInicio { get; set; }

        /// <summary>
        /// Identificador del registro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador de la sede a la que pertenece el registro.
        /// </summary>
        public int IdSede { get; set; }
    }
}