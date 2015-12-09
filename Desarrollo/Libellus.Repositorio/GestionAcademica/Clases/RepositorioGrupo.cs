namespace Libellus.Repositorio.GestionAcademica.Clases
{
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;
    using Libellus.Repositorio.Contextos;
    using Libellus.Repositorio.GestionAcademica.Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Define la persistencia con la DB de Libellus para los estudiantes por grupo.
    /// </summary>
    public class RepositorioGrupo : RepositorioBase<Grupo>, IRepositorioGrupo
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo RepositorioEstudiantesPorGrupo con el DbContext a trabajar.
        /// </summary>
        /// <param name="contextoLibellus">DbContext a trabajar.</param>
        public RepositorioGrupo(LibellusDbContext contextoLibellus)
        {
            this.ContextoLibellus = contextoLibellus;
        }

        #endregion Constructores

        #region Metodos

        /// <summary>
        /// obtiene el listado de grupos. 
        /// </summary>
        /// <param name="idAnioLectivo">Identificador del año lectivo.</param>
        /// <param name="idNivel">Identificador del nivel.</param>
        /// <returns>Retorna el resultado de la consulta.</returns>
        public IEnumerable<Grupo> ConsultarGrupos(int idAnioLectivo, int idNivel)
        {
            return this.ContextoLibellus.Grupos.Where(g => g.IdAnioLectivo == idAnioLectivo && g.GruposPorGrado.Grado.Grados.Any(x=> x.IdNivel == idNivel));
        }

        /// <summary>
        /// Consulta el identificador del grupo por grado.
        /// </summary>
        /// <param name="idGrupo">Identificador del grupo.</param>
        /// <param name="idGrado">Identificador del grado.</param>
        /// <returns>Retorna el resultado  de  la consulta.</returns>
        public int ConsultarGrupoPorGrado(int idGrupo, int idGrado)
        {
            return this.ContextoLibellus.GruposPorGrado.Where(g => g.IdGrupo == idGrupo && g.IdGrado == idGrado).FirstOrDefault().Id;
        }

        #endregion
    }
}
