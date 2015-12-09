namespace Libellus.Repositorio.Administracion.Interfaces
{
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Define la interfáz para la persistencia con la DB de Libellus para los grupos por grado.
    /// </summary>
    public interface IRepositorioGruposPorGrado : IRepositorioBase<GruposPorGrado>
    {
        /// <summary>
        /// Consulta la información de un grupo asociado.
        /// </summary>
        /// <param name="idGrupo">Identificador interno del grupo.</param>
        /// <returns>Información del grado; de lo contrario null.</returns>
        GruposPorGrado ConsultarGrupo(int idGrupo);

        //// <summary>
        /// Consulta la información de los grupos asociados a un grado.
        /// </summary>
        /// <param name="idGrado">Identificador interno del grado.</param>
        /// <returns>Información de los grupos asociados por grado..</returns>
        IEnumerable<Maestro> ConsultarGruposPorGrado(int idGrado);

        /// <summary>
        /// Consulta la información de los grupos asociados a un grado.
        /// </summary>
        /// <param name="idGrado">Identificador interno del grado.</param>
        /// <returns>Información de los grupos asociados por grado (entidad tipo GruposPorGrado).</returns>
        IEnumerable<GruposPorGrado> ConsultarGruposPorGradoEntidad(int idGrado);
    }
}