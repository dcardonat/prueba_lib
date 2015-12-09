namespace Libellus.Web.Areas.Administracion.Models.Docente
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Define la información de los estudios realizados del docente.
    /// </summary>
    public class EstudiosRealizadosViewModel
    {
        /// <summary>
        /// Obtiene o establece el identificador interno del estudio realizado.
        /// </summary>
        public int IdEstudioRealizado { get; set; }

        /// <summary>
        /// Obtiene o establece la institución educativa donde se realiza(ó) el estudio.
        /// </summary>
        [Display(Name = "Institución educativa")]
        public string InstitucionEducativa { get; set; }

        /// <summary>
        /// Obtiene o establece el título académico otorgado.
        /// </summary>
        [Display(Name = "Título otorgado")]
        public string TituloEstudio { get; set; }

        /// <summary>
        /// Obtiene o establece la clasificación del estudio.
        /// </summary>
        [Display(Name = "Clasificación")]
        public int IdClasificacion { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la clasificación del estudio.
        /// </summary>
        public string NombreClasificacion { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de terminación del estudio.
        /// </summary>
        [Display(Name = "Fecha de terminación")]
        public string FechaTerminacion { get; set; }

        /// <summary>
        /// Obtiene o establece el estado del estudio.
        /// </summary>
        [Display(Name = "Estado del estudio")]
        public int IdEstadoEstudio { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del estado del estudio.
        /// </summary>
        public string NombreEstadoEstudio { get; set; }

        /// <summary>
        /// Obtiene o establece si el registro es o no nuevo.
        /// </summary>
        public string RegistroNuevo { get; set; }
    }
}