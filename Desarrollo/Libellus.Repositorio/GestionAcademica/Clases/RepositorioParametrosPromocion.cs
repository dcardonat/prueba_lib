namespace Libellus.Repositorio.GestionAcademica
{
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;
    using Libellus.Repositorio.Contextos;
    using System.Linq;

    /// <summary>
    /// Define la persistencia con la DB de Libellus para los parametros de promoción.
    /// </summary>
    public class RepositorioParametrosPromocion : RepositorioBase<ParametroPromocion>, IRepositorioParametrosPromocion
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo RepositorioAspectosEvaluativos con el DbContext a trabajar.
        /// </summary>
        /// <param name="contextoLibellus">DbContext a trabajar.</param>
        public RepositorioParametrosPromocion(LibellusDbContext contextoLibellus)
        {
            this.ContextoLibellus = contextoLibellus;
        }

        #endregion Constructores

        #region Metodos

        /// <summary>
        /// Administra los parametros de promoción.
        /// </summary>
        /// <param name="parametrosPromocion">Parametros para el almacenamiento</param>
        /// <returns>Retorna el resultado de la transacción.</returns>
        public bool AdministrarParametrosPromocion(ParametroPromocion parametrosPromocion)
        {
            return true;
        }

        /// <summary>
        /// Consulta los parametros de promoción.
        /// </summary>
        /// <param name="anio">Parametros para la consulta</param>
        /// <param name="idSede">Idnetificador de la sede.</param>
        /// <returns>Retorna el resultado de la transacción.</returns>
        public ParametroPromocion ConsultarParametrosPromocion(int anio, int idSede)
        {
            return this.ContextoLibellus.ParametrosPromocion.Where(x => x.IdSede == idSede && x.IdAnioLectivo == anio).FirstOrDefault();
        }

        #endregion
    }
}
