namespace Libellus.Negocio.Administracion.Interfaces
{
    using Libellus.Entidades;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Define la interfáz de las reglas de negocio para los grupos por grado.
    /// </summary>
    public interface INegocioGruposPorGrado : IDisposable
    {
        /// <summary>
        /// Consulta la información de un grupo asociado.
        /// </summary>
        /// <param name="idGrupo">Identificador interno del grupo.</param>
        /// <returns>Información del grupo; de lo contrario null.</returns>
        GruposPorGrado ConsultarGrado(int idGrupo);

        /// <summary>
        /// Consulta la información de los grupos asociados a un grado.
        /// </summary>
        /// <param name="idGrado">Identificador interno del grado.</param>
        /// <returns>Información de los grupos asociados por grado.</returns>
        IEnumerable<Maestro> ConsultarGruposPorGrado(int idGrado);

        /// <summary>
        /// Consulta la información de los grupos asociados a un grado.
        /// </summary>
        /// <param name="idGrado">Identificador interno del grado.</param>
        /// <returns>Información de los grupos asociados por grado (entidad tipo GradosPorNivel).</returns>
        IEnumerable<GruposPorGrado> ConsultarGruposPorGradoEntidad(int idGrado);

        /// <summary>
        /// Elimina la información de un grupo por grado de la base de datos.
        /// <param name="idGrado">Identificador interno del grupo a eliminar.</param>
        void EliminarGruposPorGrados(int idGrupo);

        /// <summary>
        /// Guarda la información de un grupo por grado en la base de datos.
        /// </summary>
        /// <param name="grupoPorGrado">Información del grupo por grado a almacenar.</param>
        void GuardarGruposPorGrado(GruposPorGrado grupoPorGrado);
    }
}
