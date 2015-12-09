namespace Libellus.Web.Areas.Administracion.Controllers
{
    using Libellus.Entidades;
    using Libellus.Mensajes;
    using Libellus.Negocio.Seguridad;
    using Libellus.Negocio.UnidadesDeTrabajo;
    using Libellus.Utilidades;
    using Libellus.Web.Areas.Administracion.Models;
    using Libellus.Web.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Security;

    /// <summary>
    /// Proporciona las acciones de interacción con el ingreso al sistema.
    /// </summary>
    [Authorize]
    public class AccountController : Controller
    {
        #region Acciones

        /// <summary>
        /// Acción para realizar el login.
        /// </summary>
        /// <returns>Retorna la vista.</returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Bienvenida", "Home", new { area = "" });
            }

            return View();
        }

        /// <summary>
        /// Acción para realizar el logín. 
        /// </summary>
        /// <param name="model">Modelos para el login del usuario.</param>
        /// <returns>Retorna la vista.</returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                string conexionColegio = RepositorioCentral.ObtenerParametros(model.CodigoColegio);
                RespuestaAutenticacionUsuario respuestaAutenticacion = new RespuestaAutenticacionUsuario();

                if (!string.IsNullOrEmpty(conexionColegio))
                {
                    respuestaAutenticacion = this.ValidadUsuarioLogin(model);
                }
                else
                {
                    respuestaAutenticacion.Mensaje = new Mensaje(CodigoMensaje.Mensaje1007);
                }

                if (!respuestaAutenticacion.ResultadoValidacion)
                {
                    this.MostrarMensaje(respuestaAutenticacion.Mensaje);
                }
                else
                {
                    return RedirectToAction("Consultar", "Sedes", new { area = "Administracion" });
                }
            }
            catch (Exception excepcion)
            {
                Mensaje mensaje = UtilidadesApp.CapturarExcepcion(excepcion);
                this.MostrarMensaje(mensaje);
            }

            return View();
        }

        /// <summary>
        /// Realiza el cierre de sesión.
        /// </summary>
        /// <returns>Retorna a una vista.</returns>
        [HttpGet]
        public ActionResult LogOff()
        {
            this.CerrarAplicacion();
            return RedirectToAction("Login", "Account");
        }

        /// <summary>
        /// Recordar clave de acceso. 
        /// </summary>
        /// <returns>La vista para crear un usuario administrativo.</returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult RecordarClaveAcceso()
        {
            return View();
        }

        /// <summary>
        /// Recordar clave de acceso. 
        /// </summary>
        /// <returns>La vista para crear un usuario administrativo.</returns>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult RecordarClaveAcceso(RecuperarContraseniaViewModels model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                string conexionColegio = RepositorioCentral.ObtenerParametros(model.CodigoColegio);

                if (!string.IsNullOrEmpty(conexionColegio))
                {
                    UtilidadesApp.AlmacenarInformacionCookie(ConstantesCookie.CodigoColegio, model.CodigoColegio, DateTime.Now.AddDays(FormsAuthentication.Timeout.Minutes));

                    using (NegocioSeguridad negocioSeguridad = new NegocioSeguridad(new UnidadDeTrabajoLibellus()))
                    {
                        this.MostrarMensaje(negocioSeguridad.RecordarContrasenia(model.nombreUsuario));
                    }
                }
                else
                {
                    this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje1007));
                }
            }
            catch (Exception excepcion)
            {
                Mensaje mensaje = UtilidadesApp.CapturarExcepcion(excepcion);
                this.MostrarMensaje(mensaje);
            }

            return RedirectToAction("Login");
        }

        /// <summary>
        /// Recordar clave de acceso. 
        /// </summary>
        /// <returns>La vista para crear un usuario administrativo.</returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult CambiarContrasenia()
        {
            return View();
        }

        /// <summary>
        /// Recordar clave de acceso. 
        /// </summary>
        /// <returns>La vista para crear un usuario administrativo.</returns>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult CambiarContrasenia(CambiarContraseniaViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                using (NegocioUsuarios negocioUsurio = new NegocioUsuarios(new UnidadDeTrabajoLibellus()))
                {
                    Usuario usuario =  negocioUsurio.ConsultarUsurioPorNombreUsuario(this.User.Identity.Name);

                    if(usuario != null && usuario.Clave.Equals(EncripcionLibellus.Cifrar(model.ClaveAcceso)))
                    {
                        if(model.NuevaContrasenia.Equals(model.ConfirmarContrasenia))
                        {
                            usuario.Clave = EncripcionLibellus.Cifrar(model.NuevaContrasenia);
                            negocioUsurio.Editar(usuario);
                            negocioUsurio.EnvioCorreoCambiocontrasenia(this.User.Identity.Name, model.NuevaContrasenia);
                            CerrarAplicacion();
                            this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje002));
                            return RedirectToAction("Login");
                        }
                        else
                        {
                            this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje027));
                            return RedirectToAction("CambiarContrasenia");
                        }
                    }
                    else
                    {
                        this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje028));
                        return RedirectToAction("CambiarContrasenia");
                    }
                }
            }
            catch (Exception excepcion)
            {
                Mensaje mensaje = UtilidadesApp.CapturarExcepcion(excepcion);
                this.MostrarMensaje(mensaje);
            }

            return View();
        }

        /// <summary>
        /// Accion para renderizar el menu dinamico segun los roles del usuario logeado
        /// </summary>
        /// <returns>ActionResult</returns>
        [HttpGet]
        public ActionResult MenuDinamico()
        {
            IEnumerable<Funcionalidad> itemsActivos;
            using (NegocioFuncionalidades negocioFuncionalidades = new NegocioFuncionalidades(new UnidadDeTrabajoLibellus()))
            {
                var lista = negocioFuncionalidades.ConsultarMenuItemsPorUsuario(Utilidades.ContextoLibellus.ObtenerUsuarioActual);
                itemsActivos = lista.Where(o => o.Estado == true);
            }

            return PartialView("_MenuPartial", itemsActivos);
        }

        #endregion

        #region Metodos privados


        private RespuestaAutenticacionUsuario ValidadUsuarioLogin(LoginViewModel model)
        {
            RespuestaAutenticacionUsuario respuestaAutenticacion = new RespuestaAutenticacionUsuario();
            respuestaAutenticacion.ResultadoValidacion = false;

            UtilidadesApp.AlmacenarInformacionCookie(ConstantesCookie.CodigoColegio, model.CodigoColegio, DateTime.Now.AddDays(FormsAuthentication.Timeout.Minutes));

            using (NegocioSeguridad negocioSeguridad = new NegocioSeguridad(new UnidadDeTrabajoLibellus()))
            {
                respuestaAutenticacion = negocioSeguridad.AutenticarUsuario(model.NombreUsuario, model.Clave);

                if (respuestaAutenticacion != null)
                {
                    if (respuestaAutenticacion.Mensaje == null)
                    {
                        respuestaAutenticacion.ResultadoValidacion = true;
                        Utilidades.UtilidadesApp.AlmacenarInformacionCookie(ConstantesCookie.UsuarioLogin, ObtenerNombreDelUsuario(respuestaAutenticacion.usuario), DateTime.Now.AddDays(FormsAuthentication.Timeout.Minutes));
                        Utilidades.UtilidadesApp.AlmacenarInformacionCookie(ConstantesCookie.NombreUsuario, respuestaAutenticacion.usuario.NombreUsuario, DateTime.Now.AddDays(FormsAuthentication.Timeout.Minutes));
                        FormsAuthentication.SetAuthCookie(model.NombreUsuario, false);
                        FormsAuthentication.RedirectFromLoginPage(respuestaAutenticacion.usuario.NombreUsuario, true);
                        
                    }
                }
            }

            return respuestaAutenticacion;
        }

        /// <summary>
        /// Método para cerrar la aplicació y eliminar las cookie.
        /// </summary>
        private void CerrarAplicacion()
        {
            UtilidadesApp.EliminarInformacionCookie(ConstantesCookie.UsuarioLogin);
            UtilidadesApp.EliminarInformacionCookie(ConstantesCookie.Sede);
            UtilidadesApp.EliminarInformacionCookie(ConstantesCookie.CodigoColegio);
            UtilidadesApp.EliminarInformacionCookie(ConstantesCookie.SedePrincipal);
            UtilidadesApp.EliminarInformacionCookie(ConstantesCookie.NombreUsuario);
            FormsAuthentication.SignOut();
        }

        /// <summary>
        /// Redirecciona a una vista especifica.
        /// </summary>
        /// <param name="returnUrl">URL para retornar.</param>
        /// <returns>Retorna a la accion.</returns>
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Bienvenida", "Home", new { area = "" });
        }

        /// <summary>
        /// Obtiene Usuario por nombre de usuario.
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario.</param>
        /// <returns>Retorna el resultaod de la consulta. </returns>
        private Usuario ObtenerUsuario(string nombreUsuario)
        {
            Usuario usuario = new Usuario();

            using (NegocioUsuarios negocioUsuarios = new NegocioUsuarios(new UnidadDeTrabajoLibellus()))
            {
                usuario = negocioUsuarios.ConsultarUsurioPorNombreUsuario(nombreUsuario);
            }

            return usuario;
        }

        /// <summary>
        /// Obtiene el nombre completo del usuario logueado.
        /// </summary>
        /// <param name="usuario">Usuario para obtener el nombre.</param>
        /// <returns>Retorna el resultado.</returns>
        private string ObtenerNombreDelUsuario(Usuario usuario)
        {
            string nombre = string.Empty;

            if (usuario.UsuariosAdministrativos != null && usuario.UsuariosAdministrativos.Any())
            {
                nombre = usuario.UsuariosAdministrativos.FirstOrDefault().Nombres + " " + usuario.UsuariosAdministrativos.FirstOrDefault().Apellidos;
            }
            else if(usuario.Estudiante != null)
            {
                nombre = string.Format("{0} {1} {2}", usuario.Estudiante.Nombre, usuario.Estudiante.PrimerApellido, usuario.Estudiante.SegundoApellido);
            }

            return nombre;
        }

        #endregion
    }
}