using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cajero;

namespace CajeroForms
{
    public partial class Form1 : Form
    {
        int total = 0;
        int introducido = 0;
        Cajero cajero = new Cajero();
        List<int> cambio = new List<int>();

        public Form1()
        {
            
            InitializeComponent();

            
            cajero.Denominaciones.ForEach(e => e[1] += 3); //Nada más le agrego a las denominaciones para hacer pruebas
            txt1peso.Text = cajero.Denominaciones[0][1].ToString();
            txt2pesos.Text = cajero.Denominaciones[1][1].ToString();
            txt5pesos.Text = cajero.Denominaciones[2][1].ToString();
            txt10pesos.Text = cajero.Denominaciones[3][1].ToString();
            txt20pesos.Text = cajero.Denominaciones[4][1].ToString();
            txt50pesos.Text = cajero.Denominaciones[5][1].ToString();
            txt100pesos.Text = cajero.Denominaciones[6][1].ToString();
            txt200pesos.Text = cajero.Denominaciones[7][1].ToString();
            txt500pesos.Text = cajero.Denominaciones[8][1].ToString();
        }

        private void imgCoca_Click(object sender, EventArgs e)
        {
            total += 13;
            labelTotal.Text = $"Total: {total}$";
        }

        private void imgSprite_Click(object sender, EventArgs e)
        {
            total += 11;
            labelTotal.Text = $"Total: {total}$";
        }

        private void imgDrPepper_Click(object sender, EventArgs e)
        {
            total += 12;
            labelTotal.Text = $"Total: {total}$";
        }

        private void btnPedir_Click(object sender, EventArgs e)
        {
            if (introducido - total > 0)
            {
                try {
                    cambio = cajero.ReturnChange(cajero.Denominaciones, introducido - total);

                    txt1peso.Text = cajero.Denominaciones[0][1].ToString();
                    txt2pesos.Text = cajero.Denominaciones[1][1].ToString();
                    txt5pesos.Text = cajero.Denominaciones[2][1].ToString();
                    txt10pesos.Text = cajero.Denominaciones[3][1].ToString();
                    txt20pesos.Text = cajero.Denominaciones[4][1].ToString();
                    txt50pesos.Text = cajero.Denominaciones[5][1].ToString();
                    txt100pesos.Text = cajero.Denominaciones[6][1].ToString();
                    txt200pesos.Text = cajero.Denominaciones[7][1].ToString();
                    txt500pesos.Text = cajero.Denominaciones[8][1].ToString();

                    labelPantalla.Text = $"Compra realizada de manera correcta. Cambio: {introducido - total}$";

                    string data = string.Join(" pesos, ", cambio);
                    data += " pesos";
                    labelMonedero.Text = $"Monedas y billetes: {data}";

                    total = 0;
                    introducido = 0;
                    labelIntroducido.Text = $"Introducido: {introducido}$";
                    labelTotal.Text = $"Total: {total}$";

                } catch (Exception error) {
                    labelPantalla.Text = error.Message;
                }

            }
            else
            {
                labelPantalla.Text = "Lo introducido es menor al total";
            }
            
        }

        private void btn1p_Click(object sender, EventArgs e)
        {
            introducido += 1;
            labelIntroducido.Text = $"Introducido: {introducido}$";
            cajero.Denominaciones[0][1] += 1;

            txt1peso.Text = cajero.Denominaciones[0][1].ToString();
        }

        private void btn2p_Click(object sender, EventArgs e)
        {
            introducido += 2;
            labelIntroducido.Text = $"Introducido: {introducido}$";
            cajero.Denominaciones[1][1] += 1;

            txt2pesos.Text = cajero.Denominaciones[1][1].ToString();
        }

        private void btn5p_Click(object sender, EventArgs e)
        {
            introducido += 5;
            labelIntroducido.Text = $"Introducido: {introducido}$";
            cajero.Denominaciones[2][1] += 1;

            txt5pesos.Text = cajero.Denominaciones[2][1].ToString();
        }

        private void btn10p_Click(object sender, EventArgs e)
        {
            introducido += 10;
            labelIntroducido.Text = $"Introducido: {introducido}$";
            cajero.Denominaciones[3][1] += 1;

            txt10pesos.Text = cajero.Denominaciones[3][1].ToString();
        }

        private void btn20b_Click(object sender, EventArgs e)
        {
            introducido += 20;
            labelIntroducido.Text = $"Introducido: {introducido}$";
            cajero.Denominaciones[4][1] += 1;

            txt20pesos.Text = cajero.Denominaciones[4][1].ToString();
        }

        private void btn50b_Click(object sender, EventArgs e)
        {
            introducido += 50;
            labelIntroducido.Text = $"Introducido: {introducido}$";
            cajero.Denominaciones[5][1] += 1;

            txt50pesos.Text = cajero.Denominaciones[5][1].ToString();
        }

        private void btn100b_Click(object sender, EventArgs e)
        {
            introducido += 100;
            labelIntroducido.Text = $"Introducido: {introducido}$";
            cajero.Denominaciones[6][1] += 1;

            txt100pesos.Text = cajero.Denominaciones[6][1].ToString();
        }

        private void btn200b_Click(object sender, EventArgs e)
        {
            introducido += 200;
            labelIntroducido.Text = $"Introducido: {introducido}$";
            cajero.Denominaciones[7][1] += 1;

            txt200pesos.Text = cajero.Denominaciones[7][1].ToString();
        }

        private void btn500b_Click(object sender, EventArgs e)
        {
            introducido += 500;
            labelIntroducido.Text = $"Introducido: {introducido}$";
            cajero.Denominaciones[8][1] += 1;

            txt500pesos.Text = cajero.Denominaciones[8][1].ToString();
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
}
