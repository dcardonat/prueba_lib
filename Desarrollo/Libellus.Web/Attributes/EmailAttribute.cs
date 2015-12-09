namespace Libellus.Web.Attributes
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;
    using System.Web.Mvc;

    /// <summary>
    /// Establece la regla de validación de correo electrónico del lado del cliente.
    /// </summary>
    public class EmailAttribute : ValidationAttribute, IClientValidatable
    {
        #region Atributos

        /// <summary>
        /// Establece el patrón REGEX de validación.
        /// </summary>
        private string patronValidacion = @"[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$";

        #endregion Atributos

        #region Métodos protegidos

        /// <summary>
        /// Determina si la validación se cumple con la información que llega al servidor.
        /// </summary>
        /// <param name="value">Valor a evaluar.</param>
        /// <returns>True si es válido, de lo contrario false.</returns>
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

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
                ValidationType = "correoelectronicovalidation",
                ErrorMessage = this.ErrorMessageString
            };

            clienteRule.ValidationParameters["correoelectronicopattern"] = patronValidacion;

            yield return clienteRule;
        }

        #endregion Métodos públicos
    }
}