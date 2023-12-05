using System.Data.SqlClient;
using Entidades.Excepciones;
using Entidades.Exceptions;
using Entidades.Files;
using Entidades.Interfaces;

namespace Entidades.DataBase
{
    public static class DataBaseManager
    {
        private static string stringConnection;
        private static SqlConnection connection;

        static DataBaseManager() 
        {
            DataBaseManager.stringConnection = "Server=.\\MSSQLSERVER01;Database=20230622SP;Trusted_Connection=Truse;";
        }
        public static string GetImagen(string tipo)
        {
            SqlConnection sqlConnection = new SqlConnection(DataBaseManager.stringConnection);
            try
            {
                string sqlQuery = "SELECT * FROM comidas";
                SqlCommand comandos = new SqlCommand(sqlQuery, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = comandos.ExecuteReader();
                int aux = 0;
                while (reader.Read())
                {
                    if (reader.GetSqlString(1) == tipo)
                    {
                        return reader.GetSqlString(2).ToString();
                    }
                    aux++;
                }
                throw new ComidaInvalidaExeption("No se encontro comida");
            }
            catch (ComidaInvalidaExeption ex)
            {
                throw new ComidaInvalidaExeption("Leer");
            }
            catch (Exception ex)
            {
                FileManager.Guardar(ex.Message, "logs.txt", true);
                return "N/A";
            }
        }
        public static bool GuardarTicket<T>(string nombreEmpleado, T comida)
        {
            return true;
        }
    }
}