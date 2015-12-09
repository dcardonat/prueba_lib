namespace Libellus.Repositorio.Administracion
{
    using System.Collections.Generic;
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;

    /// <summary>
    /// Define la interfáz para la persistencia con la DB de Libellus para el maestro de Aulas.
    /// </summary>
    public interface IRepositorioAulas : IRepositorioBase<Aula>
    {
        /// <summary>
        /// Consulta las aulas.
        /// </summary>
        /// <param name="idSede">Identificador de la sede.</param>
        /// <returns>Coleccion de aulas.</returns>
        IEnumerable<Aula> ConsultarAulasPorSede(int idSede);
    }
}