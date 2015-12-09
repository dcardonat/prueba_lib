namespace Libellus.Repositorio.GestionAcademica.Interfaces
{
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;
    using System.Collections.Generic;

    /// <summary>
    /// Define la interfaz de la persistencia con la DB de Libellus para los grupos.
    /// </summary>
    public interface IRepositorioGrupo : IRepositorioBase<Grupo>
    {
        /// <summary>
        /// obtiene el listado de grupos. 
        /// </summary>
        /// <param name="idAnioLectivo">Identificador del año lectivo.</param>
        /// <param name="idNivel">Identificador del nivel.</param>
        /// <returns>Retorna el resultado de la consulta.</returns>
        IEnumerable<Grupo> ConsultarGrupos(int idAnioLectivo, int idNivel);

        /// <summary>
        /// Consulta el identificador del grupo por grado.
        /// </summary>
        /// <param name="idGrupo">Identificador del grupo.</param>
        /// <param name="idGrado">Identificador del grado.</param>
        /// <returns>Retorna el resultado  de  la consulta.</returns>
        int ConsultarGrupoPorGrado(int idGrupo, int idGrado);
    }
}
