namespace Libellus.Entidades
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Define la información de un maestro administrable.
    /// </summary>
    [Table("dbo.Maestros")]
    public partial class Maestro
    {
        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Maestro()
        {
            this.Asignaturas = new HashSet<Asignatura>();
            this.Aulas = new HashSet<Aula>();
            this.TiposIdentificaciones = new HashSet<Usuario>();
            this.GruposSanguineos = new HashSet<UsuarioAdministrativo>();
            this.Cargos = new HashSet<UsuarioAdministrativo>();
            this.DocumentosSoporte = new HashSet<SoportePorRolesDocumento>();
            this.RolesInstitucionales = new HashSet<SoportePorRol>();
            this.NivelesEducativos = new HashSet<SoportePorRol>();
            this.ParametrizacionInstitucionalNivelesEducativos = new HashSet<ParametrizacionInstitucional>();
            this.ParametrizacionInstitucionalNivelesEducativos = new HashSet<ParametrizacionInstitucional>();
            this.IntensidadesHorarias = new HashSet<IntensidadHoraria>();
            this.DocenteDatosPersonalesTipoDocumento = new HashSet<DocenteDatosPersonales>();
            this.DocenteDatosPersonalesSexo = new HashSet<DocenteDatosPersonales>();
            this.DocenteDatosPersonalesGrupoSanguineo = new HashSet<DocenteDatosPersonales>();
            this.DocenteDatosPersonalesEstadoCivil = new HashSet<DocenteDatosPersonales>();
            this.DocenteDatosPersonalesRolInstitucional = new HashSet<DocenteDatosPersonales>();
            this.DocenteDatosResidenciales = new HashSet<DocenteDatosResidenciales>();
            this.DocenteEstados = new HashSet<DocenteEstado>();
            this.DocenteEstudiosClasificacion = new HashSet<DocenteEstudio>();
            this.DocenteEstudiosEstadoEstudio = new HashSet<DocenteEstudio>();
            this.NivelesEducativosGrupos = new HashSet<ProyeccionCuposPorNivel>();
            this.AspectosEvaluativos = new HashSet<AspectoEvaluativo>();
            this.IntensidadHoraria = new HashSet<AspectoEvaluativo>();
            this.RangoDesempenio = new HashSet<RangosDesempenio>();
            this.ParametrosPromocion = new HashSet<ParametroPromocion>();
            this.JornadasAcademicas = new HashSet<ParametrizacionEscolar>();
            this.TiposParametrizacion = new HashSet<ParametrizacionEscolar>();
            this.Semestres = new HashSet<ParametrizacionEscolar>();
            this.GradosPorParametrizacion = new HashSet<GradoParametrizacion>();
            this.NivelesParametrizacion = new HashSet<NivelParametrizacion>();
            this.AreasNivel = new HashSet<AreaNivel>();
            this.CalificacionMinima = new HashSet<ParametroPromocion>();
            this.CalificacionMaxima = new HashSet<ParametroPromocion>();
            this.Cupos = new HashSet<Cupo>();
            this.Matriculas = new HashSet<Matricula>();
            this.CancelacionMatriculas = new HashSet<CancelacionMatriculas>();
            this.Horarios = new HashSet<Grupo>();
            this.GradosGrupo = new HashSet<GruposPorGrado>();
            this.Grupos = new HashSet<GruposPorGrado>();
        }

        /// <summary>
        /// Constructor de la clase que setea la descripcion;
        /// </summary>
        /// <param name="descripcion">Descripcion del maestro a establecer.</param>
        public Maestro(string descripcion)
        {
            this.Descripcion = descripcion;
        }

        /// <summary>
        /// Obtiene o establece el identificador interno.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el tipo de maestro.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno del tipo de maestro asociado.
        /// </summary>
        public short IdTipoMaestro { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador interno de la sede asociada.
        /// </summary>
        public int IdSede { get; set; }

        /// <summary>
        /// Obtiene o establece el estado del maestro.
        /// </summary>
        public bool Estado { get; set; }

        /// <summary>
        /// Obtiene o establece el consecutivo asociado al maestro.
        /// </summary>
        public int? Consecutivo { get; set; }

        /// <summary>
        /// Obtiene o establece la información del tipo de maestro asociado.
        /// </summary>
        public virtual TipoMaestro TipoMaestro { get; set; }

        /// <summary>
        /// Obtiene o establece la información de la sede asociada.
        /// </summary>
        public virtual Sede Sede { get; set; }

        /// <summary>
        /// Obtiene o establece las asignaturas asociadas.
        /// </summary>
        public virtual ICollection<Asignatura> Asignaturas { get; set; }

        /// <summary>
        /// Obtiene o establece las aulas asociadas.
        /// </summary>
        public virtual ICollection<Aula> Aulas { get; set; }

        /// <summary>
        /// Obtiene o establece los tipos de identificaciones asociados.
        /// </summary>
        public virtual ICollection<Usuario> TiposIdentificaciones { get; set; }

        /// <summary>
        /// Obtiene o establece los grupos sanguineos asociados.
        /// </summary>
        public virtual ICollection<UsuarioAdministrativo> GruposSanguineos { get; set; }

        /// <summary>
        /// Obtiene o establece los cargos asociados.
        /// </summary>
        public virtual ICollection<UsuarioAdministrativo> Cargos { get; set; }

        /// <summary>
        /// Obtiene o establece los niveles asociados.
        /// </summary>
        public virtual ICollection<GradosPorNivel> Niveles { get; set; }

        /// <summary>
        /// Obtiene o establece los grados asociados.
        /// </summary>
        public virtual ICollection<GradosPorNivel> Grados { get; set; }

        /// <summary>
        /// Obtiene o establece los tipos de documento para soporte asociados.
        /// </summary>
        public virtual ICollection<SoportePorRolesDocumento> DocumentosSoporte { get; set; }

        /// <summary>
        /// Obtiene o establece los Roles institucionales asociados.
        /// </summary>
        public virtual ICollection<SoportePorRol> RolesInstitucionales { get; set; }

        /// <summary>
        /// Obtiene o establece los grados por nivel asociados.
        /// </summary>
        public virtual ICollection<SoportePorRol> NivelesEducativos { get; set; }

        /// <summary>
        /// Obtiene o establece la información relacionada de la parametrización institucional con los niveles educativos.
        /// </summary>
        public virtual ICollection<ParametrizacionInstitucional> ParametrizacionInstitucionalNivelesEducativos { get; set; }

        /// <summary>
        /// Obtiene o establece la información relacionada de la parametrización institucional con los horarios.
        /// </summary>
        public virtual ICollection<ParametrizacionInstitucional> ParametrizacionInstitucionalHorarios { get; set; }

        /// <summary>
        /// Obtiene o establece la información relacionada de la intensidad horaria.
        /// </summary>
        public virtual ICollection<IntensidadHoraria> IntensidadesHorarias { get; set; }

        /// <summary>
        /// Obtiene o establece la información de los datos personales del docente asociados mediante el tipo de documento.
        /// </summary>
        public virtual ICollection<DocenteDatosPersonales> DocenteDatosPersonalesTipoDocumento { get; set; }

        /// <summary>
        /// Obtiene o establece la información de los datos personales del docente asociados mediante el sexo.
        /// </summary>
        public virtual ICollection<DocenteDatosPersonales> DocenteDatosPersonalesSexo { get; set; }

        /// <summary>
        /// Obtiene o establece la información de los datos personales del docente asociados mediante el grupo sanguíneo.
        /// </summary>
        public virtual ICollection<DocenteDatosPersonales> DocenteDatosPersonalesGrupoSanguineo { get; set; }

        /// <summary>
        /// Obtiene o establece la información de los datos personales del docente asociados mediante el estado civíl.
        /// </summary>
        public virtual ICollection<DocenteDatosPersonales> DocenteDatosPersonalesEstadoCivil { get; set; }

        /// <summary>
        /// Obtiene o establece la información de los datos personales del docente asociados mediante el rol instucional.
        /// </summary>
        public virtual ICollection<DocenteDatosPersonales> DocenteDatosPersonalesRolInstitucional { get; set; }

        /// <summary>
        /// Obtiene o establece la información de los datos residenciales del docente asociado.
        /// </summary>
        public virtual ICollection<DocenteDatosResidenciales> DocenteDatosResidenciales { get; set; }

        /// <summary>
        /// Obtiene o establece la información del horario del docente asociado.
        /// </summary>
        public virtual ICollection<DocenteEstado> DocenteHorario { get; set; }

        /// <summary>
        /// Obtiene o establece la información del estado en el sistema del docente asociado.
        /// </summary>
        public virtual ICollection<DocenteEstado> DocenteEstados { get; set; }

        /// <summary>
        /// Obtiene o establece la información de los estudios realizados por el docente asociados mediante la clasificación del estudio.
        /// </summary>
        public virtual ICollection<DocenteEstudio> DocenteEstudiosClasificacion { get; set; }

        /// <summary>
        /// Obtiene o establece la información de los estudios realizados por el docente asociados mediante el estado del estudio.
        /// </summary>
        public virtual ICollection<DocenteEstudio> DocenteEstudiosEstadoEstudio { get; set; }

        /// <summary>
        /// Obtiene o establece la información personal del docente asociados mediante el grado de escalafón.
        /// </summary>
        public virtual ICollection<DocenteDatosPersonales> DocenteDatosPersonalesGradoEscalafon { get; set; }

        /// <summary>
        /// Obtiene o establece los grados por nivel asociados.
        /// </summary>
        public virtual ICollection<ProyeccionCuposPorNivel> NivelesEducativosGrupos { get; set; }

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
        /// Obtiene o establece las parametrizaciones escolares.
        /// </summary>
        public virtual ICollection<ParametrizacionEscolar> JornadasAcademicas { get; set; }

        /// <summary>
        /// Obtiene o establece los tipos de parametrizacion de las parametrizaciones escolares.
        /// </summary>
        public virtual ICollection<ParametrizacionEscolar> TiposParametrizacion { get; set; }

        /// <summary>
        /// Obtiene o establece los semestres de las parametrizaciones escolares.
        /// </summary>
        public virtual ICollection<ParametrizacionEscolar> Semestres { get; set; }

        /// <summary>
        /// Obtiene o establece los grados por parametrización.
        /// </summary>
        public virtual ICollection<GradoParametrizacion> GradosPorParametrizacion { get; set; }

        /// <summary>
        /// Obtiene o establece los niveles por parametrizacion.
        /// </summary>
        public virtual ICollection<NivelParametrizacion> NivelesParametrizacion { get; set; }

        /// <summary>
        /// Obtiene o establece las areas por nivel.
        /// </summary>
        public virtual ICollection<AreaNivel> AreasNivel { get; set; }

        /// <summary>
        /// Obtiene o establece las Calificaciones maximas
        /// </summary>
        public virtual ICollection<ParametroPromocion> CalificacionMinima { get; set; }

        /// <summary>
        /// Obtiene o establece las calificaciones minimas
        /// </summary>
        public virtual ICollection<ParametroPromocion> CalificacionMaxima { get; set; }

        /// <summary>
        /// Obtiene o establece la intensidad horaria. 
        /// </summary>
        public virtual ICollection<AspectoEvaluativo> IntensidadHoraria { get; set; }

        /// <summary>
        /// Obtiene los cupos.
        /// </summary>
        public virtual ICollection<Cupo> Cupos { get; set; }

        /// <summary>
        /// Obtiene las matriculas.
        /// </summary>
        public virtual ICollection<Matricula> Matriculas { get; set; }

        /// <summary>
        /// Obtiene la cancelación de las matriculas.
        /// </summary>
        public virtual ICollection<CancelacionMatriculas> CancelacionMatriculas { get; set; }

        /// <summary>
        /// Obtiene los horarios.
        /// </summary>
        public virtual ICollection<Grupo> Horarios { get; set; }

        /// <summary>
        /// obtiene los grupos por grado.
        /// </summary>
        public virtual ICollection<GruposPorGrado> GradosGrupo { get; set; }

        /// <summary>
        /// obtiene los grupos por Grupos.
        /// </summary>
        public virtual ICollection<GruposPorGrado> Grupos { get; set; }
    }
}
