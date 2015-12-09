namespace Libellus.Web.Areas.Administracion.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Libellus.Entidades;
    using Libellus.Entidades.Enumerados;
    using Libellus.Mensajes;
    using Libellus.Negocio.Administracion;
    using Libellus.Utilidades;
    using Libellus.Web.Areas.Administracion.Models.GradosPorNivel;
    using Libellus.Web.Controllers;

    /// <summary>
    /// Proporciona las acciones de interacción con la administración de los grados por nivel.
    /// </summary>
    public class GradosPorNivelController : AdministracionBaseController
    {
        #region Constructores

        /// <summary>
        /// Inicializa una instancia de tipo GradosPorNivelController.
        /// </summary>
        public GradosPorNivelController()
        {
            this.NegocioGradosPorNivel = new NegocioGradosPorNivel(this.UnidadDeTrabajoLibellus);
            this.NegocioMaestros = new NegocioMaestros(this.UnidadDeTrabajoLibellus);
        }

        #endregion Constructores

        #region Acciones

        /// <summary>
        /// Renderiza la vista de administración de los grados por nivel.
        /// </summary>
        /// <returns>Vista con la información de los niveles creados en el colegio.</returns>
        public ActionResult Administrar()
        {
            GradosPorNivelViewModel gradosPorNivelViewModel = new GradosPorNivelViewModel();

            try
            {
                gradosPorNivelViewModel.Niveles = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Nivel, Utilidades.ContextoLibellus.ObtenerSedeActual, true).ToSelectListItem(o => o.Descripcion, o => o.Id);
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(gradosPorNivelViewModel);
        }

        #endregion Acciones

        #region Acciones asíncronas

        /// <summary>
        /// Consulta los grados asociados al nivel seleccionado.
        /// </summary>
        /// <param name="idNivel">Identificador interno del nivel a consultar.</param>
        /// <returns>Grados asociados al nivel.</returns>
        [HttpPost]
        public JsonResult ConsultarGradosPorNivel(int idNivel)
        {
            GradosPorNivelViewModel gradosPorNivelViewModel = new GradosPorNivelViewModel();

            List<Maestro> grados = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Grados, Utilidades.ContextoLibellus.ObtenerSedeActual, true).ToList();
            List<Maestro> gradosPorNivel = this.NegocioGradosPorNivel.ConsultarGradosPorNivel(idNivel).ToList();

            List<Maestro> gradosExceptuados = grados.Except(gradosPorNivel).ToList();
            List<Maestro> gradosSeleccionados = grados.Intersect(gradosPorNivel).ToList();

            gradosPorNivelViewModel.Grados = (from p in grados
                                              join g in gradosExceptuados on p.Id equals g.Id
                                              select new SelectListItem
                                              {
                                                  Text = p.Descripcion,
                                                  Value = p.Id.ToString()
                                              }).OrderBy(o => o.Text).ToList();

            gradosPorNivelViewModel.GradosPorNivel = (from p in grados
                                                      join g in gradosSeleccionados on p.Id equals g.Id
                                                      select new SelectListItem
                                                      {
                                                          Text = p.Descripcion,
                                                          Value = p.Id.ToString()
                                                      }).OrderBy(o => o.Text).ToList();

            return Json(gradosPorNivelViewModel);
        }

        /// <summary>
        /// Almacena un grado por nivel.
        /// </summary>
        /// <param name="idGrado">Identificador interno del grado a asociar a un nivel.</param>
        /// <param name="idNivel">Identificador interno del nivel a asociar.</param>
        /// <returns>Mensaje informando al usuario de que el grado ya se encuentra asociado a otro nivel; de lo contrario null.</returns>
        [HttpPost]
        public JsonResult AdicionGradoPorNivel(int idGrado, int idNivel)
        {
            Mensaje mensajeValidacion = null;
            GradosPorNivel gradoPorNivelExistente = this.NegocioGradosPorNivel.ConsultarGrado(idGrado);

            if (gradoPorNivelExistente == null)
            {
                GradosPorNivel gradoPorNivel = new GradosPorNivel();
                gradoPorNivel.IdGrado = idGrado;
                gradoPorNivel.IdNivel = idNivel;

                this.NegocioGradosPorNivel.GuardarGradosPorNivel(gradoPorNivel);
            }
            else
            {
                mensajeValidacion = new Mensaje(CodigoMensaje.Mensaje030, gradoPorNivelExistente.Grado.Descripcion, gradoPorNivelExistente.Nivel.Descripcion);
            }

            return Json(mensajeValidacion == null ? String.Empty : mensajeValidacion.Texto);
        }

        /// <summary>
        /// Elimina un grado asociado a un nivel.
        /// </summary>
        /// <param name="idGrado">Identificador interno del grado a eliminar.</param>
        /// <returns>Mensaje informando al usuario de que el grado ya se encuentra asociado a otra información; de lo contrario null.</returns>
        [HttpPost]
        public JsonResult EliminarGradoPorNivel(int idGrado)
        {
            Mensaje mensajeValidacion = null;

            try
            {
                this.NegocioGradosPorNivel.EliminarGradosPorNivel(idGrado);
            }
            catch (Exception excepcion)
            {
                mensajeValidacion = this.CapturarExcepcionConstraint(excepcion);
            }

            return Json(mensajeValidacion == null ? String.Empty : mensajeValidacion.Texto);
        }

        #endregion Acciones asíncronas
    }
}