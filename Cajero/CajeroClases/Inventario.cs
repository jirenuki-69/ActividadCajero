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
        List<Experiencia> experiencias;
        List<Servicio> servicios;
        List<List<string>> transacciones;
        List<List<string>> dbManagerData = new List<List<string>>();
        Experiencia experienciaElegida;
        DBManager dbManager = new DBManager();
        int index = 0;
        int index2 = 0;
        int transactionCount = 0;
        bool hayProducto = false;

        public DBManager DBManager { get => dbManager; set => dbManager = value; }
        public List<List<string>> DBManagerData { get => dbManagerData; set => dbManagerData = value; }
        public List<Servicio> Servicios { get => servicios; set => servicios = value; }
        public List<Experiencia> Experiencias { get => experiencias; set => experiencias = value; }
        public int Index { get => index; set => index = value; }
        public int Index2 { get => index2; set => index2 = value; }
        public Experiencia ExperienciaElegida { get => experienciaElegida; set => experienciaElegida = value; }
        public bool HayProducto { get => hayProducto; set => hayProducto = value; }
        public int TransactionCount { get => transactionCount; set => transactionCount = value; }
        public List<List<string>> Transacciones { get => transacciones; set => transacciones = value; }

        public Inventario()
        {
            dbManagerData = dbManager.GetProducts();
            experiencias = new List<Experiencia>();

            for (int i = 0; i < dbManagerData.Count; ++i)
            {
                experiencias.Add(
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

            index = experiencias.Count;

            servicios = new List<Servicio>() 
            {
                new Servicio { Nombre = "100 de Telcel", Precio = 100, TiempoAire = Tiempo.Cien, Company = Compania.Telcel },
                new Servicio { Nombre = "200 de Telcel", Precio = 200, TiempoAire = Tiempo.Doscientos, Company = Compania.Telcel },
                new Servicio { Nombre = "500 de Telcel", Precio = 500, TiempoAire = Tiempo.Quinientos, Company = Compania.Telcel },
                new Servicio { Nombre = "100 de Unefon", Precio = 100, TiempoAire = Tiempo.Cien, Company = Compania.Unefon },
                new Servicio { Nombre = "200 de Unefon", Precio = 200, TiempoAire = Tiempo.Doscientos, Company = Compania.Unefon },
                new Servicio { Nombre = "300 de Unefon", Precio = 300, TiempoAire = Tiempo.Trescientos, Company = Compania.Unefon },
                new Servicio { Nombre = "100 de AT_T", Precio = 100, TiempoAire = Tiempo.Cien, Company = Compania.AT_T },
                new Servicio { Nombre = "300 de AT_T", Precio = 300, TiempoAire = Tiempo.Trescientos, Company = Compania.AT_T },
                new Servicio { Nombre = "500 de AT_T", Precio = 500, TiempoAire = Tiempo.Quinientos, Company = Compania.AT_T },
            };

            index2 = servicios.Count;

            foreach (Servicio servicio in servicios)
            {
                experiencias.Add(servicio);
            }

            transacciones = dbManager.GetTransactions();
        }
    }
}
