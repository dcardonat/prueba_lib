namespace Libellus.Negocio.Administracion
{
    using System;
    using System.Collections.Generic;
    using Libellus.Entidades;

    public interface INegocioIntensidadHoraria : IDisposable
    {
        /// <summary>
        /// Actualiza una instancia de la clase intensidad horaria.
        /// </summary>
        /// <param name="intensidadHoraria">Instancia de la intensidad horaria.</param>
        void ActualizarIntensidadHoraria(IntensidadHoraria intensidadHoraria);

        /// <summary>
        /// Almacena una instancia de la clase intensidad horaria.
        /// </summary>
        /// <param name="intensidadHoraria">Instancia de la intensidad horaria.</param>
        void AlmacenarIntensidadHoraria(IntensidadHoraria intensidadHoraria);

        /// <summary>
        /// Consulta una informacion particular de la intensidad horaria.
        /// </summary>
        /// <param name="id">Identificador del registro.</param>
        /// <returns>Informacion de la intensidad horaria.</returns>
        IntensidadHoraria ConsularIntensidadHoraria(int id);

        /// <summary>
        /// Consulta un listado de las intensidades horarias registradas por sede.
        /// </summary>
        /// <returns>Colección de las intensidades horarias.</returns>
        IEnumerable<IntensidadHoraria> ConsultarIntensidadesHorariasPorSede();

        /// <summary>
        /// Elimina un registro de intensidad horaria.
        /// </summary>
        /// <param name="id">Identificador del registro.</param>
        void EliminarIntensidadHoraria(int id);
    }
}