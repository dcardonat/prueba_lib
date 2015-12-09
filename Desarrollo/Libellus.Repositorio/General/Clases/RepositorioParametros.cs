namespace Libellus.Repositorio.General
{
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;
    using Libellus.Repositorio.Contextos;

    /// <summary>
    /// Clase con metodos del repositorio de los parametros negocio. 
    /// </summary>
    public class RepositorioParametros : RepositorioBase<ParametrosNegocio>, IRepositorioParametros
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo RepositorioAspectosEvaluativos con el DbContext a trabajar.
        /// </summary>
        /// <param name="contextoLibellus">DbContext a trabajar.</param>
        public RepositorioParametros(LibellusDbContext contextoLibellus)
        {
            this.ContextoLibellus = contextoLibellus;
        }

        #endregion Constructores
    }
}
