namespace Libellus.Negocio.Matriculas
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Libellus.Entidades;
    using Libellus.Negocio.UnidadesDeTrabajo;

    /// <summary>
    /// Define las reglas de negocio para la generacion de cupos.
    /// </summary>
    public class NegocioAntecedentesAcademicos : NegocioBase, INegocioAntecedentesAcademicos
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        /// <param name="unidadDeTrabajoLibellus">Unidad de trabajo.</param>
        public NegocioAntecedentesAcademicos(IUnidadDeTrabajoLibellus unidadDeTrabajoLibellus)
        {
            this.UnidadDeTrabajoLibellus = unidadDeTrabajoLibellus;
        }

        /// <summary>
        /// Consulta la informacion de un antecedente academico.
        /// </summary>
        /// <param name="id">Identificador del antecedente.</param>
        /// <returns>Entidad con la información.</returns>
        public EstudianteAntecedenteAcademico ConsultarAntecedente(int id)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioAntecedentesAcademicos.GetById(id);
        }

        /// <summary>
        /// Actualiza un antecedente académico.
        /// </summary>
        /// <param name="antecedenteAcademico">Entidad con la información.</param>
        public void ActualizarAntecedente(EstudianteAntecedenteAcademico antecedenteAcademico)
        {
            this.UnidadDeTrabajoLibellus.RepositorioAntecedentesAcademicos.Update(antecedenteAcademico);
            this.UnidadDeTrabajoLibellus.SaveChanges();
        }

        /// <summary>
        /// Almacena un antecedente académico.
        /// </summary>
        /// <param name="antecedenteAcademico">Entidad con la información.</param>
        public void AlmacenarAntecedente(EstudianteAntecedenteAcademico antecedenteAcademico)
        {
            this.UnidadDeTrabajoLibellus.RepositorioAntecedentesAcademicos.Insert(antecedenteAcademico);
            this.UnidadDeTrabajoLibellus.SaveChanges();
        }

        /// <summary>
        /// Consulta los antecedentes académicos de un estudiante.
        /// </summary>
        /// <param name="idEstudiante">Identificador del estudiante.</param>
        /// <returns>Colección de antecedentes de un estudiante.</returns>
        public IEnumerable<EstudianteAntecedenteAcademico> ConsultarAntecedentesPorEstudiante(int idEstudiante)
        {
            return from c in this.UnidadDeTrabajoLibellus.RepositorioAntecedentesAcademicos.Get()
                   where c.IdEstudiante == idEstudiante
                   select c;
        }
    }
}
