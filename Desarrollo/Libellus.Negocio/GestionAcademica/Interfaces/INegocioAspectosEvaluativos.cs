namespace Libellus.Negocio.GestionAcademica
{
    using Libellus.Entidades;
    using Libellus.Mensajes;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Define la interfáz de las reglas de negocio para los aspectos evaluativos.
    /// </summary>
    public interface INegocioAspectosEvaluativos : IDisposable
    {
        /// <summary>
        /// COnsulta la información del registro.
        /// </summary>
        /// <param name="Id">Identificador del registro.</param>
        /// <returns>Retorna el resultado de la consulta.</returns>
        AspectoEvaluativo Consultar(int Id);

        /// <summary>
        /// Consulta la informacion de los aspectos evaluativos.
        /// </summary>
        /// <returns></returns>
        IEnumerable<AspectoEvaluativo> ConsultarPorSede();

        /// <summary>
        /// Consulta la informacion de los aspectos evaluativos.
        /// </summary>
        /// <returns></returns>
        IEnumerable<AspectoEvaluativo> Consultar();

        /// <summary>
        /// Crear el registro.
        /// </summary>
        /// <param name="aspectoEvaluativo">Aspecto evaluativo.</param>
        /// <returns>Retorna el resultado de la transacción.</returns>
        Mensaje Crear(AspectoEvaluativo aspectoEvaluativo);

        /// <summary>
        /// Editar el registro.
        /// </summary>
        /// <param name="aspectoEvaluativo">Aspecto evaluativo.</param>
        /// <returns>Retorna el resultado de la transacción.</returns>
        Mensaje Editar(AspectoEvaluativo aspectoEvaluativo);

        /// <summary>
        /// Elimina el registro.
        /// </summary>
        /// <param name="id">Identificador del registro.</param>
        /// <returns>Retorna el resultado de la operación.</returns>
        Mensaje Eliminar(int id);
    }
}
