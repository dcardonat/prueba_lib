namespace Libellus.Repositorio.Administracion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;

    /// <summary>
    ///  Define la interfáz para la persistencia con la DB de Libellus para las sedes.
    /// </summary>
    public interface IRepositorioSedes : IRepositorioBase<Sede>
    {
        /// <summary>
        /// Consulta la información de las sedes por el usuario.
        /// </summary>
        /// <param name="usuario">Usuario para la consulta.</param>
        /// <returns></returns>
        IEnumerable<Sede> ConsultarSedesPorUsuario(string usuario);

        /// <summary>
        /// Realiza la precarga de los maestros para una nueva sede.
        /// </summary>
        /// <param name="IdSede">Identificador de la sede.</param>
        void InsertarPrecargasSede(int IdSede);
    }
}
