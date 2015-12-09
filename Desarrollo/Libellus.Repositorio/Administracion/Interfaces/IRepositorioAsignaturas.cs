namespace Libellus.Repositorio.Administracion
{
    using System.Collections.Generic;
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;

    /// <summary>
    /// Define la interfáz para la persistencia con la DB de Libellus para el maestro de asignaturas.
    /// </summary>
    public interface IRepositorioAsignaturas : IRepositorioBase<Asignatura>
    {
        /// <summary>
        /// Consulta las asignaturas registradas.
        /// </summary>
        /// <param name="idSede">Identificador de la sede para filtrar items.</param>
        /// <returns>Coleccion de tipo Asignatura.</returns>
        IEnumerable<Asignatura> ConsultarAsignaturasPorSede(int idSede);
    }
}