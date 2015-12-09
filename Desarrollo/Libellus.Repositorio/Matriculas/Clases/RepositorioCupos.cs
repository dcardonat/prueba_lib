namespace Libellus.Repositorio.Matriculas
{
    using Libellus.Entidades;
    using Libellus.Entidades.Enumerados;
    using Libellus.Repositorio.Base;
    using Libellus.Repositorio.Contextos;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Define la persistencia con la DB de Libellus para los cupos.
    /// </summary>
    public class RepositorioCupos : RepositorioBase<Cupo>, IRepositorioCupos
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        /// <param name="contextoLibellus">Contexto a trabajar.</param>
        public RepositorioCupos(LibellusDbContext contextoLibellus)
        {
            this.ContextoLibellus = contextoLibellus;
        }
    }
}