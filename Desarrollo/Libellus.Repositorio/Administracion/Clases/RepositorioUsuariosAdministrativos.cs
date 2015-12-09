namespace Libellus.Repositorio.Administracion
{
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;
    using Libellus.Repositorio.Contextos;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///  Define la persistencia con la DB de Libellus para los usuarios administrativos.
    /// </summary>
    public class RepositorioUsuariosAdministrativos : RepositorioBase<UsuarioAdministrativo>, IRepositorioUsuariosAdministrativos
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo RepositorioUsuariosAdministrativos con el DbContext a trabajar.
        /// </summary>
        /// <param name="contextoLibellus">DbContext a trabajar.</param>
        public RepositorioUsuariosAdministrativos(LibellusDbContext contextoLibellus)
        {
            this.ContextoLibellus = contextoLibellus;
        }

        #endregion Constructores

        #region Métodos

        /// <summary>
        /// Consulta de usuarios administrativos.
        /// </summary>
        /// <param name="tipoIdentificacion">El tipo de identificación del usuario administrativo.</param>
        /// <param name="identificacion">La identificación del usuario administrativo.</param>
        /// <param name="rol">El rol del usuario administrativo.</param>
        /// <param name="cargo">El cargo del usuario administrativo.</param>
        /// <returns>La consulta de usuarios administrativos.</returns>
        public IEnumerable<UsuarioAdministrativo> Consultar(int? tipoIdentificacion, string identificacion, int? rol, int? cargo, int sede)
        {
            return this.ContextoLibellus.UsuariosAdministrativos.Where(ua => 
                (tipoIdentificacion == null || tipoIdentificacion == ua.Usuario.IdTipoIdentificacion)
                && (string.IsNullOrEmpty(identificacion) || identificacion.Equals(ua.Usuario.Identificacion))
                && (rol == null || ua.Usuario.UsuariosRoles.Where(r => rol == r.IdRol).Count() > 0)
                && (cargo == null || cargo == ua.IdCargo)
                && (ua.Usuario.UsuariosRoles.Where(r => sede == r.IdSede).Count() > 0));
        }

        #endregion
    }
}
