using System.Configuration;
using System.Data.SqlClient;

namespace DCCScore.Utils.Parametrizacao
{
    public class ParametrosService : IParametrosService
    {

        private const string QUERY = "SELECT VALOR FROM Parametros WHERE CHAVE = @CHAVE";

        private const string NOME_CONN_STRING = "DCCScoreDbEntities";

        private string getConnectionString()
        {
            string connectionstring = ConfigurationManager.ConnectionStrings[NOME_CONN_STRING].ToString();
            // retira parte de metadados da connection string
            return connectionstring.Remove(0, connectionstring.IndexOf("data source")).Replace("\"", "");
        }

        public string getParametro(string chave)
        {
            using (SqlConnection con = new SqlConnection(getConnectionString()))
            {
                try
                {
                    con.Open();
                    SqlCommand comando = new SqlCommand(QUERY, con);
                    comando.Parameters.AddWithValue("CHAVE", chave);
                    SqlDataReader valor = comando.ExecuteReader();

                    if (valor.HasRows)
                    {
                        valor.Read();
                        return valor.GetString(0);
                    }
                    else
                    {
                        throw new ParametroNaoEncontradoException("Não encontrado o parametro de chave [" + chave + "]");
                    }
                }
                catch (System.Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }

            }
        }
    }
}
