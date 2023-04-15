using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace QuanLySanXuatJuKi.DAO
{
    public class DataProvider
    {
        private static DataProvider instance; // Ctrl + R + E

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        private DataProvider(){}

        //private string connectionSTR = "Data Source=(local);Initial Catalog=QuanLySanXuatJuKi;Integrated Security=True";

       // private string connectionSTR = "server=localhost;user id = root; password = 100100;database=juki; persistsecurityinfo=True;";
       // private string connectionSTR = "server=localhost;user id = root; password = 100100;database=juki;";
        private string connectionSTR = "server=localhost;user id=root;password=100100;database=juki_giamsatthoigiankho; persistsecurityinfo=true;";
        

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();


            using (MySqlConnection connection = new MySqlConnection(connectionSTR))
            {
                //connection.ConnectionString = connectionSTR;
                connection.Open();

                MySqlCommand command = new MySqlCommand(query, connection);
                
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                adapter.Fill(data);

                connection.Close();
                connection.Dispose();

            }

            return data;
        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;

            using (MySqlConnection connection = new MySqlConnection(connectionSTR))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();

                connection.Close();
                connection.Dispose();
            }

            return data;
        }

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;

            using (MySqlConnection connection = new MySqlConnection(connectionSTR))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteScalar();

                connection.Close();
                connection.Dispose();
            }

            return data;
        }
    }
}
