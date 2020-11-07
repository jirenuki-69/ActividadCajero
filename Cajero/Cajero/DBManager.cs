using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Cajero
{
    public class DBManager
    {
        MySqlConnection connection;

        public DBManager()
        {
            string connectionString = "Server=localhost;Database=vendingmachine;Uid=root;Pwd=Homeruns7;";
            connection = new MySqlConnection(connectionString);
        }

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

                DebugTable(dataTableProductos);

                connection.Close();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Print(e.Message);
            }

            return dataProducts;
        }

        public void DebugTable(DataTable table)
        {
            System.Diagnostics.Debug.WriteLine("--- DebugTable(" + table.TableName + ") ---");
            int zeilen = table.Rows.Count;
            int spalten = table.Columns.Count;

            // Header
            for (int i = 0; i < table.Columns.Count; i++)
            {
                string s = table.Columns[i].ToString();
                System.Diagnostics.Debug.Write(String.Format("{0,-20} | ", s));
            }
            System.Diagnostics.Debug.Write(Environment.NewLine);
            for (int i = 0; i < table.Columns.Count; i++)
            {
                System.Diagnostics.Debug.Write("---------------------|-");
            }
            System.Diagnostics.Debug.Write(Environment.NewLine);

            // Data
            for (int i = 0; i < zeilen; i++)
            {
                DataRow row = table.Rows[i];
                //Debug.WriteLine("{0} {1} ", row[0], row[1]);
                for (int j = 0; j < spalten; j++)
                {
                    string s = row[j].ToString();
                    if (s.Length > 20) s = s.Substring(0, 17) + "...";
                    System.Diagnostics.Debug.Write(String.Format("{0,-20} | ", s));
                }
                System.Diagnostics.Debug.Write(Environment.NewLine);
            }
            for (int i = 0; i < table.Columns.Count; i++)
            {
                System.Diagnostics.Debug.Write("---------------------|-");
            }
            System.Diagnostics.Debug.Write(Environment.NewLine);
        }
    }
}
