namespace Libellus.Negocio.Seguridad
{
    using Libellus.Entidades;
    using Libellus.Negocio.UnidadesDeTrabajo;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Define la interfáz de las reglas de negocio para la administracion de RolesFuncionalidades.
    /// </summary>
    public class NegocioRolesFuncionalidades : NegocioBase, INegocioRolesFuncionalidades
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo NegocioFuncionalidades.
        /// </summary>
        public NegocioRolesFuncionalidades(IUnidadDeTrabajoLibellus unidadDeTrabajoLibellus)
        {
            this.UnidadDeTrabajoLibellus = unidadDeTrabajoLibellus;
        }

        #endregion Constructores

        #region Metodos

        /// <summary>
        /// Obtiene las funcionalidades de un rol.
        /// </summary>
        /// <param name="idRol">Id del rol</param>
        /// <returns>Las funcionalidades del rol.</returns>
        public IEnumerable<RolesFuncionalidades> ConsultarFuncionalidadesPorRol(int idRol)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioRolesFuncionalidades.Get().Where(rf => idRol.Equals(rf.IdRol));
        }

        /// <summary>
        /// Asigna las funcionalidades a las que tendrá acceso un rol.
        /// </summary>
        /// <param name="funcionalidadesRol">Funcionalidades a las que tendrá aceeso un rol.</param>        
        public void AsignarFuncionalidadesPorRol(IEnumerable<RolesFuncionalidades> funcionalidadesAEliminar, IEnumerable<RolesFuncionalidades> funcionalidadesAInsertar)
        {
            funcionalidadesAEliminar.ToList().ForEach(f => this.UnidadDeTrabajoLibellus.RepositorioRolesFuncionalidades.Delete(f));
            if (funcionalidadesAInsertar != null)
            {
                funcionalidadesAInsertar.ToList().ForEach(f => this.UnidadDeTrabajoLibellus.RepositorioRolesFuncionalidades.Insert(f));
            }
            this.UnidadDeTrabajoLibellus.SaveChanges();
        }

        #endregion
    }
}
