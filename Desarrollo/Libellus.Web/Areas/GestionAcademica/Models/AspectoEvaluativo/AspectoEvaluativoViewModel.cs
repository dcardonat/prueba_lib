namespace Libellus.Web.Areas.GestionAcademica.Models.AspectoEvaluativo
{
    using Libellus.Entidades;
    using Libellus.Mensajes;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    /// <summary>
    /// Entidad para las vistas.
    /// </summary>
    public class AspectoEvaluativoViewModel
    {
        /// <summary>
        /// Constructor de la clase. 
        /// </summary>
        public AspectoEvaluativoViewModel()
        {
            IntensidadHorariaList = new List<SelectListItem>();
            AspectosEvaluativos = new List<SelectListItem>();
            IntensidadHorariaList = new List<SelectListItem>();
        }

        /// <summary>
        /// Identificador del registro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Año para la configuración.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [Display(Name = "Año")]
        public int IdAnioLectivo { get; set; }

        /// <summary>
        /// Identificador del aspecto evaluativo.
        /// </summary>
        [Display(Name = "Aspecto evaluativo")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int IdAspectoEvaluativo { get; set; }

        /// <summary>
        /// Intensidad horaria.
        /// </summary>
        [Display(Name = "Intensidad horaria")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int IdIntensidadHoraria { get; set; }

        /// <summary>
        /// Porcentaje.
        /// </summary>
        [Display(Name = "Porcentaje (%)")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [RegularExpression(@"(^(100(?:\,0{1,2})?))|(?!^0*$)(?!^0*\,0*$)^\d{1,2}(\,\d{1,2})?$", ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1012")]
        public string Porcentaje { get; set; }

        /// <summary>
        /// Pruebas minimas.
        /// </summary>
        [Display(Name = "Pruebas mínimas")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int PruebasMinimas { get; set; }

        /// <summary>
        /// Aspectos evaluativos.
        /// </summary>
        [Display(Name = "Aspecto")]
        public virtual Maestro Evaluativo { get; set; }

        /// <summary>
        /// Aspectos evaluativos.
        /// </summary>
        [Display(Name = "Intensidad Horaria")]
        public virtual Maestro IntensidadHoraria { get; set; }

        /// <summary>
        /// Obtiene o establece el año lectivo asociado.
        /// </summary>
        public virtual AnioLectivo AnioLectivo { get; set; }

        /// <summary>
        /// Obtiene o establece la informacion del maestro Aspectos evaluativos.
        /// </summary>
        public List<SelectListItem> AspectosEvaluativos { get; set; }

        /// <summary>
        /// Obtiene o establece la informacion de la intensidad horaria
        /// </summary>
        public List<SelectListItem> IntensidadHorariaList { get; set; }

        /// <summary>
        /// Obtiene o establece la informacion de las pruebas minimas.
        /// </summary>
        public List<SelectListItem> PruebasMinimasList { get; set; }

    }
}