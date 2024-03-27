using System;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp1.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataProvider();

                return instance;
            }
            private set { instance = value; }
        }

        private string ConnectionString = @"Data Source=DESKTOP-B3E8RSQ\SQLEXPRESS;Initial Catalog=caphe;Integrated Security=True";

        private DataProvider() { }

        public DataTable ExecuteQuery(string query)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                connection.Close();
            }

            return data;
        }
    }
}
