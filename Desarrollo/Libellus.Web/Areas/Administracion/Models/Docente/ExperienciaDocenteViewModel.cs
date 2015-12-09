namespace Libellus.Web.Areas.Administracion.Models.Docente
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Define la información de la experiencia laboral del docente.
    /// </summary>
    public class ExperienciaDocenteViewModel
    {
        /// <summary>
        /// Obtiene o establece el identificador interno de la experiencia laboral registrada.
        /// </summary>
        public int IdExperienciaDocente { get; set; }

        /// <summary>
        /// Obtiene o establece la institución educativa donde se reliza(ó) la experiencia laboral.
        /// </summary>
        [Display(Name = "Institución educativa")]
        public string Institucion { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de ingreso a la institución educativa donde se reliza(ó) la experiencia laboral.
        /// </summary>
        [Display(Name = "Fecha de ingreso")]
        public string FechaIngreso { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de retiro a la institución educativa donde se reliza(ó) la experiencia laboral.
        /// </summary>
        [Display(Name = "Fecha de retiro")]
        public string FechaRetiro { get; set; }

        /// <summary>
        /// Obtiene o establece el motivo del retiro de la institución educativa donde se reliza(ó) la experiencia laboral.
        /// </summary>
        [Display(Name = "Motivo del retiro")]
        public string MotivoRetiro { get; set; }

        /// <summary>
        /// Obtiene o establece las áreas de competencia que dictó en la institución educativa donde se reliza(ó) la experiencia laboral.
        /// </summary>
        [Display(Name = "Áreas de competencia")]
        public string AreasCompetencia { get; set; }

        /// <summary>
        /// Obtiene o establece si el registro es o no nuevo.
        /// </summary>
        public string RegistroNuevo { get; set; }
    }
}