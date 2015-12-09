namespace Libellus.Negocio.GestionAcademica
{
    using Libellus.Entidades;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Define la interfáz de las reglas de negocio para los rango de desempeño.
    /// </summary>
    public interface INegocioRangosDesempenio : IDisposable
    {
        /// <summary>
        /// Consulta la informacion por filtros de los rangos de desempeo.
        /// </summary>
        /// <param name="anio">Año de la configuración.</param>
        /// <param name="idDesempenio">Identificador del desempeño.</param>
        /// <returns>Retorna el resultado de la consulta.</returns>
        IEnumerable<RangosDesempenio> Consultar(int? anio, int? idDesempenio);

        /// <summary>
        /// Consulta los rangos de desempeño.
        /// </summary>
        /// <returns>Coleccion de aspectos evaluativos.</returns>
        IEnumerable<RangosDesempenio> Consultar();

        /// <summary>
        /// Metodo negocio para crear los rangos de desempeño.
        /// </summary>
        /// <param name="rangoDesempenio">Rangos de desempeño.</param>
        /// <returns>Retorna el resultado de la trasaccion.</returns>
        bool Crear(RangosDesempenio rangoDesempenio);

        /// <summary>
        /// Metodo negocio para crear los rangos de desempeño.
        /// </summary>
        /// <param name="rangoDesempenio">Rangos de desempeño.</param>
        /// <returns>Retorna el resultado de la trasaccion.</returns>
        bool Editar(RangosDesempenio rangoDesempenio);

        /// <summary>
        /// Metodo para la consulta por Id de rango de desempeño.
        /// </summary>
        /// <param name="IdRegistro">Identificador del registro.</param>
        /// <returns>Retorna  el resultado de la consulta.</returns>
        RangosDesempenio Consultar(int IdRegistro);

        /// <summary>
        /// Administra la información de ranngos de desempeño.
        /// </summary>
        /// <param name="rangosDesempenio">Listado de rangos de desempeño.</param>
        /// <returns>Retorna el resultado de la operación.</returns> 
        bool Administrar(List<RangosDesempenio> rangosDesempenio);

        /// <summary>
        /// Elimina los rangos de desempeño.
        /// </summary>
        /// <param name="rangosDesempenios">Rangos de desempeño a eliminar.</param>
        /// <returns>true si los rangos de desempeño fueron eliminados correctamente del sistema, de lo contrario false.</returns>
        bool Eliminar(List<RangosDesempenio> rangosDesempenios);

        /// <summary>
        /// Consulta los rangos de desempeño.
        /// </summary>
        /// <param name="idAnio">Identificador del anio lectivo para filtrar items.</param>
        /// <returns>Coleccion de aspectos evaluativos.</returns>
        int ConsultarCantidadRegistroPorAnio(int idAnio);
    }
}
