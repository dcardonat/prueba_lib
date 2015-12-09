namespace Libellus.Negocio.UnidadesDeTrabajo
{
    using Libellus.Repositorio.Administracion;
using Libellus.Repositorio.Administracion.Interfaces;
using Libellus.Repositorio.General;
using Libellus.Repositorio.GestionAcademica;
using Libellus.Repositorio.GestionAcademica.Interfaces;
using Libellus.Repositorio.Matriculas;
using Libellus.Repositorio.Matriculas.Interfaces;
using Libellus.Repositorio.Seguridad;
using System;

    /// <summary>
    /// Expone una única unidad de trabajo para el contexto de la base de datos de Libellus.
    /// </summary>
    public interface IUnidadDeTrabajoLibellus : IDisposable
    {
        #region Propiedades

        /// <summary>
        /// Define la persistencia con la DB de Libellus para las actividades complementarias.
        /// </summary>
        IRepositorioActividadesComplementarias RepositorioActividadesComplementarias { get; }

        /// <summary>
        /// Define la persistencia con la DB de Libellus para las asignaturas.
        /// </summary>
        IRepositorioAsignaturas RepositorioAsignaturas { get; }

        /// <summary>
        /// Define la persistencia con la DB de Libellus para las aulas.
        /// </summary>
        IRepositorioAulas RepositorioAulas { get; }

        /// <summary>
        /// Define la persistencia con la DB de Libellus para los maestros administrables.
        /// </summary>
        IRepositorioMaestros RepositorioMaestros { get; }

        /// <summary>
        /// Define la persistencia con la DB de Libellus para los usuarios.
        /// </summary>
        IRepositorioUsuarios RepositorioUsuarios { get; }

        /// <summary>
        /// Define la persistenia con la DB de Libellus para los usuarios.
        /// </summary>
        IRepositorioRoles RepositorioRoles { get; }

        /// <summary>
        /// Define la persisitencia con la DB de Libellus para los usuarios.
        /// </summary>
        IRepositorioFuncionalidades RepositorioFuncionalidades { get; }

        /// <summary>
        /// Define la persisitencia con la DB de Libellus para los usuarios administrativos.
        /// </summary>
        IRepositorioUsuariosAdministrativos RepositorioUsuariosAdministrativos { get; }

        /// <summary>
        /// Define la persisitencia con la DB de Libellus para las sedes.
        /// </summary>
        IRepositorioSedes RepositorioSedes { get; }

        /// <summary>
        /// Define la persisitencia con la DB de Libellus para las SalidasOcupacionales.
        /// </summary>
        IRepositorioSalidasOcupacionales RepositorioSalidasOcupacionales { get; }

        /// <summary>
        /// Define la persistencia con la BD libellus para la documentacion para soporte por roles.
        /// </summary>
        IRepositorioDocumentacionSoporteRoles RepositorioDocumentacionSoporteRoles { get; }

        /// <summary>
        /// Define la persistencia con la BD libellus para la documentacion para los grados por nivel.
        /// </summary>
        IRepositorioGradosPorNivel RepositorioGradosPorNivel { get; }

        /// <summary>
        /// Define la persisitencia con la DB de Libellus para la parametrización institucional.
        /// </summary>
        IRepositorioParametrizacionInstitucional RepositorioParametrizacionInstitucional { get; }

        /// <summary>
        /// Define la persistencia con la BD libellus para la documentacion para los datos de institucion educativa.
        /// </summary>
        IRepositorioInstitucionEducativa RepositorioInstitucionEducativa { get; }

        /// <summary>
        /// Define la persistencia con la BD libellus para la documentacion para los datos del registro de intensidad horaria.
        /// </summary>
        IRepositorioIntensidadHoraria RepositorioIntensidadHoraria { get; }

        /// <summary>
        /// Define la persistencia con la BD libellus para la administración de la información de los docentes.
        /// </summary>
        IRepositorioDocente RepositorioDocente { get; }

        /// <summary>
        /// Define la persistencia con la BD libellus para la administración de la información de RolesFuncionalidades.
        /// </summary>
        IRepositorioRolesFuncionalidades RepositorioRolesFuncionalidades { get; }

        /// <summary>
        /// Define la persistencia con la BD libellus para la proyeccion de grupos por nivel.
        /// </summary>
        IRepositorioCuposPorNivel RepositorioCuposPorNivel { get; }

        /// <summary>
        /// Define la persistencia con la BD libellus para los aspectos evaluativos.
        /// </summary>
        IRepositorioAspectosEvaluativos RepositorioAspectosEvaluativos { get; }

        /// <summary>
        /// Define la persistencia con la BD libellus para los parametros de promoción.
        /// </summary>
        IRepositorioParametrosPromocion RepositorioParametrosPromocion { get; }

        /// <summary>
        /// Define la persistencia con la BD libellus para los rangos de desempeño.
        /// </summary>
        IRepositorioRangosDesempenio RepositorioRangosDesempenio { get; }

        /// <summary>
        /// Define la persistencia con la BD libellus para los Años lectivos
        /// </summary>
        IRepositorioAnioLectivo RepositorioAnioLectivo { get; }

        /// <summary>
        /// Define la persistencia con la BD libellus para la apertura extemporanea de periodos.
        /// </summary>
        IRepositorioAperturaPeriodos RepositorioAperturaPeriodos { get; }

        /// <summary>
        /// Define la persistencia con la BD libellus para la parametrizacion escolar.
        /// </summary>
        IRepositorioParametrizacionEscolar RepositorioParametrizacionEscolar { get; }

        /// <summary>
        /// Define la persistencia con la BD libellus para los parametros. 
        /// </summary>
        IRepositorioParametros RepositorioParametros { get; }

        /// <summary>
        /// Define la persistencia con la BD para los cupos.
        /// </summary>
        IRepositorioCupos RepositorioCupos { get; }

        /// <summary>
        /// Define la persistencia con la BD para los estudiantes.
        /// </summary>
        IRepositorioEstudiante RepositorioEstudiante { get; }

        /// <summary>
        /// Define la persistencia con la BD para los antecedentes academicos.
        /// </summary>
        IRepositorioAntecedentesAcademicos RepositorioAntecedentesAcademicos { get; }

        /// <summary>
        /// Define la persistencia con la BD las matriculas.
        /// </summary>
        IRepositorioMatriculas RepositorioMatriculas { get; }

        /// <summary>
        /// Define la persistencia con la BD los grupos por grado.
        /// </summary>
        IRepositorioGruposPorGrado RepositorioGruposPorGrado { get; }

        /// <summary>
        /// Define la persistencia con la BD los grupos por estudiante.
        /// </summary>
        IRepositorioGrupo RepositorioGrupo { get; }

        #endregion

        #region Métodos

        /// <summary>
        /// Expone los cambios que tiene el DbContex en la base de datos de TML.
        /// </summary>
        int SaveChanges();

        #endregion
    }
}
