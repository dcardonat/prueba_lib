namespace Libellus.Negocio.Administracion
{
    using System.Linq;
    using Libellus.Entidades;
    using Libellus.Mensajes;
    using Libellus.Negocio.UnidadesDeTrabajo;

    /// <summary>
    /// Define las reglas de negocio para los datos de la apertura extemporanea de periodos.
    /// </summary>
    public class NegocioAperturaPeriodos : NegocioBase, INegocioAperturaPeriodos
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo NegocioAnioLectivo.
        /// </summary>
        public NegocioAperturaPeriodos(IUnidadDeTrabajoLibellus unidadDeTrabajoLibellus)
        {
            this.UnidadDeTrabajoLibellus = unidadDeTrabajoLibellus;
        }

        #endregion Constructores

        /// <summary>
        /// Administra la informacion para gestionarla en la base de datos.
        /// </summary>
        /// <param name="aperturaPeriodo">Objeto con la informacion.</param>
        /// <returns>Retorna mensaje con el resultado de la operación.</returns>
        public object[] AdministrarAperturaPeriodo(AperturaExtemporaneaPeriodo aperturaPeriodo)
        {
            Mensaje mensajeRespuesta = null;
            NegocioParametrizacionEscolar negocioParametrizacion = new NegocioParametrizacionEscolar(this.UnidadDeTrabajoLibellus);
            PeriodoParametrizacion periodo = negocioParametrizacion.ConsultarPeriodo(aperturaPeriodo.IdPeriodo);

            if (this.ValidarAperturaPeriodo(ref mensajeRespuesta, aperturaPeriodo, periodo))
            {
                if (aperturaPeriodo.Id.Equals(0))
                {
                    this.UnidadDeTrabajoLibellus.RepositorioAperturaPeriodos.Insert(aperturaPeriodo);
                    this.UnidadDeTrabajoLibellus.SaveChanges();
                    mensajeRespuesta = new Mensaje(CodigoMensaje.Mensaje001);
                }
                else
                {
                    this.UnidadDeTrabajoLibellus.RepositorioAperturaPeriodos.Update(aperturaPeriodo);
                    this.UnidadDeTrabajoLibellus.SaveChanges();
                    mensajeRespuesta = new Mensaje(CodigoMensaje.Mensaje002);
                }
            }

            object[] objetoRespuesta = new object[2];
            objetoRespuesta[0] = mensajeRespuesta;
            objetoRespuesta[1] = periodo.IdParametrizacionEscolar;

            return objetoRespuesta;
        }

        /// <summary>
        /// Consulta la informacion de la apertura de un perido.
        /// </summary>
        /// <param name="id">Identificador del periodo.</param>
        /// <returns>Información de la apertura extemporanea.</returns>
        public AperturaExtemporaneaPeriodo ConsultarAperturaPeriodo(int id)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioAperturaPeriodos.Get()
                .FirstOrDefault(e => e.IdPeriodo.Equals(id));
        }

        /// <summary>
        /// Realiza las validaciones para crear el registro de apertura extemporánea de periodos.
        /// </summary>
        /// <param name="mensaje">Mensaje de respuesta.</param>
        /// <param name="aperturaPeriodo">Informacion de la apertura.</param>
        /// <param name="periodo">Informacion del periodo.</param>
        /// <returns>Verdadero si todo esta correcto, de lo contrario retorna falso.</returns>
        private bool ValidarAperturaPeriodo(ref Mensaje mensaje, AperturaExtemporaneaPeriodo aperturaPeriodo, PeriodoParametrizacion periodo)
        {
            if (System.Math.Floor(aperturaPeriodo.FechaInicial.ToOADate()) <= System.Math.Floor(periodo.FechaFinal.ToOADate()))
            {
                mensaje = new Mensaje(CodigoMensaje.Mensaje018);
                return false;
            }

            return true;
        }
    }
}