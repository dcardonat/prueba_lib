namespace Libellus.Negocio.Matriculas
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Libellus.Entidades;

    /// <summary>
    /// Define la interfáz de las reglas de negocio para los antecedentes academicos.
    /// </summary>
    public interface INegocioAntecedentesAcademicos : IDisposable
    {
        /// <summary>
        /// Consulta la informacion de un antecedente academico.
        /// </summary>
        /// <param name="id">Identificador del antecedente.</param>
        /// <returns>Entidad con la información.</returns>
        EstudianteAntecedenteAcademico ConsultarAntecedente(int id);

        /// <summary>
        /// Actualiza un antecedente académico.
        /// </summary>
        /// <param name="antecedenteAcademico">Entidad con la información.</param>
        void ActualizarAntecedente(EstudianteAntecedenteAcademico antecedenteAcademico);

        /// <summary>
        /// Almacena un antecedente académico.
        /// </summary>
        /// <param name="antecedenteAcademico">Entidad con la información.</param>
        void AlmacenarAntecedente(EstudianteAntecedenteAcademico antecedenteAcademico);

        /// <summary>
        /// Consulta los antecedentes académicos de un estudiante.
        /// </summary>
        /// <param name="idEstudiante">Identificador del estudiante.</param>
        /// <returns>Colección de antecedentes de un estudiante.</returns>
        IEnumerable<EstudianteAntecedenteAcademico> ConsultarAntecedentesPorEstudiante(int idEstudiante);

    }
}
