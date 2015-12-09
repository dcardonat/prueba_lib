namespace Libellus.Negocio.Matriculas
{
    using Libellus.Entidades;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Define la interfáz de las reglas de negocio para la generación de cupos.
    /// </summary>
    public interface INegocioCupos : IDisposable
    {
        /// <summary>
        /// Genera un nuevo cupo para un estudiante.
        /// </summary>
        /// <param name="cupo">Entidad con la informacion del cupo.</param>
        /// <returns>Retorna mensaje indicando el resultado de la operación.</returns>
        int GenerarCupo(Cupo cupo);
    }
}