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
    using System.Net.Mail;
    using System.Reflection;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;

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
        /// Retorna la url de la imagen almacenada.
        /// </summary>
        /// <param name="imagen">Imagen representada en bytes</param>
        /// <returns>Url con formato del servidor.</returns>
        public static string ObtenerUrlImagenServidor(byte[] imagen)
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
        /// Metodo para obtener la cadena de conexion a la base de datos del colegio.
        /// </summary>
        /// <param name="conexionColegio"><Parametros para la cadena de conexion./param>
        /// <returns>Retorna la cadena de conexion.</returns>
        public static string ObtenerCadenaConexionColegio(ParametroConexionColegio conexionColegio)
        {
            string connectionString = string.Empty;
            string servidor = Desencriptar(conexionColegio.Servidor);
            string usuario = Desencriptar(conexionColegio.NombreUsuario);
            string contrasenia = Desencriptar(conexionColegio.Contrasena);
            string baseDatos = Desencriptar(conexionColegio.BaseDatos);
            string puerto = conexionColegio.Puerto;
            connectionString = string.Format("Server={0},{1};Database={2};User ID={3};Password={4};Trusted_Connection=False;Encrypt=True;Connection Timeout=30;MultipleActiveResultSets=True;App=EntityFramework", servidor, puerto, baseDatos, usuario, contrasenia);
            return connectionString;
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

        #endregion Métodos públicos

        #region Métodos Encriptar

        /// <summary>
        /// Metodo para decodificar un valor.
        /// </summary>
        /// <param name="cadenaEntrada">Valor para decodificar.</param>
        /// <returns>Retorna valor decodificado.</returns>
        public static string Desencriptar(string cadenaEntrada)
        {
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            byte[] datosCifrados = Convert.FromBase64String(cadenaEntrada);
            PasswordDeriveBytes llave = new PasswordDeriveBytes(llaveEncripcion, salt);

            using (ICryptoTransform decryptor = rijndaelCipher.CreateDecryptor(llave.GetBytes(32), llave.GetBytes(16)))
            {
                using (MemoryStream memoryStream = new MemoryStream(datosCifrados))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        byte[] textoPlano = new byte[datosCifrados.Length];
                        int contador = cryptoStream.Read(textoPlano, 0, textoPlano.Length);
                        return Encoding.Unicode.GetString(textoPlano, 0, contador);
                    }
                }
            }
        }

        /// <summary>
        /// Metodo para codificar un valor.
        /// </summary>
        /// <param name="cadenaEntrada">Valor para codificar.</param>
        /// <returns>Retorna el valor codificado.</returns>
        public static string Encriptar(string cadenaEntrada)
        {
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            byte[] textoPlano = Encoding.Unicode.GetBytes(cadenaEntrada);
            PasswordDeriveBytes llave = new PasswordDeriveBytes(llaveEncripcion, salt);

            using (ICryptoTransform encryptor = rijndaelCipher.CreateEncryptor(llave.GetBytes(32), llave.GetBytes(16)))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(textoPlano, 0, textoPlano.Length);
                        cryptoStream.FlushFinalBlock();
                        return Convert.ToBase64String(memoryStream.ToArray());
                    }
                }
            }
        }

        #endregion Métodos Encriptar

        #region Métodos cookie

        /// <summary>
        /// Metodo para adicionar de una cookie.
        /// </summary>
        /// <param name="nombreCookie">Nombre de la cookie.</param>
        /// <param name="valor">Valor de la cookie</param>
        public static void AlmacenarCookie(string nombreCookie, string valor)
        {
            HttpCookie cookie = new HttpCookie(nombreCookie);
            cookie.Value = valor;
            cookie.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// Almacena la información del usuario.
        /// </summary>
        /// <param name="nombreCookie">Nombre de la cookie.</param>
        /// <param name="usuario">Usuario para almacenar.</param>
        public static void AlmacenarUsuarioCookie(string nombreCookie, UsuarioAplicacion usuario)
        {
            if (HttpContext.Current.Request.Cookies != null)
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies[nombreCookie];

                if (cookie == null)
                {
                    cookie = new HttpCookie(nombreCookie);
                    cookie[ConstantesCookie.NombreUsuario] = usuario.NombreUsuario;
                    cookie[ConstantesCookie.Nombre] = usuario.Nombre;
                    cookie.Expires = DateTime.Now.AddDays(1);
                    HttpContext.Current.Response.Cookies.Add(cookie);
                }
                else
                {
                    cookie[ConstantesCookie.Sede] = usuario.Sede;
                }
            }
        }

        /// <summary>
        /// Método para obtener una cookie.
        /// </summary>
        /// <param name="nombreCookie">Nombre de la cookie que se obtiene.</param>
        /// <returns>Retorna el valor de la cookie</returns>
        public static object ObtenerCookie(string nombreCookie)
        {
            object valor = new object();

            if (HttpContext.Current.Request.Cookies != null)
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies[nombreCookie];

                if (cookie != null)
                {
                    valor = HttpContext.Current.Server.HtmlEncode(cookie.Value);
                }
            }

            return valor;
        }

        /// <summary>
        /// Obtiene la entidad usuario aplicación.
        /// </summary>
        /// <param name="nombreCookie">Nombre para buscar la cookie.</param>
        /// <returns>Retorna la </returns>
        public static object ObtenerCookieUsuario(string nombreCookie)
        {
            UsuarioAplicacion usuario = new UsuarioAplicacion();

            if (HttpContext.Current.Request.Cookies[nombreCookie] != null)
            {
                if (HttpContext.Current.Request.Cookies[nombreCookie][ConstantesCookie.NombreUsuario] != null)
                {
                    usuario.NombreUsuario = HttpContext.Current.Request.Cookies[nombreCookie][ConstantesCookie.NombreUsuario];
                    usuario.Nombre = HttpContext.Current.Request.Cookies[nombreCookie][ConstantesCookie.Nombre];
                    usuario.Sede = HttpContext.Current.Request.Cookies[nombreCookie][ConstantesCookie.Sede];
                }
            }

            return usuario;
        }

        #endregion Métodos cookie

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
                    case 2601:
                        mensajeExcepcion = new Mensaje(CodigoMensaje.Mensaje1008);
                        break;

                    case 547:
                        mensajeExcepcion = new Mensaje(CodigoMensaje.Mensaje1009);
                        break;
                }
            }

            return mensajeExcepcion;
        }

        #endregion Metodos Excepciones

        #region Enviar correo

        /// <summary>
        /// Realiza el envío de un correo electrónico.
        /// </summary>
        /// <param name="mensaje">Mensaje a enviar en el correo electrónico.</param>
        /// <param name="asunto">Asunto del correo electrónico.</param>
        /// <param name="destinatarios">Destinatarios a enviar notificación. Si son varios, deben estar separados por coma (,).</param>
        public static void EnviarCorreoElectronico(string mensaje, string asunto, params string[] destinatarios)
        {
            using (MailMessage correoElectronico = new MailMessage())
            {
                SmtpClient clienteSmtp = new SmtpClient(ConfiguracionApp.ServidorSmtpCorreoElectronico, ConfiguracionApp.PuertoSmtpCorreoElectronico);
                clienteSmtp.Credentials = new NetworkCredential(ConfiguracionApp.UsuarioCorreoElectronico, ConfiguracionApp.ClaveAccesoCorreoElectronico);
                clienteSmtp.EnableSsl = true;

                correoElectronico.From = new MailAddress(ConfiguracionApp.UsuarioCorreoElectronico, ConfiguracionApp.AliasCorreoElectronico);
                correoElectronico.To.Add(String.Join(",", destinatarios));
                correoElectronico.IsBodyHtml = true;
                correoElectronico.Subject = asunto;
                correoElectronico.Body = mensaje;

                clienteSmtp.Send(correoElectronico);
            }
        }

        #endregion
    }
}