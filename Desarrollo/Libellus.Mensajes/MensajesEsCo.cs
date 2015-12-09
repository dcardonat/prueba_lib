namespace Libellus.Mensajes
{
    /// <summary>
    /// Define los mensajes de negocio de la aplicación en el idioma Español Colombia.
    /// </summary>
    internal class MensajesEsCo
    {
        #region Mensajes de negocio

        /// <summary>
        /// La información se almacenó correctamente.
        /// </summary>
        public static Mensaje Mensaje001
        {
            get
            {
                return new Mensaje("001", "La información se ingresó correctamente.", TipoMensaje.Informativo);
            }
        }

        /// <summary>
        /// La información se editó correctamente.
        /// </summary>
        public static Mensaje Mensaje002
        {
            get
            {
                return new Mensaje("002", "La información se actualizó correctamente.", TipoMensaje.Informativo);
            }
        }

        /// <summary>
        /// La información solicitada no existe o fue eliminada.
        /// </summary>
        public static Mensaje Mensaje003
        {
            get
            {
                return new Mensaje("003", "La información solicitada no existe o fue eliminada.", TipoMensaje.Advertencia);
            }
        }

        /// <summary>
        /// La información solicitada no existe o fue eliminada.
        /// </summary>
        public static Mensaje Mensaje004
        {
            get
            {
                return new Mensaje("004", "La información se eliminó correctamente.", TipoMensaje.Informativo);
            }
        }

        /// <summary>
        /// El grado {0} ya se encuentra asociado al nivel {1}. Por favor verifique.
        /// </summary>
        public static Mensaje Mensaje005
        {
            get
            {
                return new Mensaje("005", "El grado {0} ya se encuentra asociado al nivel {1}. Por favor verifique.", TipoMensaje.Advertencia);
            }
        }

        /// <summary>
        /// Grado asociado correctamente.
        /// </summary>
        public static Mensaje Mensaje006
        {
            get
            {
                return new Mensaje("006", "Grado asociado correctamente.", TipoMensaje.Informativo);
            }
        }

        /// <summary>
        /// El Nombre de usuario ya existe.
        /// </summary>
        public static Mensaje Mensaje007
        {
            get
            {
                return new Mensaje("007", "El Nombre de usuario ya existe.", TipoMensaje.Advertencia);
            }
        }

        /// <summary>
        /// El Correo y el correo alterno no deben coincidir.
        /// </summary>
        public static Mensaje Mensaje008
        {
            get
            {
                return new Mensaje("008", "El Correo y el correo alterno no deben coincidir.", TipoMensaje.Advertencia);
            }
        }

        /// <summary>
        /// El tipo de identificación e identificación ya existen para otro usuario.
        /// </summary>
        public static Mensaje Mensaje009
        {
            get
            {
                return new Mensaje("009", "El tipo de identificación e identificación ya existen para otro usuario.", TipoMensaje.Advertencia);
            }
        }

        /// <summary>
        /// El nivel educativo {0} en el horario {1} para el año {2}, ya se encuentra parametrizado. Verifique su información.
        /// </summary>
        public static Mensaje Mensaje010
        {
            get
            {
                return new Mensaje("010", "El nivel educativo {0} en el horario {1} para el año {2}, ya se encuentra parametrizado. Verifique su información.", TipoMensaje.Advertencia);
            }
        }

        /// <summary>
        /// Ya se ha configurado la información para el mismo aspecto, año e intensidad horaria. Por favor verifique.
        /// </summary>
        public static Mensaje Mensaje011
        {
            get
            {
                return new Mensaje("011", "Ya se ha configurado la información para el mismo aspecto, año e intensidad horaria. Por favor verifique.", TipoMensaje.Advertencia);
            }
        }

        /// <summary>
        /// Ya existe un registro de año lectivo para el año seleccionado. Por favor verifique.
        /// </summary>
        public static Mensaje Mensaje012
        {
            get
            {
                return new Mensaje("012", "Ya existe un registro de año lectivo para el año seleccionado. Por favor verifique.", TipoMensaje.Error);
            }
        }


        /// <summary>
        /// El año de cierre debe ser mayor o igual al año lectivo seleccionado. Por favor verifique.
        /// </summary>
        public static Mensaje Mensaje013
        {
            get
            {
                return new Mensaje("013", "El año de cierre debe ser mayor o igual al año lectivo seleccionado. Por favor verifique.", TipoMensaje.Error);
            }
        }

        /// <summary>
        /// Solo se permite eliminar registros de años lectivos mayores o iguales al año actual. Por favor verifique.
        /// </summary>
        public static Mensaje Mensaje014
        {
            get
            {
                return new Mensaje("014", "Solo se permite eliminar registros de años lectivos mayores o iguales al año actual. Por favor verifique.", TipoMensaje.Error);
            }
        }

        /// <summary>
        /// El año ingresado en 'Fecha de inicio' debe ser igual al año ingresado. Por favor verifique.
        /// </summary>
        public static Mensaje Mensaje015
        {
            get
            {
                return new Mensaje("015", "El año ingresado en 'Fecha de inicio' debe ser igual al año ingresado. Por favor verifique", TipoMensaje.Error);
            }
        }

        /// <summary>
        /// La fecha de cierre debe ser mayor a la fecha de inicio del año lectivo. Por favor verifique.
        /// </summary>
        public static Mensaje Mensaje016
        {
            get
            {
                return new Mensaje("016", "La fecha de cierre debe ser mayor a la fecha de inicio del año lectivo. Por favor verifique.", TipoMensaje.Error);
            }
        }

        /// <summary>
        /// La fecha de cierre de año lectivo debe ser mayor a la fecha actual. Por favor verifique.
        /// </summary>
        public static Mensaje Mensaje017
        {
            get
            {
                return new Mensaje("017", "La fecha de cierre de año lectivo debe ser mayor a la fecha actual. Por favor verifique.", TipoMensaje.Error);
            }
        }

        /// <summary>
        /// La fecha de inicio de la apertura debe ser mayor a la fecha de cierre del periodo. Por favor verifique.
        /// </summary>
        public static Mensaje Mensaje018
        {
            get
            {
                return new Mensaje("018", "La fecha de inicio de la apertura debe ser mayor a la fecha de cierre del periodo. Por favor verifique.", TipoMensaje.Error);
            }
        }

        /// <summary>
        /// Existen campos requeridos sin diligenciar. Por favor verifique cada una de las secciones.
        /// </summary>
        public static Mensaje Mensaje019
        {
            get
            {
                return new Mensaje("019", "Existen campos requeridos sin diligenciar. Por favor verifique cada una de las secciones.", TipoMensaje.Advertencia);
            }
        }

        /// <summary>
        /// Se presenta un error en las fechas del periodo. Verifique las fechas de otros periodos que estén configurados.
        /// </summary>
        public static Mensaje Mensaje020
        {
            get
            {
                return new Mensaje("020", "Se presenta un error en las fechas del periodo. Verifique las fechas de otros periodos que estén configurados.", TipoMensaje.Error);
            }
        }

        /// <summary>
        /// Esta intentando configurar grados que existen en otra parametrización del mismo año. Por favor verifique.
        /// </summary>
        public static Mensaje Mensaje021
        {
            get
            {
                return new Mensaje("021", "Esta intentando configurar grados que existen en otra parametrización del mismo año. Por favor verifique.", TipoMensaje.Advertencia);
            }
        }

        /// <summary>
        /// El año del periodo no corresponde al año de la parametrización. Por favor verifique.
        /// </summary>
        public static Mensaje Mensaje022
        {
            get
            {
                return new Mensaje("022", "El año del periodo no corresponde al año de la parametrización. Por favor verifique.", TipoMensaje.Advertencia);
            }
        }

        /// <summary>
        /// Los datos de acceso se enviaron exitosamente al correo electrónico.
        /// </summary>
        public static Mensaje Mensaje023
        {
            get
            {
                return new Mensaje("023", "Los datos de acceso se enviaron exitosamente al correo electrónico.", TipoMensaje.Informativo);
            }
        }

        /// <summary>
        /// El nombre de usuario no existe. Por favor verifique e intente nuevamente.
        /// </summary>
        public static Mensaje Mensaje024
        {
            get
            {
                return new Mensaje("024", "El nombre de usuario no existe. Por favor verifique e intente nuevamente.", TipoMensaje.Advertencia);
            }
        }

        /// <summary>
        /// El usuario no tiene una cuenta de correo electrónico asociado. Por favor contacte al administrador del sistema.
        /// </summary>
        public static Mensaje Mensaje025
        {
            get
            {
                return new Mensaje("025", "El usuario no tiene una cuenta de correo electrónico asociado. Por favor contacte al administrador del sistema.", TipoMensaje.Advertencia);
            }
        }

        /// <summary>
        /// El usuario se encuentra bloqueado en el sistema. Por favor contacte al administrador.
        /// </summary>
        public static Mensaje Mensaje026
        {
            get
            {
                return new Mensaje("026", "El usuario se encuentra bloqueado en el sistema. Por favor contacte al administrador.", TipoMensaje.Advertencia);
            }
        }

        /// <summary>
        /// La nueva contraseña y su confirmación no coinciden.
        /// </summary>
        public static Mensaje Mensaje027
        {
            get
            {
                return new Mensaje("027", "La nueva contraseña y su confirmación no coinciden.", TipoMensaje.Error);
            }
        }

        /// <summary>
        /// La contraseña actual no es correcta.
        /// </summary>
        public static Mensaje Mensaje028
        {
            get
            {
                return new Mensaje("028", "La contraseña actual no es correcta.", TipoMensaje.Error);
            }
        }

        /// <summary>
        /// El año ingresado no puede ser menor al año actual. Por favor verifique.
        /// </summary>
        public static Mensaje Mensaje029
        {
            get
            {
                return new Mensaje("029", "El año ingresado no puede ser menor al año actual. Por favor verifique.", TipoMensaje.Error);
            }
        }

        /// <summary>
        /// El grupo {0} ya se encuentra asociado al grado {1}. Por favor verifique.
        /// </summary>
        public static Mensaje Mensaje030
        {
            get
            {
                return new Mensaje("030", "El grupo {0} ya se encuentra asociado al grado {1}. Por favor verifique.", TipoMensaje.Advertencia);
            }
        }

        /// <summary>
        /// Se deben de configurar los documentos para el nivel y el rol. Por favor verifique.
        /// </summary>
        public static Mensaje Mensaje031
        {
            get
            {
                return new Mensaje("031", "Se deben de configurar los documentos para el nivel y el rol. Por favor verifique.", TipoMensaje.Advertencia);
            }
        }


        #endregion

        #region Mensajes UI

        /// <summary>
        /// Ocurrió un error inesperado. Comuníquese con el administrador del sistema.
        /// </summary>
        public static Mensaje Mensaje1000
        {
            get
            {
                return new Mensaje("1000", "Ocurrió un error inesperado. Comuníquese con el administrador del sistema.", TipoMensaje.Error);
            }
        }

        /// <summary>
        /// Campo requerido.
        /// </summary>
        public static Mensaje Mensaje1001
        {
            get
            {
                return new Mensaje("1001", "Campo requerido.", TipoMensaje.Advertencia);
            }
        }

        /// <summary>
        /// Máximo {1} caracteres.
        /// </summary>
        public static Mensaje Mensaje1002
        {
            get
            {
                return new Mensaje("1002", "Máximo {1} caracteres.", TipoMensaje.Advertencia);
            }
        }

        /// <summary>
        /// Al salir de esta pantalla perderá la información que no ha almacenado. ¿Desea continuar?.
        /// </summary>
        public static Mensaje Mensaje1003
        {
            get
            {
                return new Mensaje("1003", "Al salir de esta pantalla perderá la información que no ha almacenado. ¿Desea continuar?.", TipoMensaje.Advertencia);
            }
        }

        /// <summary>
        /// Campo numérico.
        /// </summary>
        public static Mensaje Mensaje1004
        {
            get
            {
                return new Mensaje("1004", "Campo numérico.", TipoMensaje.Advertencia);
            }
        }

        /// <summary>
        /// No existe información para mostrar.
        /// </summary>
        public static Mensaje Mensaje1005
        {
            get
            {
                return new Mensaje("1005", "No existe información para mostrar.", TipoMensaje.Advertencia);
            }
        }

        /// <summary>
        /// Los valores deben estar entre {1} y {2}.
        /// </summary>
        public static Mensaje Mensaje1006
        {
            get
            {
                return new Mensaje("1006", "Los valores deben estar entre {1} y {2}.", TipoMensaje.Advertencia);
            }
        }

        /// <summary>
        /// Información incorrecta. Por favor verifique
        /// </summary>
        public static Mensaje Mensaje1007
        {
            get
            {
                return new Mensaje("1007", "Información incorrecta. Por favor verifique", TipoMensaje.Error);
            }
        }

        /// <summary>
        /// Está intentando ingresar un registro duplicado.
        /// </summary>
        public static Mensaje Mensaje1008
        {
            get
            {
                return new Mensaje("1008", "Está intentando ingresar un registro duplicado.", TipoMensaje.Advertencia);
            }
        }

        /// <summary>
        /// Por favor verifique. El registro que desea eliminar tiene información asociada.
        /// </summary>
        public static Mensaje Mensaje1009
        {
            get
            {
                return new Mensaje("1009", "Por favor verifique. El registro que desea eliminar tiene información asociada.", TipoMensaje.Advertencia);
            }
        }

        /// <summary>
        /// El formato debe ser hh:mm de 12 horas.
        /// </summary>
        public static Mensaje Mensaje1010
        {
            get
            {
                return new Mensaje("1010", "El formato debe ser hh:mm de 12 horas.", TipoMensaje.Advertencia);
            }
        }

        /// <summary>
        /// Debe ser mayor o igual que {0}.
        /// </summary>
        public static Mensaje Mensaje1011
        {
            get
            {
                return new Mensaje("1011", "Debe ser mayor o igual que {0}.", TipoMensaje.Advertencia);
            }
        }

        /// <summary>
        /// Formato incorrecto.
        /// </summary>
        public static Mensaje Mensaje1012
        {
            get
            {
                return new Mensaje("1012", "Formato incorrecto.", TipoMensaje.Advertencia);
            }
        }

        /// <summary>
        /// Va a eliminar el registro seleccionado. ¿Desea continuar?.
        /// </summary>
        public static Mensaje Mensaje1013
        {
            get
            {
                return new Mensaje("1013", "¿Está seguro de eliminar el registro seleccionado?", TipoMensaje.Advertencia);
            }
        }

        /// <summary>
        /// No cumple con la mayoría de edad.
        /// </summary>
        public static Mensaje Mensaje1014
        {
            get
            {
                return new Mensaje("1014", "No cumple con la mayoría de edad.", TipoMensaje.Advertencia);
            }
        }

        /// <summary>
        /// El valor debe estar entre el 0 y el 100 porciento
        /// </summary>
        public static Mensaje Mensaje1015
        {
            get
            {
                return new Mensaje("1015", "El formato debe ser 000,00", TipoMensaje.Advertencia);
            }
        }

        /// <summary>
        /// Existen valores por fuera del rango de calificación mínima y máxima. Por favor valide.
        /// </summary>
        public static Mensaje Mensaje1016
        {
            get
            {
                return new Mensaje("1016", "Existen valores por fuera del rango de calificación mínima y máxima. Por favor valide", TipoMensaje.Error);
            }
        }

        /// <summary>
        /// La nota mínima debe ser menor a la nota máxima. Por favor valide.
        /// </summary>
        public static Mensaje Mensaje1017
        {
            get
            {
                return new Mensaje("1017", "La nota mínima debe ser menor a la nota máxima. Por favor valide.", TipoMensaje.Error);
            }
        }

        /// <summary>
        /// Todos los intervalos de notas de los niveles de desempeño deben ser consecutivos. Por favor valide.
        /// </summary>
        public static Mensaje Mensaje1018
        {
            get
            {
                return new Mensaje("1018", "Todos los intervalos de notas de los niveles de desempeño deben ser consecutivos. Por favor valide.", TipoMensaje.Error);
            }
        }

        /// <summary>
        /// El estudiante ha sido matriculado con éxito.
        /// </summary>
        public static Mensaje Mensaje1019
        {
            get
            {
                return new Mensaje("1019", "El estudiante ha sido matriculado con éxito.", TipoMensaje.Informativo);
            }
        }

        
        #endregion
    }
}
