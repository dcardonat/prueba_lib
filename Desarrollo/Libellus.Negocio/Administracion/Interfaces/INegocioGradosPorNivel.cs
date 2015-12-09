namespace Libellus.Negocio.Administracion
{
    using Libellus.Entidades;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Define la interfáz de las reglas de negocio para la administración de los grados por nivel.
    /// </summary>
    public interface INegocioGradosPorNivel : IDisposable
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
        /// <returns>Información de los grado asociados por nivel (entidad tipo GradosPorNivel).</returns>
        IEnumerable<GradosPorNivel> ConsultarGradosPorNivelEntidad(int idNivel);

        /// <summary>
        /// Elimina la información de un grado por nivel de la base de datos.
        /// <param name="idGrado">Identificador interno del grado a eliminar.</param>
        void EliminarGradosPorNivel(int idGrado);

        /// <summary>
        /// Guarda la información de un grado por nivel en la base de datos.
        /// </summary>
        /// <param name="gradoPorNivel">Información del grado por nivel a almacenar.</param>
        void GuardarGradosPorNivel(GradosPorNivel gradoPorNivel);
    }
}