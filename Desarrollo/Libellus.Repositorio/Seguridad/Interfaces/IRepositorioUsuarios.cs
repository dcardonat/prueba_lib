namespace Libellus.Repositorio.Seguridad
{
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;
    using System.Collections.Generic;

    /// <summary>
    /// Define la interfáz para la persistencia con la DB de Libellus para los usuarios.
    /// </summary>
    public interface IRepositorioUsuarios : IRepositorioBase<Usuario>
    {
        /// <summary>
        /// Realiza la autenticacion del usuario.
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario del usuario.</param>
        /// <param name="clave">clave del usuario.</param>
        /// <returns>Retorna registro encontrado.</returns>
        bool AutenticarUsuario(string nombreUsuario, string clave);

        /// <summary>
        /// Consulta el usuario por el nombre de usuario.
        /// </summary>
        /// <param name="logIn">Login del usuario.</param>
        /// <returns>Retorna el usuario consultado.</returns>
        Usuario ConsultarUsurioPorNombreUsuario(string nombreUsuario);

        /// <summary>
        /// Valida la duplicidad del documento y tipo de documento.
        /// </summary>
        /// <param name="usuario">Usuario para la validación.</param>
        /// <returns>Retorna el resultado de la validación.</returns>
        bool ValidarDocumento(Usuario usuario);

        /// <summary>
        /// Valida que el nombre de usuario no este repetido.
        /// </summary>
        /// <param name="usuario">Usuario para la validación.</param>
        /// <returns>Retorna el resultado de la validación.</returns>
        bool ValidarNombreUsuario(Usuario usuario);

        /// <summary>
        /// Inserta el usuario.
        /// </summary>
        /// <param name="usuario">Inserta el usuario.</param>
        void InsertarUsuario(Usuario usuario);

        /// <summary>
        /// Modificar el usuario.
        /// </summary>
        /// <param name="usuario">Inserta el usuario.</param>
        void ModificarUsuario(Usuario usuario);

        /// <summary>
        /// Consulta el usuario por el id.
        /// </summary>
        /// <param name="idUsuario">Identificador del usuario.</param>
        /// <returns>Retorna el resultado de la consulta.</returns>
        Usuario ConsultarPorId(int idUsuario);

        /// <summary>
        /// Consulta el usuario por el id.
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario.</param>
        /// <returns>Retorna el resultado de la consulta.</returns>
        string ObtenerNombreApellidos(string nombreUsuario);

        /// <summary>
        /// Consulta los usuarios que cumplan con los filtros indicados.
        /// </summary>
        /// <param name="idTipoIdentificacion">Tipo de identificación del usuario.</param>
        /// <param name="identificacion">Identificación del usuario.</param>
        /// <param name="idEstado">Estado del usuario.</param>
        /// <param name="idRol">Rol del usuario.</param>
        /// <param name="sede">Sede a la que pertenece el usuario.</param>
        /// <returns>Los usuarios que cumplan con los filtros indicados.</returns>
        IEnumerable<Usuario> Consultar(int? idTipoIdentificacion, string identificacion, byte? idEstado, int? idRol, int sede);
    }
}