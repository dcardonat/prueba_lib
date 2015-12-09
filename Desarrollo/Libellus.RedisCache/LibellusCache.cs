namespace Libellus.RedisCache
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using StackExchange.Redis;

    /// <summary>
    /// Proporciona los mecanismos de conexión, almacenamiento y obtención de información del RedisCache en Azure.
    /// </summary>
    public class LibellusCache : IDisposable
    {
        #region Atributos

        /// <summary>
        /// Bandera que determina si se libera la unidad de trabajo de memoria.
        /// </summary>
        private bool disposed;

        /// <summary>
        /// Define la configuración de conexión con el redis caché en Azure.
        /// </summary>
        private ConnectionMultiplexer conexionRedisCache;

        /// <summary>
        /// Define la instancia de almacenamiento de la información en el redis caché de Azure.
        /// </summary>
        private IDatabase redisCache;

        #endregion

        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo LibellusCache asociada al colegio en sesión.
        /// </summary>
        /// <param name="codigoColegio">Código del colegio a conectar.</param>
        public LibellusCache(string codigoColegio)
        {
            this.conexionRedisCache = ConnectionMultiplexer.Connect(this.ObtenerConexion(codigoColegio));
            this.redisCache = this.conexionRedisCache.GetDatabase();
        }

        #endregion

        #region Métodos públicos

        /// <summary>
        /// Obtiene el valor de una llave.
        /// </summary>
        /// <typeparam name="T">Tipo de dato del valor de la llave.</typeparam>
        /// <param name="key">Nombre de la llave.</param>
        /// <returns>Valor de la llave.</returns>
        public T Get<T>(string key)
        {
            return this.Deserialize<T>(this.redisCache.StringGet(key));
        }

        /// <summary>
        /// Establece un valor asociado a una llave.
        /// </summary>
        /// <param name="key">Nombre de la llave.</param>
        /// <param name="value">Valor a asociar.</param>
        /// <param name="expiracion">Timepo de expiración del valor y llave.</param>
        public void Set(string key, object value, TimeSpan expiracion)
        {
            this.redisCache.StringSet(key, this.Serialize(value), expiracion);
        }

        #endregion

        #region Métodos privados
        
        /// <summary>
        /// Serializa el valor de llave para poder almacenar cualquier tipo de dato.
        /// </summary>
        /// <param name="objeto">Valor de la llave a serializar.</param>
        /// <returns>Valor de la llave serializado.</returns>
        private byte[] Serialize(object objeto)
        {
            if (objeto == null)
            {
                return null;
            }

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, objeto);

                byte[] objectDataAsStream = memoryStream.ToArray();
                return objectDataAsStream;
            }
        }

        /// <summary>
        /// Des-serializa el valor de llave para poder manipular cualquier tipo de dato.
        /// </summary>
        /// <typeparam name="T">Tipo de dato a convertir el valor de la llave.</typeparam>
        /// <param name="stream">Valor de la llave a des-serializar.</param>
        /// <returns>Valor de llave en el formato especificado.</returns>
        private T Deserialize<T>(byte[] stream)
        {
            if (stream == null)
            {
                return default(T);
            }

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (MemoryStream memoryStream = new MemoryStream(stream))
            {
                T result = (T)binaryFormatter.Deserialize(memoryStream);
                return result;
            }
        }

        /// <summary>
        /// Obtiene la configuración de la conexión al redis caché en Azure.
        /// </summary>
        /// <param name="codigoColegio">Código del colegio a conectar.</param>
        /// <returns>Configuración de la conexión al redis caché en Azure.</returns>
        private string ObtenerConexion(string codigoColegio)
        {
            return "libelluscache.redis.cache.windows.net,ssl=true,password=VL3MHZhIMTljD7FcsGVybV+8flgg1Rj2JmNnx5JbJ2I=,ConnectTimeout=10000";
        }

        #endregion

        #region Disposed

        /// <summary>
        /// Realiza la liberación de la unidad del trabajo de la memoria.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Realiza la liberación de la conexión con el redis caché en Azure siempre y cuando sea el momento de la liberación.
        /// </summary>
        /// <param name="disposing">True si se libera, False si se mantiene.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.conexionRedisCache.Dispose();
                }
            }

            this.disposed = true;
        }

        #endregion
    }
}
