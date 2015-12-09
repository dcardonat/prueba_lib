namespace Libellus.Repositorio.Matriculas
{
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;
    using Libellus.Repositorio.Contextos;

    /// <summary>
    /// Define la persistencia con la DB de Libellus para los cupos.
    /// </summary>
    public class RepositorioAntecedentesAcademicos : RepositorioBase<EstudianteAntecedenteAcademico>, IRepositorioAntecedentesAcademicos
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        /// <param name="contextoLibellus">Contexto a trabajar.</param>
        public RepositorioAntecedentesAcademicos(LibellusDbContext contextoLibellus)
        {
            this.ContextoLibellus = contextoLibellus;
        }
    }
}