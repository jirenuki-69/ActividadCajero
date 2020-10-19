using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroClases
{
    public class Producto
    {
        private string codigo, nombre, imagen;
        private int precio, existencia;

        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Imagen { get => imagen; set => imagen = value; }
        public int Precio { get => precio; set => precio = value; }
        public int Existencia { get => existencia; set => existencia = value; }
    }
}
