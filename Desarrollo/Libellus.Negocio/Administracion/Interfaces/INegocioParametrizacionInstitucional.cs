namespace Libellus.Negocio.Administracion.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Libellus.Entidades;
    using Libellus.Mensajes;

    /// <summary>
    /// Define la interfáz de las reglas de negocio para la parametrización institucional.
    /// </summary>
    public interface INegocioParametrizacionInstitucional : IDisposable
    {
        /// <summary>
        /// Consulta los horarios dependiendo del nivel educativo seleccionado.
        /// </summary>
        /// <param name="idNivelEducativo">Identificador interno del nivel educativo.</param>
        /// <returns>Si el nivel educativo es CLEI, los horarios serán Nocturna, Sabatina, Dominical; de lo contrario serán, Mañana y tarde.</returns>
        IEnumerable<Maestro> ConsultarHorarios(int idNivelEducativo);

        /// <summary>
        /// Consulta las parametrizaciones institucionales almacenadas en el sistema.
        /// </summary>
        /// <returns>Colección con la información de la parametrización instucional.</returns>
        IEnumerable<ParametrizacionInstitucional> Consultar();

        /// <summary>
        /// Consulta la información de una parametrización institucional por su identificador interno.
        /// </summary>
        /// <param name="idParametrizacionInstitucional">Identificador interno de la parametrización institucional a consultar.</param>
        /// <returns>Información de la parametrización institucional.</returns>
        ParametrizacionInstitucional Consultar(int idParametrizacionInstitucional);

        /// <summary>
        /// Consulta los horarios dependiendo del nivel educativo seleccionado.
        /// </summary>
        /// <param name="parametrizacion">Información de la parametrización a almacenar.</param>
        /// <returns>Mensaje si la parametrización existía en base de datos; de lo contrario null.</returns>
        Mensaje AlmacenarParametrizacionInstitucional(ParametrizacionInstitucional parametrizacion);

        /// <summary>
        /// Actualiza la información de una parametrización institucional existente.
        /// </summary>
        /// <param name="parametrizacion">Información de la parametrización a actualizar.</param>
        /// <returns>Mensaje si la parametrización existía en base de datos; de lo contrario null.</returns>
        Mensaje EditarParametrizacionInstitucional(ParametrizacionInstitucional parametrizacion);
    }
}
