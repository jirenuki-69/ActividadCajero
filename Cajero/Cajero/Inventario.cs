using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroClases
{
    public class Inventario
    {
        private List<Producto> productos;
        Producto productoElegido = new Producto();

        public List<Producto> Productos { get => productos; set => productos = value; }
        public Producto ProductoElegido { get => productoElegido; set => productoElegido = value; }

        public Inventario()
        {
            productos = new List<Producto>()
        {
            new Producto(){
                Codigo = "A01",
                Nombre = "Coca cola de lata",
                Imagen = "https://www.elpasospirits.com/assets/images/coca%20cola%20sin%20azucar%20lata%20235%20ml.png",
                Precio = 13,
                Existencia = 8
            },
            new Producto(){
                Codigo = "B03",
                Nombre = "Sprite de lata",
                Imagen = "https://www.laconstancia.com/system/balloom/asset/pictures/attachments/000/001/107/original/lata.png",
                Precio = 11,
                Existencia = 6
            },
            new Producto(){
                Codigo = "F02",
                Nombre = "Botella de Dr. Pepper",
                Imagen = "https://www.drpepper.com/images/featured/drpepper-diet.png",
                Precio = 12,
                Existencia = 3
            },
        };
        }
    }
}
