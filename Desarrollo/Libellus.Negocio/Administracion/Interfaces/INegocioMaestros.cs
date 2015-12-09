namespace Libellus.Negocio.Administracion
{
    using System;
    using System.Collections.Generic;
    using Libellus.Entidades;
    using Libellus.Entidades.Enumerados;
    using Libellus.Mensajes;

    /// <summary>
    /// Define la interfáz de las reglas de negocio para los maestros administrables.
    /// </summary>
    public interface INegocioMaestros : IDisposable
    {
        /// <summary>
        /// Consulta la información de un maestro por su id.
        /// </summary>
        /// <param name="idMaestro">Identificador interno del maestro a consultar.</param>
        /// <returns>Información del maestro consultado.</returns>
        Maestro ConsultarMaestroPorId(int idMaestro);

        /// <summary>
        /// Consulta la información de un tipo de maestro.
        /// </summary>
        /// <param name="tipoMaestro">Tipo de maestro a consultar.</param>
        /// <param name="idSede">Identificador interno de la sede actualmente logeada.</param>
        /// <returns>Información del tipo de maestro consultada.</returns>
        IEnumerable<Maestro> ConsultarMaestrosPorTipo(TiposMaestros tipoMaestro, int idSede);

        /// <summary>
        /// Consulta la información de un tipo de maestro, permitiendo filtrar por el estado de los registros.
        /// </summary>
        /// <param name="tipoMaestro">Tipo de maestro a consultar.</param>
        /// <param name="idSede">Identificador interno de la sede actualmente logeada.</param>
        /// <param name="estado">Estado de los registros del maestro.</param>
        /// <returns>Información del tipo de maestro consultada.</returns>
        IEnumerable<Maestro> ConsultarMaestrosPorTipo(TiposMaestros tipoMaestro, int idSede, bool estado);

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
        /// Crea un nuevo maestro en la base de datos.
        /// </summary>
        /// <param name="maestro">Información del maestro a crear.</param>
        /// <returns>Mensaje si se intenta ingresar un registro duplicado; de lo contrario null.</returns>
        Mensaje AlmacenarMaestro(Maestro maestro);

        /// <summary>
        /// Edita la información de un maestro en la base de datos.
        /// </summary>
        /// <param name="maestro">Información del maestro a editar.</param>
        /// <returns>Mensaje si se intenta ingresar un registro duplicado; de lo contrario null.</returns>
        Mensaje EditarMaestro(Maestro maestro);

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