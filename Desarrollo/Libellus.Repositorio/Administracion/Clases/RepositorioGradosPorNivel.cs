namespace Libellus.Repositorio.Administracion
{
    using System.Collections.Generic;
    using System.Linq;
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;
    using Libellus.Repositorio.Contextos;

    /// <summary>
    /// Persistencia de los datos de los grados por nivel.
    /// </summary>
    public class RepositorioGradosPorNivel : RepositorioBase<GradosPorNivel>, IRepositorioGradosPorNivel
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo RepositorioGradosPorNivel con el DbContext a trabajar.
        /// </summary>
        /// <param name="contextoLibellus">DbContext a trabajar.</param>
        public RepositorioGradosPorNivel(LibellusDbContext contextoLibellus)
        {
            this.ContextoLibellus = contextoLibellus;
        }

        #endregion Constructores

        #region Métodos públicos

        /// <summary>
        /// Consulta la información de un grado asociado.
        /// </summary>
        /// <param name="idGrado">Identificador interno del grado.</param>
        /// <returns>Información del grado; de lo contrario null.</returns>
        public GradosPorNivel ConsultarGrado(int idGrado)
        {
            return this.ContextoLibellus.GradosPorNivel.FirstOrDefault(o => o.IdGrado == idGrado);
        }

        //// <summary>
        /// Consulta la información de los grados asociados a un nivel.
        /// </summary>
        /// <param name="idNivel">Identificador interno del nivel.</param>
        /// <returns>Información de los grado asociados por nivel.</returns>
        public IEnumerable<Maestro> ConsultarGradosPorNivel(int idNivel)
        {
            return this.ContextoLibellus.GradosPorNivel.Where(o => o.IdNivel == idNivel).Select(o => o.Grado);
        }

        /// <summary>
        /// Consulta la información de los grados asociados a un nivel.
        /// </summary>
        /// <param name="idNivel">Identificador interno del nivel.</param>
        /// <returns>Información de los grado asociados por nivel (entidad tipo GradosPorNivel).</returns>
        public IEnumerable<GradosPorNivel> ConsultarGradosPorNivelEntidad(int idNivel)
        {
            return this.ContextoLibellus.GradosPorNivel.Where(o => o.IdNivel == idNivel);
        }

        #endregion Métodos públicos
    }
}