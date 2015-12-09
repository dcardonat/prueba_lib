namespace Libellus.Negocio.Administracion
{
    using System.Collections.Generic;
    using Libellus.Entidades;
    using Libellus.Negocio.UnidadesDeTrabajo;

    /// <summary>
    /// Define las reglas de negocio para el maestro de actividades complementarias.
    /// </summary>
    public class NegocioActividadesComplementarias : NegocioBase, INegocioActividadesComplementarias
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo NegocioActividadesComplementarias.
        /// </summary>
        public NegocioActividadesComplementarias(IUnidadDeTrabajoLibellus unidadDeTrabajoLibellus)
        {
            this.UnidadDeTrabajoLibellus = unidadDeTrabajoLibellus;
        }

        #endregion Constructores

        #region Métodos

        /// <summary>
        /// Actualiza un registro de tipo actividad complementaria.
        /// </summary>
        /// <param name="actividadComplementaria">Objeto tipo ActividadComplementaria que se desea actualizar.</param>
        public void ActualizarActividadComplementaria(ActividadComplementaria actividadComplementaria)
        {
            actividadComplementaria.IdSede = Utilidades.ContextoLibellus.ObtenerSedeActual;
            this.UnidadDeTrabajoLibellus.RepositorioActividadesComplementarias.Update(actividadComplementaria);
            this.UnidadDeTrabajoLibellus.SaveChanges();
        }

        /// <summary>
        /// Almacena un nuevo registro de actividad complementaria en la base de datos.
        /// </summary>
        /// <param name="actividadComplementaria">Objeto de tipo actividad complementaria.</param>
        public void AlmacenarActividadComplementaria(ActividadComplementaria actividadComplementaria)
        {
            actividadComplementaria.IdSede = Utilidades.ContextoLibellus.ObtenerSedeActual;
            actividadComplementaria.Estado = true;
            this.UnidadDeTrabajoLibellus.RepositorioActividadesComplementarias.Insert(actividadComplementaria);
            this.UnidadDeTrabajoLibellus.SaveChanges();
        }

        /// <summary>
        /// Consulta una actividad complementaria en particular.
        /// </summary>
        /// <param name="id">Identificador de la actividad complementaria.</param>
        /// <returns>Objeto de tipo ActividadComplementaria.</returns>
        public ActividadComplementaria ConsultarActividadComplementaria(int id)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioActividadesComplementarias.GetById(id);
        }

        /// <summary>
        /// Consulta las actividades complementarias existentes en la base de datos.
        /// </summary>
        /// <returns>Coleccion de tipo ActividadComplementaria.</returns>
        public IEnumerable<ActividadComplementaria> ConsultarActividadesComplementarias()
        {
            return this.UnidadDeTrabajoLibellus.RepositorioActividadesComplementarias.Get();
        }

        /// <summary>
        /// Consulta las actividades complementarias.
        /// </summary>
        /// <param name="idSede">Identificador de la sede.</param>
        /// <returns>Coleccion de Actividades complementarias.</returns>
        public IEnumerable<ActividadComplementaria> ConsultarActividadesComplementariasPorSede()
        {
            return this.UnidadDeTrabajoLibellus.RepositorioActividadesComplementarias.ConsultarActividadesComplementariasPorSede(Utilidades.ContextoLibellus.ObtenerSedeActual);
        }

        #endregion Métodos
    }
}