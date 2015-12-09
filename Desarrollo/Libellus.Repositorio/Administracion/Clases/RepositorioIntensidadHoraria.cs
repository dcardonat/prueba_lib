namespace Libellus.Repositorio.Administracion
{
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;
    using Libellus.Repositorio.Contextos;

    /// <summary>
    /// Define la persistencia con la DB de Libellus para el registro de intensidad horario.
    /// </summary>
    public class RepositorioIntensidadHoraria : RepositorioBase<IntensidadHoraria>, IRepositorioIntensidadHoraria
    {
        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de tipo RepositorioIntensidadHoraria con el DbContext a trabajar.
        /// </summary>
        /// <param name="contextoLibellus">DbContext a trabajar.</param>
        public RepositorioIntensidadHoraria(LibellusDbContext contexto)
        {
            this.ContextoLibellus = contexto;
        }

        #endregion Constructor
    }
}