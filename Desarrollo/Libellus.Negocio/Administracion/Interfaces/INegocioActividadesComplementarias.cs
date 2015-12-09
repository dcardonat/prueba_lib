namespace Libellus.Negocio.Administracion
{
    using System;
    using System.Collections.Generic;
    using Libellus.Entidades;

    public interface INegocioActividadesComplementarias : IDisposable
    {
        /// <summary>
        /// Actualiza una actividad complementaria.
        /// </summary>
        /// <param name="actividadComplementaria">Objeto de tipo actividad complementaria.</param>
        void ActualizarActividadComplementaria(ActividadComplementaria actividadComplementaria);

        /// <summary>
        /// Almacena una actividad complementaria.
        /// </summary>
        /// <param name="actividadComplementaria">Objeto de tipo actividad complementaria.</param>
        void AlmacenarActividadComplementaria(ActividadComplementaria actividadComplementaria);

        /// <summary>
        /// Consulta la actividad complementaria.
        /// </summary>
        /// <param name="id">Identificador de la actividad.</param>
        /// <returns>Actividad complementaria.</returns>
        ActividadComplementaria ConsultarActividadComplementaria(int id);

        /// <summary>
        /// Consulta las actividades complementarias.
        /// </summary>
        /// <returns>Coleccion de Actividades complementarias.</returns>
        IEnumerable<ActividadComplementaria> ConsultarActividadesComplementarias();

        /// <summary>
        /// Consulta las actividades complementarias.
        /// </summary>
        /// <returns>Coleccion de Actividades complementarias.</returns>
        IEnumerable<ActividadComplementaria> ConsultarActividadesComplementariasPorSede();
    }
}