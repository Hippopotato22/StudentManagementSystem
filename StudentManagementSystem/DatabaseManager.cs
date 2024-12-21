using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using MySql.Data.MySqlClient;



namespace StudentManagementSystem
{
    //internal class DatabaseManager
    //  {
    //  }


    public class DatabaseManager
    {
        // Connection string
        private string connectionString = "Server=127.0.0.1;Database=StudentManagement;Uid=root;Pwd=firstsqldatabase;";

        // Method to establish and return a connection
        public MySqlConnection GetConnection()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Error connecting to the database: " + ex.Message);
            }
            return connection;
        }

        public DataTable ExecuteQueryWithResults(string query, MySqlParameter[] parameters = null)
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Database query error: {ex.Message}");
                }
            }

            return dataTable;
        }

        // Method to execute Insert, Update, Delete queries
        public int ExecuteQuery(string query, MySqlParameter[] parameters = null)
        {
            using (MySqlConnection connection = GetConnection())
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    if (parameters != null)
                        command.Parameters.AddRange(parameters);

                    return command.ExecuteNonQuery(); // Returns rows affected
                }
            }
        }

        // Method to fetch data from the database
        public DataTable GetData(string query, MySqlParameter[] parameters = null)
        {
            using (MySqlConnection connection = GetConnection())
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    if (parameters != null)
                        command.Parameters.AddRange(parameters);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

    }

}