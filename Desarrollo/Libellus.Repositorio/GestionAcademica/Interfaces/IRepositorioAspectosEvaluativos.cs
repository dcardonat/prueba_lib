namespace Libellus.Repositorio.GestionAcademica
{
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;
    using System.Collections.Generic;

    /// <summary>
    /// Define la interfaz de la persistencia con la DB de Libellus para los aspectos evaluativos.
    /// </summary>
    public interface IRepositorioAspectosEvaluativos : IRepositorioBase<AspectoEvaluativo>
    {
        /// <summary>
        /// Consulta los aspectos evaluativos.
        /// </summary>
        /// <param name="idSede">Identificador de la sede para filtrar items.</param>
        /// <returns>Coleccion de aspectos evaluativos.</returns>
        IEnumerable<AspectoEvaluativo> Consultar(int idSede);
    }
}
