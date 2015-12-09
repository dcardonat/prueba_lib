namespace Libellus.Repositorio.Administracion
{
    using System.Collections.Generic;
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;

    /// <summary>
    /// Expone la persistencia con la DB de Libellus para el maestro salidas ocupacionales.
    /// </summary>
    public interface IRepositorioSalidasOcupacionales : IRepositorioBase<SalidaOcupacional>
    {
        /// <summary>
        /// Consulta las salidas ocupacionales asociadas a una sede.
        /// </summary>
        /// <param name="idSede">Identificador interno de la sede a consultar.</param>
        /// <returns>Colección con la información de las salidas ocupacionales asociadas.</returns>
        IEnumerable<SalidaOcupacional> ConsultarSalidasOcupacionalesPorSede(int idSede);
    }
}
