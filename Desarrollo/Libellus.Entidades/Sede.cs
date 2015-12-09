namespace Libellus.Entidades
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Define la información de las sedes.
    /// </summary>
    public partial class Sede
    {
        /// <summary>
        /// Constructor de la clase, se inicializan las propiedades de 
        /// coleccion de datos que hacen referencia a otras entidades.
        /// </summary>
        public Sede()
        {
            this.ActividadesComplementarias = new HashSet<ActividadComplementaria>();
            this.Asignaturas = new HashSet<Asignatura>();
            this.Aulas = new HashSet<Aula>();
            this.Maestros = new HashSet<Maestro>();
            this.Roles = new HashSet<Rol>();
            this.ParametrizacionInstitucional = new HashSet<ParametrizacionInstitucional>();
            this.UsuariosRoles = new HashSet<UsuarioRol>();
            this.IntensidadesHorarias = new HashSet<IntensidadHoraria>();
            this.CuposPorNiveles = new HashSet<ProyeccionCuposPorNivel>();
            this.AspectosEvaluativos = new HashSet<AspectoEvaluativo>();
            this.RangoDesempenio = new HashSet<RangosDesempenio>();
            this.ParametrosPromocion = new HashSet<ParametroPromocion>();
            this.AniosLectivos = new HashSet<AnioLectivo>();
            this.Cupos = new HashSet<Cupo>();
        }

        /// <summary>
        /// Obtiene o establece el identificador interno.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la sede.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la institucion educativa.
        /// </summary>
        public int IdInstitucionEducativa { get; set; }

        /// <summary>
        /// Obtiene o establece el codigo de seccion.
        /// </summary>
        public string Seccion { get; set; }

        /// <summary>
        /// Obtiene o establece la entidad relacionada de institucion educativa.
        /// </summary>
        public virtual InstitucionEducativa InstitucionEducativa { get; set; }

        /// <summary>
        /// Obtiene o establece los maestros administrales asociados.
        /// </summary>
        public ICollection<Maestro> Maestros { get; set; }

        /// <summary>
        /// Obtiene o establece las actividades complementarias relacionadas.
        /// </summary>
        public virtual ICollection<ActividadComplementaria> ActividadesComplementarias { get; set; }

        /// <summary>
        /// Obtiene o establece las asignaturas relacionadas.
        /// </summary>
        public virtual ICollection<Asignatura> Asignaturas { get; set; }

        /// <summary>
        /// Obtiene o establece las aulas relacionadas.
        /// </summary>
        public virtual ICollection<Aula> Aulas { get; set; }

        /// <summary>
        /// Obtiene o establece los roles relacionados.
        /// </summary>
        public virtual ICollection<Rol> Roles { get; set; }

        /// <summary>
        /// Obtiene o establece las salidas ocupacionales asociadas.
        /// </summary>
        public virtual ICollection<SalidaOcupacional> SalidasOcupacionales { get; set; }

        /// <summary>
        /// Obtiene o establece los la informacion de documentacion para soporte por rol asociada.
        /// </summary>
        public virtual ICollection<SoportePorRol> SoportePorRoles { get; set; }

        /// <summary>
        /// Obtiene o establece los usuarios y roles.
        /// </summary>
        public virtual ICollection<UsuarioRol> UsuariosRoles { get; set; }

        /// <summary>
        /// Obtiene o establece la informacion de la parametrización institucional asociada.
        /// </summary>
        public virtual ICollection<ParametrizacionInstitucional> ParametrizacionInstitucional { get; set; }

        /// <summary>
        /// Obtiene o establece la informacion de la intensidad horaria asociada.
        /// </summary>
        public virtual ICollection<IntensidadHoraria> IntensidadesHorarias { get; set; }

        /// <summary>
        /// Obtiene o establece la informacion de la proyección de grupos por nivel.
        /// </summary>
        public virtual ICollection<ProyeccionCuposPorNivel> CuposPorNiveles { get; set; }

        /// <summary>
        /// Obtiene o establece los aspectos evaluativos.
        /// </summary>
        public virtual ICollection<AspectoEvaluativo> AspectosEvaluativos { get; set; }

        /// <summary>
        /// Obtiene o establece rango de desempeño.
        /// </summary>
        public virtual ICollection<RangosDesempenio> RangoDesempenio { get; set; }

        /// <summary>
        /// Obtiene o establece los parametros de promoción.
        /// </summary>
        public virtual ICollection<ParametroPromocion> ParametrosPromocion { get; set; }

        /// <summary>
        /// Obtiene o establece los Anios lectivos.
        /// </summary>
        public virtual ICollection<AnioLectivo> AniosLectivos { get; set; }

        /// <summary>
        /// Obtiene los cupos.
        /// </summary>
        public virtual ICollection<Cupo> Cupos { get; set; }

    }
}
