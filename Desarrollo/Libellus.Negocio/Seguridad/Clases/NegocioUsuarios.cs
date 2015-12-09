namespace Libellus.Negocio.Seguridad
{
    using Libellus.Entidades;
    using Libellus.Entidades.Constantes;
    using Libellus.Mensajes;
    using Libellus.Negocio.UnidadesDeTrabajo;
    using Libellus.Utilidades;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Define la clase de las reglas de negocio para los maestros administrables.
    /// </summary>
    public class NegocioUsuarios : NegocioBase, INegocioUsuarios
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo NegocioUsuarios.
        /// </summary>
        public NegocioUsuarios(IUnidadDeTrabajoLibellus unidadDeTrabajoLibellus)
        {
            this.UnidadDeTrabajoLibellus = unidadDeTrabajoLibellus;
        }

        #endregion

        #region Métodos publicos

        //// <summary>
        /// Realiza la autenticacion del usuario.
        /// </summary>
        /// <param name="nombreUsuario">LogIn del usuario.</param>
        /// <param name="clave">Contrasenia del usuario.</param>
        /// <returns>Retorna registro encontrado.</returns>
        public bool AutenticarUsuario(string nombreUsuario, string clave)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioUsuarios.AutenticarUsuario(nombreUsuario, clave);
        }

        /// <summary>
        /// Consulta el usuario por logIn.
        /// </summary>
        /// <param name="nombreUsuario">Login del usuario.</param>
        /// <returns>Retorna el usuario consultado.</returns>
        public Usuario ConsultarUsurioPorNombreUsuario(string nombreUsuario)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioUsuarios.ConsultarUsurioPorNombreUsuario(nombreUsuario);
        }

        /// <summary>
        /// Edita un usuario.
        /// </summary>
        /// <param name="usuario">Usuario a editar.</param>
        /// <returns>true si el usuario fue editado en el sistema, de lo contrario false.</returns>
        public bool Editar(Usuario usuario)
        {
            this.UnidadDeTrabajoLibellus.RepositorioUsuarios.Update(usuario);
            return this.UnidadDeTrabajoLibellus.SaveChanges() > 0;
        }

        /// <summary>
        /// Crea un usuario.
        /// </summary>
        /// <param name="usuario">Usuario a editar.</param>
        /// <returns>true si el usuario fue creado en el sistema, de lo contrario false.</returns>
        public bool Crear(Usuario usuario)
        {
            this.UnidadDeTrabajoLibellus.RepositorioUsuarios.Insert(usuario);
            return this.UnidadDeTrabajoLibellus.SaveChanges() > 0;
        }

        /// <summary>
        /// Valida la duplicidad del documento y tipo de documento.
        /// </summary>
        /// <param name="usuario">Usuario para la validación.</param>
        /// <returns>Retorna el resultado de la validación.</returns>
        public bool ValidarDocumento(Usuario usuario)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioUsuarios.ValidarDocumento(usuario);
        }

        /// <summary>
        /// Valida que el nombre de usuario no este repetido.
        /// </summary>
        /// <param name="usuario">Usuario para la validación.</param>
        /// <returns>Retorna el resultado de la validación.</returns>
        public bool ValidarNombreUsuario(Usuario usuario)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioUsuarios.ValidarNombreUsuario(usuario);
        }

        /// <summary>
        /// Consulta el usuario por el id.
        /// </summary>
        /// <param name="idUsuario">Identificador del usuario.</param>
        /// <returns>Retorna el resultado de la consulta.</returns>
        public Usuario ConsultarPorId(int idUsuario)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioUsuarios.ConsultarPorId(idUsuario);
        }

        /// <summary>
        /// Consulta los usuarios que cumplan con los filtros indicados.
        /// </summary>
        /// <param name="idTipoIdentificacion">Tipo de identificación del usuario.</param>
        /// <param name="identificacion">Identificación del usuario.</param>
        /// <param name="idEstado">Estado del usuario.</param>
        /// <param name="idRol">Rol del usuario.</param>
        /// <param name="sede">Sede a la que pertenece el usuario.</param>
        /// <returns>Los usuarios que cumplan con los filtros indicados.</returns>
        public IEnumerable<Usuario> Consultar(int? idTipoIdentificacion, string identificacion, byte? idEstado, int? idRol, int sede)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioUsuarios.Consultar(idTipoIdentificacion, identificacion, idEstado, idRol, sede);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <param name="contrasenia"></param>
        /// <returns></returns>
        public bool EnvioCorreoCambiocontrasenia(string nombreUsuario, string contrasenia)
        {
            Usuario usuario = this.ConsultarUsurioPorNombreUsuario(nombreUsuario);

            if (usuario != null && !string.IsNullOrEmpty(usuario.Correo))
            {
                string nombreApellidos = this.UnidadDeTrabajoLibellus.RepositorioUsuarios.ObtenerNombreApellidos(usuario.NombreUsuario);
                Dictionary<string, string> parametros = this.ObtenerParametrosCorreo();
                string rutaPlantillasEmail = UtilidadesApp.ObtenerRutaCompleta(String.Format("{0}/{1}", parametros[ConstantesApp.RutaPlantillaEmails], parametros[ConstantesApp.PlantillaEmailCambioContrasenia]));
                string mensajeTexto = String.Format(File.ReadAllText(rutaPlantillasEmail), nombreApellidos, usuario.NombreUsuario, EncripcionLibellus.Descifrar(usuario.Clave), Utilidades.ContextoLibellus.ObtenerColegioActual);

                UtilidadesApp.EnviarCorreoElectronico(mensajeTexto, "Cambio de contraseña",
                       parametros[ConstantesApp.ServidorSmtpCorreoElectronico],
                       Convert.ToInt16(parametros[ConstantesApp.PuertoSmtpCorreoElectronico]),
                       parametros[ConstantesApp.UsuarioCorreoElectronico],
                       parametros[ConstantesApp.ClaveAccesoCorreoElectronico],
                       parametros[ConstantesApp.AliasCorreoElectronico],
                       usuario.Correo);
            }

            return true;
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

        #endregion

    }
}
