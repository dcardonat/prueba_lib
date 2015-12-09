namespace Libellus.Web.Areas.Administracion.Models.ParametrosInstitucionales
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Exito.Sime.Web.Attributes;
    using Libellus.Mensajes;

    /// <summary>
    /// Define la información a visualizar en la vista de la administración de un parámetro institucional.
    /// </summary>
    public class ParametrizacionInstitucionalViewModel
    {
        /// <summary>
        /// Obtiene o establece el identificador interno.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno de la sede.
        /// </summary>
        public int IdSede { get; set; }

        /// <summary>
        /// Obtiene o establece el año escolar.
        /// </summary>
        [Display(Name = "Año")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int IdAnioLectivo { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del año escolar.
        /// </summary>
        [Display(Name = "Año lectivo")]
        public string AnioLectivo { get; set; }

        /// <summary>
        /// Obtiene o establece los años lectivos activos.
        /// </summary>
        public List<SelectListItem> AniosLectivos { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno del horario.
        /// </summary>
        [Display(Name = "Horario")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int IdHorario { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del horario seleccionado.
        /// </summary>
        public string NombreHorario { get; set; }

        /// <summary>
        /// Obtiene o establece los horarios existentes activos.
        /// </summary>
        public List<SelectListItem> Horarios { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno del nivel educativo.
        /// </summary>
        [Display(Name = "Nivel educativo")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int IdNivelEducativo { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del nivel educativo seleccionado.
        /// </summary>
        public string NombreNivelEducativo { get; set; }

        /// <summary>
        /// Obtiene o establece los niveles educativos existentes activos.
        /// </summary>
        public List<SelectListItem> NivelesEducativos { get; set; }

        /// <summary>
        /// Obtiene o establece el horario inicial establecido.
        /// </summary>
        [Display(Name = "Horario inicial")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [TimeAmPm(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1010")]
        public string HoraInicial { get; set; }

        /// <summary>
        /// Obtiene o establece el horario final establecido.
        /// </summary>
        [Display(Name = "Horario final")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [TimeAmPm(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1010")]
        public string HoraFinal { get; set; }

        /// <summary>
        /// Obtiene o establece los momentos semanales.
        /// </summary>
        [Display(Name = "Momentos semana (Horas)")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [RegularExpression(@"\d+", ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1004")]
        [Range(20, 40, ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1006")]
        public string MomentosSemana { get; set; }

        /// <summary>
        /// Obtiene o establece los tiempos (minutos) de descansos.
        /// </summary>
        [Display(Name = "Tiempos descansos (Minutos)")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [RegularExpression(@"\d+", ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1004")]
        [Range(0, 9999, ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1006")]
        public string TiempoDescansos { get; set; }

        /// <summary>
        /// Obtiene o establece la duración de los momentos en minutos.
        /// </summary>
        [Display(Name = "Duración momentos (Minutos)")]
        [Range(0, short.MaxValue, ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1006")]
        public string DuracionMomentos { get; set; }

        /// <summary>
        /// Obtiene o establece los momentos del docente en minutos.
        /// </summary>
        [Display(Name = "Momentos docente (Minutos)")]
        public string MomentosDocente { get; set; }

        /// <summary>
        /// Obtiene o establece el estado de la salida ocupacional.
        /// </summary>
        public bool Estado { get; set; }
    }
}