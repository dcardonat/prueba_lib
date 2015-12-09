namespace Libellus.Repositorio.Administracion
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;
    using Libellus.Repositorio.Contextos;

    /// <summary>
    /// Define la persistencia con la DB de Libellus para el maestro Asignaturas.
    /// </summary>
    public class RepositorioAsignaturas : RepositorioBase<Asignatura>, IRepositorioAsignaturas
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo RepositorioMaestros con el DbContext a trabajar.
        /// </summary>
        /// <param name="contextoLibellus">DbContext a trabajar.</param>
        public RepositorioAsignaturas(LibellusDbContext contextoLibellus)
        {
            this.ContextoLibellus = contextoLibellus;
        }

        #endregion Constructores

        #region Metodos

        /// <summary>
        /// Consulta las asignaturas registradas.
        /// </summary>
        /// <param name="idSede">Identificador de la sede para filtrar items.</param>
        /// <returns>Coleccion de tipo Asignatura.</returns>
        public IEnumerable<Asignatura> ConsultarAsignaturasPorSede(int idSede)
        {
            return this.ContextoLibellus.Asignaturas.Where(c => c.IdSede == idSede);
        }

        #endregion Metodos
    }
}