namespace Libellus.Negocio.Administracion
{
    using System;
    using System.Collections.Generic;
    using Libellus.Entidades;
    using Libellus.Mensajes;
    
    /// <summary>
    /// Expone las reglas de negocio para el maestro salidas ocupacionales.
    /// </summary>
    public interface INegocioSalidasOcupacionales : IDisposable
    {
        /// <summary>
        /// Consulta las salidas ocupacionales asociadas a una sede.
        /// </summary>
        /// <param name="id">Identificador interno de la salida ocupacional a consultar.</param>
        /// <returns>Información de las salidas ocupacionales asociadas.</returns>
        SalidaOcupacional ConsultarSalidaOcupacional(int id);

        /// <summary>
        /// Consulta las salidas ocupacionales asociadas a una sede.
        /// </summary>
        /// <returns>Colección con la información de las salidas ocupacionales asociadas.</returns>
        IEnumerable<SalidaOcupacional> ConsultarSalidasOcupacionalesPorSede();

        /// <summary>
        /// Consulta las salidas ocupacionales asociadas a una sede.
        /// </summary>
        /// <param name="estado">Estado activo de la salida ocupacional.</param>
        /// <returns>Colección con la información de las salidas ocupacionales asociadas que se encuentren segun el estado.</returns>
        IEnumerable<SalidaOcupacional> ConsultarSalidasOcupacionalesPorSede(bool estado);

        /// <summary>
        /// Consulta las salidas ocupacionales asociadas a una sede.
        /// </summary>
        /// <param name="salidaOcupacional">Información de la salida ocupacional a almacenar.</param>
        /// <returns>Mensaje si se intenta ingresar un registro duplicado; de lo contrario null.</returns>
        Mensaje AlmacenarSalidaOcupacional(SalidaOcupacional salidaOcupacional);

        /// <summary>
        /// Consulta las salidas ocupacionales asociadas a una sede.
        /// </summary>
        /// <param name="salidaOcupacional">Información de la salida ocupacional a actualizar.</param>
        /// <returns>Mensaje si se intenta ingresar un registro duplicado; de lo contrario null.</returns>
        Mensaje ActualizarSalidaOcupacional(SalidaOcupacional salidaOcupacional);
    }
}
