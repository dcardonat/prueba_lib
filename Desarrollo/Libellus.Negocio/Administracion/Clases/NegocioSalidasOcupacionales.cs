namespace Libellus.Negocio.Administracion
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Libellus.Entidades;
    using Libellus.Mensajes;
    using Libellus.Negocio.UnidadesDeTrabajo;
    using Libellus.Utilidades;

    /// <summary>
    /// Define las reglas de negocio para el maestro salidas ocupacionales.
    /// </summary>
    public class NegocioSalidasOcupacionales : NegocioBase, INegocioSalidasOcupacionales
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo NegocioSalidasOcupacionales.
        /// </summary>
        public NegocioSalidasOcupacionales(IUnidadDeTrabajoLibellus unidadDeTrabajoLibellus)
        {
            this.UnidadDeTrabajoLibellus = unidadDeTrabajoLibellus;
        }

        #endregion Constructores

        #region Métodos

        /// <summary>
        /// Consulta las salidas ocupacionales asociadas a una sede.
        /// </summary>
        /// <param name="idSede">Identificador interno de la sede a consultar.</param>
        /// <returns>Colección con la información de las salidas ocupacionales asociadas.</returns>
        public IEnumerable<SalidaOcupacional> ConsultarSalidasOcupacionalesPorSede()
        {
            return this.UnidadDeTrabajoLibellus.RepositorioSalidasOcupacionales.ConsultarSalidasOcupacionalesPorSede(Utilidades.ContextoLibellus.ObtenerSedeActual);
        }

        /// <summary>
        /// Consulta las salidas ocupacionales asociadas a una sede.
        /// </summary>
        /// <param name="estado">Estado activo de la salida ocupacional.</param>
        /// <returns>Colección con la información de las salidas ocupacionales asociadas que se encuentren segun el estado.</returns>
        public IEnumerable<SalidaOcupacional> ConsultarSalidasOcupacionalesPorSede(bool estado)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioSalidasOcupacionales.ConsultarSalidasOcupacionalesPorSede(Utilidades.ContextoLibellus.ObtenerSedeActual)
                .Where(e=> e.Estado == estado);
        }

        /// <summary>
        /// Consulta las salidas ocupacionales asociadas a una sede.
        /// </summary>
        /// <param name="id">Identificador interno de la salida ocupacional a consultar.</param>
        /// <returns>Información de las salidas ocupacionales asociadas.</returns>
        public SalidaOcupacional ConsultarSalidaOcupacional(int id)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioSalidasOcupacionales.GetById(id);
        }

        /// <summary>
        /// Consulta las salidas ocupacionales asociadas a una sede.
        /// </summary>
        /// <param name="salidaOcupacional">Información de la salida ocupacional a almacenar.</param>
        /// <returns>Mensaje si se intenta ingresar un registro duplicado; de lo contrario null.</returns>
        public Mensaje AlmacenarSalidaOcupacional(SalidaOcupacional salidaOcupacional)
        {
            Mensaje mensajeRespuesta = null;

            salidaOcupacional.IdSede = Utilidades.ContextoLibellus.ObtenerSedeActual;
            salidaOcupacional.Estado = true;

            try
            {
                this.UnidadDeTrabajoLibellus.RepositorioSalidasOcupacionales.Insert(salidaOcupacional);
                this.UnidadDeTrabajoLibellus.SaveChanges();
            }
            catch (Exception excepcion)
            {
                mensajeRespuesta = UtilidadesApp.ManejarExcepcionUniqueConstraint(excepcion);

                if (mensajeRespuesta == null)
                {
                    throw excepcion;
                }
            }

            return mensajeRespuesta;
        }

        /// <summary>
        /// Consulta las salidas ocupacionales asociadas a una sede.
        /// </summary>
        /// <param name="salidaOcupacional">Información de la salida ocupacional a actualizar.</param>
        /// <returns>Mensaje si se intenta ingresar un registro duplicado; de lo contrario null.</returns>
        public Mensaje ActualizarSalidaOcupacional(SalidaOcupacional salidaOcupacional)
        {
            Mensaje mensajeRespuesta = null;

            try
            {
                this.UnidadDeTrabajoLibellus.RepositorioSalidasOcupacionales.Update(salidaOcupacional);
                this.UnidadDeTrabajoLibellus.SaveChanges();
            }
            catch (Exception excepcion)
            {
                mensajeRespuesta = UtilidadesApp.ManejarExcepcionUniqueConstraint(excepcion);

                if (mensajeRespuesta == null)
                {
                    throw excepcion;
                }
            }

            return mensajeRespuesta;
        }

        #endregion Métodos
    }
}
