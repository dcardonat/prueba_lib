namespace Libellus.Negocio.Administracion
{
    using Libellus.Entidades;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    ///  Define la interfáz de las reglas de negocio para la proyeccion de grupos por nivel.
    /// </summary>
    public interface INegocioCuposPorNivel : IDisposable
    {
        /// <summary>
        /// Consulta la proyección de cupos por nivel.
        /// </summary>
        /// <param name="anio">Año de la proyección,</param>
        /// <returns>Retorna el resultado de la consulta.</returns>
        IEnumerable<ProyeccionCuposPorNivel> ConsultarProyeccionCuposNivel(int anio);

        /// <summary>
        /// Consulta la proyección de cupos por nivel.
        /// </summary>
        /// <returns>Retorna el resultado de la consulta.</returns>
        IEnumerable<ProyeccionCuposPorNivel> ConsultarProyeccionCuposNivel();

        /// <summary>
        /// Crea la proyeccion de cupos por nivel.
        /// </summary>
        /// <param name="cuposPorNivel">Entidad cupos por  nivel</param>
        /// <returns>Retorna el resultado de la operacion.</returns>
        bool Crear(ProyeccionCuposPorNivel cuposPorNivel);

        /// <summary>
        /// Edita la proyeccion de cupos por nivel.
        /// </summary>
        /// <param name="cuposPorNivel">Entidad cupos por  nivel</param>
        /// <returns>Retorna el resultado de la operacion.</returns>
        bool Editar(ProyeccionCuposPorNivel cuposPorNivel);

        /// <summary>
        /// Administra la informormación de los cupos por nivel.
        /// </summary>
        /// <param name="CuposPorNivel">Entidad cupos por nivel.</param>
        /// <returns>Retorna el resultado de la operación.</returns>
        bool Administrar(List<ProyeccionCuposPorNivel> CuposPorNivel);

        /// <summary>
        /// Consulata la cantidad de estudiantes por grupo.
        /// </summary>
        /// <param name="idAnioLectivo">Identificador del año.</param>
        /// <param name="idNivel">Idnetificador del nivel.</param>
        /// <returns>Retorna el resultado de la consulta.</returns>
        int ConsultarCantidadEstudiantesPorGrupo(int idAnioLectivo, int idNivel);
    }
}
