namespace Libellus.Utilidades
{
    using Libellus.Entidades;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Xml.Linq;

    /// <summary>
    /// Clase para administrar la información de los repositorios de los colegios.
    /// </summary>
    public static class RepositorioCentral
    {
        /// <summary>
        /// Constante para la carpeta donde esta el archivo. 
        /// </summary>
        private const string CapetaArchivo = "AccesoColegios";

        /// <summary>
        /// Constante nombre del archivo. 
        /// </summary>
        private const string NombreArchivo = "RepositorioCentral.xml";

        /// <summary>
        /// Contante para el nodo principal del archivo.
        /// </summary>
        private const string EstructuraArchivo = "ParametroColegio";

        /// <summary>
        /// Constante para el nodo de la información del colegio.
        /// </summary>
        private const string NodoArchivo = "CodigoColegio";

        /// <summary>
        /// COnstante para la llave del nodo. 
        /// </summary>
        private const string LlaveNodo = "CodigoColegio";

        /// <summary>
        /// Constante para el valor del nodo. 
        /// </summary>
        private const string ValorNodo = "CadenaConexion";

        /// <summary>
        /// obtiene o estblece la ruta del archivo.  
        /// </summary>
        private static string RutaArchivo;

        /// <summary>
        /// Obtiene los parametros de conexión del colegío. 
        /// </summary>
        /// <returns></returns>
        public static string ObtenerParametros(string codigoColegio)
        {
            RutaArchivo = String.Format("{0}\\AccesoColegios\\{1}", AppDomain.CurrentDomain.RelativeSearchPath, "RepositorioCentral.xml");
            ParametroColegio conexionColegio = new ParametroColegio();

            if (File.Exists(RutaArchivo))
            {
                lock (RutaArchivo)
                {
                    XDocument archivoXml = XDocument.Load(RutaArchivo);
                    conexionColegio = (from parametro in archivoXml.Descendants(EstructuraArchivo)
                                       where parametro.Attribute(NodoArchivo).Value == codigoColegio
                                       select new ParametroColegio
                                       {
                                           CodigoColegio = parametro.Attribute(LlaveNodo).Value,
                                           CadenaConexion = parametro.Attribute(ValorNodo).Value,

                                       }).FirstOrDefault();
                }
            }

            if (conexionColegio != null && !string.IsNullOrEmpty(conexionColegio.CadenaConexion))
            {
               return EncripcionLibellus.Descifrar(conexionColegio.CadenaConexion);
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
