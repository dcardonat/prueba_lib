namespace Libellus.Repositorio.Administracion
{
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;
    using Libellus.Repositorio.Contextos;

    /// <summary>
    /// Define la persistencia con la DB de Libellus para los datos de la apertura extemporanea de periodos.
    /// </summary>
    public class RepositorioAperturaPeriodos : RepositorioBase<AperturaExtemporaneaPeriodo>, IRepositorioAperturaPeriodos
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo RepositorioAperturaPeriodos con el DbContext a trabajar.
        /// </summary>
        /// <param name="contextoLibellus">DbContext a trabajar.</param>
        public RepositorioAperturaPeriodos(LibellusDbContext contextoLibellus)
        {
            this.ContextoLibellus = contextoLibellus;
        }

        #endregion Constructores
    }
}