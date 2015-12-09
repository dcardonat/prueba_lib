namespace Libellus.Negocio.Administracion
{
    using System;
    using Libellus.Entidades;

    /// <summary>
    /// Define la interfáz de las reglas de negocio para los datos de la apertura extemporanea de periodos.
    /// </summary>
    public interface INegocioAperturaPeriodos : IDisposable
    {
        /// <summary>
        /// Administra la informacion para gestionarla en la base de datos.
        /// </summary>
        /// <param name="aperturaPeriodo">Objeto con la informacion.</param>
        /// <returns>Retorna mensaje con el resultado de la operación.</returns>
        object[] AdministrarAperturaPeriodo(AperturaExtemporaneaPeriodo aperturaPeriodo);

        /// <summary>
        /// Consulta la informacion de la apertura de un perido.
        /// </summary>
        /// <param name="id">Identificador del periodo.</param>
        /// <returns>Información de la apertura extemporanea.</returns>
        AperturaExtemporaneaPeriodo ConsultarAperturaPeriodo(int id);
    }
}