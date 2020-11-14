using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroClases
{
    public enum Tiempo 
    { 
        Cien = 100, 
        Doscientos = 200, 
        Trescientos = 300, 
        Quinientos = 500 
    }

    public enum Compania { Telcel, Unefon, AT_T }

    public class Servicio : Experiencia
    {
        Tiempo tiempoAire;
        Compania company;
        Categoria categoria = Categoria.Servicio;
        string descripcion = "Disfruta de este paquete en donde te regalamos saldo a tu teléfono";

        public Tiempo TiempoAire { get => tiempoAire; set => tiempoAire = value; }
        public Compania Company { get => company; set => company = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public override Categoria Categoria { get => categoria; set => categoria = value; }
    }
}
