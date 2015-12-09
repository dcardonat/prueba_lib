namespace Libellus.Web.Areas.Administracion.Models.ParametrizacionEscolar
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Libellus.Entidades;
    using Libellus.Mensajes;

    /// <summary>
    /// Representa el modelo.
    /// </summary>
    public class ParametrizacionEscolarViewModel
    {
        /// <summary>
        /// Inicializa una nueva instancia de ParametrizacionEscolarViewModel 
        /// </summary>
        public ParametrizacionEscolarViewModel()
        {
            this.GradosParametrizacionSeleccionados = new List<int>();
            this.PeriodosParametrizacion = new List<PeriodoViewModel>();
            this.AreasNivel = new List<AreasNivelViewModel>();
            this.ComboAnios = new List<SelectListItem>();
        }

        /// <summary>
        /// Obtiene o establece el identificador del registro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del año lectivo asociado.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [Display(Name = "Año")]
        public int IdAnioLectivo { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del tipo de parametrizacion asociado.
        /// </summary>
        [Display(Name = "Tipo parametrización")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int IdTipoParametrizacion { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del semestre asociado.
        /// </summary>
        [Display(Name = "Semestre")]
        //[Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int? IdSemestre { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la jornada academica asociada.
        /// </summary>
        [Display(Name = "Jornada académica")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int IdJornadaAcademica { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de las semanas lectivas asociadas.
        /// </summary>
        [Display(Name = "Semanas lectivas")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public int SemanasLectivas { get; set; }

        /// <summary>
        /// Obtiene o establece el total de periodos configurados.
        /// </summary>
        public int Periodos
        {
            get
            {
                return this.PeriodosParametrizacion.Count();
            }
        }

        /// <summary>
        /// Obtiene o establece el porcentaje de inasistencia del año lectivo.
        /// </summary>
        [Display(Name = "Porcentaje inasistencia (%)")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        [Range(0, 100, ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1006")]
        public byte PorcentajeInasistencia { get; set; }

        /// <summary>
        /// Obtiene o establece el nivel.
        /// </summary>
        [Display(Name = "Niveles")]
        public int? IdNivel { get; set; }

        /// <summary>
        /// Obtiene o establece el año lectivo asociado.
        /// </summary>
        public virtual AnioLectivo AnioLectivo { get; set; }

        /// <summary>
        /// Obtiene o establece la jornada academica asociada.
        /// </summary>
        public virtual Maestro JornadaAcademica { get; set; }

        /// <summary>
        /// Obtiene o establece el semeestre asociado.
        /// </summary>
        public virtual Maestro Semestre { get; set; }

        /// <summary>
        /// Obtiene o establece el tipo de parametrizacion asociado.
        /// </summary>
        public virtual Maestro TipoParametrizacion { get; set; }

        /// <summary>
        /// Establece el combo para las jornadas academicas.
        /// </summary>
        public List<SelectListItem> ComboJornadasAcademicas { get; set; }

        /// <summary>
        /// Establece el combo para los semestres.
        /// </summary>
        public List<SelectListItem> ComboSemestres { get; set; }

        /// <summary>
        /// Establece el combo para los tipos de parametrización.
        /// </summary>
        public List<SelectListItem> ComboTiposParametrizacion { get; set; }

        /// <summary>
        /// Establece el combo para los grados.
        /// </summary>
        public List<SelectListItem> ComboGrados { get; set; }

        /// <summary>
        /// Establece el combo para los años.
        /// </summary>
        public List<SelectListItem> ComboAnios { get; set; }

        /// <summary>
        /// Establece la lista de valores para los grados por parametrizacion.
        /// </summary>
        [Display(Name="Grados de la parametrización")]
        [Required(ErrorMessageResourceType = typeof(MensajesEstaticos), ErrorMessageResourceName = "Mensaje1001")]
        public IEnumerable<int> GradosParametrizacionSeleccionados { get; set; }

        /// <summary>
        /// Obtiene la cadena de valores de los grados que estan seleccionados.
        /// </summary>
        public string ValoresGrados
        {
            get
            {
                return string.Join(",", this.GradosParametrizacionSeleccionados);
            }
        }

        /// <summary>
        /// Obtiene o establece los periodos de la parametrización.
        /// </summary>
        public IEnumerable<PeriodoViewModel> PeriodosParametrizacion { get; set; }

        /// <summary>
        /// Obtiene o establece las areas por nivel de la parametrización.
        /// </summary>
        public IEnumerable<AreasNivelViewModel> AreasNivel { get; set; }
    }
}