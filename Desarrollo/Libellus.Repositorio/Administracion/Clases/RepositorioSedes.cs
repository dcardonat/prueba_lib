namespace Libellus.Repositorio.Administracion
{
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;
    using Libellus.Repositorio.Contextos;

    /// <summary>
    /// Define la persistencia con la DB de Libellus para las sedes.
    /// </summary>
    public class RepositorioSedes : RepositorioBase<Sede>, IRepositorioSedes
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo RepositorioMaestros con el DbContext a trabajar.
        /// </summary>
        /// <param name="contextoLibellus">DbContext a trabajar.</param>
        public RepositorioSedes(LibellusDbContext contextoLibellus)
        {
            this.ContextoLibellus = contextoLibellus;
        }

        #endregion Constructores

        # region Metodos

        /// <summary>
        /// Consulta la información de las sedes por el usuario.
        /// </summary>
        /// <param name="usuario">Usuario para la consulta.</param>
        /// <returns></returns>
        public IEnumerable<Sede> ConsultarSedesPorUsuario(string usuario)
        {
            return this.ContextoLibellus.UsuariosRoles.Where(x => x.Usuario.NombreUsuario.Equals(usuario)).Select(s => s.Sede);
        }

        /// <summary>
        /// Realiza la precarga de los maestros para una nueva sede.
        /// </summary>
        /// <param name="IdSede">Identificador de la sede.</param>
        public void InsertarPrecargasSede(int IdSede)
        {
            this.ContextoLibellus.Database.ExecuteSqlCommand("InsertarPrecargasSede @IdSede", new SqlParameter("@IdSede", IdSede));
        }

        #endregion
    }
}
