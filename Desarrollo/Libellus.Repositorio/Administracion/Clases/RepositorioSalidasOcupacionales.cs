namespace Libellus.Repositorio.Administracion
{
    using System.Collections.Generic;
    using System.Linq;
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;
    using Libellus.Repositorio.Contextos;

    /// <summary>
    /// Define la persistencia con la DB de Libellus para el maestro salidas ocupacionales.
    /// </summary>
    public class RepositorioSalidasOcupacionales : RepositorioBase<SalidaOcupacional>, IRepositorioSalidasOcupacionales
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo RepositorioSalidasOcupacionales con el DbContext a trabajar.
        /// </summary>
        /// <param name="contextoLibellus">DbContext a trabajar.</param>
        public RepositorioSalidasOcupacionales(LibellusDbContext contextoLibellus)
        {
            this.ContextoLibellus = contextoLibellus;
        }

        #endregion Constructores

        #region Métodos

        /// <summary>
        /// Consulta las salidas ocupacionales asociadas a una sede.
        /// </summary>
        /// <param name="idSede">Identificador interno de la sede a consultar.</param>
        /// <returns>Colección con la información de las salidas ocupacionales asociadas.</returns>
        public IEnumerable<SalidaOcupacional> ConsultarSalidasOcupacionalesPorSede(int idSede)
        {
            return this.ContextoLibellus.SalidasOcupacionales.Where(o => o.IdSede == idSede);
        }

        #endregion Métodos
    }
}
