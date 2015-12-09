namespace Libellus.Negocio.Administracion.Clases
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Libellus.Entidades;
    using Libellus.Entidades.Enumerados;
    using Libellus.Mensajes;
    using Libellus.Negocio.Administracion.Interfaces;
    using Libellus.Negocio.UnidadesDeTrabajo;
    using Libellus.Utilidades;
    
    /// <summary>
    /// Define las reglas de negocio para la parametrización institucional.
    /// </summary>
    public class NegocioParametrizacionInstitucional : NegocioBase, INegocioParametrizacionInstitucional
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo NegocioParametrizacionInstitucional.
        /// </summary>
        public NegocioParametrizacionInstitucional(IUnidadDeTrabajoLibellus unidadDeTrabajoLibellus)
        {
            this.UnidadDeTrabajoLibellus = unidadDeTrabajoLibellus;
        }

        #endregion Constructores

        #region Métodos

        /// <summary>
        /// Consulta los horarios dependiendo del nivel educativo seleccionado.
        /// </summary>
        /// <param name="idNivelEducativo">Identificador interno del nivel educativo.</param>
        /// <returns>Si el nivel educativo es CLEI, los horarios serán Nocturna, Sabatina, Dominical; de lo contrario serán, Mañana y tarde.</returns>
        public IEnumerable<Maestro> ConsultarHorarios(int idNivelEducativo)
        {
            Maestro nivelEducativo = this.UnidadDeTrabajoLibellus.RepositorioMaestros.GetById(idNivelEducativo);
            int consecutivoNivelEducativo = nivelEducativo.Consecutivo ?? 0;

            IEnumerable<Maestro> horarios = this.UnidadDeTrabajoLibellus.RepositorioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.Horario, ContextoLibellus.ObtenerSedeActual);

            if (consecutivoNivelEducativo == ConsecutivoMaestros.GradosCleiUno.GetHashCode() ||
                consecutivoNivelEducativo == ConsecutivoMaestros.GradosCleiDos.GetHashCode() ||
                consecutivoNivelEducativo == ConsecutivoMaestros.GradosCleiTres.GetHashCode() ||
                consecutivoNivelEducativo == ConsecutivoMaestros.GradosCleiCuatro.GetHashCode() ||
                consecutivoNivelEducativo == ConsecutivoMaestros.GradosCleiCinco.GetHashCode() ||
                consecutivoNivelEducativo == ConsecutivoMaestros.GradosCleiSeis.GetHashCode() ||
                consecutivoNivelEducativo == ConsecutivoMaestros.NivelClei.GetHashCode())
            {
                horarios = from h in horarios
                           where h.Consecutivo == ConsecutivoMaestros.HorarioNocturna.GetHashCode() ||
                                 h.Consecutivo == ConsecutivoMaestros.HorarioSabatina.GetHashCode() ||
                                 h.Consecutivo == ConsecutivoMaestros.HorarioDominical.GetHashCode()
                           select h;
            }
            else
            {
                horarios = from h in horarios
                           where h.Consecutivo == ConsecutivoMaestros.HorarioManana.GetHashCode() ||
                                 h.Consecutivo == ConsecutivoMaestros.HorarioTarde.GetHashCode()
                           select h;
            }

            return horarios;
        }

        /// <summary>
        /// Consulta las parametrizaciones institucionales almacenadas en el sistema.
        /// </summary>
        /// <returns>Colección con la información de la parametrización instucional.</returns>
        public IEnumerable<ParametrizacionInstitucional> Consultar()
        {
            return this.UnidadDeTrabajoLibellus.RepositorioParametrizacionInstitucional.Get();
        }

        /// <summary>
        /// Consulta la información de una parametrización institucional por su identificador interno.
        /// </summary>
        /// <param name="idParametrizacionInstitucional">Identificador interno de la parametrización institucional a consultar.</param>
        /// <returns>Información de la parametrización institucional.</returns>
        public ParametrizacionInstitucional Consultar(int idParametrizacionInstitucional)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioParametrizacionInstitucional.GetById(idParametrizacionInstitucional);
        }

        /// <summary>
        /// Consulta los horarios dependiendo del nivel educativo seleccionado.
        /// </summary>
        /// <param name="parametrizacion">Información de la parametrización a almacenar.</param>
        /// <returns>Mensaje si la parametrización existía en base de datos; de lo contrario null.</returns>
        public Mensaje AlmacenarParametrizacionInstitucional(ParametrizacionInstitucional parametrizacion)
        {
            Mensaje mensajeRespuesta = null;

            parametrizacion.IdSede = Utilidades.ContextoLibellus.ObtenerSedeActual;
            parametrizacion.Estado = true;

            try
            {
                this.UnidadDeTrabajoLibellus.RepositorioParametrizacionInstitucional.Insert(parametrizacion);
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
        /// Actualiza la información de una parametrización institucional existente.
        /// </summary>
        /// <param name="parametrizacion">Información de la parametrización a actualizar.</param>
        /// <returns>Mensaje si la parametrización existía en base de datos; de lo contrario null.</returns>
        public Mensaje EditarParametrizacionInstitucional(ParametrizacionInstitucional parametrizacion)
        {
            Mensaje mensajeRespuesta = null;

            try
            {
                this.UnidadDeTrabajoLibellus.RepositorioParametrizacionInstitucional.Update(parametrizacion);
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
