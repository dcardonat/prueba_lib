namespace Libellus.Repositorio.Administracion.Clases
{
    using Libellus.Entidades;
    using Libellus.Repositorio.Administracion.Interfaces;
    using Libellus.Repositorio.Base;
    using Libellus.Repositorio.Contextos;

    /// <summary>
    /// Define la persistencia con la DB de Libellus para la parametrización institucional.
    /// </summary>
    public class RepositorioParametrizacionInstitucional : RepositorioBase<ParametrizacionInstitucional>, IRepositorioParametrizacionInstitucional
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo RepositorioParametrizacionInstitucional con el DbContext a trabajar.
        /// </summary>
        /// <param name="contextoLibellus">DbContext a trabajar.</param>
        public RepositorioParametrizacionInstitucional(LibellusDbContext contextoLibellus)
        {
            this.ContextoLibellus = contextoLibellus;
        }

        #endregion Constructores
    }
}
