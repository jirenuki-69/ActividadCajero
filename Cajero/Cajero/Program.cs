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
            cajero.Denominaciones.ForEach( e => e[1] += 3 ); //Nada más le agrego a las denominaciones para hacer pruebas

            List<double> cambio = cajero.ReturnChange(cajero.Denominaciones, 15.0 - 13.5); //1.5
            Console.WriteLine(string.Join(" ", cambio));
            Console.ReadKey();
        }
    }
    public class Cajero
    {
        private List<List<double>> denominaciones = new List<List<double>>() 
        {
            new List<double> { .10, 0 },
            new List<double> { .20, 0 },
            new List<double> { .50, 0 },
            new List<double> { 1, 0 },
            new List<double> { 2, 0 },
            new List<double> { 5, 0 },
            new List<double> { 10, 0 },
            new List<double> { 20, 0 },
            new List<double> { 50, 0 },
            new List<double> { 100, 0 },
            new List<double> { 200, 0 },
            new List<double> { 500, 0 }
        };

        public List<List<double>> Denominaciones { get => denominaciones; set => denominaciones = value; }

        public List<double> ReturnChange(List<List<double>> monedas, double cantidad)
        {
            BubbleSort(monedas);
            double n = cantidad;
            double cantidadTotal = 0;

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

            List<List<double>> matriz = new List<List<double>>();
            List<double> fila1 = new List<double>() { 0 };

            for (int i = 0; i < cantidad + 1; i++)
            {
                fila1.Add(i);
            }
            matriz.Add(fila1);

            fila1 = new List<double>();

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
                fila1 = new List<double>() { };
            }

            List<double> numeros = new List<double>();

            while (n != 0 || n > 0)
            {
                List<List<double>> posiblesMonedas = new List<List<double>>() { };

                for (int i = 1; i < monedas.Count + 1; i++)
                {
                    int indexTemp = Convert.ToInt32(n + 1);
                    posiblesMonedas.Add(new List<double> { matriz[i][indexTemp], i });
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
                            n = Math.Round(n - matriz[indexPosiblesMonedas][0], 1);
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

        private void BubbleSort(List<List<double>> data)
        {
            int n = data.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (data[j][0] > data[j + 1][0])
                    {
                        List<double> aux = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = aux;
                    }
                }
            }
        }
    }


}
