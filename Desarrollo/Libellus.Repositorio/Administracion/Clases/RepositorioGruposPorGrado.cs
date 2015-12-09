namespace Libellus.Repositorio.Administracion.Clases
{
    using Libellus.Entidades;
    using Libellus.Repositorio.Administracion.Interfaces;
    using Libellus.Repositorio.Base;
    using Libellus.Repositorio.Contextos;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///  Define la persistencia con la DB de Libellus para los grupos por grado.
    /// </summary>
    public class RepositorioGruposPorGrado : RepositorioBase<GruposPorGrado>, IRepositorioGruposPorGrado
    {
         #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo RepositorioMaestros con el DbContext a trabajar.
        /// </summary>
        /// <param name="contextoLibellus">DbContext a trabajar.</param>
        public RepositorioGruposPorGrado(LibellusDbContext contextoLibellus)
        {
            this.ContextoLibellus = contextoLibellus;
        }

        #endregion Constructores

        #region Métodos públicos

        /// <summary>
        /// Consulta la información de un grupo asociado.
        /// </summary>
        /// <param name="idGrupo">Identificador interno del grupo.</param>
        /// <returns>Información del grado; de lo contrario null.</returns>
        public GruposPorGrado ConsultarGrupo(int idGrupo)
        {
            return this.ContextoLibellus.GruposPorGrado.FirstOrDefault(o => o.IdGrupo == idGrupo);
        }

        //// <summary>
        /// Consulta la información de los grupos asociados a un grado.
        /// </summary>
        /// <param name="idGrado">Identificador interno del grado.</param>
        /// <returns>Información de los grupos asociados por grado..</returns>
        public IEnumerable<Maestro> ConsultarGruposPorGrado(int idGrado)
        {
            return this.ContextoLibellus.GruposPorGrado.Where(o => o.IdGrado == idGrado).Select(o => o.Grupo);
        }

        /// <summary>
        /// Consulta la información de los grupos asociados a un grado.
        /// </summary>
        /// <param name="idGrado">Identificador interno del grado.</param>
        /// <returns>Información de los grupos asociados por grado (entidad tipo GruposPorGrado).</returns>
        public IEnumerable<GruposPorGrado> ConsultarGruposPorGradoEntidad(int idGrado)
        {
            return this.ContextoLibellus.GruposPorGrado.Where(o => o.IdGrado == idGrado);
        }

        #endregion Métodos públicos
    }
}
