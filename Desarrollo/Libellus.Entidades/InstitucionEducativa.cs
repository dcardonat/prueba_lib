namespace Libellus.Entidades
{
    using System.Collections.Generic;

    public class InstitucionEducativa
    {
        public InstitucionEducativa()
        {
            RegistrosLegalizacion = new HashSet<RegistroLegalizacion>();
            Sedes = new HashSet<Sede>();
        }

        /// <summary>
        /// Obtiene o establece el identificador del registro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la institucion.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el la resolucion de aprobacion.
        /// </summary>
        public string ResolucionAprobacion { get; set; }

        /// <summary>
        /// Obtiene o establece el nit de la institucion.
        /// </summary>
        public string Nit { get; set; }

        /// <summary>
        /// Obtiene o establece el codigo dane para la institucion.
        /// </summary>
        public string CodigoDane { get; set; }

        /// <summary>
        /// Obtiene o establece el rut de la institucion.
        /// </summary>
        public string Rut { get; set; }

        /// <summary>
        /// Obtiene o establece el logo para la institucion.
        /// </summary>
        public byte[] Logo { get; set; }

        /// <summary>
        /// Obtiene o establece la direccion de la institucion.
        /// </summary>
        public string Direccion { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del pais.
        /// </summary>
        public int IdPais { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del departamento.
        /// </summary>
        public int IdDepartamento { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del municipio.
        /// </summary>
        public int IdMunicipio { get; set; }

        /// <summary>
        /// Obtiene o establece el telefono de la institucion.
        /// </summary>
        public string Telefono { get; set; }

        /// <summary>
        /// Obtiene o establece el fax de la institucion.
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// Obtiene o establece la pagina web de la institucion.
        /// </summary>
        public string PaginaWeb { get; set; }

        /// <summary>
        /// Obtiene o establece los registros de legalizacion asociados.
        /// </summary>
        public virtual ICollection<RegistroLegalizacion> RegistrosLegalizacion { get; set; }

        /// <summary>
        /// Obtiene o establece las sedes asociadas.
        /// </summary>
        public virtual ICollection<Sede> Sedes { get; set; }
    }
}