using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cajero
{
    class Program
    {
        static void Main(string[] args)
        {
            Cajero cajero = new Cajero();

            try {

                List<int> cambio = cajero.ReturnChange(cajero.Denominaciones, 12);
                Console.WriteLine(string.Join(" ", cambio));

            } catch (Exception e) {

                Console.WriteLine(e.Message);

            }

            Console.ReadKey();
        }
    }
    class Cajero
    {
        //readonly double[] denominaciones = new double[] { .10, .20, .50, 1, 2, 5, 10, 20, 50, 100, 200, 500 };
        //private int[] cantidadDenominaciones = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; 
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

        public List<List<int>> Denominaciones { get => denominaciones; set => denominaciones = value; }

        public List<int> ReturnChange(List<List<int>> monedas, int cantidad)
        {
            BubbleSort(monedas);
            int n = cantidad;
            int cantidadTotal = 0;

            for (int i = 0; i < monedas.Count; i++)
            {
                cantidadTotal = cantidadTotal + monedas[i][0] * monedas[i][1];
            }

            if (cantidad > cantidadTotal)
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

                        fila1.Add(fila1[j - monedas[i][0]] + 1);

                    }
                }

                matriz.Add(fila1);
                fila1 = new List<int>() { };
            }

            List<int> numeros = new List<int>();

            while (n != 0)
            {
                List<List<int>> posiblesMonedas = new List<List<int>>() { };

                for (int i = 1; i < monedas.Count + 1; i++)
                {
                    posiblesMonedas.Add(new List<int> { matriz[i][n + 1], i });
                }

                BubbleSort(posiblesMonedas);

                for (int i = 0; i < posiblesMonedas.Count; i++)
                {
                    int indexPosiblesMonedas = Convert.ToInt32(posiblesMonedas[i][1]);

                    if (monedas[indexPosiblesMonedas - 1][1] > 0)
                    {
                        if ((n - matriz[indexPosiblesMonedas][0]) >= 0)
                        {
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
}
