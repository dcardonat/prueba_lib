namespace Libellus.Repositorio.Administracion
{
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;
    using Libellus.Repositorio.Contextos;

    /// <summary>
    /// Define la persistencia con la DB de Libellus para los datos del año lectivo.
    /// </summary>
    public class RepositorioAnioLectivo : RepositorioBase<AnioLectivo>, IRepositorioAnioLectivo
    {
        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de tipo RepositorioAnioLectivo con el DbContext a trabajar.
        /// </summary>
        /// <param name="contexto">DbContext a trabajar.</param>
        public RepositorioAnioLectivo(LibellusDbContext contexto)
        {
            this.ContextoLibellus = contexto;
        }

        #endregion Constructor
    }
}