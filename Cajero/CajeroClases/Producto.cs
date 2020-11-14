using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroClases
{
    public class Producto : Experiencia
    {
        Categoria categoria = Categoria.Producto;
        private string codigo, imagen;
        private int  existencia;

        public string Codigo { get => codigo; set => codigo = value; }
        public string Imagen { get => imagen; set => imagen = value; }
        public int Existencia { get => existencia; set => existencia = value; }
        public override Categoria Categoria { get => categoria; set => categoria = value; }
    }
}
