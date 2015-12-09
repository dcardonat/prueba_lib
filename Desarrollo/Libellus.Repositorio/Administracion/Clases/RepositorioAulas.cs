namespace Libellus.Repositorio.Administracion
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;
    using Libellus.Repositorio.Contextos;

    /// <summary>
    /// Define la persistencia con la DB de Libellus para el maestro de Aulas.
    /// </summary>
    public class RepositorioAulas : RepositorioBase<Aula>, IRepositorioAulas
    {
        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de tipo RepositorioAulas con el DbContext a trabajar.
        /// </summary>
        /// <param name="contexto">DbContext a trabajar.</param>
        public RepositorioAulas(LibellusDbContext contexto)
        {
            this.ContextoLibellus = contexto;
        }

        #endregion Constructor

        #region Metodos

        /// <summary>
        /// Consulta las aulas.
        /// </summary>
        /// <param name="idSede">Identificador de la sede.</param>
        /// <returns>Coleccion de aulas.</returns>
        public IEnumerable<Aula> ConsultarAulasPorSede(int idSede)
        {
            return this.ContextoLibellus.Aulas.Where(c => c.IdSede == idSede);
        }

        #endregion Metodos
    }
}