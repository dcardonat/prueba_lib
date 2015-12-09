namespace Libellus.Negocio.Administracion
{
    using System;
    using System.Collections.Generic;
    using Libellus.Entidades;
    using Libellus.Mensajes;

    /// <summary>
    /// Define la interfáz de las reglas de negocio para los datos de la parametrizacion escolar.
    /// </summary>
    public interface INegocioParametrizacionEscolar : IDisposable
    {
        /// <summary>
        /// Actualiza un registro de parametrizacion escolar.
        /// </summary>
        /// <param name="parametrizacion">Entidad con la informacion para almacenar.</param>
        /// <returns>Retorna mensaje sobre el resultado de la operación.</returns>
        Mensaje ActualizarParametrizacionEscolar(ParametrizacionEscolar parametrizacion);

        /// <summary>
        /// Consulta un registro especifico de parametrizacion anual y semestral.
        /// </summary>
        /// <param name="id">Identificador del registro.</param>
        /// <returns>Entidad con la informacion.</returns>
        ParametrizacionEscolar ConsultarParametrizacionEscolar(int id);

        /// <summary>
        /// Obtiene las parametrizaciones escolares de la sede actual.
        /// </summary>
        /// <returns>Coleccion de datos de tipo ParametrizacionEscolar</returns>
        IEnumerable<ParametrizacionEscolar> ConsultarParametrizacionesEscolaresPorSede();

        /// <summary>
        /// Consulta la informacion de un periodo.
        /// </summary>
        /// <param name="id">Identificador del periodo.</param>
        /// <returns>Informacion de la parametrizacion.</returns>
        PeriodoParametrizacion ConsultarPeriodo(int id);

        /// <summary>
        /// Almacena un registro de configuracion de parametrizacion escolar.
        /// </summary>
        /// <param name="parametrizacion">Entidad con la informacion para almacenar.</param>
        /// <returns>Retorna mensaje sobre el resultado de la operación.</returns>
        Mensaje CrearParametrizacionEscolar(ParametrizacionEscolar parametrizacion);

        /// <summary>
        /// Elimina un registro de parametrizacion escolar.
        /// </summary>
        /// <param name="id">Identificador del registro.</param>
        void Eliminar(int id);
    }
}