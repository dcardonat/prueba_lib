namespace Libellus.Web.Areas.GestionMatricula.Controllers
{
    using Libellus.Negocio.Matriculas;
using Libellus.Negocio.Matriculas.Interfaces;
using Libellus.Web.Areas.Administracion.Controllers;

    /// <summary>
    /// Proporciona funcionalidades genéricas para los controllers del módulo Matricula.
    /// </summary>
    public class GestionMatriculaBaseController : AdministracionBaseController
    {
        #region Propiedades

        /// <summary>
        /// Define la interfaz para las reglas de negocio de los cupos.
        /// </summary>
        protected INegocioCupos NegocioCupos { get; set; }

        /// <summary>
        /// Define la interfaz para las reglas de negocio de los estudiantes.
        /// </summary>
        protected INegocioEstudiantes NegocioEstudiantes { get; set; }

        /// <summary>
        /// Define la interfaz para las reglas de negocio para los antecedentes academicos del estudiante.
        /// </summary>
        protected INegocioAntecedentesAcademicos NegocioAntecedentesAcademicos { get; set; }

        /// <summary>
        /// Define la interfaz para las reglas de negocio para los antecedentes academicos de matriculas.
        /// </summary>
        protected INegocioMatriculas NegocioMatriculas { get; set; }

        #endregion Propiedades

        #region Eventos

        /// <summary>
        /// Libera los recursos de memoria.
        /// </summary>
        /// <param name="disposing">True para liberar los recursos de memoria, de lo contrario false.</param>
        protected override void Dispose(bool disposing)
        {
            if (this.NegocioCupos != null)
            {
                this.NegocioCupos.Dispose();
            }

            if (this.NegocioEstudiantes != null)
            {
                this.NegocioEstudiantes.Dispose();
            }

            if(this.NegocioAntecedentesAcademicos != null)
            {
                this.NegocioAntecedentesAcademicos.Dispose();
            }

            if (this.NegocioMatriculas != null)
            {
                this.NegocioMatriculas.Dispose();
            }

            base.Dispose(disposing);
        }

        #endregion Eventos
    }
}