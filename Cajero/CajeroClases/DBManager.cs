using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Timers;
using CajeroClases;

namespace Cajero
{
    public class DBManager
    {
        MySqlConnection connection;
        DataTable transacciones;

        public DBManager()
        {
            string connectionString = "Server=localhost;Database=vendingmachine;Uid=root;Pwd=Homeruns7;";
            connection = new MySqlConnection(connectionString);
        }

        public DataTable Transacciones { get => transacciones; set => transacciones = value; }

        public List<List<string>> GetProducts()
        {
            DataTable dataTableProductos = null;
            List<List<string>> dataProducts = new List<List<string>>();
            string query = "SELECT * FROM productos";

            try
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter dataAdapterProducts = new MySqlDataAdapter(command);
                MySqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    dataProducts.Add(
                        new List<string> 
                        {
                            dataReader.GetString("codigo"),
                            dataReader.GetString("nombre"),
                            dataReader.GetString("imagen"),
                            dataReader.GetString("precio"),
                            dataReader.GetString("existencia"),
                        }
                    );
                }

                dataReader.Close();

                dataTableProductos = new DataTable();

                dataAdapterProducts.Fill(dataTableProductos);
                connection.Close();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Print(e.Message);
            }

            return dataProducts;
        }

        public List<List<string>> GetTransactions()
        {
            connection.Close();
            connection.Open();

            List<List<string>> dataTransactions = new List<List<string>>();
            string query = "SELECT * FROM transacciones";

            try
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter dataAdapterTransactions = new MySqlDataAdapter(command);
                MySqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    dataTransactions.Add(
                        new List<string>
                        {
                            dataReader.GetString("id"),
                            dataReader.GetString("id_experiencia"),
                            dataReader.GetString("fecha"),
                        }
                    );
                }

                dataReader.Close();
                connection.Close();

                transacciones = new DataTable();
                dataAdapterTransactions.Fill(transacciones);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Print(e.Message);
            }

            return dataTransactions;
        }

        public void TransactionPutRequest(int id, Producto producto)
        {
            string query = $"INSERT INTO transacciones VALUES(" + id + ", '" + producto.Codigo + "', '" + DateTime.Now.ToString("d") + "')";

            try
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                }

                dataReader.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Print(e.Message);
            }
        }
    }
}
