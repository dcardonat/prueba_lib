namespace Libellus.Repositorio.Administracion
{
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;
    using Libellus.Repositorio.Contextos;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Define la persistencia con la DB de Libellus para la proyeccion de grupos por nivel.
    /// </summary>
    public class RepositorioCuposPorNivel : RepositorioBase<ProyeccionCuposPorNivel>, IRepositorioCuposPorNivel
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo RepositorioCuposPorNivel con el DbContext a trabajar.
        /// </summary>
        /// <param name="contextoLibellus">DbContext a trabajar.</param>
        public RepositorioCuposPorNivel(LibellusDbContext contextoLibellus)
        {
            this.ContextoLibellus = contextoLibellus;
        }

        #endregion Constructores

        #region Metodos

        /// <summary>
        /// Consulta la proyección de cupos por nivel.
        /// </summary>
        /// <param name="idSede">Identificador de la sede.</param>
        /// <param name="anio">Año de la proyección,</param>
        /// <returns>Retorna el resultado de la consulta.</returns>
        public IEnumerable<ProyeccionCuposPorNivel> ConsultarProyeccionCuposNivel(int idSede, int anio)
        {
            return this.ContextoLibellus.CuposPorNivel.Where(cn => cn.IdAnioLectivo == anio && cn.IdSede == idSede);
        }

        /// <summary>
        /// Consulta la proyección de cupos por nivel.
        /// </summary>
        /// <param name="idSede">Identificador de la sede.</param>
        /// <returns>Retorna el resultado de la consulta.</returns>
        public IEnumerable<ProyeccionCuposPorNivel> ConsultarProyeccionCuposNivel(int idSede)
        {
            return this.ContextoLibellus.CuposPorNivel.Where(cn => cn.IdSede == idSede);
        }

        /// <summary>
        /// Consulata la cantidad de estudiantes por grupo.
        /// </summary>
        /// <param name="idAnioLectivo">Identificador del año.</param>
        /// <param name="idSede">Identificador de la sede</param>
        /// <param name="idNivel">Idnetificador del nivel.</param>
        /// <returns>Retorna el resultado de la consulta.</returns>
        public int ConsultarCantidadEstudiantesPorGrupo(int idAnioLectivo, int idSede, int idNivel)
        {
            ProyeccionCuposPorNivel cupoPorNivel = this.ContextoLibellus.CuposPorNivel.Where(c => c.IdAnioLectivo == idAnioLectivo && c.IdNivel == idNivel && c.IdSede == idSede).FirstOrDefault();
            return cupoPorNivel == null ? 0 : (int)cupoPorNivel.EstudiantesGrupo;
        }

        #endregion
    }
}
