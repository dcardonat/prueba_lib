namespace Libellus.Negocio.GestionAcademica
{
    using Libellus.Entidades;
    using Libellus.Negocio.UnidadesDeTrabajo;
    using System.Collections.Generic;

    /// <summary>
    /// Define las reglas de negocio para los rango de desempeño.
    /// </summary>
    public class NegocioRangosDesempenio : NegocioBase, INegocioRangosDesempenio
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo NegocioRangosDesempenio.
        /// </summary>
        public NegocioRangosDesempenio(IUnidadDeTrabajoLibellus unidadDeTrabajoLibellus)
        {
            this.UnidadDeTrabajoLibellus = unidadDeTrabajoLibellus;
        }

        #endregion Constructores

        #region Métodos

        /// <summary>
        /// Consulta la informacion por filtros de los rangos de desempeo.
        /// </summary>
        /// <param name="anio">Año de la configuración.</param>
        /// <param name="idDesempenio">Identificador del desempeño.</param>
        /// <returns>Retorna el resultado de la consulta.</returns>
        public IEnumerable<RangosDesempenio> Consultar(int? anio, int? idDesempenio)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioRangosDesempenio.Consultar(anio, idDesempenio, Utilidades.ContextoLibellus.ObtenerSedeActual);
        }

        /// <summary>
        /// Consulta los rangos de desempeño.
        /// </summary>
        /// <returns>Coleccion de aspectos evaluativos.</returns>
        public IEnumerable<RangosDesempenio> Consultar()
        {
            return this.UnidadDeTrabajoLibellus.RepositorioRangosDesempenio.Get();
        }

        /// <summary>
        /// Metodo para la consulta por Id de rango de desempeño.
        /// </summary>
        /// <param name="IdRegistro">Identificador del registro.</param>
        /// <returns>Retorna  el resultado de la consulta.</returns>
        public RangosDesempenio Consultar(int IdRegistro)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioRangosDesempenio.GetById(IdRegistro);
        }

        /// <summary>
        /// Metodo negocio para crear los rangos de desempeño.
        /// </summary>
        /// <param name="rangoDesempenio">Rangos de desempeño.</param>
        /// <returns>Retorna el resultado de la trasaccion.</returns>
        public bool Crear(RangosDesempenio rangoDesempenio)
        {
            rangoDesempenio.IdSede = Utilidades.ContextoLibellus.ObtenerSedeActual;
            this.UnidadDeTrabajoLibellus.RepositorioRangosDesempenio.Insert(rangoDesempenio);
            return this.UnidadDeTrabajoLibellus.SaveChanges() > 0;
        }

        /// <summary>
        /// Metodo negocio para crear los rangos de desempeño.
        /// </summary>
        /// <param name="rangoDesempenio">Rangos de desempeño.</param>
        /// <returns>Retorna el resultado de la trasaccion.</returns>
        public bool Editar(RangosDesempenio rangoDesempenio)
        {
            rangoDesempenio.IdSede = Utilidades.ContextoLibellus.ObtenerSedeActual;
            this.UnidadDeTrabajoLibellus.RepositorioRangosDesempenio.Update(rangoDesempenio);
            return this.UnidadDeTrabajoLibellus.SaveChanges() > 0;
        }

        /// <summary>
        /// Administra la información de ranngos de desempeño.
        /// </summary>
        /// <param name="rangosDesempenio">Listado de rangos de desempeño.</param>
        /// <returns>Retorna el resultado de la operación.</returns> 
        public bool Administrar(List<RangosDesempenio> rangosDesempenio)
        {
            foreach (var rangoDesempenio in rangosDesempenio)
            {
                rangoDesempenio.IdSede = Utilidades.ContextoLibellus.ObtenerSedeActual;

                if (rangoDesempenio.Id > 0)
                {
                    this.UnidadDeTrabajoLibellus.RepositorioRangosDesempenio.Update(rangoDesempenio);
                }
                else
                {
                    this.UnidadDeTrabajoLibellus.RepositorioRangosDesempenio.Insert(rangoDesempenio);
                }
            }

            return this.UnidadDeTrabajoLibellus.SaveChanges() > 0;
        }

        /// <summary>
        /// Elimina los rangos de desempeño.
        /// </summary>
        /// <param name="rangosDesempenios">Rangos de desempeño a eliminar.</param>
        /// <returns>true si los rangos de desempeño fueron eliminados correctamente del sistema, de lo contrario false.</returns>
        public bool Eliminar(List<RangosDesempenio> rangosDesempenios)
        {
            rangosDesempenios.ForEach(rd => this.UnidadDeTrabajoLibellus.RepositorioRangosDesempenio.Delete(rd));
            return this.UnidadDeTrabajoLibellus.SaveChanges() > 0;
        }

        /// <summary>
        /// Consulta los rangos de desempeño.
        /// </summary>
        /// <param name="idAnio">Identificador del anio lectivo para filtrar items.</param>
        /// <returns>Coleccion de aspectos evaluativos.</returns>
        public int ConsultarCantidadRegistroPorAnio(int idAnio)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioRangosDesempenio.ConsultarCantidadRegistroPorAnio(Utilidades.ContextoLibellus.ObtenerSedeActual, idAnio);
        }

        #endregion
    }
}
