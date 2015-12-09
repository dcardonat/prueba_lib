namespace Libellus.Negocio.Administracion
{
    using System;
    using Libellus.Entidades;
    using Libellus.Mensajes;

    /// <summary>
    /// Define la interfáz de las reglas de negocio para los datos de institucion educativa.
    /// </summary>
    public interface INegocioInstitucionEducativa : IDisposable
    {
        /// <summary>
        /// Actualiza los datos de la institucion educativa.
        /// </summary>
        /// <param name="institucionEducativa">Entidad con los campos diligenciados.</param>
        void ActualizarDatosInstitucionEducativa(InstitucionEducativa institucionEducativa);

        /// <summary>
        /// Administra la informacion diligenciada.
        /// </summary>
        /// <param name="institucionEducativa">Entidad con los campos diligenciados.</param>
        /// <returns>Mensaje de la operacion.</returns>
        Mensaje AdministrarInstitucionEducativa(InstitucionEducativa institucionEducativa);

        /// <summary>
        /// Consulta los datos registrados de la institucion educativa.
        /// </summary>
        /// <returns>Entidad con los campos diligenciados.</returns>
        InstitucionEducativa ConsultarDatosInstitucionEducativa();

        /// <summary>
        /// Crea el registro de la institucion educativa.
        /// </summary>
        /// <param name="institucionEducativa">Entidad con los campos diligenciados.</param>
        void CrearInstitucionEducativa(InstitucionEducativa institucionEducativa);
    }
}