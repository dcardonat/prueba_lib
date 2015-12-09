namespace Libellus.Web.Areas.Administracion.Controllers
{
    using Libellus.Entidades;
    using Libellus.Mensajes;
    using Libellus.Negocio.Seguridad;
    using Libellus.Utilidades;
    using Libellus.Web.Areas.Administracion.Models;
    using Libellus.Web.Autorizacion;
    using Libellus.Web.Helpers;
    using PagedList;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Mime;
    using System.Web.Mvc;

    /// <summary>
    /// Proporciona funcionalidades genéricas para los controllers.
    /// </summary>
   // [AutorizacionFuncionalidad]
    public class RolesController : AdministracionBaseController
    {
        #region Constructores

        /// <summary>
        /// Proporciona las acciones de interacción con la administración de roles.
        /// </summary>
        public RolesController()
        {
            this.NegocioRoles = new NegocioRoles(this.UnidadDeTrabajoLibellus);
        }

        #endregion

        #region Acciones

        /// <summary>
        /// Lista de roles por sede.
        /// </summary>
        /// <returns>Redirige a la vista que lista de roles.</returns>
        [HttpGet]
        //[AutorizacionFuncionalidad]
        public ActionResult Consultar(int? pagina)
        {
            IEnumerable<RolViewModel> roles = null;

            try
            {
                roles = from c in this.NegocioRoles.ConsultarRolesPorSede().ToList()
                        select new RolViewModel
                              {
                                  Id = c.Id,
                                  Nombre = c.Nombre,
                                  Estado = c.Estado
                              };

                if (roles.Count() == 0)
                {
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje1005));
                }
                else
                {
                    int numeroPagina = (pagina ?? 1);
                    int numeroRegistrosXPagina = 10;
                    return View(roles.ToPagedList(numeroPagina, numeroRegistrosXPagina));
                }
            }
            catch (Exception ex)
            {
                this.CapturarExcepcion(ex);
            }

            return View(roles);
        }

        /// <summary>
        /// Acción HttpGet que realiza la creación del rol.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [HttpGet]
       // [AutorizacionFuncionalidad]
        public ActionResult Crear()
        {
            ViewBag.NuevoRegistro = true;
            return View();
        }

        /// <summary>
        /// Acción HttpPost que realiza la creación del ro.
        /// </summary>
        /// <param name="roleViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Crear(RolViewModel roleViewModel)
        {
            try
            {
                Rol rol = new Rol { Nombre = roleViewModel.Nombre, Estado = true };
                NegocioRoles.AgregarRol(rol);
                this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje001));
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return RedirectToAction("Consultar", "Roles", new { area = "Administracion" });
        }

        /// <summary>
        /// Muestra el formulario de edicion de registros de actividades complementarias, cargando los datos de la actividad especificada.
        /// </summary>
        /// <param name="id">Identificador de la actividad.</param>
        /// <returns>Redirecciona a la vista.</returns>
        [HttpGet]
        public ActionResult Editar(int id)
        {
            RolViewModel rolviewModel = new RolViewModel();
            ViewBag.NuevoRegistro = false;
            try
            {
                Rol rol = this.NegocioRoles.Consultar(id);

                if (rol == null)
                {
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje003));
                    return RedirectToAction("Consultar");
                }
                else
                {
                    rolviewModel.Nombre = rol.Nombre;
                    rolviewModel.Estado = rol.Estado;
                }
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
                return RedirectToAction("Consultar");
            }

            return View(rolviewModel);
        }

        /// <summary>
        /// Edita la información de un maestro administrable.
        /// </summary>
        /// <param name="maestro">Información del maestro a editar.</param>
        /// <returns>Vista para consultar maestros administrables.</returns>
        [HttpPost]
        public ActionResult Editar(Rol rol)
        {
            try
            {
                this.NegocioRoles.ActualizarRol(rol);
                this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje002));
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);

            }

            return RedirectToAction("Consultar");
        }

        /// <summary>
        /// Exportar la información de las salidas ocupacionales a Excel.
        /// </summary>
        /// <param name="token">Token generado para determinar el estado de exportación a Excel.</param>
        /// <returns>Array de bytes con la información exportada a Excel.</returns>
        [HttpGet]
        public ActionResult ExportarInformacionExcel(string token)
        {
            byte[] byteArray = null;
            string nombreArchivo = "Libellus_Roles.xlsx";
            this.Response.AppendCookie(new System.Web.HttpCookie("cookieExportarExcel", token));

            try
            {
                IEnumerable<object> salidasOcupacionales = (from p in this.NegocioRoles.ConsultarRolesPorSede()
                                                            select new
                                                            {
                                                                Nombre = p.Nombre,
                                                                Estado = p.Estado ? "Activo" : "Inactivo",
                                                            }).OrderByDescending(o => o.Estado).ThenBy(o => o.Nombre);

                byteArray = ExportarExcel.Exportar(salidasOcupacionales.ToList(), "Roles");
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return this.File(byteArray, MediaTypeNames.Application.Octet, nombreArchivo);
        }

        #endregion
    }
}