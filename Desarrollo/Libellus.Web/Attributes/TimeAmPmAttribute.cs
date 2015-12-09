namespace Exito.Sime.Web.Attributes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;
    using System.Web.Mvc;

    /// <summary>
    /// Establece la regla de validación para campos de tipo horario incluido el AM/PM del lado del cliente.
    /// </summary>
    public class TimeAmPmAttribute : ValidationAttribute, IClientValidatable
    {
        #region Atributos

        /// <summary>
        /// Establece el patrón REGEX de validación.
        /// </summary>
        private string patronValidacion = @"^((0?[1-9]|1[012])(:[0-5]\d){1,2}(\ ?[AP]M))$";

        #endregion Atributos

        #region Métodos protegidos

        /// <summary>
        /// Determina si la validación se cumple con la información que llega al servidor.
        /// </summary>
        /// <param name="value">Valor a evaluar.</param>
        /// <returns>True si es válido, de lo contrario false.</returns>
        public override bool IsValid(object value)
        {
            return Regex.IsMatch(value.ToString(), patronValidacion);
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
                ValidationType = "timeampmvalidation",
                ErrorMessage = this.ErrorMessageString
            };

            clienteRule.ValidationParameters["timeampmpattern"] = patronValidacion;

            yield return clienteRule;
        }

        #endregion Métodos públicos
    }
}