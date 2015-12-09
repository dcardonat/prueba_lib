namespace Libellus.Repositorio.Administracion
{
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;
    using System.Collections.Generic;

    /// <summary>
    /// Define la interfáz para la persistencia con la DB de Libellus para los usuarios administrativos.
    /// </summary>
    public interface IRepositorioUsuariosAdministrativos : IRepositorioBase<UsuarioAdministrativo>
    {
        /// <summary>
        /// Consulta de usuarios administrativos.
        /// </summary>
        /// <param name="tipoIdentificacion">El tipo de identificación del usuario administrativo.</param>
        /// <param name="identificacion">La identificación del usuario administrativo.</param>
        /// <param name="rol">El rol del usuario administrativo.</param>
        /// <param name="cargo">El cargo del usuario administrativo.</param>
        /// <returns>La consulta de usuarios administrativos.</returns>
        IEnumerable<UsuarioAdministrativo> Consultar(int? tipoIdentificacion, string identificacion, int? rol, int? cargo, int sede);
    }
}
