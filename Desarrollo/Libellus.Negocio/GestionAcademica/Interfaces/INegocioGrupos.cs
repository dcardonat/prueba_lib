namespace Libellus.Negocio.GestionAcademica
{
    using Libellus.Entidades;
    using Libellus.Mensajes;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Define la interfáz de las reglas de negocio para los grupos.
    /// </summary>
    public interface INegocioGrupos : IDisposable
    {
        /// <summary>
        /// Consuta un grupo por id.
        /// </summary>
        /// <param name="id">Id del grupo.</param>
        /// <returns>El grupo consultado.</returns>
        Grupo Consultar(int id);

        /// <summary>
        /// obtiene el listado de grupos. 
        /// </summary>
        /// <param name="idAnioLectivo">Identificador del año lectivo.</param>
        /// <param name="idNivel">Identificador del nivel.</param>
        /// <returns>Retorna el resultado de la consulta.</returns>
        IEnumerable<Grupo> ConsultarGrupos(int idAnioLectivo, int idNivel);

        /// <summary>
        /// Almacena la información del grupo.
        /// </summary>
        /// <param name="grupo">Grupo.</param>
        /// <returns></returns>
        Mensaje GuardarGrupos(Grupo grupo);

        /// <summary>
        /// Consulta el id del grupo por grado.
        /// </summary>
        /// <param name="idGrupo">grupo seleccionado.</param>
        /// <param name="idGrado">Grado seleccionado.</param>
        /// <returns>Retorna el resultado de la consulta.</returns>
        int ConsultarGrupoPorGrado(int idGrupo, int idGrado);

        /// <summary>
        /// Asocia los estudiantes matriculados al grupo.
        /// </summary>
        /// <param name="grupos">Listado de grupos.</param>
        /// <param name="idGrado">Identificador del grado.</param>
        /// <param name="cantidadEstudiantes">Identificador del grado.</param>
        /// <returns>Retorna el resultado de la acción.</returns>
        Mensaje AsociarEstudiantesAGrupos(IList<Grupo> grupos, int idGrado, int cantidadEstudiantes);
    }
}
