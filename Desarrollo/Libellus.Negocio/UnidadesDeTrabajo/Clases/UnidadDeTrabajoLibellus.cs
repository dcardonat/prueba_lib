namespace Libellus.Negocio.UnidadesDeTrabajo
{
    using System;
    using Libellus.Repositorio.Administracion;
    using Libellus.Repositorio.Administracion.Clases;
    using Libellus.Repositorio.Administracion.Interfaces;
    using Libellus.Repositorio.Contextos;
    using Libellus.Repositorio.GestionAcademica;
    using Libellus.Repositorio.Seguridad;
    using Libellus.Utilidades;
    using Libellus.Repositorio.General;
    using Libellus.Repositorio.Matriculas;
    using Libellus.Repositorio.Matriculas.Interfaces;
    using Libellus.Repositorio.Matriculas.Clases;
using Libellus.Repositorio.GestionAcademica.Clases;
    using Libellus.Repositorio.GestionAcademica.Interfaces;

    /// <summary>
    /// Define una única unidad de trabajo para el contexto de la base de datos LibellusCentral.
    /// </summary>
    public class UnidadDeTrabajoLibellus : IUnidadDeTrabajoLibellus, IDisposable
    {
        #region Atributos

        /// <summary>
        /// Define el contexto de la base de datos Libellus.
        /// </summary>
        private LibellusDbContext contextoLibellus;

        /// <summary>
        /// Bandera que determina si se libera la unidad de trabajo de memoria.
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// Atributo que define la persistencia con la DB de Libellus para las actividades complementarias.
        /// </summary>
        private RepositorioActividadesComplementarias repositorioActividadesComplementarias;

        /// <summary>
        /// Atributo que define la persistencia con la DB de Libellus para el maestro de Asignaturas.
        /// </summary>
        private RepositorioAsignaturas repositorioAsignaturas;

        /// <summary>
        /// Atributo que define la persistencia con la DB de Libellus para el maestro de Aulas.
        /// </summary>
        private RepositorioAulas repositorioAulas;

        /// <summary>
        /// Atributo que define la persistencia con la DB de Libellus para los maestros administrables.
        /// </summary>
        private RepositorioMaestros repositorioMaestros;

        /// <summary>
        /// Atributo que define la persistencia con la DB de Libellus para los usuarios.
        /// </summary>
        private RepositorioUsuarios repositorioUsuarios;

        /// <summary>
        /// Atributo que define la persistencia con la DB de Libellus para los roles.
        /// </summary>
        private RepositorioRoles repositorioRoles;

        /// <summary>
        /// Atributo que define la persistencia con la DB de Libellus para las funcionalidades.
        /// </summary>
        private RepositorioFuncionalidades repositorioFuncionalidades;

        /// <summary>
        /// Atributo que define la persistencia con la DB de Libellus para los usuarios administrativos.
        /// </summary>
        private RepositorioUsuariosAdministrativos repositorioUsuariosAdministrativos;

        /// <summary>
        /// Atributo que define la persistencia con la DB de Libellus para las sedes.
        /// </summary>
        private RepositorioSedes repositorioSede;

        /// <summary>
        /// Define la persisitencia con la DB de Libellus para las SalidasOcupacionales.
        /// </summary>
        private RepositorioSalidasOcupacionales repositorioSalidasOcupacionales;

        /// <summary>
        /// Define la persisitencia con la DB de Libellus para los Grados por nivel.
        /// </summary>
        private RepositorioGradosPorNivel repositorioGradosPorNivel;

        /// <summary>
        /// Define la persisitencia con la DB de Libellus para la documentacion para soporte por roles.
        /// </summary>
        private RepositorioDocumentacionSoporteRoles repositorioDocumentacionSoporteRoles;

        /// <summary>
        /// Define la persisitencia con la DB de Libellus para la parametrización institucional.
        /// </summary>
        private RepositorioParametrizacionInstitucional repositorioParametrizacionInstitucional;

        /// <summary>
        /// Define la persisitencia con la DB de Libellus para los datos de insitucion educativa.
        /// </summary>
        private RepositorioInsititucionEducativa repositorioInsititucionEducativa;

        /// <summary>
        /// Define la persisitencia con la DB de Libellus para los datos del registro de intensidad horaria.
        /// </summary>
        private RepositorioIntensidadHoraria repositorioIntensidadHoraria;

        /// <summary>
        /// Define la persistencia con la BD libellus para la administración de la información de los docentes.
        /// </summary>
        private RepositorioDocente repositorioDocente;

        /// <summary>
        /// Define la persistencia con la BD libellus para la administración de la información de RolesFuncionalidades.
        /// </summary>
        private RepositorioRolesFuncionalidades repositorioRolesFuncionalidades;

        /// <summary>
        /// Define la persistencia con la BD libellus para la proyeccion de grupos por nivel.
        /// </summary>
        private RepositorioCuposPorNivel repositorioGruposPorNivel;

        /// <summary>
        /// Define la persistencia con la BD libellus para los aspectos evaluativos.
        /// </summary>
        private RepositorioAspectosEvaluativos repositorioAspectosEvaluativos;

        /// <summary>
        /// Define la persistencia con la BD libellus para los parametros de promoción.
        /// </summary>
        private RepositorioParametrosPromocion repositorioParametrosPromocion;

        /// <summary>
        /// Define la persistencia con la BD libellus para los rangos de desempeño.
        /// </summary>
        private RepositorioRangosDesempenio repositorioRangosDesempenio;

        /// <summary>
        /// Define la persistencia con la BD libellus para el año lectivo.
        /// </summary>
        private RepositorioAnioLectivo repositorioAnioLectivo;

        /// <summary>
        /// Define la persistencia con la BD libellus para la parametrizacion escolar.
        /// </summary>
        private RepositorioParametrizacionEscolar repositorioParametrizacionEscolar;

        /// <summary>
        /// Define la persistencia con la BD libellus para la apertura extemporanea de periodos.
        /// </summary>
        private RepositorioAperturaPeriodos repositorioAperturaPeriodos;

        /// <summary>
        /// Define la persistencia con la BD libellus para los parametros.
        /// </summary>
        private RepositorioParametros repositorioParametros;

        /// <summary>
        /// Define la persitencia con la BD para los cupos.
        /// </summary>
        private RepositorioCupos repositorioCupos;

        /// <summary>
        /// Define la persistencia con la BD para los estudiantes.
        /// </summary>
        private RepositorioEstudiante repositorioEstudiante;

        /// <summary>
        /// Define la persistencia con la BD para los antecedentes academicos.
        /// </summary>
        private RepositorioAntecedentesAcademicos repositorioAntecedentesAcademicos;

        /// <summary>
        /// Define la persistencia con la BD para las matriculas.
        /// </summary>
        private RepositorioMatriculas repositorioMatriculas;

        /// <summary>
        /// Define la persistencia con la BD para los grupos por grado.
        /// </summary>
        private RepositorioGruposPorGrado repositorioGruposPorGrado;

        /// <summary>
        /// Define la persistencia con la BD para los grupos. 
        /// </summary>
        private RepositorioGrupo repositorioGrupo;

        #endregion Atributos

        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo UnidadDeTrabajoLibellus con el DbContext de la DB Libellus.
        /// </summary>
        public UnidadDeTrabajoLibellus()
        {
            if (this.contextoLibellus == null)
            {
                this.contextoLibellus = new LibellusDbContext(RepositorioCentral.ObtenerParametros(ContextoLibellus.ObtenerColegioActual));
            }
        }

        #endregion Constructores

        #region Propiedades

        /// <summary>
        /// Define la persistencia con la DB de Libellus para los grupos.
        /// </summary>
        public IRepositorioGrupo RepositorioGrupo
        {
            get
            {
                if (this.repositorioGrupo == null)
                {
                    this.repositorioGrupo = new RepositorioGrupo(this.contextoLibellus);
                }

                return this.repositorioGrupo;
            }
        }

        /// <summary>
        /// Define la persistencia con la DB de Libellus para las actividades complementarias.
        /// </summary>
        public IRepositorioActividadesComplementarias RepositorioActividadesComplementarias
        {
            get
            {
                if (this.repositorioActividadesComplementarias == null)
                {
                    this.repositorioActividadesComplementarias = new RepositorioActividadesComplementarias(this.contextoLibellus);
                }

                return this.repositorioActividadesComplementarias;
            }
        }

        /// <summary>
        /// Define la persistencia con la DB de Libellus para las asignaturas.
        /// </summary>
        public IRepositorioAsignaturas RepositorioAsignaturas
        {
            get
            {
                if (this.repositorioAsignaturas == null)
                {
                    this.repositorioAsignaturas = new RepositorioAsignaturas(this.contextoLibellus);
                }

                return this.repositorioAsignaturas;
            }
        }

        /// <summary>
        /// Define la persistencia con la DB de Libellus para las aulas.
        /// </summary>
        public IRepositorioAulas RepositorioAulas
        {
            get
            {
                if (this.repositorioAulas == null)
                {
                    this.repositorioAulas = new RepositorioAulas(this.contextoLibellus);
                }

                return this.repositorioAulas;
            }
        }

        /// <summary>
        /// Define la persistencia con la DB de Libellus para los maestros administrables.
        /// </summary>
        public IRepositorioMaestros RepositorioMaestros
        {
            get
            {
                if (this.repositorioMaestros == null)
                {
                    this.repositorioMaestros = new RepositorioMaestros(this.contextoLibellus);
                }

                return this.repositorioMaestros;
            }
        }

        /// <summary>
        /// Define la persistencia con la DB de Libellus para los usuarios.
        /// </summary>
        public IRepositorioUsuarios RepositorioUsuarios
        {
            get
            {
                if (this.repositorioUsuarios == null)
                {
                    this.repositorioUsuarios = new RepositorioUsuarios(this.contextoLibellus);
                }

                return this.repositorioUsuarios;
            }
        }

        /// <summary>
        /// Define la persistencia con la DB de Libellus para los roles.
        /// </summary>
        public IRepositorioFuncionalidades RepositorioFuncionalidades
        {
            get
            {
                if (this.repositorioFuncionalidades == null)
                {
                    this.repositorioFuncionalidades = new RepositorioFuncionalidades(this.contextoLibellus);
                }

                return this.repositorioFuncionalidades;
            }
        }

        /// <summary>
        /// Define la persistencia con la DB de Libellus para los roles.
        /// </summary>
        public IRepositorioRoles RepositorioRoles
        {
            get
            {
                if (this.repositorioRoles == null)
                {
                    this.repositorioRoles = new RepositorioRoles(this.contextoLibellus);
                }

                return this.repositorioRoles;
            }
        }

        /// <summary>
        /// Define la persistencia con la DB de Libellus para los usuarios amiistrativos.
        /// </summary>
        public IRepositorioUsuariosAdministrativos RepositorioUsuariosAdministrativos
        {
            get
            {
                if (this.repositorioUsuariosAdministrativos == null)
                {
                    this.repositorioUsuariosAdministrativos = new RepositorioUsuariosAdministrativos(this.contextoLibellus);
                }

                return this.repositorioUsuariosAdministrativos;
            }
        }

        /// <summary>
        /// Define la persistencia con la DB de Libellus para las sedes.
        /// </summary>
        public IRepositorioSedes RepositorioSedes
        {
            get
            {
                if (this.repositorioSede == null)
                {
                    this.repositorioSede = new RepositorioSedes(this.contextoLibellus);
                }

                return this.repositorioSede;
            }
        }

        /// <summary>
        /// Define la persistencia con la DB de Libellus para las SalidasOcupacionales.
        /// </summary>
        public IRepositorioSalidasOcupacionales RepositorioSalidasOcupacionales
        {
            get
            {
                if (this.repositorioSalidasOcupacionales == null)
                {
                    this.repositorioSalidasOcupacionales = new RepositorioSalidasOcupacionales(this.contextoLibellus);
                }

                return this.repositorioSalidasOcupacionales;
            }
        }

        /// <summary>
        /// Define la persistencia con la DB de Libellus para los grados por nivel.
        /// </summary>
        public IRepositorioGradosPorNivel RepositorioGradosPorNivel
        {
            get
            {
                if (this.repositorioGradosPorNivel == null)
                {
                    this.repositorioGradosPorNivel = new RepositorioGradosPorNivel(this.contextoLibellus);
                }

                return this.repositorioGradosPorNivel;
            }
        }

        /// <summary>
        /// Define la persistencia con la DB de Libellus para la documentacion para soporte por roles.
        /// </summary>
        public IRepositorioDocumentacionSoporteRoles RepositorioDocumentacionSoporteRoles
        {
            get
            {
                if (this.repositorioDocumentacionSoporteRoles == null)
                {
                    this.repositorioDocumentacionSoporteRoles = new RepositorioDocumentacionSoporteRoles(this.contextoLibellus);
                }

                return this.repositorioDocumentacionSoporteRoles;
            }
        }

        /// <summary>
        /// Define la persisitencia con la DB de Libellus para la parametrización institucional.
        /// </summary>
        public IRepositorioParametrizacionInstitucional RepositorioParametrizacionInstitucional
        {
            get
            {
                if (this.repositorioParametrizacionInstitucional == null)
                {
                    this.repositorioParametrizacionInstitucional = new RepositorioParametrizacionInstitucional(this.contextoLibellus);
                }

                return this.repositorioParametrizacionInstitucional;
            }
        }

        /// <summary>
        /// Define la persistencia con la DB de Libellus para los datos de institucion educativa.
        /// </summary>
        public IRepositorioInstitucionEducativa RepositorioInstitucionEducativa
        {
            get
            {
                if (this.repositorioInsititucionEducativa == null)
                {
                    this.repositorioInsititucionEducativa = new RepositorioInsititucionEducativa(this.contextoLibellus);
                }

                return this.repositorioInsititucionEducativa;
            }
        }

        /// <summary>
        /// Define la persistencia con la DB de Libellus para los datos del registro de intensidad horaria.
        /// </summary>
        public IRepositorioIntensidadHoraria RepositorioIntensidadHoraria
        {
            get
            {
                if (this.repositorioIntensidadHoraria == null)
                {
                    this.repositorioIntensidadHoraria = new RepositorioIntensidadHoraria(this.contextoLibellus);
                }

                return this.repositorioIntensidadHoraria;
            }
        }

        /// <summary>
        /// Define la persistencia con la BD libellus para la administración de la información de los docentes.
        /// </summary>
        public IRepositorioDocente RepositorioDocente
        {
            get
            {
                if (this.repositorioDocente == null)
                {
                    this.repositorioDocente = new RepositorioDocente(this.contextoLibellus);
                }

                return this.repositorioDocente;
            }
        }

        /// <summary>
        /// Define la persistencia con la BD libellus para la administración de la información de los docentes.
        /// </summary>
        public IRepositorioRolesFuncionalidades RepositorioRolesFuncionalidades
        {
            get
            {
                if (this.repositorioRolesFuncionalidades == null)
                {
                    this.repositorioRolesFuncionalidades = new RepositorioRolesFuncionalidades(this.contextoLibellus);
                }

                return this.repositorioRolesFuncionalidades;
            }
        }

        /// <summary>
        /// Define la persistencia con la BD libellus para la administración de la proyección de grupos por nivel.
        /// </summary>
        public IRepositorioCuposPorNivel RepositorioCuposPorNivel
        {
            get
            {
                if (this.repositorioGruposPorNivel == null)
                {
                    this.repositorioGruposPorNivel = new RepositorioCuposPorNivel(this.contextoLibellus);
                }

                return this.repositorioGruposPorNivel;
            }
        }

        /// <summary>
        /// Define la persistencia con la BD libellus para la administración aspectos evaluativos.
        /// </summary>
        public IRepositorioAspectosEvaluativos RepositorioAspectosEvaluativos
        {
            get
            {
                if (this.repositorioAspectosEvaluativos == null)
                {
                    this.repositorioAspectosEvaluativos = new RepositorioAspectosEvaluativos(this.contextoLibellus);
                }

                return this.repositorioAspectosEvaluativos;
            }
        }

        /// <summary>
        /// Define la persistencia con la BD libellus para los parametros de negocio.
        /// </summary>
        public IRepositorioParametrosPromocion RepositorioParametrosPromocion
        {
            get
            {
                if (this.repositorioParametrosPromocion == null)
                {
                    this.repositorioParametrosPromocion = new RepositorioParametrosPromocion(this.contextoLibellus);
                }

                return this.repositorioParametrosPromocion;
            }
        }

        /// <summary>
        /// Define la persistencia con la BD libellus para los rango de desempeño.
        /// </summary>
        public IRepositorioRangosDesempenio RepositorioRangosDesempenio
        {
            get
            {
                if (this.repositorioRangosDesempenio == null)
                {
                    this.repositorioRangosDesempenio = new RepositorioRangosDesempenio(this.contextoLibellus);
                }

                return this.repositorioRangosDesempenio;
            }
        }

        /// <summary>
        /// Define la persistencia con la BD libellus para el año lectivo.
        /// </summary>
        public IRepositorioAnioLectivo RepositorioAnioLectivo
        {
            get
            {
                if (this.repositorioAnioLectivo == null)
                {
                    this.repositorioAnioLectivo = new RepositorioAnioLectivo(this.contextoLibellus);
                }

                return this.repositorioAnioLectivo;
            }
        }

        /// <summary>
        /// Define la persistencia con la BD libellus para la parametrizacion escolar.
        /// </summary>
        public IRepositorioParametrizacionEscolar RepositorioParametrizacionEscolar
        {
            get
            {
                if (this.repositorioParametrizacionEscolar == null)
                {
                    this.repositorioParametrizacionEscolar = new RepositorioParametrizacionEscolar(this.contextoLibellus);
                }

                return this.repositorioParametrizacionEscolar;
            }
        }

        /// <summary>
        /// Define la persistencia con la BD libellus para la apertura extemporanea de periodos.
        /// </summary>
        public IRepositorioAperturaPeriodos RepositorioAperturaPeriodos
        {
            get
            {
                if (this.repositorioAperturaPeriodos == null)
                {
                    this.repositorioAperturaPeriodos = new RepositorioAperturaPeriodos(this.contextoLibellus);
                }

                return this.repositorioAperturaPeriodos;
            }
        }

        /// <summary>
        /// Define la persistencia con la BD libellus para la apertura extemporanea de periodos.
        /// </summary>
        public IRepositorioParametros RepositorioParametros
        {
            get
            {
                if (this.repositorioParametros == null)
                {
                    this.repositorioParametros = new RepositorioParametros(this.contextoLibellus);
                }

                return this.repositorioParametros;
            }
        }

        /// <summary>
        /// Define la persistencia con la BD libellus para la generacion de cupos.
        /// </summary>
        public IRepositorioCupos RepositorioCupos
        {
            get
            {
                if (this.repositorioCupos == null)
                {
                    this.repositorioCupos = new RepositorioCupos(this.contextoLibellus);
                }

                return this.repositorioCupos;
            }
        }

        /// <summary>
        /// Define la persistencia con la BD para los estudiantes.
        /// </summary>
        public IRepositorioEstudiante RepositorioEstudiante
        {
            get
            {
                if (this.repositorioEstudiante == null)
                {
                    this.repositorioEstudiante = new RepositorioEstudiante(this.contextoLibellus);
                }

                return this.repositorioEstudiante;
            }
        }

        /// <summary>
        /// Define la persistencia con la BD para los estudiantes.
        /// </summary>
        public IRepositorioAntecedentesAcademicos RepositorioAntecedentesAcademicos
        {
            get
            {
                if (this.repositorioAntecedentesAcademicos == null)
                {
                    this.repositorioAntecedentesAcademicos = new RepositorioAntecedentesAcademicos(this.contextoLibellus);
                }

                return this.repositorioAntecedentesAcademicos;
            }
        }

        /// <summary>
        /// Define la persistencia con la BD para las matriculas.
        /// </summary>
        public IRepositorioMatriculas RepositorioMatriculas
        {
            get
            {
                if (this.repositorioMatriculas == null)
                {
                    this.repositorioMatriculas = new RepositorioMatriculas(this.contextoLibellus);
                }

                return this.repositorioMatriculas;
            }
        }

        /// <summary>
        /// Define la persistencia con la BD para las matriculas.
        /// </summary>
        public IRepositorioGruposPorGrado RepositorioGruposPorGrado
        {
            get
            {
                if (this.repositorioGruposPorGrado == null)
                {
                    this.repositorioGruposPorGrado = new RepositorioGruposPorGrado(this.contextoLibellus);
                }

                return this.repositorioGruposPorGrado;
            }
        }

        #endregion Propiedades

        #region Métodos

        /// <summary>
        /// Realiza los cambios que tiene el DbContex en la base de datos de Libellus.
        /// </summary>
        public int SaveChanges()
        {
            return this.contextoLibellus.SaveChanges();
        }

        #endregion Métodos

        #region Disposed

        /// <summary>
        /// Realiza la liberación de la unidad del trabajo de la memoria.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Realiza la liberación de la unidad del trabajo de la memoria siempre y cuando sea el momento de la liberación.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.contextoLibellus.Dispose();
                }
            }

            this.disposed = true;
        }

        #endregion Disposed
    }
}