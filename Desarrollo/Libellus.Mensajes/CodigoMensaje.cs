namespace Libellus.Mensajes
{
    /// <summary>
    /// Define los códigos de los mensajes de negocio del sistema.
    /// </summary>
    public static class CodigoMensaje
    {
        #region Mensajes de negocio

        /// <summary>
        /// La información se ingresó correctamente.
        /// </summary>
        public const string Mensaje001 = "001";

        /// <summary>
        /// La información se actualizó correctamente.
        /// </summary>
        public const string Mensaje002 = "002";

        /// <summary>
        /// La información solicitada no existe o fue eliminada.
        /// </summary>
        public const string Mensaje003 = "003";

        /// <summary>
        /// La información se eliminó correctamente.
        /// </summary>
        public const string Mensaje004 = "004";

        /// <summary>
        /// El grado {0} ya se encuentra asociado al nivel {1}. Por favor verifique.
        /// </summary>
        public const string Mensaje005 = "005";

        /// <summary>
        /// Grado asociado correctamente.
        /// </summary>
        public const string Mensaje006 = "006";

        /// <summary>
        /// El Nombre de usuario ya existe.
        /// </summary>
        public const string Mensaje007 = "007";

        /// <summary>
        /// El Correo y el correo alterno no deben coincidir.
        /// </summary>
        public const string Mensaje008 = "008";

        /// <summary>
        /// El tipo de identificación e identificación ya existen para otro usuario.
        /// </summary>
        public const string Mensaje009 = "009";

        /// <summary>
        /// El nivel educativo {0} en el horario {1} para el año {2}, ya se encuentra parametrizado. Verifique su información.
        /// </summary>
        public const string Mensaje010 = "010";

        /// <summary>
        /// Ya se ha configurado la información para el mismo aspecto, año e intensidad horaria. Por favor verifique.
        /// </summary>
        public const string Mensaje011 = "011";

        /// <summary>
        /// Ya existe un registro de año lectivo para el año seleccionado. Por favor verifique.
        /// </summary>
        public const string Mensaje012 = "012";

        /// <summary>
        /// El año de cierre debe ser mayor o igual al año lectivo seleccionado. Por favor verifique.
        /// </summary>
        public const string Mensaje013 = "013";

        /// <summary>
        /// Solo se permite eliminar registros de años lectivos mayores o iguales al año actual. Por favor verifique.
        /// </summary>
        public const string Mensaje014 = "014";

        /// <summary>
        /// El año de inicio del año lectivo debe ser igual al año ingresado. Por favor verifique.
        /// </summary>
        public const string Mensaje015 = "015";

        /// <summary>
        /// La fecha de cierre debe ser mayor a la fecha de inicio del año lectivo. Por favor verifique.
        /// </summary>
        public const string Mensaje016 = "016";

        /// <summary>
        /// La fecha de cierre de año lectivo debe ser mayor a la fecha actual. Por favor verifique.
        /// </summary>
        public const string Mensaje017 = "017";

        /// <summary>
        /// La fecha de inicio de la apertura debe ser mayor a la fecha de cierre del periodo. Por favor verifique.
        /// </summary>
        public const string Mensaje018 = "018";

        /// <summary>
        /// Existen campos requeridos sin diligenciar. Por favor verifique cada una de las secciones.
        /// </summary>
        public const string Mensaje019 = "019";

        /// <summary>
        /// Se presenta un error en las fechas del periodo. Verifique las fechas de otros periodos que estén configurados.
        /// </summary>
        public const string Mensaje020 = "020";

        /// <summary>
        /// Esta intentando configurar grados que existen en otra parametrización del mismo año. Por favor verifique.
        /// </summary>
        public const string Mensaje021 = "021";

        /// <summary>
        /// El año del periodo no corresponde al año de la parametrización. Por favor verifique.
        /// </summary>
        public const string Mensaje022 = "022";

        /// <summary>
        /// Los datos de acceso se enviaron exitosamente al correo electrónico.
        /// </summary>
        public const string Mensaje023 = "023";

        /// <summary>
        /// El nombre de usuario no existe. Por favor verifique e intente nuevamente.
        /// </summary>
        public const string Mensaje024 = "024";

        /// <summary>
        /// El usuario no tiene una cuenta de correo electrónico asociado. Por favor contacte al administrador del sistema.
        /// </summary>
        public const string Mensaje025 = "025";

        /// <summary>
        /// El usuario se encuentra bloqueado en el sistema. Por favor contacte al administrador.
        /// </summary>
        public const string Mensaje026 = "026";

        /// <summary>
        /// La nueva contraseña y su confirmación no coinciden.
        /// </summary>
        public const string Mensaje027 = "027";

        /// <summary>
        /// La contraseña actual no es correcta.
        /// </summary>
        public const string Mensaje028 = "028";

        /// <summary>
        /// El año ingresado no puede ser menor al año actual. Por favor verifique.
        /// </summary>
        public const string Mensaje029 = "029";

        /// <summary>
        /// El grupo {0} ya se encuentra asociado al grado {1}. Por favor verifique.
        /// </summary>
        public const string Mensaje030 = "030";

        /// <summary>
        /// Se deben de configurar los documentos para el nivel y el rol. Por favor verifique.
        /// </summary>
        public const string Mensaje031 = "031";

        #endregion

        #region Mensajes UI

        /// <summary>
        /// Ocurrió un error inesperado. Comuníquese con el administrador del sistema.
        /// </summary>
        public const string Mensaje1000 = "1000";

        /// <summary>
        /// Campo requerido.
        /// </summary>
        public const string Mensaje1001 = "1001";

        /// <summary>
        /// Máximo {1} caracteres.
        /// </summary>
        public const string Mensaje1002 = "1002";

        /// <summary>
        /// Al salir de esta pantalla perderá la información que no ha almacenado. ¿Desea continuar?.
        /// </summary>
        public const string Mensaje1003 = "1003";

        /// <summary>
        /// Campo numérico.
        /// </summary>
        public const string Mensaje1004 = "1004";

        /// <summary>
        /// No existe información para mostrar.
        /// </summary>
        public const string Mensaje1005 = "1005";

        /// <summary>
        /// Los valores deben estar entre {1} y {2}.
        /// </summary>
        public const string Mensaje1006 = "1006";

        /// <summary>
        /// Información incorrecta. Por favor verifique.
        /// </summary>
        public const string Mensaje1007 = "1007";

        /// <summary>
        /// Está intentando ingresar un registro duplicado.
        /// </summary>
        public const string Mensaje1008 = "1008";

        /// <summary>
        /// Por favor verifique. El registro que desea eliminar tiene información asociada.
        /// </summary>
        public const string Mensaje1009 = "1009";

        /// <summary>
        /// El formato debe ser hh:mm de 12 horas.
        /// </summary>
        public const string Mensaje1010 = "1010";

        /// <summary>
        /// Debe ser mayor o igual que {0}.
        /// </summary>
        public const string Mensaje1011 = "1011";

        /// <summary>
        /// El usuaio se encuentra bloqueado o inactivo.
        /// </summary>
        public const string Mensaje1012 = "1012";

        /// <summary>
        /// Va a eliminar el registro seleccionado. ¿Desea continuar?.
        /// </summary>
        public const string Mensaje1013 = "1013";

        /// <summary>
        /// El valor debe estar entre el 0 y el 100 porciento
        /// </summary>
        public const string Mensaje1015 = "1015";

        /// <summary>
        /// Existen valores por fuera del rango de calificación mínima y máxima. Por favor valide.
        /// </summary>
        public const string Mensaje1016 = "1016";

        /// <summary>
        /// La nota mínima debe ser menor a la nota máxima. Por favor valide.
        /// </summary>
        public const string Mensaje1017 = "1017";

        /// <summary>
        ///  Todos los intervalos de notas de los niveles de desempeño deben ser consecutivos. Por favor valide.
        /// </summary>
        public const string Mensaje1018 = "1018";

        // <summary>
        /// El estudiante ha sido matriculado con éxito.
        /// </summary>
        public const string Mensaje1019 = "1019";


        #endregion
    }
}
