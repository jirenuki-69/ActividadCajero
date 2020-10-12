using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CajeroClases;

namespace CajeroForms
{
    public partial class Form1 : Form
    {
        int total = 0;
        int introducido = 0;

        Cajero cajero = new Cajero();
        Inventario inventario = new Inventario(); //Este manejará mis productos
        MoneyManager moneyManager = new MoneyManager(); //Este manejará el dinero
        List<Producto> productos = new List<Producto>() 
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

        Producto productoElegido;

        List<int> cambio = new List<int>();
        
        public Form1()
        {
            
            InitializeComponent();

            inventario.Productos = productos;
            cajero.Denominaciones.ForEach(e => e[1] += 3); //Nada más le agrego a las denominaciones para hacer pruebas
            //Inicializando las cantidades por denominación al forms
            txt1peso.Text = cajero.Denominaciones[0][1].ToString();
            txt2pesos.Text = cajero.Denominaciones[1][1].ToString();
            txt5pesos.Text = cajero.Denominaciones[2][1].ToString();
            txt10pesos.Text = cajero.Denominaciones[3][1].ToString();
            txt20pesos.Text = cajero.Denominaciones[4][1].ToString();
            txt50pesos.Text = cajero.Denominaciones[5][1].ToString();
            txt100pesos.Text = cajero.Denominaciones[6][1].ToString();
            txt200pesos.Text = cajero.Denominaciones[7][1].ToString();
            txt500pesos.Text = cajero.Denominaciones[8][1].ToString();

            LoadContent();
        }

        private void btn1p_Click(object sender, EventArgs e)
        {
            introducido += 1;
            labelIntroducido.Text = $"Introducido: {introducido}$";
            cajero.Denominaciones[0][1] += 1;

            moneyManager.AddDinero(1);
            labelDineroTotal.Text = moneyManager.DineroTotal.ToString();
            txt1peso.Text = cajero.Denominaciones[0][1].ToString();
        }

        private void btn2p_Click(object sender, EventArgs e)
        {
            introducido += 2;
            labelIntroducido.Text = $"Introducido: {introducido}$";
            cajero.Denominaciones[1][1] += 1;

            moneyManager.AddDinero(2);
            labelDineroTotal.Text = moneyManager.DineroTotal.ToString();
            txt2pesos.Text = cajero.Denominaciones[1][1].ToString();
        }

        private void btn5p_Click(object sender, EventArgs e)
        {
            introducido += 5;
            labelIntroducido.Text = $"Introducido: {introducido}$";
            cajero.Denominaciones[2][1] += 1;

            moneyManager.AddDinero(5);
            labelDineroTotal.Text = moneyManager.DineroTotal.ToString();
            txt5pesos.Text = cajero.Denominaciones[2][1].ToString();
        }

        private void btn10p_Click(object sender, EventArgs e)
        {
            introducido += 10;
            labelIntroducido.Text = $"Introducido: {introducido}$";
            cajero.Denominaciones[3][1] += 1;

            moneyManager.AddDinero(10);
            labelDineroTotal.Text = moneyManager.DineroTotal.ToString();
            txt10pesos.Text = cajero.Denominaciones[3][1].ToString();
        }

        private void btn20b_Click(object sender, EventArgs e)
        {
            introducido += 20;
            labelIntroducido.Text = $"Introducido: {introducido}$";
            cajero.Denominaciones[4][1] += 1;

            moneyManager.AddDinero(20);
            labelDineroTotal.Text = moneyManager.DineroTotal.ToString();
            txt20pesos.Text = cajero.Denominaciones[4][1].ToString();
        }

        private void btn50b_Click(object sender, EventArgs e)
        {
            introducido += 50;
            labelIntroducido.Text = $"Introducido: {introducido}$";
            cajero.Denominaciones[5][1] += 1;

            moneyManager.AddDinero(50);
            labelDineroTotal.Text = moneyManager.DineroTotal.ToString();
            txt50pesos.Text = cajero.Denominaciones[5][1].ToString();
        }

