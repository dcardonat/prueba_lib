namespace Libellus.Negocio.GestionAcademica
{
    using Libellus.Entidades;
    using Libellus.Mensajes;
    using Libellus.Negocio.UnidadesDeTrabajo;
    using Libellus.Utilidades;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Define las reglas de negocio para los aspectos evaluativos.
    /// </summary>
    public class NegocioAspectosEvaluativos : NegocioBase, INegocioAspectosEvaluativos
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo NegocioAspectosEvaluativos.
        /// </summary>
        public NegocioAspectosEvaluativos(IUnidadDeTrabajoLibellus unidadDeTrabajoLibellus)
        {
            this.UnidadDeTrabajoLibellus = unidadDeTrabajoLibellus;
        }

        #endregion Constructores

        #region Métodos

        /// <summary>
        /// COnsulta la información del registro.
        /// </summary>
        /// <param name="Id">Identificador del registro.</param>
        /// <returns>Retorna el resultado de la consulta.</returns>
        public AspectoEvaluativo Consultar(int Id)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioAspectosEvaluativos.GetById(Id);
        }

        /// <summary>
        /// Consulta la informacion de los aspectos evaluativos.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AspectoEvaluativo> Consultar()
        {
            return this.UnidadDeTrabajoLibellus.RepositorioAspectosEvaluativos.Get();
        }

        /// <summary>
        /// Consulta la informacion de los aspectos evaluativos.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AspectoEvaluativo> ConsultarPorSede()
        {
            return this.UnidadDeTrabajoLibellus.RepositorioAspectosEvaluativos.Consultar(Utilidades.ContextoLibellus.ObtenerSedeActual);
        }

        /// <summary>
        /// Crear el registro.
        /// </summary>
        /// <param name="aspectoEvaluativo">Aspecto evaluativo.</param>
        /// <returns>Retorna el resultado de la transacción.</returns>
        public Mensaje Crear(AspectoEvaluativo aspectoEvaluativo)
        {
            Mensaje mensajeRespuesta = null;
            aspectoEvaluativo.IdSede = Utilidades.ContextoLibellus.ObtenerSedeActual;

            try
            {
                this.UnidadDeTrabajoLibellus.RepositorioAspectosEvaluativos.Insert(aspectoEvaluativo);
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
        /// Editar el registro.
        /// </summary>
        /// <param name="aspectoEvaluativo">Aspecto evaluativo.</param>
        /// <returns>Retorna el resultado de la transacción.</returns>
        public Mensaje Editar(AspectoEvaluativo aspectoEvaluativo)
        {
            Mensaje mensajeRespuesta = null;
            aspectoEvaluativo.IdSede = Utilidades.ContextoLibellus.ObtenerSedeActual;

            try
            {
                this.UnidadDeTrabajoLibellus.RepositorioAspectosEvaluativos.Update(aspectoEvaluativo);
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
        /// Elimina el registro.
        /// </summary>
        /// <param name="id">Identificador del registro.</param>
        /// <returns>Retorna el resultado de la operación.</returns>
        public Mensaje Eliminar(int id)
        {
            Mensaje mensajeRespuesta = null;

            try
            {
                AspectoEvaluativo entidad =  this.UnidadDeTrabajoLibellus.RepositorioAspectosEvaluativos.GetById(id);
                this.UnidadDeTrabajoLibellus.RepositorioAspectosEvaluativos.Delete(entidad);
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

        #endregion
    }
}
