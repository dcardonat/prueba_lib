namespace Libellus.Negocio.Administracion
{
    using Libellus.Entidades;
    using Libellus.Negocio.UnidadesDeTrabajo;
    using System.Collections.Generic;

    /// <summary>
    /// Clase para el manejo del negocio de sedes.
    /// </summary>
    public class NegocioSedes : NegocioBase, INegocioSedes
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo NegocioUsuariosAdministrativos.
        /// </summary>
        public NegocioSedes(IUnidadDeTrabajoLibellus unidadDeTrabajoLibellus)
        {
            this.UnidadDeTrabajoLibellus = unidadDeTrabajoLibellus;
        }

        #endregion Constructores

        #region Métodos

        /// <summary>
        /// Consulta la información de las sedes por el usuario.
        /// </summary>
        /// <param name="usuario">Usuario para la consulta.</param>
        /// <returns></returns>
        public IEnumerable<Sede> ConsultarSedesPorUsuario(string usuario)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioSedes.ConsultarSedesPorUsuario(usuario);
        }

        /// <summary>
        /// Consulta la información de la sede por id.
        /// </summary>
        /// <param name="idSede">Identificadr de la sede.</param>
        /// <returns>Retorna la coonsulta</returns>
        public Sede ConsultarSedes(int idSede)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioSedes.GetById(idSede);
        }

        /// <summary>
        /// Consulta la información de la sedes.
        /// </summary>
        /// <returns>Retorna la coonsulta</returns>
        public IEnumerable<Sede> ConsultarSedes()
        {
            return this.UnidadDeTrabajoLibellus.RepositorioSedes.Get();
        }

        #endregion
    }
}
