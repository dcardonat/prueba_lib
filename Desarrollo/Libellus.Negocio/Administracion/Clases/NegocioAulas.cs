namespace Libellus.Negocio.Administracion
{
    using System.Collections.Generic;
    using Libellus.Entidades;
    using Libellus.Negocio.UnidadesDeTrabajo;

    /// <summary>
    /// Define las reglas de negocio para el maestro de aulas.
    /// </summary>
    public class NegocioAulas : NegocioBase, INegocioAulas
    {
        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de tipo NegocioAulas.
        /// </summary>
        public NegocioAulas(IUnidadDeTrabajoLibellus unidadDeTrabajoLibellus)
        {
            this.UnidadDeTrabajoLibellus = unidadDeTrabajoLibellus;
        }

        #endregion Constructor

        #region Metodos

        /// <summary>
        /// Actualiza el aula.
        /// </summary>
        /// <param name="aula">Objeto aula.</param>
        public void ActualizarAula(Aula aula)
        {
            aula.IdSede = Utilidades.ContextoLibellus.ObtenerSedeActual;
            this.UnidadDeTrabajoLibellus.RepositorioAulas.Update(aula);
            this.UnidadDeTrabajoLibellus.SaveChanges();
        }

        /// <summary>
        /// Almacena el aula.
        /// </summary>
        /// <param name="aula">Objeto aula.</param>
        public void AlmacenarAula(Aula aula)
        {
            aula.IdSede = Utilidades.ContextoLibellus.ObtenerSedeActual;
            aula.Estado = true;
            this.UnidadDeTrabajoLibellus.RepositorioAulas.Insert(aula);
            this.UnidadDeTrabajoLibellus.SaveChanges();
        }

        /// <summary>
        /// Consulta el aula.
        /// </summary>
        /// <param name="id">Identificador del aula.</param>
        /// <returns>Objeto aula.</returns>
        public Aula ConsultarAula(int id)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioAulas.GetById(id);
        }

        /// <summary>
        /// Consulta las aulas.
        /// </summary>
        /// <returns>Coleccion de aulas.</returns>
        public IEnumerable<Aula> ConsultarAulas()
        {
            return this.UnidadDeTrabajoLibellus.RepositorioAulas.Get();
        }

        /// <summary>
        /// Consulta las aulas.
        /// </summary>
        /// <returns>Coleccion de aulas.</returns>
        public IEnumerable<Aula> ConsultarAulasPorSede()
        {
            return this.UnidadDeTrabajoLibellus.RepositorioAulas.ConsultarAulasPorSede(Utilidades.ContextoLibellus.ObtenerSedeActual);
        }

        #endregion Metodos
    }
}