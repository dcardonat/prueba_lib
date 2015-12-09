namespace Libellus.Negocio.GestionAcademica
{
    using Libellus.Entidades;
    using Libellus.Mensajes;
    using Libellus.Negocio.UnidadesDeTrabajo;
    using Libellus.Repositorio.GestionAcademica;

    /// <summary>
    /// Define las reglas de negocio para los parametros de promoción.
    /// </summary>
    public class NegocioParametrosPromocion : NegocioBase, INegocioParametrosPromocion
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo NegocioParametrosPromocion.
        /// </summary>
        public NegocioParametrosPromocion(IUnidadDeTrabajoLibellus unidadDeTrabajoLibellus)
        {
            this.UnidadDeTrabajoLibellus = unidadDeTrabajoLibellus;
        }

        #endregion Constructores

        #region Métodos

        /// <summary>
        /// Administra los parametros de promoción.
        /// </summary>
        /// <param name="parametrosPromocion">Parametros para el almacenamiento</param>
        /// <returns>Retorna el resultado de la transacción.</returns>
        public Mensaje AdministrarParametrosPromocion(ParametroPromocion parametrosPromocion)
        {
            Mensaje mensaje = null;
            parametrosPromocion.IdSede = Utilidades.ContextoLibellus.ObtenerSedeActual;

            if(parametrosPromocion.Id > 0)
            {
                this.UnidadDeTrabajoLibellus.RepositorioParametrosPromocion.Update(parametrosPromocion);
                mensaje = new Mensaje(CodigoMensaje.Mensaje002);
            }
            else
            {
                this.UnidadDeTrabajoLibellus.RepositorioParametrosPromocion.Insert(parametrosPromocion);
                mensaje = new Mensaje(CodigoMensaje.Mensaje001);
            }

            UnidadDeTrabajoLibellus.SaveChanges();

            return mensaje;
        }

        /// <summary>
        /// Consulta los parametros de promoción.
        /// </summary>
        /// <param name="anio">Parametros para la consulta</param>
        /// <returns>Retorna el resultado de la transacción.</returns>
        public ParametroPromocion ConsultarParametrosPromocion(int anio)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioParametrosPromocion.ConsultarParametrosPromocion(anio, Utilidades.ContextoLibellus.ObtenerSedeActual);
        }

        #endregion
    }
}
