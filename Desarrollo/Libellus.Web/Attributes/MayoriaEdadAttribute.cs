namespace Exito.Sime.Web.Attributes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;
    using Libellus.Entidades.Enumerados;
    using Libellus.Negocio.Administracion;
    using Libellus.Negocio.UnidadesDeTrabajo;
    using Libellus.Utilidades;

    /// <summary>
    /// Establece la regla de validación para campos tipo fecha para determinar la mayoría de edad del lado del cliente.
    /// </summary>
    public class MayoriaEdadAttribute : ValidationAttribute, IClientValidatable
    {
        #region Métodos protegidos

        /// <summary>
        /// Determina si la validación se cumple con la información que llega al servidor.
        /// </summary>
        /// <param name="value">Valor a evaluar.</param>
        /// <returns>True si es válido, de lo contrario false.</returns>
        public override bool IsValid(object value)
        {
            int mayoriaEdad = 0;

            using (INegocioMaestros negocioMaestros = new NegocioMaestros(new UnidadDeTrabajoLibellus()))
            {
                mayoriaEdad = Int32.Parse(negocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.MayoriaEdad, ContextoLibellus.ObtenerSedeActual).FirstOrDefault().Descripcion);
            }

            DateTime fechaNacimiento = Convert.ToDateTime(value);
            int anios = Convert.ToInt32((UtilidadesApp.ObtenerFechaActual() - fechaNacimiento).TotalDays / 365);

            return anios >= mayoriaEdad;
        }

        #endregion Métodos protegidos

        #region Métodos públicos

        /// <summary>
        /// Establece los valores configurables para las reglas de validación.
        /// </summary>
        /// <param name="metadata">Metadata especificada en el ViewModel.</param>
        /// <param name="context">Contexto actual del controlador.</param>
        /// <returns>Colección con las reglas de validación.</returns>
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            ModelClientValidationRule clienteRule = new ModelClientValidationRule
            {
                ValidationType = "mayoriaedadvalidation",
                ErrorMessage = this.ErrorMessageString
            };

            int mayoriaEdad = 0;

            using (INegocioMaestros negocioMaestros = new NegocioMaestros(new UnidadDeTrabajoLibellus()))
            {
                mayoriaEdad = Int32.Parse(negocioMaestros.ConsultarMaestrosPorTipo(TiposMaestros.MayoriaEdad, ContextoLibellus.ObtenerSedeActual).FirstOrDefault().Descripcion);
            }

            clienteRule.ValidationParameters["mayoriaedadpattern"] = mayoriaEdad;

            yield return clienteRule;
        }

        #endregion Métodos públicos
    }
}