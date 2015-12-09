namespace Libellus.Repositorio.Administracion
{
    using System.Collections.Generic;
    using System.Linq;
    using Libellus.Entidades;
    using Libellus.Entidades.Enumerados;
    using Libellus.Repositorio.Contextos;
    using Libellus.Repositorio.Base;
    
    /// <summary>
    /// Define la persistencia con la DB de Libellus para los maestros administrables.
    /// </summary>
    public class RepositorioMaestros : RepositorioBase<Maestro>, IRepositorioMaestros
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo RepositorioMaestros con el DbContext a trabajar.
        /// </summary>
        /// <param name="contextoLibellus">DbContext a trabajar.</param>
        public RepositorioMaestros(LibellusDbContext contextoLibellus)
        {
            this.ContextoLibellus = contextoLibellus;
        }

        #endregion Constructores

        #region Métodos

        /// <summary>
        /// Consulta la información de un maestro por su tipo.
        /// </summary>
        /// <param name="tipoMaestro">Tipo de maestro a consultar.</param>
        /// <param name="idSede">Identificador interno de la sede actualmente logeada.</param>
        /// <returns>Información del tipo de maestro consultada.</returns>
        public IEnumerable<Maestro> ConsultarMaestrosPorTipo(TiposMaestros tipoMaestro, int idSede)
        {
            return this.ContextoLibellus.Maestros.Where(o => o.IdTipoMaestro == (short)tipoMaestro && o.IdSede == idSede);
        }

        /// <summary>
        /// Consulta la información de un maestro por su consecutivo.
        /// </summary>
        /// <param name="consecutivo">Consecutivo del maestro.</param>
        /// <param name="idSede">Identificador interno de la sede actualmente logeada.</param>
        /// <returns>Información del tipo de maestro consultado.</returns>
        public Maestro ConsultarMaestrosPorConsecutivo(int consecutivo, int idSede)
        {
            return this.ContextoLibellus.Maestros.FirstOrDefault(o => o.Consecutivo == consecutivo && o.IdSede == idSede);
        }
        
        /// <summary>
        /// Consulta los tipos de maestro existentes.
        /// </summary>
        /// <returns>Información de los tipos de maestro existentes.</returns>
        public IEnumerable<TipoMaestro> ConsultarTipoMaestros()
        {
            return this.ContextoLibellus.TipoMaestros.Where(o => o.Administrable);
        }

        /// <summary>
        /// Consulta los países existentes.
        /// </summary>
        /// <returns>Colección con la información de los países.</returns>
        public IEnumerable<Pais> ConsultarPaises()
        {
            return this.ContextoLibellus.Paises;
        }

        /// <summary>
        /// Consulta los departamentos existentes asociados a un país.
        /// </summary>
        /// <param name="idPais">Identificador interno del país asociado a los departamentos a consultar.</param>
        /// <returns>Colección con la información de los departamentos.</returns>
        public IEnumerable<Departamento> ConsultarDepartamentos(short idPais)
        {
            return this.ContextoLibellus.Departamentos.Where(d => d.IdPais == idPais);
        }

        /// <summary>
        /// Consulta los municipios existentes asociados a un departamento.
        /// </summary>
        /// <param name="idDepartamento">Identificador interno del departamento asociado a los municipios a consultar.</param>
        /// <returns>Colección con la información de los municipios.</returns>
        public IEnumerable<Municipio> ConsultarMunicipios(short idDepartamento)
        {
            return this.ContextoLibellus.Municipios.Where(m => m.IdDepartamento == idDepartamento);
        }

        #endregion Métodos
    }
}
