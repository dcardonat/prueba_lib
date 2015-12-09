namespace Libellus.Repositorio.Administracion
{
    using System.Collections.Generic;
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;

    /// <summary>
    /// Define la interfáz para la persistencia con la DB de Libellus para los grados por nivel.
    /// </summary>
    public interface IRepositorioGradosPorNivel : IRepositorioBase<GradosPorNivel>
    {
        /// <summary>
        /// Consulta la información de un grado asociado.
        /// </summary>
        /// <param name="idGrado">Identificador interno del grado.</param>
        /// <returns>Información del grado; de lo contrario null.</returns>
        GradosPorNivel ConsultarGrado(int idGrado);

        //// <summary>
        /// Consulta la información de los grados asociados a un nivel.
        /// </summary>
        /// <param name="idNivel">Identificador interno del nivel.</param>
        /// <returns>Información de los grado asociados por nivel.</returns>
        IEnumerable<Maestro> ConsultarGradosPorNivel(int idNivel);

        /// <summary>
        /// Consulta la información de los grados asociados a un nivel.
        /// </summary>
        /// <param name="idNivel">Identificador interno del nivel.</param>
        /// <returns>Información de los grado asociados por nivel.</returns>
        IEnumerable<GradosPorNivel> ConsultarGradosPorNivelEntidad(int idNivel);
    }
}
