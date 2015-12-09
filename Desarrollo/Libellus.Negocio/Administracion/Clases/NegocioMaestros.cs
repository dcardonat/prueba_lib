namespace Libellus.Negocio.Administracion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Libellus.Entidades;
    using Libellus.Entidades.Enumerados;
    using Libellus.Mensajes;
    using Libellus.Negocio.UnidadesDeTrabajo;
    using Libellus.Utilidades;

    /// <summary>
    /// Define las reglas de negocio para los maestros administrables.
    /// </summary>
    public class NegocioMaestros : NegocioBase, INegocioMaestros
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo NegocioMaestros.
        /// </summary>
        public NegocioMaestros(IUnidadDeTrabajoLibellus unidadDeTrabajoLibellus)
        {
            this.UnidadDeTrabajoLibellus = unidadDeTrabajoLibellus;
        }

        #endregion Constructores

        #region Métodos

        /// <summary>
        /// Consulta la información de un maestro por su id.
        /// </summary>
        /// <param name="idMaestro">Identificador interno del maestro a consultar.</param>
        /// <returns>Información del maestro consultado.</returns>
        public Maestro ConsultarMaestroPorId(int idMaestro)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioMaestros.GetById(idMaestro);
        }

        /// <summary>
        /// Consulta la información de un tipo de maestro.
        /// </summary>
        /// <param name="tipoMaestro">Tipo de maestro a consultar.</param>
        /// <param name="idSede">Identificador interno de la sede actualmente logeada.</param>
        /// <returns>Información del tipo de maestro consultada.</returns>
        public IEnumerable<Maestro> ConsultarMaestrosPorTipo(TiposMaestros tipoMaestro, int idSede)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioMaestros.ConsultarMaestrosPorTipo(tipoMaestro, idSede);
        }

        /// <summary>
        /// Consulta la información de un tipo de maestro, permitiendo filtrar por el estado de los registros.
        /// </summary>
        /// <param name="tipoMaestro">Tipo de maestro a consultar.</param>
        /// <param name="idSede">Identificador interno de la sede actualmente logeada.</param>
        /// <param name="estado">Estado de los registros del maestro.</param>
        /// <returns>Información del tipo de maestro consultada.</returns>
        public IEnumerable<Maestro> ConsultarMaestrosPorTipo(TiposMaestros tipoMaestro, int idSede, bool estado)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioMaestros.ConsultarMaestrosPorTipo(tipoMaestro, idSede).Where(o => o.Estado == estado);
        }

        /// <summary>
        /// Consulta la información de un maestro por su consecutivo.
        /// </summary>
        /// <param name="consecutivo">Consecutivo del maestro.</param>
        /// <param name="idSede">Identificador interno de la sede actualmente logeada.</param>
        /// <returns>Información del tipo de maestro consultado.</returns>
        public Maestro ConsultarMaestrosPorConsecutivo(int consecutivo, int idSede)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioMaestros.ConsultarMaestrosPorConsecutivo(consecutivo, idSede);
        }

        /// <summary>
        /// Consulta los tipos de maestro existentes.
        /// </summary>
        /// <returns>Información de los tipos de maestro existentes.</returns>
        public IEnumerable<TipoMaestro> ConsultarTipoMaestros()
        {
            return this.UnidadDeTrabajoLibellus.RepositorioMaestros.ConsultarTipoMaestros();
        }

        /// <summary>
        /// Crea un nuevo maestro en la base de datos.
        /// </summary>
        /// <param name="maestro">Información del maestro a crear.</param>
        /// <returns>Mensaje si se intenta ingresar un registro duplicado; de lo contrario null.</returns>
        public Mensaje AlmacenarMaestro(Maestro maestro)
        {
            Mensaje mensajeRespuesta = null;
            maestro.IdSede = Utilidades.ContextoLibellus.ObtenerSedeActual;
            maestro.Estado = true;

            try
            {
                this.UnidadDeTrabajoLibellus.RepositorioMaestros.Insert(maestro);
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
        /// Edita la información de un maestro en la base de datos.
        /// </summary>
        /// <param name="maestro">Información del maestro a editar.</param>
        /// <returns>Mensaje si se intenta ingresar un registro duplicado; de lo contrario null.</returns>
        public Mensaje EditarMaestro(Maestro maestro)
        {
            Mensaje mensajeRespuesta = null;

            try
            {
                this.UnidadDeTrabajoLibellus.RepositorioMaestros.Update(maestro);
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
        /// Consulta los países existentes.
        /// </summary>
        /// <returns>Colección con la información de los países.</returns>
        public IEnumerable<Pais> ConsultarPaises()
        {
            return this.UnidadDeTrabajoLibellus.RepositorioMaestros.ConsultarPaises();
        }

        /// <summary>
        /// Consulta los departamentos existentes asociados a un país.
        /// </summary>
        /// <param name="idPais">Identificador interno del país asociado a los departamentos a consultar.</param>
        /// <returns>Colección con la información de los departamentos.</returns>
        public IEnumerable<Departamento> ConsultarDepartamentos(short idPais)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioMaestros.ConsultarDepartamentos(idPais);
        }

        /// <summary>
        /// Consulta los municipios existentes asociados a un departamento.
        /// </summary>
        /// <param name="idDepartamento">Identificador interno del departamento asociado a los municipios a consultar.</param>
        /// <returns>Colección con la información de los municipios.</returns>
        public IEnumerable<Municipio> ConsultarMunicipios(short idDepartamento)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioMaestros.ConsultarMunicipios(idDepartamento);
        }

        #endregion Métodos
    }
}