        private void btn100b_Click(object sender, EventArgs e)
        {
            introducido += 100;
            labelIntroducido.Text = $"Introducido: {introducido}$";
            cajero.Denominaciones[6][1] += 1;

            moneyManager.AddDinero(100);
            labelDineroTotal.Text = moneyManager.DineroTotal.ToString();
            txt100pesos.Text = cajero.Denominaciones[6][1].ToString();
        }

        private void btn200b_Click(object sender, EventArgs e)
        {
            introducido += 200;
            labelIntroducido.Text = $"Introducido: {introducido}$";
            cajero.Denominaciones[7][1] += 1;

            moneyManager.AddDinero(200);
            labelDineroTotal.Text = moneyManager.DineroTotal.ToString();
            txt200pesos.Text = cajero.Denominaciones[7][1].ToString();
        }

        private void btn500b_Click(object sender, EventArgs e)
        {
            introducido += 500;
            labelIntroducido.Text = $"Introducido: {introducido}$";
            cajero.Denominaciones[8][1] += 1;

            moneyManager.AddDinero(500);
            labelDineroTotal.Text = moneyManager.DineroTotal.ToString();
            txt500pesos.Text = cajero.Denominaciones[8][1].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtInput.Text += "A";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtInput.Text += "B";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtInput.Text += "C";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtInput.Text += "D";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtInput.Text += "E";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtInput.Text += "F";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtInput.Text += "1";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtInput.Text += "2";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            txtInput.Text += "3";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            txtInput.Text += "4";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            txtInput.Text += "5";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtInput.Text += "6";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            txtInput.Text += "7";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            txtInput.Text += "8";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            txtInput.Text += "9";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            txtInput.Text += "0";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (productoElegido != null)
            {
                if (introducido - total > 0)
                {
                    try
                    {
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

                    }
                    catch (Exception error)
                    {
                        labelPantalla.Text = error.Message;
                    }

                    moneyManager.GetDineroTotal(cajero);
                    labelDineroTotal.Text = moneyManager.DineroTotal.ToString();
                    txtInput.Text = "";
                }
                else if(introducido - total == 0)
                {
                    labelPantalla.Text = "Gracias por su compra!!";
                }
                else
                {
                    labelPantalla.Text = "Lo introducido es menor al total";
                }

            } else {

                labelPantalla.Text = "Sin producto a elegir";

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            txtInput.Text += "";
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            if(txtInput.TextLength == 3)
            {
                productoElegido = new Producto();
                productoElegido = inventario.Productos.Find( element => element.Codigo == txtInput.Text );

                total += productoElegido.Precio;
                labelTotal.Text = $"Total: {total}$";

                labelPantalla.Text = $"Usted ha elegido el producto: {productoElegido.Nombre}";
            }
        }

        private void LoadContent()
        {
            LoadImages();

            moneyManager.GetDineroTotal(cajero);
            cajero._MoneyManager = moneyManager;

            Producto coca = inventario.Productos[0];
            Producto sprite = inventario.Productos[1];
            Producto drPepper = inventario.Productos[2];

            precioCoca.Text = $"Precio: {coca.Precio} pesos";
            nombreCoca.Text = $"Nombre: {coca.Nombre}";
            codigoCoca.Text = $"Código: {coca.Codigo}";
            existenciaCoca.Text = $"Existencia: {coca.Existencia}";

            precioSprite.Text = $"Precio: {sprite.Precio} pesos";
            nombreSprite.Text = $"Nombre: {sprite.Nombre}";
            codigoSprite.Text = $"Código: {sprite.Codigo}";
            existenciaSprite.Text = $"Existencia: {sprite.Existencia}";

            precioPepper.Text = $"Precio: {drPepper.Precio} pesos";
            nombrePepper.Text = $"Nombre: {drPepper.Nombre}";
            codigoPepper.Text = $"Código: {drPepper.Codigo}";
            existenciaPepper.Text = $"Existencia: {drPepper.Existencia}";

            labelDineroTotal.Text = moneyManager.DineroTotal.ToString();
        }

        private void LoadImages()
        {
            imgCoca.Load(inventario.Productos[0].Imagen);
            imgSprite.Load(inventario.Productos[1].Imagen);
            imgDrPepper.Load(inventario.Productos[2].Imagen);
        }

    }
}
