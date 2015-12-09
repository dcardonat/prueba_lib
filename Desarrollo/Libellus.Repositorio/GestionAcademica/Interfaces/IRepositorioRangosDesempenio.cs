namespace Libellus.Repositorio.GestionAcademica
{
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;
    using System.Collections.Generic;

    /// <summary>
    /// Define la persistencia con la DB de Libellus para los rango de desempeño.
    /// </summary>
    public interface IRepositorioRangosDesempenio : IRepositorioBase<RangosDesempenio>
    {
        /// <summary>
        /// Consulta la informacion por filtros de los rangos de desempeo.
        /// </summary>
        /// <param name="anio">Año de la configuración.</param>
        /// <param name="idDesempenio">Identificador del desempeño.</param>
        /// <param name="idSede">Identificador de la sede.</param>
        /// <returns>Retorna el resultado de la consulta.</returns>
        IEnumerable<RangosDesempenio> Consultar(int? anio, int? idDesempenio, int idSede);

        /// <summary>
        /// Consulta los rangos de desempeño.
        /// </summary>
        /// <param name="idSede">Identificador de la sede para filtrar items.</param>
        /// <returns>Coleccion de aspectos evaluativos.</returns>
        IEnumerable<RangosDesempenio> Consultar(int idSede);

        /// <summary>
        /// Consulta los rangos de desempeño.
        /// </summary>
        /// <param name="idSede">Identificador de la sede para filtrar items.</param>
        /// <param name="idAnio">Identificador del anio lectivo para filtrar items.</param>
        /// <returns>Coleccion de aspectos evaluativos.</returns>
        int ConsultarCantidadRegistroPorAnio(int idSede, int idAnio);
    }
}
