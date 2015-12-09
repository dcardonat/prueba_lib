namespace Libellus.Negocio.Administracion
{
    using System;
    using System.Collections.Generic;
    using Libellus.Entidades;

    /// <summary>
    /// Define la interfáz de las reglas de negocio para el maestro de asignaturas.
    /// </summary>
    public interface INegocioAsignaturas : IDisposable
    {
        /// <summary>
        /// Actualiza la asignatura.
        /// </summary>
        /// <param name="asignatura">Objeto de tipo Asignatura.</param>
        void ActualizarAsignatura(Asignatura asignatura);

        /// <summary>
        /// Almacena una asignatura.
        /// </summary>
        /// <param name="asignatura">Objeto de tipo Asignatura.</param>
        void AlmacenarAsignatura(Asignatura asignatura);

        /// <summary>
        /// Consulta la informacion de una asignatura.
        /// </summary>
        /// <param name="id">Identificador de la asignatura.</param>
        /// <returns>Objeto de tipo Asignatura.</returns>
        Asignatura ConsultarAsignatura(int id);

        /// <summary>
        /// Consulta las asignaturas registradas.
        /// </summary>
        /// <returns>Coleccion de tipo Asignatura.</returns>
        IEnumerable<Asignatura> ConsultarAsignaturas();

        /// <summary>
        /// Consulta las asignaturas registradas.
        /// </summary>
        /// <returns>Coleccion de tipo Asignatura.</returns>
        IEnumerable<Asignatura> ConsultarAsignaturasPorSede();

        /// <summary>
        /// Consulta las asignaturas pertenecientes a un area.
        /// </summary>
        /// <param name="idArea">Identificador del area a filtrar.</param>
        /// <returns>Coleccion de asignaturas filtradas por area.</returns>
        IEnumerable<Asignatura> ConsultarAsignaturasPorArea(int idArea);
    }
}