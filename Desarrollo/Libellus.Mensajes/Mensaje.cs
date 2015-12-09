namespace Libellus.Mensajes
{
    using System;
    using System.Reflection;

    /// <summary>
    /// Permite almacenar la información de un mensaje que puede ser generado por una operación de negocio.
    /// </summary>
    public class Mensaje : MensajesEstaticos
    {
        #region Propiedades

        /// <summary>
        /// Obtiene el código del mensaje.
        /// </summary>
        public string Codigo { get; private set; }

        /// <summary>
        /// Obtiene el tipo del mensaje.
        /// </summary>
        public TipoMensaje Tipo { get; private set; }

        /// <summary>
        /// Obtiene el texto del mensaje.
        /// </summary>
        public string Texto { get; private set; }

        #endregion

        #region Constructores públicos

        /// <summary>
        /// Inicializa una instancia de tipo Mensaje con el código del mensaje asociado.
        /// </summary>
        /// <param name="codigo">Código del mensaje a consultar.</param>
        public Mensaje(string codigo)
            : this(codigo, null)
        { }

        /// <summary>
        /// Inicializa una instancia de tipo Mensaje con el código del mensaje asociado y los parámetros a concatenar en el mensaje.
        /// </summary>
        /// <param name="codigo">Código del mensaje a consultar.</param>
        /// <param name="parametros">Parámetros a concatenar en el mensaje.</param>
        public Mensaje(string codigo, params object[] parametros)
        {
            Type idiomaMensaje = typeof(MensajesEsCo);

            if (idiomaMensaje == null)
            {
                throw new Exception("El idioma especificado no se encuentra configurado.");
            }
            else
            {
                Mensaje mensaje = idiomaMensaje.GetProperty(String.Format("Mensaje{0}", codigo)).GetValue(idiomaMensaje, null) as Mensaje;

                this.Codigo = mensaje.Codigo;
                this.Tipo = mensaje.Tipo;
                this.Texto = parametros == null ? mensaje.Texto : String.Format(mensaje.Texto, parametros);
            }
        }

        #endregion

        #region Constructores internos

        /// <summary>
        /// Inicializa una nueva instancia de tipo Mensaje con el código del mensaje asociado, su texto y su tipo.
        /// </summary>
        /// <param name="codigo">Código del mensaje a consultar.</param>
        /// <param name="texto">Texto del mensaje.</param>
        /// <param name="tipoMensaje">Tipo del mensaje.</param>
        internal Mensaje(string codigo, string texto, TipoMensaje tipoMensaje)
        {
            this.Codigo = codigo;
            this.Texto = texto;
            this.Tipo = tipoMensaje;
        }

        #endregion
    }
}
