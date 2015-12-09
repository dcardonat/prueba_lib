namespace Libellus.Negocio.Administracion.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Libellus.Entidades;

    /// <summary>
    /// Define la interfáz de las reglas de negocio para la administración de la información de los docentes.
    /// </summary>
    public interface INegocioDocente : IDisposable
    {
        /// <summary>
        /// Almacena la información de un docente en base de datos.
        /// </summary>
        /// <param name="informacionDocente">Información del docente.</param>
        void AlmacenarDocente(DocenteDatosPersonales informacionDocente);

        /// <summary>
        /// Actualiza la información de un docente en base de datos.
        /// </summary>
        /// <param name="informacionDocente">Información del docente.</param>
        void ActualizarDocente(DocenteDatosPersonales informacionDocente);

        /// <summary>
        /// Consulta la información de un docente por su identificador interno.
        /// </summary>
        /// <param name="idDocente">Identificador interno del docente.</param>
        /// <returns>Información del docente consultado, si no existe, null.</returns>
        DocenteDatosPersonales ConsultarDocente(int idDocente);

        /// <summary>
        /// Consulta los docentes que se encuentran asociados a los filtros especificados.
        /// </summary>
        /// <param name="idTipoDocumento">Identificador interno del tipo de documento. Opcional.</param>
        /// <param name="documentoIdentidad">Número del documento de identidad. Opcional.</param>
        /// <param name="idEstado">Identificador interno del estado del docente. Opcional.</param>
        /// <param name="nombres">Valor que coincida con los nombres de un docente. Opcional.</param>
        /// <param name="apellidos">Valor que coincida con los apellidos de un docente. Opcional.</param>
        /// <param name="idSexo">Identificador interno del sexo. Opcional.</param>
        /// <returns>Colección de docentes asociados al filtro especificado.</returns>
        IEnumerable<DocenteDatosPersonales> ConsultarDocentes(int? idTipoDocumento, string documentoIdentidad, int? idEstado, string nombres, string apellidos, int? idSexo);
    }
}
