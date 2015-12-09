namespace Libellus.Repositorio.Administracion
{
    using System.Collections.Generic;
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;

    /// <summary>
    /// Define la interfáz para la persistencia con la DB de Libellus para el maestro de actividades complementarias.
    /// </summary>
    public interface IRepositorioActividadesComplementarias : IRepositorioBase<ActividadComplementaria>
    {
        /// <summary>
        /// Consulta la informacion de las actividades complementarias registradas.
        /// </summary>
        /// <param name="idSede">Identificador de la sede para consultar los items.</param>
        /// <returns>Coleccion de tipo ActividadComplementaria.</returns>
        IEnumerable<ActividadComplementaria> ConsultarActividadesComplementariasPorSede(int idSede);
    }
}