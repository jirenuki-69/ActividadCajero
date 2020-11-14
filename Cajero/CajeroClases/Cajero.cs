using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroClases
{
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
        private int cambio;

        public List<List<int>> Denominaciones { get => denominaciones; set => denominaciones = value; }
        public int Cambio { get => cambio; set => cambio = value; }

        public List<int> ReturnChange(int cantidad)
        {
            List<List<int>> copiaDenominaciones = denominaciones;
            BubbleSort(copiaDenominaciones);
            int n = cantidad;
            int cantidadTotal = 0;

            for (int i = 0; i < copiaDenominaciones.Count; i++)
            {
                cantidadTotal = cantidadTotal + copiaDenominaciones[i][0] * copiaDenominaciones[i][1];
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

            for (int i = 0; i < copiaDenominaciones.Count; i++)
            {
                for (int j = 0; j < cantidad + 2; j++)
                {
                    if (j == 0)
                    {

                        fila1.Add(copiaDenominaciones[i][0]);

                    }
                    else if (matriz[0][j] < copiaDenominaciones[i][0])
                    {

                        fila1.Add(matriz[i][j]);

                    }
                    else if (matriz[0][j] == copiaDenominaciones[i][0])
                    {

                        fila1.Add(1);

                    }
                    else if (matriz[0][j] > copiaDenominaciones[i][0])
                    {
                        int indexTemp = copiaDenominaciones[i][0] < 1 ? 1 : Convert.ToInt32(copiaDenominaciones[i][0]);

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

                for (int i = 1; i < copiaDenominaciones.Count + 1; i++)
                {
                    int indexTemp = Convert.ToInt32(n + 1);
                    posiblesMonedas.Add(new List<int> { matriz[i][indexTemp], i });
                }

                BubbleSort(posiblesMonedas);

                for (int i = 0; i < posiblesMonedas.Count; i++)
                {
                    int indexPosiblesMonedas = Convert.ToInt32(posiblesMonedas[i][1]);

                    if (copiaDenominaciones[indexPosiblesMonedas - 1][1] > 0)
                    {
                        if ((n - matriz[indexPosiblesMonedas][0]) >= 0)
                        {
                            Console.WriteLine(matriz[indexPosiblesMonedas][0]);
                            numeros.Add(matriz[indexPosiblesMonedas][0]);
                            n = n - matriz[indexPosiblesMonedas][0];
                            copiaDenominaciones[indexPosiblesMonedas - 1][1] = copiaDenominaciones[indexPosiblesMonedas - 1][1] - 1;
                            break;
                        }
                        else if (copiaDenominaciones[indexPosiblesMonedas - 1][1] < 0)
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
   
        public void AddDenomination(string moneda)
        {
            switch (moneda)
            {
                case "1":
                    denominaciones[0][1] += 1;
                    return;
                case "2":
                    denominaciones[1][1] += 1;
                    return;
                case "5":
                    denominaciones[2][1] += 1;
                    return;
                case "10":
                    denominaciones[3][1] += 1;
                    return;
                case "20":
                    denominaciones[4][1] += 1;
                    return;
                case "50":
                    denominaciones[5][1] += 1;
                    return;
                case "100":
                    denominaciones[6][1] += 1;
                    return;
                case "200":
                    denominaciones[7][1] += 1;
                    return;
                case "500":
                    denominaciones[8][1] += 1;
                    return;
            }
        }
    }
}   
