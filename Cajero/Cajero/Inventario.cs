using Cajero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroClases
{
    public class Inventario
    {
        List<Producto> productos;
        List<List<string>> dbManagerData = new List<List<string>>();
        Producto productoElegido;
        DBManager dbManager = new DBManager();

        public List<Producto> Productos { get => productos; set => productos = value; }
        public Producto ProductoElegido { get => productoElegido; set => productoElegido = value; }
        public DBManager DBManager { get => dbManager; set => dbManager = value; }
        public List<List<string>> DBManagerData { get => dbManagerData; set => dbManagerData = value; }

        public Inventario()
        {
            dbManagerData = dbManager.GetProducts();
            productos = new List<Producto>();

            for (int i = 0; i < dbManagerData.Count; ++i)
            {
                productos.Add(
                    new Producto
                    {
                        Codigo = dbManagerData[i][0],
                        Nombre = dbManagerData[i][1],
                        Imagen = dbManagerData[i][2],
                        Precio = Convert.ToInt32(dbManagerData[i][3]),
                        Existencia = Convert.ToInt32(dbManagerData[i][4]),
                    }    
                );
            }
        }
    }
}
