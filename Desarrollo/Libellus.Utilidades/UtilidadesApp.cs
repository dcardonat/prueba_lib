namespace Libellus.Utilidades
{
    using Elmah;
    using Libellus.Entidades;
    using Libellus.Mensajes;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Net;
    //using System.Web.Mail;
    using System.Reflection;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.Mvc;
    using System.Net;
    using System.Net.Mail;

    /// <summary>
    /// Define las propiedades y utilidades generales para el contexto de la aplicación.
    /// </summary>
    public static class UtilidadesApp
    {
        #region Propiedades

        /// <summary>
        /// Constante para codificar y decoficar la clave.
        /// </summary>
        ////private const string llaveEncripcion = "0k@9;yUyp5Q2C]i*oaV*";

        /// <summary>
        /// Constante para codificar y decoficar la clave.
        /// </summary>
        private const string llaveEncripcion = "key";

        /// <summary>
        /// TODO: DCC, establecer comentario.
        /// </summary>
        private readonly static byte[] salt = Encoding.ASCII.GetBytes(llaveEncripcion.Length.ToString());

        #endregion Propiedades

        #region Métodos públicos

        /// <summary>
        /// Obtiene un arreglo de byte que representa un archivo.
        /// </summary>
        /// <param name="stream">Lectura del archivo.</param>
        /// <param name="tamano">Tamaño del archivo.</param>
        /// <returns>Archivo convertido en arreglo de datos.</returns>
        public static byte[] ObtenerBytesArchivo(Stream stream, int tamano)
        {
            byte[] fileByteData = null;

            using (BinaryReader binaryReader = new BinaryReader(stream))
            {
                fileByteData = binaryReader.ReadBytes(tamano);
            }

            return fileByteData;
        }

        /// <summary>
        /// Obtiene una url de 64bits a partir de un array de bytes de una imagen.
        /// </summary>
        /// <param name="imagen">Array de bytes de la imagen a convertir.</param>
        /// <returns>Url para renderizar la imagen.</returns>
        public static string ObtenerUrlBase64(byte[] imagen)
        {
            string imageDataUrl = null;

            if (imagen != null)
            {
                string imageBase64Data = Convert.ToBase64String(imagen);
                imageDataUrl = String.Format("data:image/png;base64,{0}", imageBase64Data);
            }

            return imageDataUrl;
        }

        /// <summary>
        /// Obtiene una url de 64bits a partir del stream de una imagen.
        /// </summary>
        /// <param name="imagen">Stream de la imagen a convertir.</param>
        /// <returns>Url para renderizar la imagen.</returns>
        public static string ObtenerUrlBase64(Stream imagen)
        {
            string imageDataUrl = null;
            byte[] imageByteData = null;

            if (imagen != null)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    imagen.CopyTo(memoryStream);
                    imageByteData = memoryStream.ToArray();
                }

                string imageBase64Data = Convert.ToBase64String(imageByteData);
                imageDataUrl = String.Format("data:image/png;base64,{0}", imageBase64Data);
            }

            return imageDataUrl;
        }

        /// <summary>
        /// Obtiene la fecha actual del sistema en formato UTC por estár la aplicación instalada en cualquier región del mundo.
        /// </summary>
        /// <returns>Fecha actual en formato UTC.</returns>
        public static DateTime ObtenerFechaActual()
        {
            TimeZoneInfo timeZoneColombia = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneColombia);
        }

        /// <summary>
        /// Realiza la conversión de una hora AM/PM a una hora militar.
        /// </summary>
        /// <param name="hora">Hora a convertir.</param>
        /// <returns>Hora militar.</returns>
        public static TimeSpan ObtenerHoraMilitar(string hora)
        {
            string horaMilitar = DateTime.Parse(hora).ToString("HH:mm");
            return new TimeSpan(Int32.Parse(horaMilitar.Split(':')[0]), Int32.Parse(horaMilitar.Split(':')[1]), 0);
        }

        /// <summary>
        /// Retorna el nombre de un estado asociado a un registro (Activo / Inactivo).
        /// </summary>
        /// <param name="estado">Bool que representa el estado de un registro.</param>
        /// <returns>Activo si es <paramref name="estado" /> es true; de lo contrario Inactivo.</returns>
        public static string ObtenerNombreEstadoRegistro(bool estado)
        {
            return estado ? "Activo" : "Inactivo";
        }

        /// <summary>
        /// Obtiene el timepo de expiración de las variables en la cache.
        /// </summary>
        /// <returns>Retorna el tiempo de expiración.</returns>
        public static TimeSpan ObtenerTiempoExpiracionCache()
        {
            TimeSpan duracion = new TimeSpan(10, 12, 15, 50);
            return duracion;
        }

        /// <summary>
        /// Castea a SelectListItem una colección de datos.
        /// </summary>
        /// <typeparam name="T">Tipo de dato a castear.</typeparam>
        /// <param name="coleccionObjetos">Colección a castear.</param>
        /// <param name="dataText">Nombre de la propiedad que se visualizará en la vista.</param>
        /// <param name="dataValue">Nombre de la propiedad que contendrá el valor.</param>
        /// <returns>Lista de SelectListItems.</returns>
        public static List<SelectListItem> ToSelectListItem<T>(this IEnumerable<T> coleccionObjetos, Expression<Func<T, object>> dataText, Expression<Func<T, object>> dataValue, bool requerido = true)
        {
            MemberExpression memberDataText = dataText.Body as MemberExpression;

            if (memberDataText == null)
            {
                memberDataText = (dataText.Body as UnaryExpression).Operand as MemberExpression;
            }

            MemberExpression memberDataValue = dataValue.Body as MemberExpression;

            if (memberDataValue == null)
            {
                memberDataValue = (dataValue.Body as UnaryExpression).Operand as MemberExpression;
            }

            PropertyInfo propiedadDataText = memberDataText.Member as PropertyInfo;
            PropertyInfo propiedadDataValue = memberDataValue.Member as PropertyInfo;

            List<SelectListItem> listaObjetos = (from objeto in coleccionObjetos
                                                 select new SelectListItem
                                                 {
                                                     Text = propiedadDataText.GetValue(objeto, null).ToString(),
                                                     Value = Convert.ToInt32(propiedadDataValue.GetValue(objeto, null)).ToString()
                                                 }).ToList();

            if (requerido)
            {
                listaObjetos.Insert(0, new SelectListItem() { Text = "Seleccione", Value = String.Empty });
            }
            else
            {
                listaObjetos.Insert(0, new SelectListItem() { Text = "Todos", Value = String.Empty });
            }

            return listaObjetos;
        }

        /// <summary>
        /// Crea una lista SelectListItem con una coleccion de datos de un solo valor.
        /// </summary>
        /// <typeparam name="T">Tipo de dato.</typeparam>
        /// <param name="coleccionObjetos">Lista con los objetos.</param>
        /// <param name="requerido">Si el control es requerido.</param>
        /// <returns>Lista tipo SelectListItem.</returns>
        public static List<SelectListItem> ToSelectListItem<T>(this IEnumerable<T> coleccionObjetos, bool requerido = true)
        {
            List<SelectListItem> listaObjetos = (from objeto in coleccionObjetos
                                                 select new SelectListItem
                                                 {
                                                     Text = objeto.ToString(),
                                                     Value = objeto.ToString()
                                                 }).ToList();

            if (requerido)
            {
                listaObjetos.Insert(0, new SelectListItem() { Text = "Seleccione", Value = String.Empty });
            }
            else
            {
                listaObjetos.Insert(0, new SelectListItem() { Text = "Todos", Value = String.Empty });
            }

            return listaObjetos;
        }

        /// <summary>
        /// Obtiene el listado de maestros.
        /// </summary>
        /// <param name="valor">Valor a descomponer.</param>
        /// <returns>Retorna el listado del maestro.</returns>
        public static List<SelectListItem> ObtenerListaMaestro(string valor)
        {
            string[] valores = valor.Split(',');
            int inicio = int.Parse(valores[0]);
            int fin = int.Parse(valores[1]);
            int salto = int.Parse(valores[2]);
            SelectListItem item = null;
            List<SelectListItem> listaObjetos = new List<SelectListItem>();

            for (int i = inicio; i <= fin; i += salto)
            {
                item = new SelectListItem()
                {
                    Text = i.ToString(),
                    Value = i.ToString()
                };

                listaObjetos.Add(item);
            }

            return listaObjetos;
        }

        /// <summary>
        /// Almacena información en una cookie.
        /// </summary>
        /// <param name="llave">Llave de la cookie.</param>
        /// <param name="valor">Valor a almacenar en la cookie.</param>
        /// <param name="expiracion">Tiempo de expiración de la cookie.</param>
        public static void AlmacenarInformacionCookie(string llave, string valor, DateTime? expiracion = null)
        {
            if (HttpContext.Current.Request.Cookies.AllKeys.Contains(llave))
            {
                EliminarInformacionCookie(llave);
            }

            HttpCookie cookie = new HttpCookie(llave);
            cookie.Value = valor;

            if (expiracion.HasValue)
            {
                cookie.Expires = expiracion.Value;
            }

            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// Obtiene la información almacenada en una cookie.
        /// </summary>
        /// <param name="llave">Llave de la cookie.</param>
        /// <returns>Valor almacenado en la cookie. Si no existe String.Empty.</returns>
        public static string ObtenerInformacionCookie(string llave)
        {
            string valor = String.Empty;

            if (HttpContext.Current.Request.Cookies.AllKeys.Contains(llave))
            {
                valor = HttpContext.Current.Request.Cookies[llave].Value;
            }

            return valor;
        }

        /// <summary>
        /// Elimina la información de una cookie.
        /// </summary>
        /// <param name="llave">Llave de la cookie.</param>
        public static void EliminarInformacionCookie(string llave)
        {
            if (HttpContext.Current.Request.Cookies.AllKeys.Contains(llave))
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies[llave];
                cookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }

        #endregion Métodos públicos

        #region Metodos Excepciones

        /// <summary>
        /// Registra de la excepción en el log de errores configurado.
        /// </summary>
        /// <param name="excepcion">Excepción a almacenar.</param>
        public static Mensaje CapturarExcepcion(Exception excepcion)
        {
            Mensaje mensajeValidacion = ManejarExcepcionUniqueConstraint(excepcion);

            if (mensajeValidacion == null)
            {
                ErrorSignal.FromCurrentContext().Raise(excepcion, System.Web.HttpContext.Current);
                mensajeValidacion = new Mensaje(CodigoMensaje.Mensaje1000);
            }

            return mensajeValidacion;
        }

        /// <summary>
        /// Determina si la excepción generada consta de una excepción de duplicidad en base de datos.
        /// </summary>
        /// <param name="excepcion">Excepción a validar.</param>
        public static Mensaje ManejarExcepcionUniqueConstraint(Exception excepcion)
        {
            Exception exceptionHandle = excepcion;
            SqlException excepcionSql = null;
            Mensaje mensajeExcepcion = null;

            while (exceptionHandle != null)
            {
                excepcionSql = exceptionHandle as SqlException;

                if (excepcionSql != null)
                {
                    break;
                }

                exceptionHandle = exceptionHandle.InnerException;
            }

            if (excepcionSql != null)
            {
                switch (excepcionSql.Number)
                {
                    case 2627:
                        mensajeExcepcion = new Mensaje(CodigoMensaje.Mensaje1008);
                        break;
                    case 547:
                        mensajeExcepcion = new Mensaje(CodigoMensaje.Mensaje1008);
                        break;
                    case 2601:
                        mensajeExcepcion = new Mensaje(CodigoMensaje.Mensaje1009);
                        break;
                }
            }

            return mensajeExcepcion;
        }

        #endregion Metodos Excepciones

        #region Metodos Envio correo

        /// <summary>
        /// Realiza el envío de un correo electrónico.
        /// </summary>
        /// <param name="mensaje">Mensaje a enviar en el correo electrónico.</param>
        /// <param name="asunto">Asunto del correo electrónico.</param>
        /// <param name="destinatarios">Destinatarios a enviar notificación. Si son varios, deben estar separados por coma (,).</param>
        public static void EnviarCorreoElectronico(string mensaje, string asunto, string ServidorSmtpCorreoElectronico, int puertoServidor, string UsuarioCorreoElectronico, string ClaveAccesoCorreoElectronico, string AliasCorreoElectronico, params string[] destinatarios)
        {
            var fromAddress = new MailAddress(UsuarioCorreoElectronico, "ISM Libellus");
            var toAddress = new MailAddress(destinatarios[0], "Usuario aplicación libellus");

            var smtp = new SmtpClient
            {
                Host = ServidorSmtpCorreoElectronico,
                Port = puertoServidor,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, ClaveAccesoCorreoElectronico)

            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = asunto,
                Body = mensaje,
                IsBodyHtml = true
            })
            {
                smtp.Send(message);
            }
        }

        /// <summary>
        /// Obtiene la ruta completa del servidor web.
        /// </summary>
        /// <param name="ruta">Ruta dinámica a obtener.</param>
        /// <returns>Ruta completa del servidor web.</returns>
        public static string ObtenerRutaCompleta(string ruta)
        {
            return HttpContext.Current.Server.MapPath(ruta);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoverCaracterClave(string str)
        {
            return Regex.Replace(str, "/", "", RegexOptions.Compiled);
        }

        #endregion

    }
}