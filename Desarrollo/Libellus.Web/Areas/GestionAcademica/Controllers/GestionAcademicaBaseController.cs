namespace Libellus.Web.Areas.GestionAcademica.Controllers
{
    using Libellus.Negocio.Administracion;
    using Libellus.Negocio.GestionAcademica;
    using Libellus.Negocio.Matriculas;
    using Libellus.Negocio.Matriculas.Interfaces;
    using Libellus.Web.Areas.Administracion.Controllers;
    using Libellus.Web.Areas.GestionMatricula.Controllers;
    using Libellus.Web.Controllers;

    /// <summary>
    /// Proporciona funcionalidades genéricas para los controllers del módulo gestión academica.
    /// </summary>
    public class GestionAcademicaBaseController : AdministracionBaseController
    {
        #region Propiedades

        /// <summary>
        /// Expone las reglas de negocio para la funcionalidad de aspectos evaluativos.
        /// </summary>
        protected INegocioAspectosEvaluativos NegocioAspectosEvaluativos { get; set; }

        /// <summary>
        /// Expone las reglas de negocio para la funcionalidad de parametros de promoción.
        /// </summary>
        protected INegocioParametrosPromocion NegocioParametrosPromocion { get; set; }

        /// <summary>
        /// Expone las reglas de negocio para la funcionalidad de rangos de desempeño.
        /// </summary>
        protected INegocioRangosDesempenio NegocioRangosDesempenio { get; set; }

        /// <summary>
        /// Expone las reglas de negocio para la funcionalidad de grupos.
        /// </summary>
        protected INegocioGrupos NegocioGrupos { get; set; }

        /// <summary>
        /// Define la interfaz para las reglas de negocio para los antecedentes academicos de matriculas.
        /// </summary>
        protected INegocioMatriculas NegocioMatriculas { get; set; }

        /// <summary>
        /// Define la interfaz para las reglas de negocio para  los cupos por nivel.
        /// </summary>
        protected INegocioCuposPorNivel NegocioCuposPorNivel { get; set; }

        /// <summary>
        /// Define la interfaz para las reglas de negocio para  los estudaintes.
        /// </summary>
        protected INegocioEstudiantes NegocioEstudiantes { get; set; }

        #endregion

        #region Eventos

        /// <summary>
        /// Libera los recursos de memoria.
        /// </summary>
        /// <param name="disposing">True para liberar los recursos de memoria, de lo contrario false.</param>
        protected override void Dispose(bool disposing)
        {
            if (this.NegocioAspectosEvaluativos != null)
            {
                this.NegocioAspectosEvaluativos.Dispose();
            }

            if (this.NegocioParametrosPromocion != null)
            {
                this.NegocioParametrosPromocion.Dispose();
            }

            if (this.NegocioRangosDesempenio != null)
            {
                this.NegocioRangosDesempenio.Dispose();
            }

            if (this.NegocioGrupos != null)
            {
                this.NegocioGrupos.Dispose();
            }

            if (this.NegocioMatriculas != null)
            {
                this.NegocioMatriculas.Dispose();
            }

            if (this.NegocioCuposPorNivel != null)
            {
                this.NegocioCuposPorNivel.Dispose();
            }

            if (this.NegocioEstudiantes != null)
            {
                this.NegocioEstudiantes.Dispose();
            }

            base.Dispose(disposing);
        }

        #endregion
    }
}