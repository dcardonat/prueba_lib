namespace Libellus.Repositorio.Contextos
{
    using System.Data.Entity;
    using Libellus.Entidades;
    using Libellus.Repositorio.MapeoEntidades;

    /// <summary>
    /// Proporciona funciones para consultar y trabajar con datos de la DB Libellus.
    /// </summary>
    public partial class LibellusDbContext : DbContext
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo LibellusDbContext.
        /// </summary>
        public LibellusDbContext()
            : base("name=LibellusDbContext")
        {
            //// Se establece el inicializador de la base de datos a null para usar Code First con una base de datos ya existente.
            Database.SetInitializer<LibellusDbContext>(null);
            //Configuration.ProxyCreationEnabled = false;
        }

        /// <summary>
        /// Inicializa una nueva instancia de tipo LibellusDbContext con la cadena de conexión de la DB a trabajar.
        /// </summary>
        /// <param name="cadenaConexion">Cadena de conexión con la que se trabajará.</param>
        public LibellusDbContext(string cadenaConexion)
            : base(cadenaConexion)
        {
            //// Se establece el inicializador de la base de datos a null para usar Code First con una base de datos ya existente.
            Database.SetInitializer<LibellusDbContext>(null);
            //Configuration.ProxyCreationEnabled = false;
        }

        #endregion Constructores

        #region Propiedades

        /// <summary>
        /// Define la información de la tabla ActividadesComplementarias.
        /// </summary>
        public virtual DbSet<ActividadComplementaria> ActividadesComplementarias { get; set; }

        /// <summary>
        /// Obtiene o establece la informacion de la tabla Asignaturas.
        /// </summary>
        public virtual DbSet<Asignatura> Asignaturas { get; set; }

        /// <summary>
        /// Obtiene o establece la informacion de la tabla Aulas.
        /// </summary>
        public virtual DbSet<Aula> Aulas { get; set; }

        /// <summary>
        /// Obtiene o establece la informacion de la tabla Funcionalidades.
        /// </summary>
        public virtual DbSet<Funcionalidad> Funcionalidades { get; set; }

        /// <summary>
        /// Define la información de la tabla RolesFuncionalidades.
        /// </summary>
        public virtual DbSet<RolesFuncionalidades> RolesFuncionalidades { get; set; }

        /// <summary>
        /// Define la información de la tabla Maestros.
        /// </summary>
        public virtual DbSet<Maestro> Maestros { get; set; }

        /// <summary>
        /// Define la informacion de la tabla Roles.
        /// </summary>
        public virtual DbSet<Rol> Roles { get; set; }

        /// <summary>
        /// Define la información de la tabla Sedes.
        /// </summary>
        public virtual DbSet<Sede> Sedes { get; set; }

        /// <summary>
        /// Define la información de la tabla TipoMaestros.
        /// </summary>
        public virtual DbSet<TipoMaestro> TipoMaestros { get; set; }

        /// <summary>
        /// Define la información de la tabla Usuarios.
        /// </summary>
        public virtual DbSet<Usuario> Usuario { get; set; }

        /// <summary>
        /// Define la información de la tabla Usuarios Administrativos.
        /// </summary>
        public virtual DbSet<UsuarioAdministrativo> UsuariosAdministrativos { get; set; }

        /// <summary>
        /// Define la información de la tabla SalidasOcupacionales.
        /// </summary>
        public virtual DbSet<SalidaOcupacional> SalidasOcupacionales { get; set; }

        /// <summary>
        /// Define la información de la tabla GradosPorNivel.
        /// </summary>
        public virtual DbSet<GradosPorNivel> GradosPorNivel { get; set; }

        /// <summary>
        /// Define la informacion de la tabla SoportePorRoles.
        /// </summary>
        public virtual DbSet<SoportePorRol> SoportePorRoles { get; set; }

        /// <summary>
        /// Define la informacion de la tabla SoportePorRolesDocumentos.
        /// </summary>
        public virtual DbSet<SoportePorRolesDocumento> SoportePorRolesDocumentos { get; set; }

        /// <summary>
        /// Define la informacion de la tabla ParametrizacionInstitucional.
        /// </summary>
        public virtual DbSet<ParametrizacionInstitucional> ParametrizacionInstitucional { get; set; }

        /// <summary>
        /// Define la información de la tabla UsuariosRoles.
        /// </summary>
        public virtual DbSet<UsuarioRol> UsuariosRoles { get; set; }

        /// <summary>
        /// Define la informacion de la tabla InstitucionEducativa.
        /// </summary>
        public virtual DbSet<InstitucionEducativa> InstitucionEducativa { get; set; }

        /// <summary>
        /// Define la informacion de la tabla RegistrosLegalizacion.
        /// </summary>
        public virtual DbSet<RegistroLegalizacion> RegistrosLegalizacion { get; set; }

        /// <summary>
        /// Define la informacion de la tabla IntensidadHoraria.
        /// </summary>
        public virtual DbSet<IntensidadHoraria> IntensidadHoraria { get; set; }

        /// <summary>
        /// Define la informacion de la tabla DocenteArchivos.
        /// </summary>
        public virtual DbSet<DocenteArchivo> DocenteArchivos { get; set; }

        /// <summary>
        /// Define la informacion de la tabla DocenteDatosPersonales.
        /// </summary>
        public virtual DbSet<DocenteDatosPersonales> DocenteDatosPersonales { get; set; }

        /// <summary>
        /// Define la informacion de la tabla DocenteDatosResidenciales.
        /// </summary>
        public virtual DbSet<DocenteDatosResidenciales> DocenteDatosResidenciales { get; set; }

        /// <summary>
        /// Define la informacion de la tabla DocenteDocumentosSoporte.
        /// </summary>
        public virtual DbSet<DocenteDocumentoSoporte> DocenteDocumentosSoporte { get; set; }

        /// <summary>
        /// Define la informacion de la tabla DocenteEstados.
        /// </summary>
        public virtual DbSet<DocenteEstado> DocenteEstados { get; set; }

        /// <summary>
        /// Define la informacion de la tabla DocenteEstudios.
        /// </summary>
        public virtual DbSet<DocenteEstudio> DocenteEstudios { get; set; }

        /// <summary>
        /// Define la informacion de la tabla DocenteExperienciaLaboral.
        /// </summary>
        public virtual DbSet<DocenteExperienciaLaboral> DocenteExperienciaLaboral { get; set; }

        /// <summary>
        /// Define la informacion de la tabla Paises.
        /// </summary>
        public virtual DbSet<Pais> Paises { get; set; }

        /// <summary>
        /// Define la informacion de la tabla Departamentos.
        /// </summary>
        public virtual DbSet<Departamento> Departamentos { get; set; }

        /// <summary>
        /// Define la informacion de la tabla Municipios.
        /// </summary>
        public virtual DbSet<Municipio> Municipios { get; set; }

        /// <summary>
        /// Define la informacion de la tabla ParametrosPromocion.
        /// </summary>
        public virtual DbSet<ParametroPromocion> ParametrosPromocion { get; set; }

        /// <summary>
        /// Define la informacion de la tabla ProyeccionCuposNiveles.
        /// </summary>
        public virtual DbSet<ProyeccionCuposPorNivel> CuposPorNivel { get; set; }

        /// <summary>
        /// Define la informacion de la tabla RangosDesempenio.
        /// </summary>
        public virtual DbSet<RangosDesempenio> RangosDesempenio { get; set; }

        /// <summary>
        /// Define la informacion de la tabla AspectosEvaluativos.
        /// </summary>
        public virtual DbSet<AspectoEvaluativo> AspectosEvaluativos { get; set; }

        /// <summary>
        /// Define la informacion de la tabla AnioLectivo.
        /// </summary>
        public virtual DbSet<AnioLectivo> AnioLectivo { get; set; }

        /// <summary>
        /// Define la informacion de la tabla AperturaExtemporaneaPeriodo.
        /// </summary>
        public virtual DbSet<AperturaExtemporaneaPeriodo> AperturaExtemporaneaPeriodos { get; set; }

        /// <summary>
        /// Define la informacion de la tabla AreaNivel.
        /// </summary>
        public virtual DbSet<AreaNivel> AreasNivel { get; set; }

        /// <summary>
        /// Define la informacion de la tabla GradoParametrizacion.
        /// </summary>
        public virtual DbSet<GradoParametrizacion> GradosParametrizacion { get; set; }

        /// <summary>
        /// Define la informacion de la tabla NivelParametrizacion.
        /// </summary>
        public virtual DbSet<NivelParametrizacion> NivelesParametrizacion { get; set; }

        /// <summary>
        /// Define la informacion de la tabla ParametrizacionEscolar.
        /// </summary>
        public virtual DbSet<ParametrizacionEscolar> ParametrizacionEscolar { get; set; }

        /// <summary>
        /// Define la informacion de la tabla PeriodoParametrizacion.
        /// </summary>
        public virtual DbSet<PeriodoParametrizacion> PeriodosParametrizacion { get; set; }

        /// <summary>
        /// Define la informacion de la tabla ParametrosNegocio.
        /// </summary>
        public virtual DbSet<ParametrosNegocio> ParametrosNegocio { get; set; }

        /// <summary>
        /// Define la informacion de la tabla UsuariosEstado.
        /// </summary>
        public virtual DbSet<UsuariosEstado> UsuariosEstado { get; set; }

        /// <summary>
        /// Define la informacion de la tabla Cupos.
        /// </summary>
        public virtual DbSet<Cupo> Cupos { get; set; }

        /// <summary>
        /// Define la informacion de la tabla EstudiantesDatosPersonales.
        /// </summary>
        public virtual DbSet<EstudianteDatosPersonales> EstudiantesDatosPersonales { get; set; }

        /// <summary>
        /// Define la informacion de la tabla EstudiantesDatosResidenciales.
        /// </summary>
        public virtual DbSet<EstudianteDatosResidenciales> EstudiantesDatosResidenciales { get; set; }

        /// <summary>
        /// Define la informacion de la tabla EstudiantesArchivos.
        /// </summary>
        public virtual DbSet<EstudianteArchivo> EstudiantesArchivos { get; set; }

        /// <summary>
        /// Define la informacion de la tabla EstudiantesArchivos.
        /// </summary>
        public virtual DbSet<EstudianteAntecedenteAcademico> EstudiantesAntecedentesAcademicos { get; set; }

        /// <summary>
        /// Define la informacion de la tabla MatriculaDocumentosSoporte.
        /// </summary>
        public virtual DbSet<MatriculasDocumentos> MatriculaDocumentosSoporte { get; set; }

        /// <summary>
        /// Define la informacion de la tabla CancelacionMatriculas.
        /// </summary>
        public virtual DbSet<CancelacionMatriculas> CancelacionMatriculas { get; set; }

        /// <summary>
        /// Define la informacion de la tabla CancelacionMatriculas.
        /// </summary>
        public virtual DbSet<Matricula> Matriculas { get; set; }

        /// <summary>
        /// Define la informacion de la tabla Grupos.
        /// </summary>
        public virtual DbSet<Grupo> Grupos { get; set; }

        /// <summary>
        /// Define la informacion de la tabla EstudiantesPorGrupo.
        /// </summary>
        public virtual DbSet<EstudiantePorGrupo> EstudiantesPorGrupo { get; set; }

        /// <summary>
        /// Define la informacion de la tabla GruposPorGrado.
        /// </summary>
        public virtual DbSet<GruposPorGrado> GruposPorGrado { get; set; }

        /// <summary>
        /// Define la informacion de la tabla EstuiantesDatosFamiliares.
        /// </summary>
        public virtual DbSet<EstudianteDatosFamiliares> EstudiantesDatosFamiliares { get; set; }

        /// <summary>
        /// Define la informacion de la tabla FamiliaresEstudiantes.
        /// </summary>
        public virtual DbSet<FamiliarEstudiante> FamiliaresEstudiantes { get; set; }

        #endregion Propiedades

        #region Eventos

        /// <summary>
        /// Injecta las configuraciones de las entidades en el modelo de la DB Libellus.
        /// </summary>
        /// <param name="modelBuilder">Modelo a configurar.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            MapeoAdministracion.EstablecerMapeo(modelBuilder);
            MapeoAcademica.EstablecerMapeo(modelBuilder);
            MapeoMatricula.EstablecerMapeo(modelBuilder);
        }

        #endregion Eventos
    }
}