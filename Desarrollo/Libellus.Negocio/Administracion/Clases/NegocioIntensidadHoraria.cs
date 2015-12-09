namespace Libellus.Negocio.Administracion
{
    using System.Collections.Generic;
    using System.Linq;
    using Libellus.Entidades;
    using Libellus.Negocio.UnidadesDeTrabajo;

    public class NegocioIntensidadHoraria : NegocioBase, INegocioIntensidadHoraria
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo NegocioIntensidadHoraria.
        /// </summary>
        public NegocioIntensidadHoraria(IUnidadDeTrabajoLibellus unidadDeTrabajoLibellus)
        {
            this.UnidadDeTrabajoLibellus = unidadDeTrabajoLibellus;
        }

        #endregion Constructores

        /// <summary>
        /// Actualiza una instancia de la clase intensidad horaria.
        /// </summary>
        /// <param name="intensidadHoraria">Instancia de la intensidad horaria.</param>
        public void ActualizarIntensidadHoraria(IntensidadHoraria intensidadHoraria)
        {
            intensidadHoraria.IdSede = Utilidades.ContextoLibellus.ObtenerSedeActual;
            this.UnidadDeTrabajoLibellus.RepositorioIntensidadHoraria.Update(intensidadHoraria);
            this.UnidadDeTrabajoLibellus.SaveChanges();
        }

        /// <summary>
        /// Almacena una instancia de la clase intensidad horaria.
        /// </summary>
        /// <param name="intensidadHoraria">Instancia de la intensidad horaria.</param>
        public void AlmacenarIntensidadHoraria(IntensidadHoraria intensidadHoraria)
        {
            intensidadHoraria.IdSede = Utilidades.ContextoLibellus.ObtenerSedeActual;
            this.UnidadDeTrabajoLibellus.RepositorioIntensidadHoraria.Insert(intensidadHoraria);
            this.UnidadDeTrabajoLibellus.SaveChanges();
        }

        /// <summary>
        /// Consulta una informacion particular de la intensidad horaria.
        /// </summary>
        /// <param name="id">Identificador del registro.</param>
        /// <returns>Informacion de la intensidad horaria.</returns>
        public IntensidadHoraria ConsularIntensidadHoraria(int id)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioIntensidadHoraria.GetById(id);
        }

        /// <summary>
        /// Consulta un listado de las intensidades horarias registradas por sede.
        /// </summary>
        /// <returns>Colección de las intensidades horarias.</returns>
        public IEnumerable<IntensidadHoraria> ConsultarIntensidadesHorariasPorSede()
        {
            var query = this.UnidadDeTrabajoLibellus.RepositorioIntensidadHoraria.Get();
            return query.Where(i => i.IdSede == Utilidades.ContextoLibellus.ObtenerSedeActual);
        }

        /// <summary>
        /// Elimina un registro de intensidad horaria.
        /// </summary>
        /// <param name="id">Identificador del registro.</param>
        public void EliminarIntensidadHoraria(int id)
        {
            var intensidadHoraria = this.ConsularIntensidadHoraria(id);
            this.UnidadDeTrabajoLibellus.RepositorioIntensidadHoraria.Delete(intensidadHoraria);
            this.UnidadDeTrabajoLibellus.SaveChanges();
        }
    }
}