namespace Libellus.Negocio.Administracion
{
    using System;
    using System.Collections.Generic;
    using Libellus.Entidades;

    public interface INegocioAulas : IDisposable
    {
        /// <summary>
        /// Actualiza el aula.
        /// </summary>
        /// <param name="aula">Objeto aula.</param>
        void ActualizarAula(Aula aula);

        /// <summary>
        /// Almacena el aula.
        /// </summary>
        /// <param name="aula">Objeto aula.</param>
        void AlmacenarAula(Aula aula);

        /// <summary>
        /// Consulta el aula.
        /// </summary>
        /// <param name="id">Identificador del aula.</param>
        /// <returns>Objeto aula.</returns>
        Aula ConsultarAula(int id);

        /// <summary>
        /// Consulta las aulas.
        /// </summary>
        /// <returns>Coleccion de aulas.</returns>
        IEnumerable<Aula> ConsultarAulas();

        /// <summary>
        /// Consulta las aulas.
        /// </summary>
        /// <param name="idSede">Identificador de la sede.</param>
        /// <returns>Coleccion de aulas.</returns>
        IEnumerable<Aula> ConsultarAulasPorSede();
    }
}