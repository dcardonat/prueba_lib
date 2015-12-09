namespace Libellus.Repositorio.GestionAcademica
{
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;
    using Libellus.Repositorio.Contextos;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Define la persistencia con la DB de Libellus para los rango de desempeño.
    /// </summary>
    public class RepositorioRangosDesempenio : RepositorioBase<RangosDesempenio>, IRepositorioRangosDesempenio
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo RepositorioRangosDesempenio con el DbContext a trabajar.
        /// </summary>
        /// <param name="contextoLibellus">DbContext a trabajar.</param>
        public RepositorioRangosDesempenio(LibellusDbContext contextoLibellus)
        {
            this.ContextoLibellus = contextoLibellus;
        }

        #endregion Constructores

        #region Metodos

        /// <summary>
        /// Consulta la informacion por filtros de los rangos de desempeo.
        /// </summary>
        /// <param name="anio">Año de la configuración.</param>
        /// <param name="idDesempenio">Identificador del desempeño.</param>
        /// <param name="idSede">Identificador de la sede.</param>
        /// <returns>Retorna el resultado de la consulta.</returns>
        public IEnumerable<RangosDesempenio> Consultar(int? anio, int? idDesempenio, int idSede)
        {
            return this.ContextoLibellus.RangosDesempenio.Where(rd => (anio == null || anio == rd.IdAnioLectivo)
                && (idDesempenio == null || idDesempenio == rd.IdDesempenio)
                && rd.IdSede == idSede);
        }

        /// <summary>
        /// Consulta los rangos de desempeño.
        /// </summary>
        /// <param name="idSede">Identificador de la sede para filtrar items.</param>
        /// <returns>Coleccion de aspectos evaluativos.</returns>
        public IEnumerable<RangosDesempenio> Consultar(int idSede)
        {
            return this.ContextoLibellus.RangosDesempenio.Where(c => c.IdSede == idSede);
        }

        /// <summary>
        /// Consulta los rangos de desempeño.
        /// </summary>
        /// <param name="idSede">Identificador de la sede para filtrar items.</param>
        /// <param name="idAnio">Identificador del anio lectivo para filtrar items.</param>
        /// <returns>Coleccion de aspectos evaluativos.</returns>
        public int ConsultarCantidadRegistroPorAnio(int idSede, int idAnio)
        {
            return this.ContextoLibellus.RangosDesempenio.Where(c => c.IdSede == idSede && c.IdAnioLectivo == idAnio).Count();
        }

        #endregion
    }
}
