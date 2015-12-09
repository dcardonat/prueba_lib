namespace Libellus.Repositorio.Administracion
{
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;

    /// <summary>
    /// Expone la persistencia con la DB de Libellus para el registro de apertura extemporanea de periodos.
    /// </summary>
    public interface IRepositorioAperturaPeriodos : IRepositorioBase<AperturaExtemporaneaPeriodo>
    {
    }
}