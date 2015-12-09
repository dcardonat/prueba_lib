namespace Libellus.Web.Areas.Administracion.Controllers
{
    using Libellus.Negocio.Administracion;
    using Libellus.Negocio.Administracion.Interfaces;
    using Libellus.Negocio.Matriculas.Interfaces;
    using Libellus.Negocio.Seguridad;
    using Libellus.Web.Controllers;

    /// <summary>
    /// Proporciona funcionalidades genéricas para los controllers del módulo administrativo.
    /// </summary>
    public class AdministracionBaseController : BaseController
    {
        #region Propiedades

        /// <summary>
        /// Define la interfáz de las reglas de negocio para el maestro .
        /// </summary>
        protected INegocioActividadesComplementarias NegocioActividadesComplementarias { get; set; }

        /// <summary>
        /// Define la interfáz de las reglas de negocio para el maestro .
        /// </summary>
        protected INegocioAsignaturas NegocioAsignaturas { get; set; }

        /// <summary>
        /// Define la interfáz de las reglas de negocio para el maestro .
        /// </summary>
        protected INegocioAulas NegocioAulas { get; set; }

        /// <summary>
        /// Define la interfáz de las reglas de negocio para los maestros administrables.
        /// </summary>
        protected INegocioMaestros NegocioMaestros { get; set; }

        /// <summary>
        /// Define la interfáz de las reglas de negocio para los maestros administrables.
        /// </summary>
        protected INegocioUsuarios NegocioUsuarios { get; set; }

        /// <summary>
        /// Define la interfáz de las reglas de negocio para los roles.
        /// </summary>
        protected INegocioRoles NegocioRoles { get; set; }

        /// <summary>
        /// Define la interfáz de las reglas de negocio para RolesFuncionalidades.
        /// </summary>
        protected INegocioRolesFuncionalidades NegocioRolesFuncionalidades { get; set; }

        /// <summary>
        /// Define la interfáz de las reglas de negocio para las funcionalidades.
        /// </summary>
        protected INegocioFuncionalidades NegocioFuncionalidades { get; set; }

        /// <summary>
        /// Define la interfáz de las reglas de negocio para los usuarios administrativos.
        /// </summary>
        protected INegocioUsuariosAdministrativos NegocioUsuariosAdministrativos { get; set; }

        /// <summary>
        /// Define la interfáz de las reglas de negocio para las sedes.
        /// </summary>
        protected INegocioSedes NegocioSedes { get; set; }

        /// <summary>
        /// Expone las reglas de negocio para el maestro salidas ocupacionales.
        /// </summary>
        protected INegocioSalidasOcupacionales NegocioSalidasOcupacionales { get; set; }

        /// <summary>
        /// Expone las reglas de negocio para el maestro grados por nivel.
        /// </summary>
        protected INegocioGradosPorNivel NegocioGradosPorNivel { get; set; }

        /// <summary>
        /// Expone las reglas de negocio para la funcionalidad documentacion para soporte por roles.
        /// </summary>
        protected INegocioDocumentacionSoporteRoles NegocioDocumentacionSoporteRoles { get; set; }

        /// <summary>
        /// Expone las reglas de negocio para la funcionalidad parametrización institucional.
        /// </summary>
        protected INegocioParametrizacionInstitucional NegocioParametrizacionInstitucional { get; set; }

        /// <summary>
        /// Expone las reglas de negocio para la funcionalidad datos de institucion educativa.
        /// </summary>
        protected INegocioInstitucionEducativa NegocioInstitucionEducativa { get; set; }

        /// <summary>
        /// Expone las reglas de negocio para la funcionalidad datos de intensidad horaria.
        /// </summary>
        protected INegocioIntensidadHoraria NegocioIntensidadHoraria { get; set; }

        /// <summary>
        /// Expone las reglas de negocio para la funcionalidad de docentes.
        /// </summary>
        protected INegocioDocente NegocioDocente { get; set; }

        /// <summary>
        /// Expone las reglas de negocio para la funcionalidad de cupos. por nivel.
        /// </summary>
        protected INegocioCuposPorNivel NegocioCuposPorNivel { get; set; }

        /// <summary>
        /// Expone las reglas de negocio para la funcionalidad de parametrizacion anual y semestral.
        /// </summary>
        protected INegocioParametrizacionEscolar NegocioParametrizacionEscolar { get; set; }

        /// <summary>
        /// Expone las reglas de negocio para la funcionalidad de Año lectivo.
        /// </summary>
        protected INegocioAnioLectivo NegocioAnioLectivo { get; set; }

        /// <summary>
        /// Expone las reglas de negocio para la funcionalidad de Año lectivo.
        /// </summary>
        protected INegocioAperturaPeriodos NegocioAperturaPeriodos { get; set; }

        /// <summary>
        /// Expone las reglas de negocio para la funcionalidad matriculas.
        /// </summary>
        protected INegocioMatriculas NegocioMatriculas { get; set; }

        /// <summary>
        /// Expone las reglas de negocio para la funcionalidad grupos por grado.
        /// </summary>
        protected INegocioGruposPorGrado NegocioGruposPorGrado { get; set; }

        #endregion Propiedades

        #region Eventos

        /// <summary>
        /// Libera los recursos de memoria.
        /// </summary>
        /// <param name="disposing">True para liberar los recursos de memoria, de lo contrario false.</param>
        protected override void Dispose(bool disposing)
        {
            if (this.NegocioMaestros != null)
            {
                this.NegocioMaestros.Dispose();
            }

            if (this.NegocioUsuarios != null)
            {
                this.NegocioUsuarios.Dispose();
            }

            if (this.NegocioRoles != null)
            {
                this.NegocioRoles.Dispose();
            }

            if (this.NegocioFuncionalidades != null)
            {
                this.NegocioFuncionalidades.Dispose();
            }

            if (this.NegocioUsuariosAdministrativos != null)
            {
                this.NegocioUsuariosAdministrativos.Dispose();
            }

            if (this.NegocioSedes != null)
            {
                this.NegocioSedes.Dispose();
            }

            if (this.NegocioSalidasOcupacionales != null)
            {
                this.NegocioSalidasOcupacionales.Dispose();
            }

            if (this.NegocioGradosPorNivel != null)
            {
                this.NegocioGradosPorNivel.Dispose();
            }

            if (this.NegocioActividadesComplementarias != null)
            {
                this.NegocioActividadesComplementarias.Dispose();
            }

            if (this.NegocioAsignaturas != null)
            {
                this.NegocioAsignaturas.Dispose();
            }

            if (this.NegocioAulas != null)
            {
                this.NegocioAulas.Dispose();
            }

            if (this.NegocioDocumentacionSoporteRoles != null)
            {
                this.NegocioDocumentacionSoporteRoles.Dispose();
            }

            if (this.NegocioParametrizacionInstitucional != null)
            {
                this.NegocioParametrizacionInstitucional.Dispose();
            }

            if (this.NegocioInstitucionEducativa != null)
            {
                this.NegocioInstitucionEducativa.Dispose();
            }

            if (this.NegocioIntensidadHoraria != null)
            {
                this.NegocioIntensidadHoraria.Dispose();
            }

            if (this.NegocioDocente != null)
            {
                this.NegocioDocente.Dispose();
            }

            if (this.NegocioCuposPorNivel != null)
            {
                this.NegocioCuposPorNivel.Dispose();
            }

            if (this.NegocioParametrizacionEscolar != null)
            {
                this.NegocioParametrizacionEscolar.Dispose();
            }

            if (this.NegocioAnioLectivo != null)
            {
                this.NegocioAnioLectivo.Dispose();
            }

            if (this.NegocioAperturaPeriodos != null)
            {
                this.NegocioAperturaPeriodos.Dispose();
            }

            if (this.NegocioMatriculas != null)
            {
                this.NegocioMatriculas.Dispose();
            }

            if(this.NegocioGruposPorGrado != null)
            {
                this.NegocioGruposPorGrado.Dispose();
            }

            base.Dispose(disposing);
        }

        #endregion Eventos
    }
}