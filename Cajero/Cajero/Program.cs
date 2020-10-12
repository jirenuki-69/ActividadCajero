using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroClases
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Cajero
    {
        private List<List<int>> denominaciones = new List<List<int>>()
        {
            //new List<int> { .10, 0 },
            //new List<int> { .20, 0 },
            //new List<int> { .50, 0 },
            new List<int> { 1, 0 },
            new List<int> { 2, 0 },
            new List<int> { 5, 0 },
            new List<int> { 10, 0 },
            new List<int> { 20, 0 },
            new List<int> { 50, 0 },
            new List<int> { 100, 0 },
            new List<int> { 200, 0 },
            new List<int> { 500, 0 }
        };
        private MoneyManager moneyManager = new MoneyManager();

        public List<List<int>> Denominaciones { get => denominaciones; set => denominaciones = value; }
        public MoneyManager _MoneyManager { get => moneyManager; set => moneyManager = value; }

        public List<int> ReturnChange(List<List<int>> monedas, int cantidad)
        {
            BubbleSort(monedas);
            int n = cantidad;

            if (cantidad > moneyManager.DineroTotal)
            {

                throw new Exception("Error, la cantidad de monedas no alcanza a cubrir la cantidad ingresada");

            }
            else if (cantidad < 0)
            {

                throw new Exception("Error, no se aceptan números negativos");

            }

            List<List<int>> matriz = new List<List<int>>();
            List<int> fila1 = new List<int>() { 0 };

            for (int i = 0; i < cantidad + 1; i++)
            {
                fila1.Add(i);
            }
            matriz.Add(fila1);

            fila1 = new List<int>();

            for (int i = 0; i < monedas.Count; i++)
            {
                for (int j = 0; j < cantidad + 2; j++)
                {
                    if (j == 0)
                    {

                        fila1.Add(monedas[i][0]);

                    }
                    else if (matriz[0][j] < monedas[i][0])
                    {

                        fila1.Add(matriz[i][j]);

                    }
                    else if (matriz[0][j] == monedas[i][0])
                    {

                        fila1.Add(1);

                    }
                    else if (matriz[0][j] > monedas[i][0])
                    {
                        int indexTemp = monedas[i][0] < 1 ? 1 : Convert.ToInt32(monedas[i][0]);

                        fila1.Add(fila1[j - indexTemp] + 1);

                    }
                }

                matriz.Add(fila1);
                fila1 = new List<int>() { };
            }

            List<int> numeros = new List<int>();

            while (n != 0 || n > 0)
            {
                List<List<int>> posiblesMonedas = new List<List<int>>() { };

                for (int i = 1; i < monedas.Count + 1; i++)
                {
                    int indexTemp = Convert.ToInt32(n + 1);
                    posiblesMonedas.Add(new List<int> { matriz[i][indexTemp], i });
                }

                BubbleSort(posiblesMonedas);

                for (int i = 0; i < posiblesMonedas.Count; i++)
                {
                    int indexPosiblesMonedas = Convert.ToInt32(posiblesMonedas[i][1]);

                    if (monedas[indexPosiblesMonedas - 1][1] > 0)
                    {
                        if ((n - matriz[indexPosiblesMonedas][0]) >= 0)
                        {
                            Console.WriteLine(matriz[indexPosiblesMonedas][0]);
                            numeros.Add(matriz[indexPosiblesMonedas][0]);
                            n = n - matriz[indexPosiblesMonedas][0];
                            monedas[indexPosiblesMonedas - 1][1] = monedas[indexPosiblesMonedas - 1][1] - 1;
                            break;
                        }
                        else if (monedas[indexPosiblesMonedas - 1][1] < 0)
                        {

                            throw new Exception("Error, no se puede retornar dicha cantidad, por falta de monedas");

                        }
                    }
                }
            }
            return numeros;
        }

        private void BubbleSort(List<List<int>> data)
        {
            int n = data.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (data[j][0] > data[j + 1][0])
                    {
                        List<int> aux = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = aux;
                    }
                }
            }
        }
    }

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

    public class Inventario
    {
        private List<Producto> productos = new List<Producto>();

        public List<Producto> Productos { get => productos; set => productos = value; }
    }

    public class MoneyManager
    {
        private int dineroTotal, dineroIntroducido;

        public int DineroTotal { get => dineroTotal; }
        public int DineroIntroducido { get => dineroIntroducido; }

        public void GetDineroTotal(Cajero cajero)
        {
            dineroTotal = 0;
            for(int i = 0; i < cajero.Denominaciones.Count; i++)
            {
                dineroTotal += cajero.Denominaciones[i][0] * cajero.Denominaciones[i][1];
            }
        }

        public void AddDinero(int dinero)
        {
            dineroTotal += dinero;
        }

        public void ValorIntroducidoEvent(int dinero)
        {
            dineroIntroducido = dinero;
            dineroTotal = dineroIntroducido;
        }
    }
}
