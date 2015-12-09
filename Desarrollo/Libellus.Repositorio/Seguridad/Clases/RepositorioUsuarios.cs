namespace Libellus.Repositorio.Seguridad
{
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;
    using Libellus.Repositorio.Contextos;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    /// <summary>
    /// Define la persistencia con la DB de Libellus para los usuarios.
    /// </summary>
    public class RepositorioUsuarios : RepositorioBase<Usuario>, IRepositorioUsuarios
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo RepositorioMaestros con el DbContext a trabajar.
        /// </summary>
        /// <param name="contextoLibellus">DbContext a trabajar.</param>
        public RepositorioUsuarios(LibellusDbContext contextoLibellus)
        {
            this.ContextoLibellus = contextoLibellus;
        }

        #endregion Constructores

        #region Métodos

        /// <summary>
        /// Realiza la autenticacion del usuario.
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario del usuario.</param>
        /// <param name="clave">clave del usuario.</param>
        /// <returns>Retorna registro encontrado.</returns>
        public bool AutenticarUsuario(string nombreUsuario, string clave)
        {
            return this.ContextoLibellus.Usuario.Where(o => o.NombreUsuario.Equals(nombreUsuario) && o.Clave.Equals(clave)).Count() > 0;
        }

        /// <summary>
        /// Consulta el usuario por el nombre de usuario.
        /// </summary>
        /// <param name="nombreUsuario">Login del usuario.</param>
        /// <returns>Retorna el usuario consultado.</returns>
        public Usuario ConsultarUsurioPorNombreUsuario(string nombreUsuario)
        {
            return this.ContextoLibellus.Usuario.Where(x => x.NombreUsuario.Equals(nombreUsuario)).FirstOrDefault();
        }

        /// <summary>
        /// Valida la duplicidad del documento y tipo de documento.
        /// </summary>
        /// <param name="usuario">Usuario para la validación.</param>
        /// <returns>Retorna el resultado de la validación.</returns>
        public bool ValidarDocumento(Usuario usuario)
        {
            Usuario usuarioSelec = this.ContextoLibellus.Usuario.Where(x => x.IdTipoIdentificacion == usuario.IdTipoIdentificacion && x.Identificacion.Equals(usuario.Identificacion)).FirstOrDefault();

            if (usuarioSelec != null && usuario.Id != usuarioSelec.Id)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Valida que el nombre de usuario no este repetido.
        /// </summary>
        /// <param name="usuario">Usuario para la validación.</param>
        /// <returns>Retorna el resultado de la validación.</returns>
        public bool ValidarNombreUsuario(Usuario usuario)
        {
            return this.ContextoLibellus.Usuario.Where(x => x.NombreUsuario.Equals(usuario.NombreUsuario) && ((usuario.Id == 0) || (usuario.Id != x.Id))).Count() > 0;
        }

        /// <summary>
        /// Inserta el usuario.
        /// </summary>
        /// <param name="usuario">Inserta el usuario.</param>
        public void InsertarUsuario(Usuario usuario)
        {
            this.ContextoLibellus.Usuario.Add(usuario);
        }

        /// <summary>
        /// Modificar el usuario.
        /// </summary>
        /// <param name="usuario">Inserta el usuario.</param>
        public void ModificarUsuario(Usuario usuario)
        {
            this.ContextoLibellus.Entry(usuario).State = EntityState.Modified;
        }

        /// <summary>
        /// Consulta el usuario por el id.
        /// </summary>
        /// <param name="idUsuario">Identificador del usuario.</param>
        /// <returns>Retorna el resultado de la consulta.</returns>
        public Usuario ConsultarPorId(int idUsuario)
        {
            return this.ContextoLibellus.Usuario.Where(x => x.Id == idUsuario).FirstOrDefault();
        }


        /// <summary>
        /// Consulta el usuario por el id.
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario.</param>
        /// <returns>Retorna el resultado de la consulta.</returns>
        public string ObtenerNombreApellidos(string nombreUsuario)
        {
            Usuario usuario = this.ContextoLibellus.Usuario.Where(x => x.NombreUsuario == nombreUsuario).FirstOrDefault();
            string nombre = usuario.UsuariosAdministrativos.FirstOrDefault().Nombres;
            return nombre;
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
            return this.ContextoLibellus.Usuario.Where(u => (idTipoIdentificacion == null || idTipoIdentificacion == u.IdTipoIdentificacion)
                && (string.IsNullOrEmpty(identificacion) || identificacion.Equals(u.Identificacion))
                && (idEstado == null || idEstado == u.IdEstado)
                && u.UsuariosRoles.Any(ur => (idRol == null || idRol == ur.IdRol) && sede == ur.Sede.Id));
        }

        #endregion Métodos
    }
}
