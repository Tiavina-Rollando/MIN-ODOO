using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.Common;
using System.Data;


namespace Gestion_RH.Services
{
    public class Database
    {
        private MySqlConnection connection;

        public Database()
        {
            // Récupère la chaîne de connexion à partir de App.config
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            connection = new MySqlConnection(connectionString);
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }

        public void OpenConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public MySqlDataReader ExecuteQuery(string query, MySqlConnection conn)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand(query, conn);
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }

}
