namespace Libellus.Negocio.Administracion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Libellus.Entidades;
    using Libellus.Mensajes;
    using Libellus.Negocio.UnidadesDeTrabajo;
    using Libellus.Utilidades;
    using Libellus.Entidades.Enumerados;

    /// <summary>
    /// Define las reglas de negocio para los datos de la parametrizacion escolar.
    /// </summary>
    public class NegocioParametrizacionEscolar : NegocioBase, INegocioParametrizacionEscolar
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo parametrizacion escolar.
        /// </summary>
        /// <param name="unidadDeTrabajoLibellus">Unidad de trabajo del contexto.</param>
        public NegocioParametrizacionEscolar(IUnidadDeTrabajoLibellus unidadDeTrabajoLibellus)
        {
            this.UnidadDeTrabajoLibellus = unidadDeTrabajoLibellus;
        }

        #endregion Constructores

        /// <summary>
        /// Actualiza un registro de parametrizacion escolar.
        /// </summary>
        /// <param name="parametrizacion">Entidad con la informacion para almacenar.</param>
        /// <returns>Retorna mensaje sobre el resultado de la operación.</returns>
        public Mensaje ActualizarParametrizacionEscolar(ParametrizacionEscolar parametrizacion)
        {
            Mensaje respuesta = null;

            try
            {
                parametrizacion.GradosParametrizacionSeleccionados.ForEach((i) =>
                {
                    parametrizacion.GradosParametrizacion.Add(new GradoParametrizacion() { IdGrado = i });
                });

                if (this.ValidacionesNegocio(ref respuesta, parametrizacion))
                {
                    this.UnidadDeTrabajoLibellus.RepositorioParametrizacionEscolar.Actualizar(parametrizacion);
                    this.UnidadDeTrabajoLibellus.SaveChanges();
                }
            }
            catch (Exception excepcion)
            {
                respuesta = UtilidadesApp.ManejarExcepcionUniqueConstraint(excepcion);
                if (respuesta == null)
                {
                    throw excepcion;
                }
            }

            return respuesta;
        }

        /// <summary>
        /// Consulta un registro especifico de parametrizacion anual y semestral.
        /// </summary>
        /// <param name="id">Identificador del registro.</param>
        /// <returns>Entidad con la informacion.</returns>
        public ParametrizacionEscolar ConsultarParametrizacionEscolar(int id)
        {
            var parametrizacion = this.UnidadDeTrabajoLibellus.RepositorioParametrizacionEscolar.GetById(id);
            return parametrizacion;
        }

        /// <summary>
        /// Obtiene las parametrizaciones escolares de la sede actual.
        /// </summary>
        /// <returns>Coleccion de datos de tipo ParametrizacionEscolar</returns>
        public IEnumerable<ParametrizacionEscolar> ConsultarParametrizacionesEscolaresPorSede()
        {
            var query = this.UnidadDeTrabajoLibellus.RepositorioParametrizacionEscolar.Get();
            return query.Where(p => p.AnioLectivo.IdSede == ContextoLibellus.ObtenerSedeActual);
        }

        /// <summary>
        /// Consulta la informacion de un periodo.
        /// </summary>
        /// <param name="id">Identificador del periodo.</param>
        /// <returns>Instancia del periodo.</returns>
        public PeriodoParametrizacion ConsultarPeriodo(int id)
        {
            PeriodoParametrizacion parametrizacion = (from c in this.UnidadDeTrabajoLibellus.RepositorioParametrizacionEscolar.Get()
                                                      from d in c.PeriodosParametrizacion
                                                      where d.Id.Equals(id)
                                                      select d).FirstOrDefault();

            return parametrizacion;
        }

        /// <summary>
        /// Almacena un registro de configuracion de parametrizacion escolar.
        /// </summary>
        /// <param name="parametrizacion">Entidad con la informacion para almacenar.</param>
        /// <returns>Retorna mensaje sobre el resultado de la operación.</returns>
        public Mensaje CrearParametrizacionEscolar(ParametrizacionEscolar parametrizacion)
        {
            Mensaje resultado = null;

            try
            {
                parametrizacion.GradosParametrizacionSeleccionados.ForEach((i) =>
                {
                    parametrizacion.GradosParametrizacion.Add(new GradoParametrizacion() { IdGrado = i });
                });

                if (ValidacionesNegocio(ref resultado, parametrizacion))
                {
                    this.UnidadDeTrabajoLibellus.RepositorioParametrizacionEscolar.Insert(parametrizacion);
                    this.UnidadDeTrabajoLibellus.SaveChanges();
                }
            }
            catch (Exception excepcion)
            {
                resultado = UtilidadesApp.ManejarExcepcionUniqueConstraint(excepcion);
                if (resultado == null)
                {
                    throw excepcion;
                }
            }

            return resultado;
        }

        /// <summary>
        /// Realiza las validaciones de negocio.
        /// </summary>
        /// <param name="mensaje">Mensaje de respuesta.</param>
        /// <param name="parametrizacion">Entidad con los datos a evaluar.</param>
        /// <returns>Verdadero si pasa todas las validaciones, falso si falla alguna.</returns>
        private bool ValidacionesNegocio(ref Mensaje mensaje, ParametrizacionEscolar parametrizacion)
        {
            IEnumerable<ParametrizacionEscolar> parametrizacionesBD = from c in this.ConsultarParametrizacionesEscolaresPorSede()
                                                                      where c.IdAnioLectivo == parametrizacion.IdAnioLectivo
                                                                      select c;

            Maestro tipoParametrizacion = this.UnidadDeTrabajoLibellus.RepositorioMaestros.GetById(parametrizacion.IdTipoParametrizacion);
            int consecutivoTipoParametrizacion = tipoParametrizacion.Consecutivo ?? 0;

            if (consecutivoTipoParametrizacion == ConsecutivoMaestros.Semestral.GetHashCode())
            {
                parametrizacionesBD = from c in parametrizacionesBD
                                      where c.TipoParametrizacion.Consecutivo == ConsecutivoMaestros.Anual.GetHashCode()
                                      select c;
            }

            foreach (var p in parametrizacionesBD)
            {
                if (parametrizacion.GradosParametrizacion.Any(e => p.GradosParametrizacion.Any(f => e.IdGrado == f.IdGrado)))
                {
                    mensaje = new Mensaje(CodigoMensaje.Mensaje021);
                    return false;
                }
            }

            if (!ValidarFechasPeriodo(parametrizacion))
            {
                mensaje = new Mensaje(CodigoMensaje.Mensaje020);
                return false;
            }

            if(!ValidarAño(parametrizacion))
            {
                mensaje = new Mensaje(CodigoMensaje.Mensaje022);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Valida que los años de las fechas configuradas en los periodos, sean del año de la parametrizacion.
        /// </summary>
        /// <param name="parametrizacion">Parametrizacion con los periodos.</param>
        /// <returns>Verdadero si cumple, de lo contrario false.</returns>
        private bool ValidarAño(ParametrizacionEscolar parametrizacion)
        {
            AnioLectivo anioParametrizacion = this.UnidadDeTrabajoLibellus.RepositorioAnioLectivo.GetById(parametrizacion.IdAnioLectivo);
            foreach (var periodo in parametrizacion.PeriodosParametrizacion)
            {
                int anioInicial = periodo.FechaInicial.Year;
                int anioFinal = periodo.FechaFinal.Year;

                if(anioParametrizacion.Anio != anioInicial || anioParametrizacion.Anio != anioFinal)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Valida que las fechas de los periodos no esten traspuestas.
        /// </summary>
        /// <param name="parametrizacion">Parametrizacion que contiene los periodos.</param>
        /// <returns>Verdadero si cumple, Falso si alguna fecha es incorrecta.</returns>
        private bool ValidarFechasPeriodo(ParametrizacionEscolar parametrizacion)
        {
            if (parametrizacion.PeriodosParametrizacion.Count > 1)
            {
                int index = 0;
                PeriodoParametrizacion p2;

                foreach (var p1 in parametrizacion.PeriodosParametrizacion)
                {
                    index++;
                    if (!p1.Equals(parametrizacion.PeriodosParametrizacion.ElementAt(parametrizacion.PeriodosParametrizacion.Count - 1)))
                    {
                        p2 = parametrizacion.PeriodosParametrizacion.ElementAt(index);
                        if (p1.FechaFinal >= p2.FechaInicial)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Elimina un registro de parametrizacion escolar.
        /// </summary>
        /// <param name="id">Identificador del registro.</param>
        public void Eliminar(int id)
        {
            this.UnidadDeTrabajoLibellus.RepositorioParametrizacionEscolar.Eliminar(id);
            this.UnidadDeTrabajoLibellus.SaveChanges();
        }
    }
}