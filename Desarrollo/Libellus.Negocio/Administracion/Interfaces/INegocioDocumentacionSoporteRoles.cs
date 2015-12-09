namespace Libellus.Negocio.Administracion
{
    using System;
    using System.Collections.Generic;
    using Libellus.Entidades;
    using Libellus.Entidades.TiposComplejos;

    /// <summary>
    /// Define la interfáz de las reglas de negocio para la funcionalidad de documentacion para soporte por roles.
    /// </summary>
    public interface INegocioDocumentacionSoporteRoles : IDisposable
    {
        /// <summary>
        /// Actualiza la informacion diligenciada para la documentacion para soporte por roles.
        /// </summary>
        /// <param name="soporte">Entidad de tipo SoportePorRol con la informacion actualizada.</param>
        void ActualizarDocumentacionSoporte(SoportePorRol soporte);

        /// <summary>
        /// Almacena la informacion diligenciada para la documentacion para soporte por roles.
        /// </summary>
        /// <param name="soporte">Entidad de tipo SoportePorRol con la informacion ingresada.</param>
        void AlmacenarDocumentacionSoporte(SoportePorRol soporte);

        /// <summary>
        /// Consulta la informacion detallada de un soporte.
        /// </summary>
        /// <param name="id">Identificador del registro.</param>
        /// <returns>Entidad con la informacion diligenciada.</returns>
        SoportePorRol ConsultarDocumentacionSoporte(int id);

        /// <summary>
        /// Consulta la informacion de documentacion para soporte por roles respectivos de la sede.
        /// </summary>
        /// <returns>Coleccion de datos tipo SoportePorRol.</returns>
        IEnumerable<SoportePorRol> ConsultarDocumentacionSoportePorSede();

        /// <summary>
        /// Consulta la documentación de soporte asociada a un rol.
        /// </summary>
        /// <param name="idRolInstitucional">Identificador interno del rol institucional a consultar.</param>
        /// <param name="idSede">Identificador interno de la sede.</param>
        /// <param name="anioEscolar">Año escolar a filtar.</param>
        /// <param name="idDocente">Identificador interno del docente.</param>
        /// <returns>Colección con los documentos de soporte asociados.</returns>
        IEnumerable<DocumentoSoportePorRolSeleccionado> ConsultarDocumentacionSoportePorRol(int idRolInstitucional, int idSede, int anioEscolar, int? idDocente);

        /// <summary>
        /// Elimina la información de soporte asociada al rol.
        /// </summary>
        /// <param name="id">Identificador del registro.</param>
        void EliminarDocumentacionSoporteRol(int id);

        /// <summary>
        /// Consulta la documentación de soporte asociada a un rol.
        /// </summary>
        /// <param name="idRolInstitucional">Identificador interno del rol institucional a consultar.</param>
        /// <param name="idSede">Identificador interno de la sede.</param>
        /// <param name="anioEscolar">Año escolar a filtar.</param>
        /// <param name="idDocente">Identificador interno del docente.</param>
        /// <returns>Colección con los documentos de soporte asociados.</returns>
        IEnumerable<SoportePorRolesDocumento> ConsultarDocumentacionSoporteRol(int idRolInstitucional, int anioEscolar);

        /// <summary>
        /// Consulta la documentación de soporte asociada a un rol.
        /// </summary>
        /// <param name="idRolInstitucional">Identificador interno del rol institucional a consultar.</param>
        /// <param name="anioEscolar">Año escolar a filtar.</param>
        /// <param name="idDocente">Identificador interno del docente.</param>
        /// <param name="idNivel">Nivel educativo.</param>
        /// <returns>Colección con los documentos de soporte asociados.</returns>
        IEnumerable<SoportePorRolesDocumento> ConsultarDocumentacionSoporteRol(int idRolInstitucional, int anioEscolar, int idNivel);
    }
}