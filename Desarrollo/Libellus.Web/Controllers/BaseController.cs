namespace Libellus.Web.Controllers
{
    using System;
    using System.Data.SqlClient;
    using System.Web.Mvc;
    using Libellus.Mensajes;
    using Libellus.Negocio.UnidadesDeTrabajo;
    using Libellus.Utilidades;
    using Libellus.Web.Helpers;

    /// <summary>
    /// Proporciona funcionalidades genéricas para los controllers.
    /// </summary>
    public class BaseController : Controller
    {
        #region Propiedades

        /// <summary>
        /// Expone la unidad de trabajo del DbContextTml a trabajar.
        /// </summary>
        protected IUnidadDeTrabajoLibellus UnidadDeTrabajoLibellus { get; set; }

        #endregion

        #region Constructores

        /// <summary>
        /// Inicializa una instancia de tipo BaseController que inicializa la unidad de trabajo común a todos los negocios asociados al controlador.
        /// </summary>
        public BaseController()
        {
            this.UnidadDeTrabajoLibellus = new UnidadDeTrabajoLibellus();
        }

        #endregion

        #region Métodos internos

        /// <summary>
        /// Registra de la excepción en el log de errores configurado.
        /// </summary>
        /// <param name="excepcion">Excepción a almacenar.</param>
        internal void CapturarExcepcion(Exception excepcion)
        {
            Mensaje mensajeValidacion = UtilidadesApp.CapturarExcepcion(excepcion);
            this.MostrarMensaje(mensajeValidacion);
        }

        /// <summary>
        /// Valida si la excepción generada es a causa de una violación de foreign key.
        /// </summary>
        /// <param name="excepcion">Excepción a validar.</param>
        internal Mensaje CapturarExcepcionConstraint(Exception excepcion)
        {
            Mensaje mensajeValidacion = this.ManejarExcepcionConstraint(excepcion);

            if (mensajeValidacion == null)
            {
                this.CapturarExcepcion(excepcion);
            }

            return mensajeValidacion;
        }

        #endregion

        #region Métodos privados

        /// <summary>
        /// Determina si la excepción generada fue por alguna constraint en base de datos.
        /// </summary>
        /// <param name="excepcion">Excepción a validar.</param>
        private Mensaje ManejarExcepcionConstraint(Exception excepcion)
        {
            Exception exceptionHandle = excepcion;
            SqlException excepcionSql = null;
            Mensaje mensajeExcepcion = null;

            while (exceptionHandle != null)
            {
                excepcionSql = exceptionHandle as SqlException;

                if (excepcionSql != null)
                {
                    break;
                }

                exceptionHandle = exceptionHandle.InnerException;
            }

            if (excepcionSql == null)
            {
                throw excepcion;
            }
            else
            {
                switch (excepcionSql.Number)
                {
                    case 2627:
                    case 2601:
                        mensajeExcepcion = new Mensaje(CodigoMensaje.Mensaje1008);
                        break;
                    case 547:
                        mensajeExcepcion = new Mensaje(CodigoMensaje.Mensaje1009);
                        break;
                }
            }

            return mensajeExcepcion;
        }

        #endregion
    }
}