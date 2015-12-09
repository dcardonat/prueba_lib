namespace Libellus.Utilidades
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Clase para encriptar la información. 
    /// </summary>
    public static  class EncripcionLibellus
    {
        #region Atributos

        /// <summary>
        /// Llave de encripción genérica.  8IKMa4dTKWwN1Q2w8BVTpimU5TyFO6WQ
        /// </summary>
        private const string llaveEncripcion = @"G]^E+P*b7j/SN.z\(c+W\S[.Pte9XG";

        #endregion

        #region Métodos 

        /// <summary>
        /// Cifra un array de bytes con el algoritmo AES.
        /// </summary>
        /// <param name="cadena">Cadena de texto a cifrar.</param>
        /// <returns>Cadena de texto cifrada.</returns>
        public static string Cifrar(string cadena)
        {
            byte[] bytesEncriptados = null;
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            byte[] bytesACifrar = Encoding.UTF8.GetBytes(cadena);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (RijndaelManaged encryptor = new RijndaelManaged())
                {
                    encryptor.KeySize = 256;
                    encryptor.BlockSize = 128;

                    Rfc2898DeriveBytes llave = new Rfc2898DeriveBytes(ObtenerLlave(), saltBytes, 1000);
                    encryptor.Key = llave.GetBytes(encryptor.KeySize / 8);
                    encryptor.IV = llave.GetBytes(encryptor.BlockSize / 8);

                    encryptor.Mode = CipherMode.CBC;

                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(bytesACifrar, 0, bytesACifrar.Length);
                        cryptoStream.Close();
                    }

                    bytesEncriptados = memoryStream.ToArray();
                }
            }

            return Convert.ToBase64String(bytesEncriptados);
        }

        /// <summary>
        /// Descifra una cadena encriptada mediante el algoritmo AES.
        /// </summary>
        /// <param name="cadenaCifrada">Cadena de texto a descifrar.</param>
        /// <returns>Cadena de texto descifrada.</returns>
        public static string Descifrar(string cadenaCifrada)
        {
            bool continuarDescifrar = false;
            byte[] bytesADescifrar = null;

            try
            {
                bytesADescifrar = Convert.FromBase64String(cadenaCifrada);
                continuarDescifrar = true;
            }
            catch
            {
                continuarDescifrar = false;
            }

            if (continuarDescifrar)
            {
                byte[] bytesEncriptados = null;
                byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (RijndaelManaged encryptor = new RijndaelManaged())
                    {
                        encryptor.KeySize = 256;
                        encryptor.BlockSize = 128;

                        Rfc2898DeriveBytes llave = new Rfc2898DeriveBytes(ObtenerLlave(), saltBytes, 1000);
                        encryptor.Key = llave.GetBytes(encryptor.KeySize / 8);
                        encryptor.IV = llave.GetBytes(encryptor.BlockSize / 8);

                        encryptor.Mode = CipherMode.CBC;

                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(bytesADescifrar, 0, bytesADescifrar.Length);
                            cryptoStream.Close();
                        }

                        bytesEncriptados = memoryStream.ToArray();
                    }
                }

                return Encoding.UTF8.GetString(bytesEncriptados);
            }
            else
            {
                return cadenaCifrada;
            }
        }

        #endregion

        #region Métodos 

        /// <summary>
        /// Obtiene la llave para el cifrado.
        /// </summary>
        /// <returns>Retorna array.</returns>
        private static byte[] ObtenerLlave()
        {
            return SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(llaveEncripcion));
        }

        #endregion
    }
}
