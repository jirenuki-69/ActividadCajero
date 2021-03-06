﻿using System;
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

                connection.Close();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Print(e.Message);
            }

            return dataProducts;
        }

    }
}
