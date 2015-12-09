namespace Libellus.Repositorio.Administracion
{
    using System.Collections.Generic;
    using Libellus.Entidades;
    using Libellus.Entidades.TiposComplejos;
    using Libellus.Repositorio.Base;

    /// <summary>
    /// Define la interfáz para la persistencia con la DB de Libellus para la funcionalidad de documentacion para soporte por roles.
    /// </summary>
    public interface IRepositorioDocumentacionSoporteRoles : IRepositorioBase<SoportePorRol>
    {
        /// <summary>
        /// Elimina un documento soporte de la lista.
        /// </summary>
        /// <param name="documento">Documento a eliminar.</param>
        void EliminarDocumento(SoportePorRolesDocumento documento);

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
        /// Consulta la documentación de soporte asociada a un rol.
        /// </summary>
        /// <param name="idRolInstitucional">Identificador interno del rol institucional a consultar.</param>
        /// <param name="idSede">Identificador interno de la sede.</param>
        /// <param name="anioEscolar">Año escolar a filtar.</param>
        /// <param name="idDocente">Identificador interno del docente.</param>
        /// <returns>Colección con los documentos de soporte asociados.</returns>
        IEnumerable<SoportePorRolesDocumento> ConsultarDocumentacionSoporteRol(int idRolInstitucional, int idSede, int anioEscolar);

        /// <summary>
        /// Consulta la documentación de soporte asociada a un rol.
        /// </summary>
        /// <param name="idRolInstitucional">Identificador interno del rol institucional a consultar.</param>
        /// <param name="idSede">Identificador interno de la sede.</param>
        /// <param name="anioEscolar">Año escolar a filtar.</param>
        /// <param name="idDocente">Identificador interno del docente.</param>
        /// <param name="idNivel">Nivel educativo.</param>
        /// <returns>Colección con los documentos de soporte asociados.</returns>
        IEnumerable<SoportePorRolesDocumento> ConsultarDocumentacionSoporteRol(int idRolInstitucional, int idSede, int anioEscolar, int idNivel);
    }
}