namespace Libellus.Negocio
{
    using Libellus.Negocio.UnidadesDeTrabajo;
    using System;
    
    /// <summary>
    /// Define información común para las entidades que contienen las reglas de negocio.
    /// </summary>
    public abstract class NegocioBase : IDisposable
    {
        #region Atributos

        /// <summary>
        /// Bandera que determina si se libera la unidad de trabajo de memoria.
        /// </summary>
        private bool disposed = false;        

        #endregion

        #region Propiedades

        /// <summary>
        /// Define la unidad de trabajo a manejar en memoria.
        /// </summary>
        public IUnidadDeTrabajoLibellus UnidadDeTrabajoLibellus { get; set; }

        #endregion

        #region Métodos privados

      

        #endregion

        #region Disposed

        /// <summary>
        /// Realiza la liberación de la unidad del trabajo de la memoria.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Realiza la liberación de la unidad del trabajo de la memoria siempre y cuando sea el momento de la liberación.
        /// </summary>
        /// <param name="disposing">True si se libera, False si se mantiene.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.UnidadDeTrabajoLibellus.Dispose();
                }
            }

            this.disposed = true;
        }

        #endregion
    }
}
