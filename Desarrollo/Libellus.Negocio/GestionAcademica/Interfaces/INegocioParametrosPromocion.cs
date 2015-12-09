namespace Libellus.Negocio.GestionAcademica
{
    using Libellus.Entidades;
    using Libellus.Mensajes;
    using System;

    /// <summary>
    /// Define la interfáz de las reglas de negocio para los parametros de promocion.
    /// </summary>
    public interface INegocioParametrosPromocion : IDisposable
    {
        /// <summary>
        /// Administra los parametros de promoción.
        /// </summary>
        /// <param name="parametrosPromocion">Parametros para el almacenamiento</param>
        /// <returns>Retorna el resultado de la transacción.</returns>
        Mensaje AdministrarParametrosPromocion(ParametroPromocion parametrosPromocion);

        /// <summary>
        /// Consulta los parametros de promoción.
        /// </summary>
        /// <param name="anio">Parametros para la consulta</param>
        /// <returns>Retorna el resultado de la transacción.</returns>
        ParametroPromocion ConsultarParametrosPromocion(int anio);
    }
}
