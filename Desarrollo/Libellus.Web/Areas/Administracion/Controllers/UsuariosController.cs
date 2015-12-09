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
    using Libellus.Negocio.Seguridad;
    using Libellus.Utilidades;
    using Libellus.Web.Areas.Administracion.Models;
    using PagedList;

    /// <summary>
    /// Clase para la administración de usuarios.
    /// </summary>
    public class UsuariosController : AdministracionBaseController
    {
        #region Constructor

        /// <summary>
        /// Inicializa una instancia de UsuariosController.
        /// </summary>
        public UsuariosController()
        {
            this.NegocioMaestros = new NegocioMaestros(this.UnidadDeTrabajoLibellus);
            this.NegocioRoles = new NegocioRoles(this.UnidadDeTrabajoLibellus);
            this.NegocioUsuarios = new NegocioUsuarios(this.UnidadDeTrabajoLibellus);
        }

        #endregion

        #region Acciones

        /// <summary>
        /// Consulta los usuarios que cumplan con los filtros indicados.
        /// </summary>
        /// <param name="idTipoIdentificacion">Tipo de identificación del usuario.</param>
        /// <param name="identificacion">Identificación del usuario.</param>
        /// <param name="idEstado">Estado del usuario.</param>
        /// <param name="idRol">Rol del usuario.</param>
        /// <param name="pagina">Página actual.</param>
        /// <returns>La vista para consulta de usuarios.</returns>
        [HttpGet]
        public ActionResult Consultar(int? idTipoIdentificacion, string identificacion, byte? idEstado, int? idRol, int? pagina, bool consultar = false)
        {
            IEnumerable<UsuarioViewModel> usuarios = new UsuarioViewModel[] { };

            try
            {
                int sede = Utilidades.ContextoLibellus.ObtenerSedeActual;
                IEnumerable<SelectListItem> estados = Enum.GetValues(typeof(EstadoUsuario)).Cast<EstadoUsuario>().Select(eu => new SelectListItem { Value = ((int)eu).ToString(), Text = eu.ToString() }).OrderBy(eu => eu.Text);
                IEnumerable<SelectListItem> roles = this.NegocioRoles.ConsultarRolesPorSede().Select(r => new SelectListItem { Value = r.Id.ToString(), Text = r.Nombre }).OrderBy(r => r.Text);
                ViewBag.TiposIdentificaciones = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.TiposIdentificaciones, sede).OrderBy(x => x.Descripcion);
                ViewBag.Estados = estados;
                ViewBag.Roles = roles;
                if (consultar)
                {
                    usuarios = this.NegocioUsuarios.Consultar(idTipoIdentificacion, identificacion, idEstado, idRol, sede)
                        .Select(u => new UsuarioViewModel
                        {
                            Id = u.Id,
                            TipoIdentificacion = u.TipoIdentificacion.Descripcion,
                            Identificacion = u.Identificacion,
                            Correo = u.Correo,
                            Estados = estados.Select(e => { e.Selected = u.IdEstado == int.Parse(e.Value); return e; }),
                            Roles = roles.Select(r => { r.Selected = u.UsuariosRoles.FirstOrDefault().IdRol == int.Parse(r.Value); return r; })
                        });
                    ViewBag.Consultar = consultar;
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(usuarios.ToPagedList(pagina ?? 1, 10));
        }

        /// <summary>
        /// Edita la información del usuario.
        /// </summary>
        /// <param name="id">Id del usuario.</param>
        /// <param name="idEstado">Estado del usuario.</param>
        /// <param name="idRol">Rol del usuario.</param>
        /// <returns>El estado de la transacción.</returns>
        [HttpPost]
        public JsonResult Editar(int id, byte idEstado, int idRol)
        {
            try
            {
                Usuario usuario = this.NegocioUsuarios.ConsultarPorId(id);
                usuario.IdEstado = idEstado;
                usuario.UsuariosRoles.Where(ur => Utilidades.ContextoLibellus.ObtenerSedeActual == ur.IdSede).FirstOrDefault().IdRol = idRol;
                this.NegocioUsuarios.Editar(usuario);
                return Json(new Mensaje(CodigoMensaje.Mensaje002));
            }
            catch (Exception excepcion)
            {
                return Json(UtilidadesApp.CapturarExcepcion(excepcion));
            }
        }

        #endregion
    }
}