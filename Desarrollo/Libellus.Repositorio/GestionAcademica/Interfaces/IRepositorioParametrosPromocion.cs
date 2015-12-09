namespace Libellus.Repositorio.GestionAcademica
{
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;

    /// <summary>
    /// Define la interfáz para la persistencia con la DB de Libellus para los parametros de promoción.
    /// </summary>
    public interface IRepositorioParametrosPromocion : IRepositorioBase<ParametroPromocion>
    {
        /// <summary>
        /// Consulta los parametros de promoción.
        /// </summary>
        /// <param name="anio">Parametros para la consulta</param>
        /// <param name="idSede">Idnetificador de la sede.</param>
        /// <returns>Retorna el resultado de la transacción.</returns>
        ParametroPromocion ConsultarParametrosPromocion(int anio, int idSede);
    }
}
