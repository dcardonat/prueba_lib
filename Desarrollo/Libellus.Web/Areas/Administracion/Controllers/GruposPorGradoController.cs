namespace Libellus.Web.Areas.Administracion.Controllers
{
    using Libellus.Entidades;
    using Libellus.Entidades.Enumerados;
    using Libellus.Mensajes;
    using Libellus.Negocio.Administracion;
    using Libellus.Negocio.Administracion.Clases;
    using Libellus.Utilidades;
    using Libellus.Web.Areas.Administracion.Models.GruposPorGrado;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    /// <summary>
    /// 
    /// </summary>
    public class GruposPorGradoController : AdministracionBaseController
    {
         #region Constructores

        /// <summary>
        /// Inicializa una instancia de tipo GruposPorGradoController.
        /// </summary>
        public GruposPorGradoController()
        {
            this.NegocioGradosPorNivel = new NegocioGradosPorNivel(this.UnidadDeTrabajoLibellus);
            this.NegocioMaestros = new NegocioMaestros(this.UnidadDeTrabajoLibellus);
            this.NegocioGruposPorGrado = new NegocioGruposPorGrado(this.UnidadDeTrabajoLibellus);
        }

        #endregion Constructores

        #region Acciones

        /// <summary>
        /// Renderiza la vista de administración de los grados por nivel.
        /// </summary>
        /// <returns>Vista con la información de los niveles creados en el colegio.</returns>
        public ActionResult Administrar()
        {
            GruposPorGradoViewModel gruposPorGradoViewModel = new GruposPorGradoViewModel();

            try
            {
                gruposPorGradoViewModel.Grados = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Grados, Utilidades.ContextoLibellus.ObtenerSedeActual, true).ToSelectListItem(o => o.Descripcion, o => o.Id);
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(gruposPorGradoViewModel);
        }

        #endregion Acciones

        #region Acciones asíncronas

        /// <summary>
        /// Consulta los grados asociados al nivel seleccionado.
        /// </summary>
        /// <param name="idGrado">Identificador interno del grado a consultar.</param>
        /// <returns>Grupos asociados al grado.</returns>
        [HttpPost]
        public JsonResult ConsultarGruposPorGrado(int idGrado)
        {
            GruposPorGradoViewModel gruposGradoViewModel = new GruposPorGradoViewModel();

            List<Maestro> grupos = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Grupos, Utilidades.ContextoLibellus.ObtenerSedeActual, true).ToList();
            List<Maestro> gruposPorGrado = this.NegocioGruposPorGrado.ConsultarGruposPorGrado(idGrado).ToList();

            List<Maestro> gruposExceptuados = grupos.Except(gruposPorGrado).ToList();
            List<Maestro> gruposSeleccionados = grupos.Intersect(gruposPorGrado).ToList();

            gruposGradoViewModel.Grupos = (from p in grupos
                                           join g in gruposExceptuados on p.Id equals g.Id
                                              select new SelectListItem
                                              {
                                                  Text = p.Descripcion,
                                                  Value = p.Id.ToString()
                                              }).OrderBy(o => o.Text).ToList();

            gruposGradoViewModel.GruposPorGrado = (from p in grupos
                                                   join g in gruposSeleccionados on p.Id equals g.Id
                                                      select new SelectListItem
                                                      {
                                                          Text = p.Descripcion,
                                                          Value = p.Id.ToString()
                                                      }).OrderBy(o => o.Text).ToList();

            return Json(gruposGradoViewModel);
        }

        /// <summary>
        /// Almacena un grado por nivel.
        /// </summary>
        /// <param name="idGrado">Identificador interno del grupo a asociar a un grado.</param>
        /// <param name="idGrupo">Identificador interno del grado a asociar.</param>
        /// <returns>Mensaje informando al usuario de que el grupo ya se encuentra asociado a otro grado; de lo contrario null.</returns>
        [HttpPost]
        public JsonResult AdicionGruposPorGrado(int idGrupo, int idGrado)
        {
            Mensaje mensajeValidacion = null;
            GruposPorGrado gruposPorGradoExistente = this.NegocioGruposPorGrado.ConsultarGrado(idGrupo);

            if (gruposPorGradoExistente == null)
            {
                GruposPorGrado gruposPorGrado = new GruposPorGrado();
                gruposPorGrado.IdGrupo = idGrupo;
                gruposPorGrado.IdGrado = idGrado;

                this.NegocioGruposPorGrado.GuardarGruposPorGrado(gruposPorGrado);
            }
            else
            {
                mensajeValidacion = new Mensaje(CodigoMensaje.Mensaje005, gruposPorGradoExistente.Grupo.Descripcion, gruposPorGradoExistente.Grado.Descripcion);
            }

            return Json(mensajeValidacion == null ? String.Empty : mensajeValidacion.Texto);
        }

        /// <summary>
        /// Elimina un grado asociado a un nivel.
        /// </summary>
        /// <param name="idGrado">Identificador interno del grado a eliminar.</param>
        /// <returns>Mensaje informando al usuario de que el grado ya se encuentra asociado a otra información; de lo contrario null.</returns>
        [HttpPost]
        public JsonResult EliminarGruposPorGrado(int idGrupo)
        {
            Mensaje mensajeValidacion = null;

            try
            {
                this.NegocioGruposPorGrado.EliminarGruposPorGrados(idGrupo);
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