namespace Libellus.Web.Atributos
{
    using Elmah;
    using System.Web;
    using System.Web.Mvc;

    /// <summary>
    /// Define el atributo de errores no controlador con el componente Elmah.
    /// </summary>
    public class ElmahAttribute : HandleErrorAttribute
    {
        #region Eventos

        /// <summary>
        /// Ocurre cada que se captura un error no controlado en el sistema.
        /// </summary>
        /// <param name="context">Contexto en el que se encuentra el sistema al momento de ocurrir la excepción.</param>
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            if (!context.ExceptionHandled || TryRaiseErrorSignal(context) || IsFiltered(context))
            {
                return;
            }

            LogException(context);
        }

        #endregion Eventos

        #region Métodos privados

        /// <summary>
        /// Intenta capturar el error no controlado desde el contexto actual.
        /// </summary>
        /// <param name="context">Contexto de la excepción ocurrida.</param>
        /// <returns>True si fue capturado correctamente; de lo contrario false.</returns>
        private static bool TryRaiseErrorSignal(ExceptionContext context)
        {
            var httpContext = GetHttpContextImpl(context.HttpContext);
            if (httpContext == null)
            {
                return false;
            }

            var signal = ErrorSignal.FromContext(httpContext);
            if (signal == null)
            {
                return false;
            }

            signal.Raise(context.Exception, httpContext);

            return true;
        }

        /// <summary>
        /// Determina si la excepción se captura desde un filtro.
        /// </summary>
        /// <param name="context">Contexto de la excepción ocurrida.</param>
        /// <returns>True si fue capturado correctamente; de lo contrario false.</returns>
        private static bool IsFiltered(ExceptionContext context)
        {
            var config = context.HttpContext.GetSection("elmah/errorFilter") as ErrorFilterConfiguration;

            if (config == null)
            {
                return false;
            }

            var testContext = new ErrorFilterModule.AssertionHelperContext(context.Exception, GetHttpContextImpl(context.HttpContext));
            return config.Assertion.Test(testContext);
        }

        /// <summary>
        /// Registra la excepción no controlada ocurrida en el repositorio configurado.
        /// </summary>
        /// <param name="context">Contexto de la excepción ocurrida.</param>
        private static void LogException(ExceptionContext context)
        {
            var httpContext = GetHttpContextImpl(context.HttpContext);
            var error = new Error(context.Exception, httpContext);
            ErrorLog.GetDefault(httpContext).Log(error);
        }

        /// <summary>
        /// Obtiene el contexto en el que se encuentra el sistema al momento de ocurrir la excepción.
        /// </summary>
        /// <param name="context">Contexto en el que ocurrió la excepción.</param>
        /// <returns>Contexto en el que se encuentra el sistema.</returns>
        private static HttpContext GetHttpContextImpl(HttpContextBase context)
        {
            return context.ApplicationInstance.Context;
        }

        #endregion Métodos privados
    }
}