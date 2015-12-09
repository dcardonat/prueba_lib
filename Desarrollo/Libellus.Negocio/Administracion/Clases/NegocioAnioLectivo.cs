namespace Libellus.Negocio.Administracion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Libellus.Entidades;
    using Libellus.Mensajes;
    using Libellus.Negocio.UnidadesDeTrabajo;

    /// <summary>
    /// Define las reglas de negocio para los datos del año lectivo.
    /// </summary>
    public class NegocioAnioLectivo : NegocioBase, INegocioAnioLectivo
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo NegocioAnioLectivo.
        /// </summary>
        public NegocioAnioLectivo(IUnidadDeTrabajoLibellus unidadDeTrabajoLibellus)
        {
            this.UnidadDeTrabajoLibellus = unidadDeTrabajoLibellus;
        }

        #endregion Constructores

        /// <summary>
        /// Actualiza un registro de año lectivo.
        /// </summary>
        /// <param name="anioLectivo">Año lectivo a actualizar.</param>
        /// <returns>Mensaje que indica el resultado de la operación.</returns>
        public Mensaje ActualizarAnioLectivo(AnioLectivo anioLectivo)
        {
            Mensaje mensajeRespuesta = null;
            anioLectivo.Cerrado = anioLectivo.FechaCierre.HasValue;

            if (ValidacionesAnioLectivo(ref mensajeRespuesta, anioLectivo))
            {
                try
                {
                    this.UnidadDeTrabajoLibellus.RepositorioAnioLectivo.Update(anioLectivo);
                    this.UnidadDeTrabajoLibellus.SaveChanges();
                    mensajeRespuesta = new Mensaje(CodigoMensaje.Mensaje002);
                }
                catch (Exception excepcion)
                {
                    mensajeRespuesta = Utilidades.UtilidadesApp.ManejarExcepcionUniqueConstraint(excepcion);
                    if (mensajeRespuesta == null)
                    {
                        throw excepcion;
                    }
                }
            }

            return mensajeRespuesta;
        }

        /// <summary>
        /// Crea un registro para año lectivo.
        /// </summary>
        /// <param name="anioLectivo">Año lectivo a crear.</param>
        /// <returns>Mensaje que indica el resultado de la operación.</returns>
        public Mensaje AlmacenarAnioLectivo(AnioLectivo anioLectivo)
        {
            Mensaje mensajeRespuesta = null;
            anioLectivo.IdSede = Utilidades.ContextoLibellus.ObtenerSedeActual;
            anioLectivo.Cerrado = anioLectivo.FechaCierre.HasValue;

            if (ValidacionesAnioLectivo(ref mensajeRespuesta, anioLectivo))
            {
                try
                {
                    this.UnidadDeTrabajoLibellus.RepositorioAnioLectivo.Insert(anioLectivo);
                    this.UnidadDeTrabajoLibellus.SaveChanges();
                    mensajeRespuesta = new Mensaje(CodigoMensaje.Mensaje001);
                }
                catch (Exception excepcion)
                {
                    mensajeRespuesta = Utilidades.UtilidadesApp.ManejarExcepcionUniqueConstraint(excepcion);
                    if (mensajeRespuesta == null)
                    {
                        throw excepcion;
                    }
                }
            }

            return mensajeRespuesta;
        }

        /// <summary>
        /// Consulta un registro de año lectivo.
        /// </summary>
        /// <param name="id">Identificador del registro.</param>
        /// <returns>Año lectivo.</returns>
        public AnioLectivo ConsultarAnioLectivo(int id)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioAnioLectivo.GetById(id);
        }

        /// <summary>
        /// Consulta el id del año actual.
        /// </summary>
        /// <param name="anio">Año actual.</param>
        /// <returns>Año lectivo.</returns>
        public int ConsultarIdAnioActual(short anio)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioAnioLectivo.Get()
                .Where(e => Utilidades.ContextoLibellus.ObtenerSedeActual == e.IdSede && anio == e.Anio)
                .FirstOrDefault().Id;
        }

        /// <summary>
        /// Permite consultar los años lectivos registrados.
        /// </summary>
        /// <returns>Listado de los años lectivos registrados en el sistema.</returns>
        public IEnumerable<AnioLectivo> ConsultarAniosLectivos()
        {
            return this.UnidadDeTrabajoLibellus.RepositorioAnioLectivo.Get()
                .Where(e => e.IdSede == Utilidades.ContextoLibellus.ObtenerSedeActual);
        }

        /// <summary>
        /// /// Permite consultar los años lectivos registrados que están vigentes.
        /// </summary>
        /// <returns>Listado de años lectivos vigentes.</returns>
        public IEnumerable<AnioLectivo> ConsultarAniosLectivosAbiertos()
        {
            return this.UnidadDeTrabajoLibellus.RepositorioAnioLectivo.Get()
                .Where(e => e.IdSede == Utilidades.ContextoLibellus.ObtenerSedeActual && e.Cerrado == false);
        }

        /// <summary>
        /// Elimina un registro de año lectivo.
        /// </summary>
        /// <param name="id">Identificador del registro.</param>
        /// <returns>Mensaje indicando el resultado de la operación.</returns>
        public Mensaje EliminarAnioLectivo(int id)
        {
            Mensaje mensajeRespuesta = null;

            try
            {
                AnioLectivo anio = this.ConsultarAnioLectivo(id);
                if (anio.Anio < Utilidades.UtilidadesApp.ObtenerFechaActual().Year)
                {
                    mensajeRespuesta = new Mensaje(CodigoMensaje.Mensaje014);
                    return mensajeRespuesta;
                }

                this.UnidadDeTrabajoLibellus.RepositorioAnioLectivo.Delete(anio);
                this.UnidadDeTrabajoLibellus.SaveChanges();
                mensajeRespuesta = new Mensaje(CodigoMensaje.Mensaje004);
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }

            return mensajeRespuesta;
        }

        /// <summary>
        /// Realiza las validaciones para almacenar o editar un año lectivo.
        /// </summary>
        /// <param name="mensaje">Objeto para retornar el mensaje.</param>
        /// <returns>Retorna verdadero si cumple con todas las validaciones.</returns>
        private static bool ValidacionesAnioLectivo(ref Mensaje mensaje, AnioLectivo anioLectivo)
        {
            if (anioLectivo.Anio < DateTime.Now.Year)
            {
                mensaje = new Mensaje(CodigoMensaje.Mensaje029);
                return false;
            }

            if (anioLectivo.FechaInicio.Year != anioLectivo.Anio)
            {
                mensaje = new Mensaje(CodigoMensaje.Mensaje015);
                return false;
            }

            if (anioLectivo.FechaCierre.HasValue)
            {
                if (anioLectivo.FechaCierre.Value < anioLectivo.FechaInicio)
                {
                    mensaje = new Mensaje(CodigoMensaje.Mensaje016);
                    return false;
                }

                if (anioLectivo.FechaCierre.Value.Year < anioLectivo.Anio)
                {
                    mensaje = new Mensaje(CodigoMensaje.Mensaje013);
                    return false;
                }

                if (anioLectivo.FechaCierre.Value < Utilidades.UtilidadesApp.ObtenerFechaActual())
                {
                    mensaje = new Mensaje(CodigoMensaje.Mensaje017);
                    return false;
                }
            }

            return true;
        }
    }
}