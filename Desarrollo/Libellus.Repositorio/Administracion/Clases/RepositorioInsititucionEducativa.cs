namespace Libellus.Repositorio.Administracion
{
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;
    using Libellus.Repositorio.Contextos;

    /// <summary>
    /// Define la persistencia con la DB de Libellus para los datos de Institucion educativa.
    /// </summary>
    public class RepositorioInsititucionEducativa : RepositorioBase<InstitucionEducativa>, IRepositorioInstitucionEducativa
    {
        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de tipo RepositorioInsititucionEducativa con el DbContext a trabajar.
        /// </summary>
        /// <param name="contexto">DbContext a trabajar.</param>
        public RepositorioInsititucionEducativa(LibellusDbContext contexto)
        {
            this.ContextoLibellus = contexto;
        }

        #endregion Constructor

        /// <summary>
        /// Elimina un registro de legalización.
        /// </summary>
        /// <param name="registro">Entidad de tipo Registro.</param>
        public void EliminarRegistroLegalizacion(RegistroLegalizacion registro)
        {
            this.ContextoLibellus.Entry(registro).State = System.Data.Entity.EntityState.Deleted;
        }
    }
}