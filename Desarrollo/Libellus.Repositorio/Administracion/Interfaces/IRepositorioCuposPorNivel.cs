namespace Libellus.Repositorio.Administracion
{
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;
    using System.Collections.Generic;

    /// <summary>
    /// Define la interfáz para la persistencia con la DB de Libellus para la proyeccion de grupos por nivel.
    /// </summary>
    public interface IRepositorioCuposPorNivel : IRepositorioBase<ProyeccionCuposPorNivel>
    {
        /// <summary>
        /// Consulta la proyección de cupos por nivel.
        /// </summary>
        /// <param name="idSede">Identificador de la sede.</param>
        /// <param name="anio">Año de la proyección,</param>
        /// <returns>Retorna el resultado de la consulta.</returns>
        IEnumerable<ProyeccionCuposPorNivel> ConsultarProyeccionCuposNivel(int idSede, int anio);

        /// <summary>
        /// Consulta la proyección de cupos por nivel.
        /// </summary>
        /// <param name="idSede">Identificador de la sede.</param>
        /// <returns>Retorna el resultado de la consulta.</returns>
        IEnumerable<ProyeccionCuposPorNivel> ConsultarProyeccionCuposNivel(int idSede);

        /// <summary>
        /// Consulata la cantidad de estudiantes por grupo.
        /// </summary>
        /// <param name="idAnioLectivo">Identificador del año.</param>
        /// <param name="idSede">Identificador de la sede</param>
        /// <param name="idNivel">Idnetificador del nivel.</param>
        /// <returns>Retorna el resultado de la consulta.</returns>
        int ConsultarCantidadEstudiantesPorGrupo(int idAnioLectivo, int idSede, int idNivel);
    }
}
