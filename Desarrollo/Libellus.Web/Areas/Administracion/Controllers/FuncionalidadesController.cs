namespace Libellus.Web.Areas.Administracion.Controllers
{
    using Libellus.Entidades;
    using Libellus.Mensajes;
    using Libellus.Negocio.Seguridad;
    using Libellus.Web.Areas.Administracion.Models;
    using Libellus.Web.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    /// <summary>
    /// Clase para el manejo se las funcionalidades por rol.
    /// </summary>
    public class FuncionalidadesController : AdministracionBaseController
    {
        #region Constructores

        /// <summary>
        /// Proporciona las acciones de interacción con la administración de roles.
        /// </summary>
        public FuncionalidadesController()
        {
            this.NegocioFuncionalidades = new NegocioFuncionalidades(this.UnidadDeTrabajoLibellus);
            this.NegocioRoles = new NegocioRoles(this.UnidadDeTrabajoLibellus);
            this.NegocioRolesFuncionalidades = new NegocioRolesFuncionalidades(this.UnidadDeTrabajoLibellus);
        }

        #endregion

        #region Acciones

        /// <summary>
        /// Acción http GET que consulta y muestra las funcionalidades de un rol.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [HttpGet]
        public ActionResult AsociarFuncionalidadesPorRol()
        {
            FuncionalidadesRolViewModel FuncinalidadesRolVM = new FuncionalidadesRolViewModel();
            try
            {
                FuncinalidadesRolVM = new FuncionalidadesRolViewModel()
                {
                    Roles = this.NegocioRoles.ConsultarRolesPorSede().Select(rs => new SelectListItem { Text = rs.Nombre, Value = rs.Id.ToString() })
                };
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(FuncinalidadesRolVM);
        }

        /// <summary>
        /// Consulta las funcionalidades por rol.
        /// </summary>
        /// <param name="idRol">Id del rol.</param>
        /// <returns>Un Json con las funcionalidades del rol</returns>
        [HttpGet]
        public JsonResult ConsultarFuncionalidadesPorRol(int idRol)
        {
            JsonResult Jsonresult = new JsonResult();
            try
            {
                var funcionalidadesPorRol = this.NegocioFuncionalidades.ConsultarFuncionalidadesPorRol(idRol).Select(f => f.Id);

                Jsonresult = Json(this.NegocioFuncionalidades.ConsultarFuncionalidades()
                    .Select(f => new
                    {
                        id = f.Id,
                        text = f.Nombre,
                        parent = f.IdPadre != null ? f.IdPadre.ToString() : "#",
                        state = new
                        {
                            selected = funcionalidadesPorRol.Contains(f.Id) && f.Categoria == ConstantesMenu.TipoMenuAccion
                        },
                        type = f.Categoria == ConstantesMenu.TipoMenuAccion ? f.Categoria : (f.Categoria == ConstantesMenu.CategoriaFuncionalidadMenu && f.Url == "#" && f.IdPadre != null) ? ConstantesMenu.TipoMenuGrupo : (f.Categoria == ConstantesMenu.CategoriaFuncionalidadMenu && f.Url.IndexOf("/") != -1 && f.IdPadre != null) ? ConstantesMenu.TipoMenuFuncionalidad : (f.Categoria == ConstantesMenu.CategoriaFuncionalidadMenu && f.IdPadre == null) ? ConstantesMenu.TipoMenuModulo : ConstantesMenu.TipoMenuDefecto,
                        li_attr = new
                        {
                            init_data = funcionalidadesPorRol.ToArray()
                        }
                    }), JsonRequestBehavior.AllowGet);
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return Jsonresult;
        }

        /// <summary>
        /// Acción http POST que asocia una collección  de IDs de funncionalidades a un Rol.
        /// </summary>
        /// <param name="model">FuncionalidadesRolViewModel.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult AsociarFuncionalidadesPorRol(FuncionalidadesRolViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IEnumerable<RolesFuncionalidades> funcionalidadesAEliminar = this.NegocioRolesFuncionalidades.ConsultarFuncionalidadesPorRol(model.IdRol);
                    IEnumerable<RolesFuncionalidades> funcionalidadesAInsertar = !string.IsNullOrEmpty(model.IdsFuncionalidades) ? model.IdsFuncionalidades.Split(',').Select(f => new RolesFuncionalidades() { IdRol = model.IdRol, IdFuncionalidad = int.Parse(f) }) : null;
                    this.NegocioRolesFuncionalidades.AsignarFuncionalidadesPorRol(funcionalidadesAEliminar, funcionalidadesAInsertar);
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje001));
                }
                catch (Exception excepcion)
                {
                    this.CapturarExcepcion(excepcion);
                }
            }


            return RedirectToAction("AsociarFuncionalidadesPorRol");
        }

        /// <summary>
        /// Consulta las funcionalidades por rol.
        /// </summary>
        /// <param name="idRol">Id del rol.</param>
        /// <returns>Un Json con las funcionalidades ususario.</returns>
        [HttpGet]
        public JsonResult ConsultarFuncionalidadesPorUsuario()
        {
            JsonResult Jsonresult = new JsonResult();
            try
            {
                var funcionalidadesPorRol = this.NegocioFuncionalidades.ConsultarMenuItemsPorUsuario(Utilidades.ContextoLibellus.ObtenerUsuarioActual).Select(f => f.Id); 

                Jsonresult = Json(this.NegocioFuncionalidades.ConsultarFuncionalidades()
                    .Select(f => new
                    {
                        id = f.Id,
                        text = f.Nombre,
                        parent = f.IdPadre != null ? f.IdPadre.ToString() : "#",
                        type = f.Categoria == ConstantesMenu.TipoMenuAccion ? f.Categoria : (f.Categoria == ConstantesMenu.CategoriaFuncionalidadMenu && f.Url == "#" && f.IdPadre != null) ? ConstantesMenu.TipoMenuGrupo : (f.Categoria == ConstantesMenu.CategoriaFuncionalidadMenu && f.Url.IndexOf("/") != -1 && f.IdPadre != null) ? ConstantesMenu.TipoMenuFuncionalidad : (f.Categoria == ConstantesMenu.CategoriaFuncionalidadMenu && f.IdPadre == null) ? ConstantesMenu.TipoMenuModulo : ConstantesMenu.TipoMenuDefecto,
                        li_attr = new
                        {
                            init_data = funcionalidadesPorRol.ToArray()
                        },
                        a_attr = new
                        {
                            href = f.Url
                        }
                    }), JsonRequestBehavior.AllowGet);
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return Jsonresult;
        }

        #endregion
    }
}