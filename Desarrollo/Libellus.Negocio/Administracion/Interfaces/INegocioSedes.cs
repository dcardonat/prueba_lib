namespace Libellus.Negocio.Administracion
{
    using Libellus.Entidades;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Define la interfáz de las reglas de negocio para las sedes.
    /// </summary>
    public interface INegocioSedes : IDisposable
    {
        /// <summary>
        /// Consulta la información de las sedes por el usuario.
        /// </summary>
        /// <param name="usuario">Usuario para la consulta.</param>
        /// <returns></returns>
        IEnumerable<Sede> ConsultarSedesPorUsuario(string usuario);

        /// <summary>
        /// Consulta la información de la sede por id.
        /// </summary>
        /// <param name="idSede">Identificadr de la sede.</param>
        /// <returns>Retorna la coonsulta</returns>
        Sede ConsultarSedes(int idSede);

        /// <summary>
        /// Consulta la información de la sedes.
        /// </summary>
        /// <returns>Retorna la coonsulta</returns>
        IEnumerable<Sede> ConsultarSedes();
    }
}
