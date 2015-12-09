namespace Libellus.Repositorio.GestionAcademica
{
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;
    using Libellus.Repositorio.Contextos;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Define la persistencia con la DB de Libellus para los aspectos evaluativos.
    /// </summary>
    public class RepositorioAspectosEvaluativos : RepositorioBase<AspectoEvaluativo>, IRepositorioAspectosEvaluativos
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo RepositorioAspectosEvaluativos con el DbContext a trabajar.
        /// </summary>
        /// <param name="contextoLibellus">DbContext a trabajar.</param>
        public RepositorioAspectosEvaluativos(LibellusDbContext contextoLibellus)
        {
            this.ContextoLibellus = contextoLibellus;
        }

        #endregion Constructores

        #region Metodos

        /// <summary>
        /// Consulta los aspectos evaluativos.
        /// </summary>
        /// <param name="idSede">Identificador de la sede para filtrar items.</param>
        /// <returns>Coleccion de aspectos evaluativos.</returns>
        public IEnumerable<AspectoEvaluativo> Consultar(int idSede)
        {
            return this.ContextoLibellus.AspectosEvaluativos.Where(c => c.IdSede == idSede);
        }

        #endregion
    }
}
