namespace Libellus.Repositorio.Matriculas
{
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;
    using System.Collections.Generic;

    /// <summary>
    /// Define la interfáz para la persistencia con la DB de Libellus para los cupos.
    /// </summary>
    public interface IRepositorioCupos : IRepositorioBase<Cupo>
    {
    }
}