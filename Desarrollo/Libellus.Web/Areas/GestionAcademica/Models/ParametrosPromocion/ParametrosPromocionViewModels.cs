namespace Libellus.Web.Areas.GestionAcademica.Models.ParametrosPromocion
{
    using Libellus.Entidades;
    using Libellus.Mensajes;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    /// <summary>
    /// View model Para la administración de la informacion de los parametros de promoción.
    /// </summary>
    public class ParametrosPromocionViewModels
    {
        /// <summary>
        /// Contructor de la clase. 
        /// </summary>
        public ParametrosPromocionViewModels()
        {
            this.Evaluaciones = new List<SelectListItem>();
            this.PromediosPromocion = new List<SelectListItem>();
            this.CalificacionesMaximas = new List<SelectListItem>();
            this.CalificacionesMinimas = new List<SelectListItem>();
            this.AnioLectivo = new AnioLectivo();
        }

        /// <summary>
        /// Identificador de la entidad.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Año para la configuración.
        /// </summary>
        [Display(Name = "Año")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int IdAnioLectivo { get; set; }

        /// <summary>
        /// Calificación minima.
        /// </summary>
        [Display(Name = "Calificación mínima")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int IdCalificacionMinima { get; set; }

        /// <summary>
        /// Calificación maxima.
        /// </summary>
        [Display(Name = "Calificación máxima")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int IdCalificacionMaxima { get; set; }

        /// <summary>
        /// Minimo areas reprobadas.
        /// </summary>
        
        [RegularExpression(@"\d+", ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1004")]
        [Display(Name = "Mínimo áreas Reprobadas/ Promoción")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string MinimoAreasReprobadas { get; set; }

        /// <summary>
        /// Maximo de areas mejoramiento.
        /// </summary>
        [Display(Name = "Máxima áreas plan de mejoramiento")]
        [RegularExpression(@"\d+", ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1004")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string MaximoAreasMejoramiento { get; set; }

        /// <summary>
        /// Minimo areas reprobación.
        /// </summary>
        [Display(Name = "Mínimo  áreas reprobación")]
        [RegularExpression(@"\d+", ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1004")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string MinimoAreaReprobacion { get; set; }

        /// <summary>
        /// Promedio de la promoción.
        /// </summary>
        [Display(Name = "Promedio promoción")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int IdPromedioPromocion { get; set; }

        /// <summary>
        /// Porcentaje de inasistencia.
        /// </summary>
        [Display(Name = "Porcentaje inasistencia")]
        [RegularExpression(@"(^(100(?:\,0{1,2})?))|(?!^0*$)(?!^0*\,0*$)^\d{1,2}(\,\d{1,2})?$", ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1012")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string PorcentajeInasistencia { get; set; }

        /// <summary>
        /// Identificador de la evaluacion aprendizaje.
        /// </summary>
        [Display(Name = "Evaluación aprendizaje")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int IdEvaluacionAprendizaje { get; set; }

        /// <summary>
        /// Promedio ponderado.
        /// </summary>
        [Display(Name = "Promedio ponderado")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public bool PromedioPonderado { get; set; }

        /// <summary>
        /// Calificación minima para la aprobación.
        /// </summary>
        [Display(Name = "Calificación mínima de aprobación")]
        [RegularExpression(@"(^(100(?:\,0{1,2})?))|(?!^0*$)(?!^0*\,0*$)^\d{1,2}(\,\d{1,2})?$", ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1012")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public string CalificacionMinimaAprobacion { get; set; }

        /// <summary>
        /// Indica si ya se han configurado rangos de desempeño.
        /// </summary>
        public bool ConfiguracionRangos { get; set; }

        /// <summary>
        /// Maestro evaluación del aprendizaje.
        /// </summary>
        public virtual Maestro EvaluacionAprendizaje { get; set; }

        /// <summary>
        /// Maestro evaluación del aprendizaje.
        /// </summary>
        public virtual Maestro CalificacionMinima { get; set; }

        /// <summary>
        /// Maestro evaluación del aprendizaje.
        /// </summary>
        public virtual Maestro CalificacionMaxima { get; set; }

        /// <summary>
        /// Obtiene o establece el año lectivo asociado.
        /// </summary>
        public virtual AnioLectivo AnioLectivo { get; set; }

        /// <summary>
        /// Obtiene o establece la informacion del maestro asociado (EvaluacionAprendizaje)
        /// </summary>
        public List<SelectListItem> Evaluaciones { get; set; }

        /// <summary>
        /// Obtiene o establece la informacion del maestro asociado (PromediosPromocion)
        /// </summary>
        public List<SelectListItem> PromediosPromocion { get; set; }

        /// <summary>
        /// Obtiene o establece la informacion del maestro asociado (PromediosPromocion)
        /// </summary>
        public List<SelectListItem> CalificacionesMinimas { get; set; }

        /// <summary>
        /// Obtiene o establece la informacion del maestro asociado (PromediosPromocion)
        /// </summary>
        public List<SelectListItem> CalificacionesMaximas { get; set; }
    }
}