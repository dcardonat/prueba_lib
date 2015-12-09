namespace Libellus.Negocio.Administracion
{
    using Libellus.Entidades;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Define la interfáz de las reglas de negocio para los usuarios administrativos.
    /// </summary>
    public interface INegocioUsuariosAdministrativos : IDisposable
    {
        /// <summary>
        /// Consulta de usuarios administrativos por id.
        /// </summary>
        /// <param name="id">Id del usuario administrativo a consultar.</param>
        /// <returns>El usuario administrativo.</returns>
        UsuarioAdministrativo Consultar(int id);

        /// <summary>
        /// Consulta de usuarios administrativos.
        /// </summary>
        /// <param name="tipoIdentificacion">El tipo de identificación del usuario administrativo.</param>
        /// <param name="identificacion">La identificación del usuario administrativo.</param>
        /// <param name="rol">El rol del usuario administrativo.</param>
        /// <param name="cargo">El cargo del usuario administrativo.</param>
        /// <returns>La consulta de usuarios administrativos.</returns>
        IEnumerable<UsuarioAdministrativo> Consultar(int? tipoIdentificacion, string identificacion, int? rol, int? cargo);

        /// <summary>
        /// Crea un usuario administrativo.
        /// </summary>
        /// <returns>true si el usuario administrativo fue creado en el sistema, de lo contrario false.</returns>
        bool Crear(UsuarioAdministrativo usuarioAdministrativo);

        /// <summary>
        /// Edita un usuario administrativo.
        /// </summary>
        /// <param name="usuarioAdministrativo"></param>
        /// <returns>true si el usuario administrativo fue editado en el sistema, de lo contrario false.</returns>
        bool Editar(UsuarioAdministrativo usuarioAdministrativo);

        /// <summary>
        /// COnsulta el usuario administrativo por Id.
        /// </summary>
        /// <param name="id">Identificador para la busqueda.</param>
        /// <returns>Retorma el resultado de la consulta.</returns>
        UsuarioAdministrativo ConsultarPorId(int id);
    }
}
