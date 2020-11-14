using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroClases
{
    public enum Categoria { Producto, Servicio };
    public class Experiencia
    {
        string nombre;
        int precio;
        Categoria categoria;

        public string Nombre { get => nombre; set => nombre = value; }
        public int Precio { get => precio; set => precio = value; }
        public virtual Categoria Categoria { get => categoria; set => categoria = value; }
    }
}
