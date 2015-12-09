namespace Libellus.Web.Areas.Administracion.Controllers
{
    using Libellus.Entidades;
    using Libellus.Entidades.Enumerados;
    using Libellus.Mensajes;
    using Libellus.Negocio.Administracion;
    using Libellus.Negocio.Administracion.Clases;
    using Libellus.Negocio.Seguridad;
    using Libellus.Utilidades;
    using Libellus.Web.Areas.Administracion.Models.UsuariosAdministrativos;
    using Libellus.Web.Helpers;
    using PagedList;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Mime;
    using System.Web.Mvc;

    /// <summary>
    /// Proporciona las acciones para usuarios administrativos.
    /// </summary>
    // [AutorizacionFuncionalidad]
    public class UsuariosAdministrativosController : AdministracionBaseController
    {
        #region Atributos
        #endregion

        #region Propiedades
        #endregion

        #region Constructor

        /// <summary>
        /// Inicializa una instancia de tipo MaestrosController.
        /// </summary>
        public UsuariosAdministrativosController()
        {
            this.NegocioUsuariosAdministrativos = new NegocioUsuariosAdministrativos(this.UnidadDeTrabajoLibellus);
            this.NegocioMaestros = new NegocioMaestros(this.UnidadDeTrabajoLibellus);
            this.NegocioRoles = new NegocioRoles(this.UnidadDeTrabajoLibellus);
            this.NegocioUsuarios = new NegocioUsuarios(this.UnidadDeTrabajoLibellus);
            this.NegocioSedes = new NegocioSedes(this.UnidadDeTrabajoLibellus);
        }

        #endregion

        #region Acciones

        /// <summary>
        /// Acción para consulta de usuarios administrativos.
        /// </summary>
        /// <param name="tipoIdentificacion">El tipo de identificación del usuario administrativo.</param>
        /// <param name="identificacion">La identificación del usuario administrativo.</param>
        /// <param name="usuario">El login del usuario administrativo.</param>
        /// <param name="rol">El rol del usuario administrativo.</param>
        /// <param name="cargo">El cargo del usuario administrativo.</param>
        /// <returns>La vista de consulta para usuarios administrativos.</returns>
        [HttpGet]
        // [AutorizacionFuncionalidad]
        public ActionResult Consultar(int? tipoIdentificacion, string identificacion,
            int? rol, int? cargo, int? pagina)
        {
            IEnumerable<UsuarioAdministrativoViewModelConsulta> usuariosAdministrativo = new UsuarioAdministrativoViewModelConsulta[] { };

            try
            {
                int sede = Utilidades.ContextoLibellus.ObtenerSedeActual;
                ViewBag.TiposIdentificaciones = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.TiposIdentificaciones, sede).OrderBy(x => x.Descripcion);
                ViewBag.Cargos = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Cargos, sede).OrderBy(x => x.Descripcion);
                ViewBag.Roles = this.NegocioRoles.ConsultarRolesPorSede().OrderBy(x => x.Nombre);

                usuariosAdministrativo = this.NegocioUsuariosAdministrativos
                    .Consultar(tipoIdentificacion, identificacion, rol, cargo)
                    .Select(ua => new UsuarioAdministrativoViewModelConsulta
                    {
                        Id = ua.Id,
                        TipoIdentificacion = ua.Usuario.TipoIdentificacion.Descripcion,
                        Identificacion = ua.Usuario.Identificacion,
                        Nombres = ua.Nombres,
                        Apellidos = ua.Apellidos,
                        Rol = ua.Usuario.UsuariosRoles.FirstOrDefault().Rol.Nombre,
                        Cargo = ua.Cargo.Descripcion,
                        Activo = ua.Usuario.UsuariosEstado.Descripcion
                    });
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            int numeroPagina = (pagina ?? 1);
            int tamanoPagina = 10;

            return View(usuariosAdministrativo.ToPagedList(numeroPagina, tamanoPagina));
        }

        /// <summary>
        /// Muestra la vista para crear un usuario administrativo.
        /// </summary>
        /// <returns>La vista para crear un usuario administrativo.</returns>
        [HttpGet]
        public ActionResult Crear()
        {
            UsuarioAdministrativoViewModel usuarioAdministrativo = new UsuarioAdministrativoViewModel();
            ViewBag.NuevoRegistro = true;

            try
            {
                ObtenerListadoModelo(usuarioAdministrativo);
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return View(usuarioAdministrativo);
        }

        /// <summary>
        /// Acción para crear un usuario administrativo.
        /// </summary>
        /// <param name="usuarioAdministrativo">Información del usuario a crear.</param>
        /// <returns>La acción de la creación de un usuario administrativo.</returns>
        [HttpPost]
        public ActionResult Crear(UsuarioAdministrativoViewModel modeloUsuarioAdministrativo)
        {
            ViewBag.NuevoRegistro = true;
            if (ModelState.IsValid)
            {
                try
                {
                    int sede = Utilidades.ContextoLibellus.ObtenerSedeActual;
                    ICollection<UsuarioRol> listaRol = new List<UsuarioRol>();
                    listaRol.Add(new UsuarioRol() { IdRol = modeloUsuarioAdministrativo.ModeloRegistrarUsuario.IdRol, IdSede = sede });
                    UsuarioRol usuarioRol = new UsuarioRol();
                    usuarioRol.Rol = this.NegocioRoles.Consultar(modeloUsuarioAdministrativo.ModeloRegistrarUsuario.IdRol);
                    usuarioRol.Sede = this.NegocioSedes.ConsultarSedes(Utilidades.ContextoLibellus.ObtenerSedeActual);

                    UsuarioAdministrativo usuarioAdministrativo = new UsuarioAdministrativo()
                    {
                        Usuario = new Usuario()
                        {
                            Clave = EncripcionLibellus.Cifrar(UtilidadesApp.RemoverCaracterClave(Convert.ToDateTime(modeloUsuarioAdministrativo.FechaNacimiento).ToShortDateString().Replace("/", string.Empty))),
                            Correo = modeloUsuarioAdministrativo.ModeloRegistrarUsuario.Correo,
                            IdEstado = (int)EstadoUsuario.Activo,
                            Identificacion = modeloUsuarioAdministrativo.ModeloRegistrarUsuario.Identificacion,
                            IdTipoIdentificacion = modeloUsuarioAdministrativo.ModeloRegistrarUsuario.IdTipoIdentificacion,
                            NombreUsuario = modeloUsuarioAdministrativo.ModeloRegistrarUsuario.Identificacion,
                            UsuariosRoles = listaRol
                        },
                        Apellidos = modeloUsuarioAdministrativo.Apellidos,
                        Celular = modeloUsuarioAdministrativo.Celular,
                        Direccion = modeloUsuarioAdministrativo.Direccion,
                        FechaNacimiento = Convert.ToDateTime(modeloUsuarioAdministrativo.FechaNacimiento),
                        IdCargo = modeloUsuarioAdministrativo.IdCargo,
                        IdGrupoSanguineo = modeloUsuarioAdministrativo.IdGrupoSanguineo,
                        Nombres = modeloUsuarioAdministrativo.Nombres,
                        Telefono = modeloUsuarioAdministrativo.Telefono
                    };

                    if (ValidacionesUsuario(usuarioAdministrativo))
                    {
                        CrearUsuarioAdministrativo(usuarioAdministrativo);
                        this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje001));
                    }
                    else
                    {
                        ObtenerListadoModelo(modeloUsuarioAdministrativo);
                        return View(modeloUsuarioAdministrativo);
                    }
                }
                catch (Exception excepcion)
                {
                    this.CapturarExcepcion(excepcion);
                }
            }

            return RedirectToAction("Consultar");
        }

        /// <summary>
        /// Muestra la vista para editar un usuario administrativo.
        /// </summary>
        /// <returns>La vista para editar un usuario administrativo.</returns>
        [HttpGet]
        public ActionResult Editar(int id)
        {
            ViewBag.NuevoRegistro = false;
            UsuarioAdministrativoViewModel modeloUsuarioAdministrativo = new UsuarioAdministrativoViewModel();
            int sede = Utilidades.ContextoLibellus.ObtenerSedeActual;

            try
            {
                UsuarioAdministrativo usuarioAdministrativo = this.NegocioUsuariosAdministrativos.Consultar(id);
                ObtenerListadoModelo(modeloUsuarioAdministrativo);
                modeloUsuarioAdministrativo.Id = usuarioAdministrativo.Id;
                modeloUsuarioAdministrativo.ModeloRegistrarUsuario.IdTipoIdentificacion = usuarioAdministrativo.Usuario.IdTipoIdentificacion;
                modeloUsuarioAdministrativo.ModeloRegistrarUsuario.Identificacion = usuarioAdministrativo.Usuario.Identificacion;
                modeloUsuarioAdministrativo.Nombres = usuarioAdministrativo.Nombres;
                modeloUsuarioAdministrativo.Apellidos = usuarioAdministrativo.Apellidos;
                modeloUsuarioAdministrativo.ModeloRegistrarUsuario.NombreUsuario = usuarioAdministrativo.Usuario.NombreUsuario;
                modeloUsuarioAdministrativo.ModeloRegistrarUsuario.Correo = usuarioAdministrativo.Usuario.Correo;
                modeloUsuarioAdministrativo.ModeloRegistrarUsuario.Estado = usuarioAdministrativo.Usuario.IdEstado;
                modeloUsuarioAdministrativo.ModeloRegistrarUsuario.IdRol = usuarioAdministrativo.Usuario.UsuariosRoles.FirstOrDefault().IdRol;
                modeloUsuarioAdministrativo.ModeloRegistrarUsuario.Id = usuarioAdministrativo.Usuario.Id;
                modeloUsuarioAdministrativo.Telefono = usuarioAdministrativo.Telefono;
                modeloUsuarioAdministrativo.IdGrupoSanguineo = usuarioAdministrativo.IdGrupoSanguineo;
                modeloUsuarioAdministrativo.FechaNacimiento = usuarioAdministrativo.FechaNacimiento.ToString();
                modeloUsuarioAdministrativo.IdCargo = usuarioAdministrativo.IdCargo;
                modeloUsuarioAdministrativo.Direccion = usuarioAdministrativo.Direccion;
                modeloUsuarioAdministrativo.Celular = usuarioAdministrativo.Celular;
            }
            catch (Exception exception)
            {
                this.CapturarExcepcion(exception);
            }

            return View(modeloUsuarioAdministrativo);
        }

        /// <summary>
        /// Acción para editar un usuario administrativo.
        /// </summary>
        /// <param name="usuarioAdministrativo">Información del usuario a crear.</param>
        /// <returns>La acción para editar un usuario administrativo.</returns>
        [HttpPost]
        public ActionResult Editar(UsuarioAdministrativoViewModel modeloUsuarioAdministrativo)
        {
            ViewBag.NuevoRegistro = false;
            if (ModelState.IsValid)
            {
                try
                {
                    UsuarioAdministrativo usuarioAdministrativo = this.NegocioUsuariosAdministrativos.ConsultarPorId(modeloUsuarioAdministrativo.Id);
                    usuarioAdministrativo.Usuario.Correo = modeloUsuarioAdministrativo.ModeloRegistrarUsuario.Correo;
                    usuarioAdministrativo.Usuario.UsuariosRoles.FirstOrDefault().IdRol = modeloUsuarioAdministrativo.ModeloRegistrarUsuario.IdRol;
                    usuarioAdministrativo.Apellidos = modeloUsuarioAdministrativo.Apellidos;
                    usuarioAdministrativo.Celular = modeloUsuarioAdministrativo.Celular;
                    usuarioAdministrativo.Direccion = modeloUsuarioAdministrativo.Direccion;
                    usuarioAdministrativo.FechaNacimiento = Convert.ToDateTime(modeloUsuarioAdministrativo.FechaNacimiento);
                    usuarioAdministrativo.IdCargo = modeloUsuarioAdministrativo.IdCargo;
                    usuarioAdministrativo.IdGrupoSanguineo = modeloUsuarioAdministrativo.IdGrupoSanguineo;
                    usuarioAdministrativo.Nombres = modeloUsuarioAdministrativo.Nombres;
                    usuarioAdministrativo.Telefono = modeloUsuarioAdministrativo.Telefono;
                    usuarioAdministrativo.Usuario.IdEstado = usuarioAdministrativo.Usuario.IdEstado;
                    usuarioAdministrativo.Usuario.Id = modeloUsuarioAdministrativo.ModeloRegistrarUsuario.Id;
                    usuarioAdministrativo.Usuario.Identificacion = modeloUsuarioAdministrativo.ModeloRegistrarUsuario.Identificacion;
                    usuarioAdministrativo.Usuario.IdTipoIdentificacion = modeloUsuarioAdministrativo.ModeloRegistrarUsuario.IdTipoIdentificacion;
                    usuarioAdministrativo.Usuario.NombreUsuario = modeloUsuarioAdministrativo.ModeloRegistrarUsuario.Identificacion;

                    if (ValidacionesUsuario(usuarioAdministrativo))
                    {
                        this.NegocioUsuariosAdministrativos.Editar(usuarioAdministrativo);
                        this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje002));
                    }
                    else
                    {
                        ObtenerListadoModelo(modeloUsuarioAdministrativo);
                        return View(modeloUsuarioAdministrativo);
                    }
                }
                catch (Exception excepcion)
                {
                    this.CapturarExcepcion(excepcion);
                }
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
            string nombreArchivo = "Libellus_UsuariosAdministrativos.xlsx";
            this.Response.AppendCookie(new System.Web.HttpCookie("cookieExportarExcel", token));

            try
            {
                IEnumerable<object> aspectosEvaluativos = (from usuario in this.NegocioUsuariosAdministrativos.Consultar(null, null, null, null)
                                                           select new
                                                           {
                                                               Tipo_Documento = usuario.Usuario.TipoIdentificacion.Descripcion,
                                                               Documento_Identidad = usuario.Usuario.Identificacion,
                                                               Nombres = usuario.Nombres,
                                                               Apellidos = usuario.Apellidos,
                                                               Rol = usuario.Usuario.UsuariosRoles.FirstOrDefault().Rol.Nombre,
                                                               Cargo = usuario.Cargo.Descripcion,
                                                               Estado = usuario.Usuario.UsuariosEstado.Descripcion
                                                           });

                byteArray = ExportarExcel.Exportar(aspectosEvaluativos.ToList(), "Usuarios administrativos");
            }
            catch (Exception excepcion)
            {
                this.CapturarExcepcion(excepcion);
            }

            return this.File(byteArray, MediaTypeNames.Application.Octet, nombreArchivo);
        }

        #endregion

        #region Metodos Privado

        /// <summary>
        /// Obtiene el listado para los usuarios administrativos.
        /// </summary>
        /// <param name="modeloUsuarioAdministrativo">Parametros para la consulta.</param>
        private void ObtenerListadoModelo(UsuarioAdministrativoViewModel modeloUsuarioAdministrativo)
        {
            IEnumerable<SelectListItem> estados = Enum.GetValues(typeof(EstadoUsuario)).Cast<EstadoUsuario>().Select(ti => new SelectListItem { Value = ((int)ti).ToString(), Text = ti.ToString() }).OrderBy(x => x.Text);

            int sede = Utilidades.ContextoLibellus.ObtenerSedeActual;
            IEnumerable<SelectListItem> gruposSanguineos = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.GruposSanguineos, sede)
                .Select(ti => new SelectListItem { Value = ti.Id.ToString(), Text = ti.Descripcion }).OrderBy(x => x.Text);

            IEnumerable<SelectListItem> cargos = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Cargos, sede)
                .Select(ti => new SelectListItem { Value = ti.Id.ToString(), Text = ti.Descripcion }).OrderBy(x => x.Text);

            IEnumerable<SelectListItem> tiposIdentificaciones = this.NegocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.TiposIdentificaciones, sede)
               .Select(ti => new SelectListItem { Value = ti.Id.ToString(), Text = ti.Descripcion }).OrderBy(x => x.Text);

            IEnumerable<SelectListItem> roles = this.NegocioRoles.ConsultarRolesPorSede()
                .Select(ti => new SelectListItem { Value = ti.Id.ToString(), Text = ti.Nombre }).OrderBy(x => x.Text);

            modeloUsuarioAdministrativo.ModeloRegistrarUsuario.TiposIdentificaciones = tiposIdentificaciones;
            modeloUsuarioAdministrativo.ModeloRegistrarUsuario.Roles = roles;
            modeloUsuarioAdministrativo.GruposSanguineos = gruposSanguineos;
            modeloUsuarioAdministrativo.Cargos = cargos;
            modeloUsuarioAdministrativo.ModeloRegistrarUsuario.Estados = estados;
        }

        /// <summary>
        /// Realiza las validaciones del usuario. 
        /// </summary>
        /// <param name="usuarioAdministrativo">Parametros para las validaciones.</param>
        private bool ValidacionesUsuario(UsuarioAdministrativo usuarioAdministrativo)
        {
            bool respuesta = true;

            if (NegocioUsuarios.ValidarDocumento(usuarioAdministrativo.Usuario))
            {
                respuesta = false;
                this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje009));
                return respuesta;
            }

            if (NegocioUsuarios.ValidarNombreUsuario(usuarioAdministrativo.Usuario))
            {
                respuesta = false;
                this.MostrarMensaje(new Mensaje(CodigoMensaje.Mensaje007));
                return respuesta;
            }

            return respuesta;
        }

        /// <summary>
        /// Metodo que realiza el llamado al almacenamiento de la información del usuario administrativo.
        /// </summary>
        /// <param name="usuarioAdministrativo"></param>
        private void CrearUsuarioAdministrativo(UsuarioAdministrativo usuarioAdministrativo)
        {
            this.NegocioUsuariosAdministrativos.Crear(usuarioAdministrativo);
        }

        #endregion
    }
}