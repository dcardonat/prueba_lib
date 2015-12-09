namespace Libellus.Negocio.Administracion
{
    using System;
    using System.Collections.Generic;
    using Libellus.Entidades;
    using Libellus.Mensajes;

    /// <summary>
    /// Define la interfáz de las reglas de negocio para los datos del año lectivo.
    /// </summary>
    public interface INegocioAnioLectivo : IDisposable
    {
        /// <summary>
        /// Actualiza un registro de año lectivo.
        /// </summary>
        /// <param name="anioLectivo">Año lectivo a actualizar.</param>
        /// <returns>Mensaje que indica el resultado de la operación.</returns>
        Mensaje ActualizarAnioLectivo(AnioLectivo anioLectivo);

        /// <summary>
        /// Crea un registro para año lectivo.
        /// </summary>
        /// <param name="anioLectivo">Año lectivo a crear.</param>
        /// <returns>Mensaje que indica el resultado de la operación.</returns>
        Mensaje AlmacenarAnioLectivo(AnioLectivo anioLectivo);

        /// <summary>
        /// Consulta un registro de año lectivo.
        /// </summary>
        /// <param name="id">Identificador del registro.</param>
        /// <returns>Año lectivo.</returns>
        AnioLectivo ConsultarAnioLectivo(int id);

        /// <summary>
        /// Consulta el id del año actual.
        /// </summary>
        /// <param name="anio">Año actual.</param>
        /// <returns>Año lectivo.</returns>
        int ConsultarIdAnioActual(short anio);

        /// <summary>
        /// Permite consultar los años lectivos registrados.
        /// </summary>
        /// <returns>Listado de los años lectivos registrados en el sistema.</returns>
        IEnumerable<AnioLectivo> ConsultarAniosLectivos();

        /// <summary>
        /// Permite consultar los años lectivos registrados que están vigentes.
        /// </summary>
        /// <returns>Listado de años lectivos vigentes.</returns>
        IEnumerable<AnioLectivo> ConsultarAniosLectivosAbiertos();

        /// <summary>
        /// Elimina un registro de año lectivo.
        /// </summary>
        /// <param name="id">Identificador del registro.</param>
        /// <returns>Mensaje indicando el resultado de la operación.</returns>
        Mensaje EliminarAnioLectivo(int id);
    }
}