namespace Libellus.Mensajes
{
    /// <summary>
    /// Establece los mensajes estáticos del negocio y de IU.
    /// </summary>
    public abstract class MensajesEstaticos
    {
        #region Mensajes estáticos de negocio

        /// <summary>
        /// La información se almacenó correctamente.
        /// </summary>
        public static string Mensaje001
        {
            get
            {
                return ObtenerTextoMensaje("001");
            }
        }

        /// <summary>
        /// La información se almacenó correctamente.
        /// </summary>
        public static string Mensaje002
        {
            get
            {
                return ObtenerTextoMensaje("002");
            }
        }

        /// <summary>
        /// El tipo de identificación e identificación ya existen para otro usuario.
        /// </summary>
        public static string Mensaje006
        {
            get
            {
                return ObtenerTextoMensaje("006");
            }
        }

        /// <summary>
        /// El Nombre de usuario ya existe.
        /// </summary>
        public static string Mensaje007
        {
            get
            {
                return ObtenerTextoMensaje("007");
            }
        }

        /// <summary>
        /// El Correo y el correo alterno no deben coincidir.
        /// </summary>
        public static string Mensaje008
        {
            get
            {
                return ObtenerTextoMensaje("008");
            }
        }

        /// <summary>
        /// El tipo de identificación e identificación ya existen para otro usuario.
        /// </summary>
        public static string Mensaje009
        {
            get
            {
                return ObtenerTextoMensaje("009");
            }
        }

        /// <summary>
        /// Se presenta un error en las fechas del periodo. Verifique las fechas de otros periodos que estén configurados.
        /// </summary>
        public static string Mensaje020
        {
            get
            {
                return ObtenerTextoMensaje("020");
            }
        }

        /// <summary>
        /// El año del periodo no corresponde al año de la parametrización. Por favor verifique.
        /// </summary>
        public static string Mensaje022
        {
            get
            {
                return ObtenerTextoMensaje("022");
            }
        }

        /// <summary>
        /// Los datos de acceso se enviaron exitosamente al correo electrónico.
        /// </summary>
        public static string Mensaje023
        {
            get
            {
                return ObtenerTextoMensaje("023");
            }
        }

        /// <summary>
        /// El nombre de usuario no existe. Por favor verifique e intente nuevamente.
        /// </summary>
        public static string Mensaje024
        {
            get
            {
                return ObtenerTextoMensaje("024");
            }
        }

        /// <summary>
        /// El usuario no tiene una cuenta de correo electrónico asociado. Por favor contacte al administrador del sistema.
        /// </summary>
        public static string Mensaje025
        {
            get
            {
                return ObtenerTextoMensaje("025");
            }
        }

        /// <summary>
        /// El usuario se encuentra bloqueado en el sistema. Por favor contacte al administrador.
        /// </summary>
        public static string Mensaje026
        {
            get
            {
                return ObtenerTextoMensaje("026");
            }
        }

        /// <summary>
        /// La nueva contraseña y su confirmación no coinciden.
        /// </summary>
        public static string Mensaje027
        {
            get
            {
                return ObtenerTextoMensaje("027");
            }
        }

        /// <summary>
        /// La contraseña actual no es correcta.
        /// </summary>
        public static string Mensaje028
        {
            get
            {
                return ObtenerTextoMensaje("028");
            }
        }

        /// <summary>
        /// Ocurrió un error inesperado. Comuníquese con el administrador del sistema.
        /// </summary>
        public static string Mensaje1000
        {
            get
            {
                return ObtenerTextoMensaje("1000");
            }
        }

        /// <summary>
        /// Campo requerido.
        /// </summary>
        public static string Mensaje1001
        {
            get
            {
                return ObtenerTextoMensaje("1001");
            }
        }

        /// <summary>
        /// Máximo {1} caracteres.
        /// </summary>
        public static string Mensaje1002
        {
            get
            {
                return ObtenerTextoMensaje("1002");
            }
        }

        /// <summary>
        /// Al salir de esta pantalla perderá la información que no ha almacenado. ¿Desea continuar?.
        /// </summary>
        public static string Mensaje1003
        {
            get
            {
                return ObtenerTextoMensaje("1003");
            }
        }

        /// <summary>
        /// Campo numérico.
        /// </summary>
        public static string Mensaje1004
        {
            get
            {
                return ObtenerTextoMensaje("1004");
            }
        }

        /// <summary>
        /// No existe información para mostrar.
        /// </summary>
        public static string Mensaje1005
        {
            get
            {
                return ObtenerTextoMensaje("1005");
            }
        }

        /// <summary>
        /// Los valores deben estar entre {1} y {2}.
        /// </summary>
        public static string Mensaje1006
        {
            get
            {
                return ObtenerTextoMensaje("1006");
            }
        }

        /// <summary>
        /// Información incorrecta. Por favor verifique
        /// </summary>
        public static string Mensaje1007
        {
            get
            {
                return ObtenerTextoMensaje("1007");
            }
        }

        /// <summary>
        /// Está intentando ingresar un registro duplicado.
        /// </summary>
        public static string Mensaje1008
        {
            get
            {
                return ObtenerTextoMensaje("1008");
            }
        }

        /// <summary>
        /// El formato debe ser hh:mm de 12 horas.
        /// </summary>
        public static string Mensaje1010
        {
            get
            {
                return ObtenerTextoMensaje("1010");
            }
        }

        /// <summary>
        /// Debe ser mayor o igual que {0}.
        /// </summary>
        public static string Mensaje1011
        {
            get
            {
                return ObtenerTextoMensaje("1011");
            }
        }

        /// <summary>
        /// Ocurrió un error inesperado. Comuníquese con el administrador del sistema.
        /// </summary>
        public static string Mensaje1012
        {
            get
            {
                return ObtenerTextoMensaje("1012");
            }
        }

        /// <summary>
        /// Va a eliminar el registro seleccionado. ¿Desea continuar?.
        /// </summary>
        public static string Mensaje1013
        {
            get
            {
                return ObtenerTextoMensaje("1013");
            }
        }

        /// <summary>
        /// No cumple con la mayoría de edad.
        /// </summary>
        public static string Mensaje1014
        {
            get
            {
                return ObtenerTextoMensaje("1014");
            }
        }

        /// <summary>
        /// El valor debe estar entre el 0 y el 100 porciento
        /// </summary>
        public static string Mensaje1015
        {
            get
            {
                return ObtenerTextoMensaje("1015");
            }
        }

        /// <summary>
        /// Existen valores por fuera del rango de calificación mínima y máxima
        /// </summary>
        public static string Mensaje1016
        {
            get
            {
                return ObtenerTextoMensaje("1016");
            }
        }

        /// <summary>
        ///  La nota mínima debe ser menor a la nota máxima
        /// </summary>
        public static string Mensaje1017
        {
            get
            {
                return ObtenerTextoMensaje("1017");
            }
        }

        /// <summary>
        ///  El intervalo debe ser consecutivo.
        /// </summary>
        public static string Mensaje1018
        {
            get
            {
                return ObtenerTextoMensaje("1018");
            }
        }

        #endregion

        #region Métodos privados

        /// <summary>
        /// Obtiene el texto de los mensajes de validación de la interfáz de usuario.
        /// </summary>
        /// <param name="codigoMensaje">Código del mensaje a leer.</param>
        /// <returns>Texto del mensaje a leer.</returns>
        private static string ObtenerTextoMensaje(string codigoMensaje)
        {
            Mensaje mensaje = new Mensaje(codigoMensaje);
            return mensaje.Texto;
        }

        #endregion
    }
}
