namespace Libellus.Entidades
{
    using System.Collections.Generic;

    public partial class ParametrizacionEscolar
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        public ParametrizacionEscolar()
        {
            this.GradosParametrizacion = new HashSet<GradoParametrizacion>();
            this.NivelesParametrizacion = new HashSet<NivelParametrizacion>();
            this.PeriodosParametrizacion = new HashSet<PeriodoParametrizacion>();
            this.GradosParametrizacionSeleccionados = new List<int>();
        }

        /// <summary>
        /// Obtiene o establece el identificador del registro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del año lectivo asociado.
        /// </summary>
        public int IdAnioLectivo { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del tipo de parametrizacion asociado.
        /// </summary>
        public int IdTipoParametrizacion { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del semestre asociado.
        /// </summary>
        public int? IdSemestre { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la jornada academica asociada.
        /// </summary>
        public int IdJornadaAcademica { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de las semanas lectivas asociadas.
        /// </summary>
        public int SemanasLectivas { get; set; }

        /// <summary>
        /// Obtiene o establece el porcentaje de inasistencia del año lectivo.
        /// </summary>
        public byte PorcentajeInasistencia { get; set; }

        /// <summary>
        /// Obtiene o establece el año lectivo asociado.
        /// </summary>
        public virtual AnioLectivo AnioLectivo { get; set; }

        /// <summary>
        /// Obtiene o establece los grados por parametrizacion a los cuales aplica la configuracion.
        /// </summary>
        public virtual ICollection<GradoParametrizacion> GradosParametrizacion { get; set; }

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
        /// Obtiene o establece los niveles de parametrizacion a los que aplica la parametrizacion.
        /// </summary>
        public virtual ICollection<NivelParametrizacion> NivelesParametrizacion { get; set; }

        /// <summary>
        /// Obtiene o establece los periodos a los cuales aplica la parametrizacion.
        /// </summary>
        public virtual ICollection<PeriodoParametrizacion> PeriodosParametrizacion { get; set; }

        /// <summary>
        /// Establece la lista de valores para los grados por parametrizacion.
        /// </summary>
        public List<int> GradosParametrizacionSeleccionados { get; set; }
        
    }
}