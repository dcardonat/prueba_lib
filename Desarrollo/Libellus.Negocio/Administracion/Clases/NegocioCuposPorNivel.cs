namespace Libellus.Negocio.Administracion.Clases
{
    using Libellus.Entidades;
    using Libellus.Negocio.UnidadesDeTrabajo;
    using Libellus.Utilidades;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Define las reglas de negocio para los datos de proyeccion de grupos por nivel.
    /// </summary>
    public class NegocioCuposPorNivel : NegocioBase, INegocioCuposPorNivel
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo NegocioGruposPorNivel.
        /// </summary>
        public NegocioCuposPorNivel(IUnidadDeTrabajoLibellus unidadDeTrabajoLibellus)
        {
            this.UnidadDeTrabajoLibellus = unidadDeTrabajoLibellus;
        }

        #endregion Constructores

        #region Metodos

        /// <summary>
        /// Consulta la proyección de cupos por nivel.
        /// </summary>
        /// <param name="anio">Año de la proyección,</param>
        /// <returns>Retorna el resultado de la consulta.</returns>
        public IEnumerable<ProyeccionCuposPorNivel> ConsultarProyeccionCuposNivel(int anio)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioCuposPorNivel.ConsultarProyeccionCuposNivel(Utilidades.ContextoLibellus.ObtenerSedeActual, anio);
        }

        /// <summary>
        /// Consulta la proyección de cupos por nivel.
        /// </summary>
        /// <returns>Retorna el resultado de la consulta.</returns>
        public IEnumerable<ProyeccionCuposPorNivel> ConsultarProyeccionCuposNivel()
        {
            return this.UnidadDeTrabajoLibellus.RepositorioCuposPorNivel.ConsultarProyeccionCuposNivel(Utilidades.ContextoLibellus.ObtenerSedeActual);
        }

        /// <summary>
        /// Crea la proyeccion de cupos por nivel.
        /// </summary>
        /// <param name="cuposPorNivel">Entidad cupos por  nivel</param>
        /// <returns>Retorna el resultado de la operacion.</returns>
        public bool Crear(ProyeccionCuposPorNivel cuposPorNivel)
        {
            this.UnidadDeTrabajoLibellus.RepositorioCuposPorNivel.Insert(cuposPorNivel);
            return this.UnidadDeTrabajoLibellus.SaveChanges() > 0;
        }

        /// <summary>
        /// Edita la proyeccion de cupos por nivel.
        /// </summary>
        /// <param name="cuposPorNivel">Entidad cupos por  nivel</param>
        /// <returns>Retorna el resultado de la operacion.</returns>
        public bool Editar(ProyeccionCuposPorNivel cuposPorNivel)
        {
            this.UnidadDeTrabajoLibellus.RepositorioCuposPorNivel.Update(cuposPorNivel);
            return this.UnidadDeTrabajoLibellus.SaveChanges() > 0;
        }

        /// <summary>
        /// Administra la informormación de los cupos por nivel.
        /// </summary>
        /// <param name="CuposPorNivel">Entidad cupos por nivel.</param>
        /// <returns>Retorna el resultado de la operación.</returns>
        public bool Administrar(List<ProyeccionCuposPorNivel> CuposPorNivel)
        {
            foreach (var cupoPorNivel in CuposPorNivel)
            {
                cupoPorNivel.IdSede = Utilidades.ContextoLibellus.ObtenerSedeActual;

                if (cupoPorNivel.Id > 0)
                {
                    this.UnidadDeTrabajoLibellus.RepositorioCuposPorNivel.Update(cupoPorNivel);
                }
                else
                {
                    this.UnidadDeTrabajoLibellus.RepositorioCuposPorNivel.Insert(cupoPorNivel);
                }
            }

            return this.UnidadDeTrabajoLibellus.SaveChanges() > 0;
        }

        /// <summary>
        /// Consulata la cantidad de estudiantes por grupo.
        /// </summary>
        /// <param name="idAnioLectivo">Identificador del año.</param>
        /// <param name="idNivel">Idnetificador del nivel.</param>
        /// <returns>Retorna el resultado de la consulta.</returns>
        public int ConsultarCantidadEstudiantesPorGrupo(int idAnioLectivo, int idNivel)
        {
            return this.UnidadDeTrabajoLibellus.RepositorioCuposPorNivel.ConsultarCantidadEstudiantesPorGrupo(idAnioLectivo, ContextoLibellus.ObtenerSedeActual, idNivel);
        }

        #endregion
    }
}
