namespace Libellus.Negocio.Administracion.Clases
{
    using Libellus.Entidades;
    using Libellus.Entidades.Constantes;
    using Libellus.Negocio.Seguridad;
    using Libellus.Negocio.UnidadesDeTrabajo;
    using Libellus.Utilidades;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Define las reglas de negocio para los usuarios administrativos.
    /// </summary>
    public class NegocioUsuariosAdministrativos : NegocioBase, INegocioUsuariosAdministrativos
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo NegocioUsuariosAdministrativos.
        /// </summary>
        public NegocioUsuariosAdministrativos(IUnidadDeTrabajoLibellus unidadDeTrabajoLibellus)
        {
            this.UnidadDeTrabajoLibellus = unidadDeTrabajoLibellus;
        }

        #endregion Constructores

        #region Métodos

        /// <summary>
        /// Consulta de usuarios administrativos por id.
        /// </summary>
        /// <param name="id">Id del usuario administrativo a consultar.</param>
        /// <returns>El usuario administrativo.</returns>
        public UsuarioAdministrativo Consultar(int id)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioUsuariosAdministrativos.GetById(id);
        }

        /// <summary>
        /// Consulta de usuarios administrativos.
        /// </summary>
        /// <param name="tipoIdentificacion">El tipo de identificación del usuario administrativo.</param>
        /// <param name="identificacion">La identificación del usuario administrativo.</param>
        /// <param name="rol">El rol del usuario administrativo.</param>
        /// <param name="cargo">El cargo del usuario administrativo.</param>
        /// <returns>La consulta de usuarios administrativos.</returns>
        public IEnumerable<UsuarioAdministrativo> Consultar(int? tipoIdentificacion, string identificacion, int? rol, int? cargo)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioUsuariosAdministrativos
                .Consultar(tipoIdentificacion, identificacion, rol, cargo, Utilidades.ContextoLibellus.ObtenerSedeActual);
        }

        /// <summary>
        /// Crea un usuario administrativo
        /// </summary>
        /// <returns>true si el usuario administrativo fue creado en el sistema, de lo contrario false.</returns>
        public bool Crear(UsuarioAdministrativo usuarioAdministrativo)
        {
            Usuario usuario = usuarioAdministrativo.Usuario;
            this.UnidadDeTrabajoLibellus.RepositorioUsuarios.Insert(usuario);
            usuarioAdministrativo.IdUsuario = usuario.Id;
            this.UnidadDeTrabajoLibellus.RepositorioUsuariosAdministrativos.Insert(usuarioAdministrativo);
            int respuesta = this.UnidadDeTrabajoLibellus.SaveChanges();
            this.EnvioCorreoElectronicoDatosAcceso(usuarioAdministrativo.Usuario);
            return respuesta > 0;
        }

        /// <summary>
        /// Edita un usuario administrativo.
        /// </summary>
        /// <param name="usuarioAdministrativo"></param>
        /// <returns>true si el usuario administrativo fue editado en el sistema, de lo contrario false.</returns>
        public bool Editar(UsuarioAdministrativo usuarioAdministrativo)
        {
            Usuario usuarioConsultado = this.UnidadDeTrabajoLibellus.RepositorioUsuarios.ConsultarUsurioPorNombreUsuario(usuarioAdministrativo.Usuario.NombreUsuario);
            Usuario usuario = usuarioAdministrativo.Usuario;
            this.UnidadDeTrabajoLibellus.RepositorioUsuarios.Update(usuario);
            this.UnidadDeTrabajoLibellus.RepositorioUsuariosAdministrativos.Update(usuarioAdministrativo);
            int respuesta = this.UnidadDeTrabajoLibellus.SaveChanges();

            if (usuarioConsultado.Identificacion != usuarioAdministrativo.Usuario.Identificacion)
            {
                this.EnvioCorreoElectronicoDatosAcceso(usuarioAdministrativo.Usuario);
            }

            return respuesta > 0;
        }

        /// <summary>
        /// COnsulta el usuario administrativo por Id.
        /// </summary>
        /// <param name="id">Identificador para la busqueda.</param>
        /// <returns>Retorma el resultado de la consulta.</returns>
        public UsuarioAdministrativo ConsultarPorId(int id)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioUsuariosAdministrativos.GetById(id);
        }

        #endregion

        #region Metodos privados

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
        /// Realiza el envio de correo electronico.
        /// </summary>
        /// <param name="usuario">Usuario para el envio de correo.</param>
        private void EnvioCorreoElectronicoDatosAcceso(Usuario usuario)
        {
            if (usuario != null && !string.IsNullOrEmpty(usuario.Correo))
            {
                string nombreApellidos = this.UnidadDeTrabajoLibellus.RepositorioUsuarios.ObtenerNombreApellidos(usuario.NombreUsuario);
                Dictionary<string, string> parametros = this.ObtenerParametrosCorreo();
                string rutaPlantillasEmail = UtilidadesApp.ObtenerRutaCompleta(String.Format("{0}/{1}", parametros[ConstantesApp.RutaPlantillaEmails], parametros[ConstantesApp.PlantillaEmailRegistroUsuario]));
                string mensajeTexto = String.Format(File.ReadAllText(rutaPlantillasEmail), nombreApellidos, usuario.NombreUsuario, EncripcionLibellus.Descifrar(usuario.Clave), Utilidades.ContextoLibellus.ObtenerColegioActual);

                UtilidadesApp.EnviarCorreoElectronico(mensajeTexto, "Registro de usuario",
                       parametros[ConstantesApp.ServidorSmtpCorreoElectronico],
                       Convert.ToInt16(parametros[ConstantesApp.PuertoSmtpCorreoElectronico]),
                       parametros[ConstantesApp.UsuarioCorreoElectronico],
                       parametros[ConstantesApp.ClaveAccesoCorreoElectronico],
                       parametros[ConstantesApp.AliasCorreoElectronico],
                       usuario.Correo);
            }
        }

        #endregion
    }
}
