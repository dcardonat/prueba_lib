namespace Libellus.Repositorio.Administracion
{
    using System.Collections.Generic;
    using Libellus.Entidades;
    using Libellus.Entidades.Enumerados;
    using Libellus.Repositorio.Base;

    /// <summary>
    /// Define la interfáz para la persistencia con la DB de Libellus para los maestros administrables.
    /// </summary>
    public interface IRepositorioMaestros : IRepositorioBase<Maestro>
    {
        /// <summary>
        /// Consulta la información de un tipo de maestro.
        /// </summary>
        /// <param name="tipoMaestro">Tipo de maestro a consultar.</param>
        /// <param name="idSede">Identificador interno de la sede actualmente logeada.</param>
        /// <returns>Información del tipo de maestro consultada.</returns>
        IEnumerable<Maestro> ConsultarMaestrosPorTipo(TiposMaestros tipoMaestro, int idSede);

        /// <summary>
        /// Consulta la información de un maestro por su consecutivo.
        /// </summary>
        /// <param name="consecutivo">Consecutivo del maestro.</param>
        /// <param name="idSede">Identificador interno de la sede actualmente logeada.</param>
        /// <returns>Información del tipo de maestro consultado.</returns>
        Maestro ConsultarMaestrosPorConsecutivo(int consecutivo, int idSede);

        /// <summary>
        /// Consulta los tipos de maestro existentes.
        /// </summary>
        /// <returns>Información de los tipos de maestro existentes.</returns>
        IEnumerable<TipoMaestro> ConsultarTipoMaestros();

        /// <summary>
        /// Consulta los países existentes.
        /// </summary>
        /// <returns>Colección con la información de los países.</returns>
        IEnumerable<Pais> ConsultarPaises();

        /// <summary>
        /// Consulta los departamentos existentes asociados a un país.
        /// </summary>
        /// <param name="idPais">Identificador interno del país asociado a los departamentos a consultar.</param>
        /// <returns>Colección con la información de los departamentos.</returns>
        IEnumerable<Departamento> ConsultarDepartamentos(short idPais);

        /// <summary>
        /// Consulta los municipios existentes asociados a un departamento.
        /// </summary>
        /// <param name="idDepartamento">Identificador interno del departamento asociado a los municipios a consultar.</param>
        /// <returns>Colección con la información de los municipios.</returns>
        IEnumerable<Municipio> ConsultarMunicipios(short idDepartamento);
    }
}
