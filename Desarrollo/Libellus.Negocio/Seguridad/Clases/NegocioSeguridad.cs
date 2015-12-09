namespace Libellus.Negocio.Seguridad
{
    using Libellus.Entidades;
    using Libellus.Entidades.Constantes;
    using Libellus.Entidades.Enumerados;
    using Libellus.Mensajes;
    using Libellus.Negocio.UnidadesDeTrabajo;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Utilidades;

    /// <summary>
    /// Clase para la logica de negocio de la seguridad. 
    /// </summary>
    public class NegocioSeguridad : NegocioBase, INegocioSeguridad
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo NegocioUsuarios.
        /// </summary>
        public NegocioSeguridad(IUnidadDeTrabajoLibellus unidadDeTrabajoLibellus)
        {
            this.UnidadDeTrabajoLibellus = unidadDeTrabajoLibellus;
        }

        #endregion

        #region Métodos públicos

        /// <summary>
        /// Autentica un usuario en el ecosistema TML.
        /// </summary>
        /// <param name="nombreUsuario">Usuario a validar.</param>
        /// <param name="contrasena">Contraseña del usuario a validar.</param>
        /// <returns>Información del resultado del proceso de autenticación del usuario.</returns>
        public RespuestaAutenticacionUsuario AutenticarUsuario(string nombreUsuario, string contrasena)
        {
            RespuestaAutenticacionUsuario respuesta = new RespuestaAutenticacionUsuario();
            Usuario usuario = this.UnidadDeTrabajoLibellus.RepositorioUsuarios.ConsultarUsurioPorNombreUsuario(nombreUsuario);

            if (usuario == null)
            {
                respuesta.Mensaje = new Mensaje(CodigoMensaje.Mensaje1007);
            }
            else
            {
                respuesta = this.ValidarEstadoUsuario(usuario, nombreUsuario, contrasena);
                respuesta.usuario = usuario;
            }

            return respuesta;
        }

        /// <summary>
        /// Metodo para recordar la clave de acceso del usuario. 
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario.</param>
        /// <returns>Retorna el mensaje de recordar contraseña.</returns>
        public Mensaje RecordarContrasenia(string nombreUsuario)
        {
            Mensaje mensajeRespuesta = null;
            Usuario usuario = this.UnidadDeTrabajoLibellus.RepositorioUsuarios.ConsultarUsurioPorNombreUsuario(nombreUsuario);

            if (usuario == null)
            {
                mensajeRespuesta = new Mensaje(CodigoMensaje.Mensaje024);
                return mensajeRespuesta;
            }

            if (usuario.IdEstado == (int)EstadoUsuario.Bloqueado)
            {
                mensajeRespuesta = new Mensaje(CodigoMensaje.Mensaje026);
                return mensajeRespuesta;
            }

            return this.VerificarEnvioCorreo(usuario);
        }

        #endregion

        #region Métodos privados

        /// <summary>
        /// Verifica si el usuario tiene correo para realizar el envio de la iformación.
        /// </summary>
        /// <param name="usuario">Usuario para realizar la verificación.</param>
        /// <returns>Retorna mensaje de respuesta.</returns>
        private Mensaje VerificarEnvioCorreo(Usuario usuario)
        {
            Mensaje mensajeRespuesta = null;

            if (!string.IsNullOrEmpty(usuario.Correo))
            {
                this.EnvioCorreoElectronicoDatosAcceso(usuario);
                mensajeRespuesta = new Mensaje(CodigoMensaje.Mensaje023);
            }
            else
            {
                mensajeRespuesta = new Mensaje(CodigoMensaje.Mensaje025);
            }

            return mensajeRespuesta;
        }

        /// <summary>
        /// Realiza el envio de correo electronico.
        /// </summary>
        /// <param name="usuario">Usuario para el envio de correo.</param>
        private void EnvioCorreoElectronicoDatosAcceso(Usuario usuario)
        {
            string nombreApellidos = this.UnidadDeTrabajoLibellus.RepositorioUsuarios.ObtenerNombreApellidos(usuario.NombreUsuario);
            Dictionary<string, string> parametros = this.ObtenerParametrosCorreo();
            string rutaPlantillasEmail = UtilidadesApp.ObtenerRutaCompleta(String.Format("{0}/{1}", parametros[ConstantesApp.RutaPlantillaEmails], parametros[ConstantesApp.PlantillaEmailRecordarClaveAcceso]));
            string mensajeTexto = String.Format(File.ReadAllText(rutaPlantillasEmail), nombreApellidos, usuario.NombreUsuario, EncripcionLibellus.Descifrar(usuario.Clave), Utilidades.ContextoLibellus.ObtenerColegioActual);

            UtilidadesApp.EnviarCorreoElectronico(mensajeTexto, "Datos de acceso",
                   parametros[ConstantesApp.ServidorSmtpCorreoElectronico],
                   Convert.ToInt16(parametros[ConstantesApp.PuertoSmtpCorreoElectronico]),
                   parametros[ConstantesApp.UsuarioCorreoElectronico],
                   parametros[ConstantesApp.ClaveAccesoCorreoElectronico],
                   parametros[ConstantesApp.AliasCorreoElectronico],
                   usuario.Correo);
        }

        /// <summary>
        /// Obtiene los parametros para el envio de correo. 
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> ObtenerParametrosCorreo()
        {
            List<ParametrosNegocio> parametros = this.UnidadDeTrabajoLibellus.RepositorioParametros.Get().ToList();
            Dictionary<string, string> data = new Dictionary<string, string>();

            if (parametros != null && parametros.Count > 0)
            {
                foreach (var item in parametros)
                {
                    data.Add(item.Nombre, item.Valor);
                }
            }

            return data;
        }

        /// <summary>
        /// Metodo para validar el estado del usuario.
        /// </summary>
        /// <param name="usuario">Usuario para la validación.</param>
        /// <param name="nombreUsuario">Nombre de usuario.</param>
        /// <param name="contrasena">Contraseña ingresada.</param>
        /// <returns>Retorna la respuesta de la operación.</returns>
        private RespuestaAutenticacionUsuario ValidarEstadoUsuario(Usuario usuario, string nombreUsuario, string contrasena)
        {
            RespuestaAutenticacionUsuario respuesta = new RespuestaAutenticacionUsuario();

            if (usuario.IdEstado == (int)EstadoUsuario.Bloqueado)
            {
                respuesta.Mensaje = new Mensaje(CodigoMensaje.Mensaje026);
            }
            else
            {
                respuesta = this.ValidarCredencialesUsuario(usuario, nombreUsuario, contrasena);
            }

            return respuesta;
        }

        /// <summary>
        /// Método para validar el nombre de usuario y contraseña del usuario.
        /// </summary>
        /// <param name="usuario">Usuario a validar.</param>
        /// <param name="nombreUsuario">Nombre de usuario.</param>
        /// <param name="contrasena">Contraseña ingresada.</param>
        /// <returns>Retorna el resultado de la operación.</returns>
        private RespuestaAutenticacionUsuario ValidarCredencialesUsuario(Usuario usuario, string nombreUsuario, string contrasena)
        {
            RespuestaAutenticacionUsuario respuesta = new RespuestaAutenticacionUsuario();
            string contrasenaEncriptada = EncripcionLibellus.Cifrar(contrasena);

            if (usuario.NombreUsuario.Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase) && usuario.Clave == contrasenaEncriptada)
            {
                if (usuario.IntentosFallidos > 0)
                {
                    this.InicializarIntentosFallidosUsuario(usuario);
                }
            }
            else
            {
                respuesta = this.ValidarNumeroIntentosFallidosUsuario(usuario);
            }

            return respuesta;
        }

        /// <summary>
        /// Método para validar el número de intentos fallidos.
        /// </summary>
        /// <param name="usuario">Usuario a validar.</param>
        /// <returns>Retorna resultado de la operación.</returns>
        private RespuestaAutenticacionUsuario ValidarNumeroIntentosFallidosUsuario(Usuario usuario)
        {
            RespuestaAutenticacionUsuario respuesta = new RespuestaAutenticacionUsuario();
            ParametrosNegocio parametros = this.UnidadDeTrabajoLibellus.RepositorioParametros.GetById(ConstantesApp.NumeroIntentosFallidos);

            if (usuario.IntentosFallidos == Byte.Parse(parametros.Valor) - 1)
            {
                respuesta.Mensaje = new Mensaje(CodigoMensaje.Mensaje1007);
                usuario.IdEstado = (byte)EstadoUsuario.Bloqueado;
                this.IncrementarNumeroIntentosFallidosUsuario(usuario);
            }
            else
            {
                respuesta.Mensaje = new Mensaje(CodigoMensaje.Mensaje1007);

                this.IncrementarNumeroIntentosFallidosUsuario(usuario);
            }

            return respuesta;
        }

        /// <summary>
        /// Metodo para incrementar el numero de intentos fallidos. 
        /// </summary>
        /// <param name="usuario">Usuario para incrementar los intentos fallidos.</param>
        private void IncrementarNumeroIntentosFallidosUsuario(Usuario usuario)
        {
            if (usuario.IntentosFallidos == null)
            {
                usuario.IntentosFallidos = 0;
            }

            usuario.IntentosFallidos += 1;
            this.UnidadDeTrabajoLibellus.RepositorioUsuarios.Update(usuario);
            this.UnidadDeTrabajoLibellus.SaveChanges();
        }

        /// <summary>
        /// Método para inicializar los intentos fallidos de la aplicación.
        /// </summary>
        /// <param name="usuario">Usuario para inicializar los intentos fallidos.</param>
        private void InicializarIntentosFallidosUsuario(Usuario usuario)
        {
            usuario.IntentosFallidos = 0;
            this.UnidadDeTrabajoLibellus.RepositorioUsuarios.Update(usuario);
            this.UnidadDeTrabajoLibellus.SaveChanges();
        }

        #endregion
    }
}
