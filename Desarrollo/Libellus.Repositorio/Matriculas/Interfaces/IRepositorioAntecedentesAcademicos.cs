namespace Libellus.Repositorio.Matriculas
{
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;

    /// <summary>
    /// Define la interfáz para la persistencia con la DB de Libellus para los antecedentes académicos.
    /// </summary>
    public interface IRepositorioAntecedentesAcademicos : IRepositorioBase<EstudianteAntecedenteAcademico>
    {
    }
}