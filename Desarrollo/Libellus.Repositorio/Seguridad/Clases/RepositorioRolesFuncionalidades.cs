namespace Libellus.Repositorio.Seguridad
{
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;
    using Libellus.Repositorio.Contextos;

    /// <summary>
    /// Define la clase para la persistencia con la DB de Libellus central para los parametros de RolesFuncionalidades.
    /// </summary>
    public class RepositorioRolesFuncionalidades : RepositorioBase<RolesFuncionalidades>, IRepositorioRolesFuncionalidades
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo RolesFuncionalidades con el DbContext a trabajar.
        /// </summary>
        /// <param name="contextoLibellus">DbContext a trabajar.</param>
        public RepositorioRolesFuncionalidades(LibellusDbContext contextoLibellus)
        {
            this.ContextoLibellus = contextoLibellus;
        }

        #endregion Constructores
    }
}
