namespace Libellus.Repositorio.Administracion
{
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;

    /// <summary>
    /// Define la interfáz para la persistencia con la DB de Libellus para la institucion educativa.
    /// </summary>
    public interface IRepositorioInstitucionEducativa : IRepositorioBase<InstitucionEducativa>
    {
        /// <summary>
        /// Elimina un registro de legalización.
        /// </summary>
        /// <param name="registro">Entidad de tipo Registro.</param>
        void EliminarRegistroLegalizacion(RegistroLegalizacion registro);
    }
}