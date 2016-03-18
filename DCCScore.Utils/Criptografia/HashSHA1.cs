using System;
using System.Security.Cryptography;
using System.Text;

namespace DCCScore.Utils.Criptografia
{
    public class HashSHA1
    {

        /// <summary>     
        /// Metodo de encriptação SHA1 de valor     
        /// </summary>     
        /// <param name="text">valor a ser encriptado</param>     
        /// <returns>valor encriptado</returns>
        public static string GeraHash(string text)
        {

             try
            {
                SHA1 sha1 = SHA1.Create();

                //converte o texto de entrada em byte[]
                byte[] hashData = sha1.ComputeHash(Encoding.Default.GetBytes(text));

                StringBuilder returnValue = new StringBuilder();

                // para cada byte, adiciona ao valor de retorno
                for (int i = 0; i < hashData.Length; i++)
                {
                    returnValue.Append(hashData[i].ToString());
                }

            // retorna o hash em hexadecimal
            return returnValue.ToString();
            }
            catch (Exception ex)
            {   
                throw new ApplicationException("Erro ao encriptar SHA1", ex);
            }
        }
        
    }
}