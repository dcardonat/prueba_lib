namespace Libellus.Entidades
{
    using System;
    using System.Collections.Generic;

    public partial class AnioLectivo
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        public AnioLectivo()
        {
            this.ParametrizacionesEscolares = new HashSet<ParametrizacionEscolar>();
            this.ProyeccionCuposPorNivel = new HashSet<ProyeccionCuposPorNivel>();
            this.RangosDesempenio = new HashSet<RangosDesempenio>();
            this.ParametrosPromocion = new HashSet<ParametroPromocion>();
            this.AspectosEvaluativos = new HashSet<AspectoEvaluativo>();
            this.SoportePorRoles = new HashSet<SoportePorRol>();
            this.IntensidadesHorarias = new HashSet<IntensidadHoraria>();
            this.ParametrizacionesInstitucionales = new HashSet<ParametrizacionInstitucional>();
            this.Cupos = new HashSet<Cupo>();
            this.Grupos = new HashSet<Grupo>();
        }

        /// <summary>
        /// Identificador del registro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Año para el cual se realiza la configuracion.
        /// </summary>
        public Int16 Anio { get; set; }

        /// <summary>
        /// Fecha de inicio escolar del año lectivo.
        /// </summary>
        public DateTime FechaInicio { get; set; }

        /// <summary>
        /// Obtiene o establece el estado del año.
        /// </summary>
        public bool Cerrado { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de cierre del año escolar.
        /// </summary>
        public DateTime? FechaCierre { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la sede del registro.
        /// </summary>
        public int IdSede { get; set; }

        /// <summary>
        /// Obtiene o establece la sede del registro.
        /// </summary>
        public virtual Sede Sede { get; set; }

        /// <summary>
        /// Obtiene o establece las parametrizaciones escolares asociadas al año escolar.
        /// </summary>
        public virtual ICollection<ParametrizacionEscolar> ParametrizacionesEscolares { get; set; }

        /// <summary>
        /// Obtiene o establece la proyeccion de cupos por nivel.
        /// </summary>
        public virtual ICollection<ProyeccionCuposPorNivel> ProyeccionCuposPorNivel { get; set; }

        /// <summary>
        /// Obtiene o establece los rangos de desempeño.
        /// </summary>
        public virtual ICollection<RangosDesempenio> RangosDesempenio { get; set; }

        /// <summary>
        /// Obtiene o establece los parametros de promoción.
        /// </summary>
        public virtual ICollection<ParametroPromocion> ParametrosPromocion { get; set; }

        /// <summary>
        /// Obtiene o establece los aspectos evaluativos.
        /// </summary>
        public virtual ICollection<AspectoEvaluativo> AspectosEvaluativos { get; set; }

        /// <summary>
        /// Obtiene los soportes por roles.
        /// </summary>
        public virtual ICollection<SoportePorRol> SoportePorRoles { get; set; }

        /// <summary>
        /// Obtiene las intensidades horarias relacionadas.
        /// </summary>
        public virtual ICollection<IntensidadHoraria> IntensidadesHorarias { get; set; }

        /// <summary>
        /// Obtiene las parametrizaciones institucionales relacionadas.
        /// </summary>
        public virtual ICollection<ParametrizacionInstitucional> ParametrizacionesInstitucionales { get; set; }

        /// <summary>
        /// Obtiene los cupos.
        /// </summary>
        public virtual ICollection<Cupo> Cupos { get; set; }

        /// <summary>
        /// Obtiene los grupos.
        /// </summary>
        public virtual ICollection<Grupo> Grupos { get; set; }
    }
}