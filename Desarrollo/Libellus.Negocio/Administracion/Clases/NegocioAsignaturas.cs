namespace Libellus.Negocio.Administracion
{
    using System.Collections.Generic;
    using Libellus.Entidades;
    using Libellus.Negocio.UnidadesDeTrabajo;
    using System.Linq;

    /// <summary>
    /// Define las reglas de negocio para el maestro de asignaturas.
    /// </summary>
    public class NegocioAsignaturas : NegocioBase, INegocioAsignaturas
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo NegocioAsignaturas.
        /// </summary>
        public NegocioAsignaturas(IUnidadDeTrabajoLibellus unidadDeTrabajoLibellus)
        {
            this.UnidadDeTrabajoLibellus = unidadDeTrabajoLibellus;
        }

        #endregion Constructores

        #region Metodos

        /// <summary>
        /// Actualiza la asignatura.
        /// </summary>
        /// <param name="asignatura">Objeto de tipo Asignatura.</param>
        public void ActualizarAsignatura(Asignatura asignatura)
        {
            asignatura.IdSede = Utilidades.ContextoLibellus.ObtenerSedeActual;
            this.UnidadDeTrabajoLibellus.RepositorioAsignaturas.Update(asignatura);
            this.UnidadDeTrabajoLibellus.SaveChanges();
        }

        /// <summary>
        /// Almacena una asignatura.
        /// </summary>
        /// <param name="asignatura">Objeto de tipo Asignatura.</param>
        public void AlmacenarAsignatura(Asignatura asignatura)
        {
            asignatura.IdSede = Utilidades.ContextoLibellus.ObtenerSedeActual;
            asignatura.Estado = true;
            this.UnidadDeTrabajoLibellus.RepositorioAsignaturas.Insert(asignatura);
            this.UnidadDeTrabajoLibellus.SaveChanges();
        }

        /// <summary>
        /// Consulta la informacion de una asignatura.
        /// </summary>
        /// <param name="id">Identificador de la asignatura.</param>
        /// <returns>Objeto de tipo Asignatura.</returns>
        public Asignatura ConsultarAsignatura(int id)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioAsignaturas.GetById(id);
        }

        /// <summary>
        /// Consulta las asignaturas registradas.
        /// </summary>
        /// <returns>Coleccion de tipo Asignatura.</returns>
        public IEnumerable<Asignatura> ConsultarAsignaturas()
        {
            return this.UnidadDeTrabajoLibellus.RepositorioAsignaturas.Get();
        }

        /// <summary>
        /// Consulta las asignaturas registradas.
        /// </summary>
        /// <returns>Coleccion de tipo Asignatura.</returns>
        public IEnumerable<Asignatura> ConsultarAsignaturasPorSede()
        {
            return this.UnidadDeTrabajoLibellus.RepositorioAsignaturas.ConsultarAsignaturasPorSede(Utilidades.ContextoLibellus.ObtenerSedeActual);
        }

        /// <summary>
        /// Consulta las asignaturas pertenecientes a un area.
        /// </summary>
        /// <param name="idArea">Identificador del area a filtrar.</param>
        /// <returns>Coleccion de asignaturas filtradas por area.</returns>
        public IEnumerable<Asignatura> ConsultarAsignaturasPorArea(int idArea)
        {
            //// TODO: DCC, Obtener la sede actual.
            var asignaturas = this.UnidadDeTrabajoLibellus.RepositorioAsignaturas.Get()
                .Where(e => e.IdMaestro == idArea)
                .Where(e => e.Estado == true)
                .Where(e=>e.IdSede == Utilidades.ContextoLibellus.ObtenerSedeActual);

            return asignaturas;
        }

        #endregion Metodos
    }
}