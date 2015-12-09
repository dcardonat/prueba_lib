namespace Libellus.Negocio.Seguridad
{
    using Libellus.Entidades;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Define la interfáz de las reglas de negocio para los usuarios.
    /// </summary>
    public interface INegocioUsuarios : IDisposable
    {
        /// <summary>
        /// Realiza la autenticacion del usuario.
        /// </summary>
        /// <param name="logIn">LogIn del usuario.</param>
        /// <param name="clave">Contrasenia del usuario.</param>
        /// <returns>Retorna registro encontrado.</returns>
        bool AutenticarUsuario(string logIn, string clave);

        /// <summary>
        /// Consulta el usuario por logIn.
        /// </summary>
        /// <param name="nombreUsuario">Login del usuario.</param>
        /// <returns>Retorna el usuario consultado.</returns>
        Usuario ConsultarUsurioPorNombreUsuario(string nombreUsuario);

        /// <summary>
        /// Edita un usuario.
        /// </summary>
        /// <param name="usuario">Usuario a editar.</param>
        /// <returns>true si el usuario fue editado en el sistema, de lo contrario false.</returns>
        bool Editar(Usuario usuario);

        /// <summary>
        /// Crea un usuario.
        /// </summary>
        /// <param name="usuario">Usuario a editar.</param>
        /// <returns>true si el usuario fue creado en el sistema, de lo contrario false.</returns>
        bool Crear(Usuario usuario);

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
        /// Consulta el usuario por el id.
        /// </summary>
        /// <param name="idUsuario">Identificador del usuario.</param>
        /// <returns>Retorna el resultado de la consulta.</returns>
        Usuario ConsultarPorId(int idUsuario);

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
