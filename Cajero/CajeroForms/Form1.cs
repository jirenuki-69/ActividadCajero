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
        ControlCentral controlCentral = new ControlCentral();

        public Form1()
        {
            InitializeComponent();

            Control.CheckForIllegalCrossThreadCalls = false;

            controlCentral.DisplayControl.InitializeDisplayControlTextBoxes(
                txtInput, txt1peso, txt2pesos, txt5pesos, txt10pesos, txt20pesos, txt50pesos,
                txt100pesos, txt200pesos, txt500pesos, txtHora
            );

            controlCentral.DisplayControl.InitializeDisplayControlLabels(
                labelPantalla, labelDineroTotal, labelMonedero, labelIntroducido, labelTotal
            );

            controlCentral.DisplayControl.RefreshTxtDenominations();

            LoadContent();

            controlCentral.InitTimer();
        }

        private void btn1p_Click(object sender, EventArgs e)
        {
            controlCentral.MoneyManager.AddDinero(1);
            controlCentral.DisplayControl.ChangeLabelIntroducidoState($"Introducido: {controlCentral.MoneyManager.DineroIntroducido}$");
            controlCentral.Cajero.AddDenomination("1");

            controlCentral.DisplayControl.ChangeLabelDineroTotalState(controlCentral.MoneyManager.DineroTotal.ToString());
            controlCentral.DisplayControl.RefreshCertainDenomination("1");
        }

        private void btn2p_Click(object sender, EventArgs e)
        {
            controlCentral.MoneyManager.AddDinero(2);
            controlCentral.DisplayControl.ChangeLabelIntroducidoState($"Introducido: {controlCentral.MoneyManager.DineroIntroducido}$");
            controlCentral.Cajero.AddDenomination("2");

            controlCentral.DisplayControl.ChangeLabelDineroTotalState(controlCentral.MoneyManager.DineroTotal.ToString());
            controlCentral.DisplayControl.RefreshCertainDenomination("2");
        }

        private void btn5p_Click(object sender, EventArgs e)
        {
            controlCentral.MoneyManager.AddDinero(5);
            controlCentral.DisplayControl.ChangeLabelIntroducidoState($"Introducido: {controlCentral.MoneyManager.DineroIntroducido}$");
            controlCentral.Cajero.AddDenomination("5");

            controlCentral.DisplayControl.ChangeLabelDineroTotalState(controlCentral.MoneyManager.DineroTotal.ToString());
            controlCentral.DisplayControl.RefreshCertainDenomination("5");
        }

        private void btn10p_Click(object sender, EventArgs e)
        {
            controlCentral.MoneyManager.AddDinero(10);
            controlCentral.DisplayControl.ChangeLabelIntroducidoState($"Introducido: {controlCentral.MoneyManager.DineroIntroducido}$"); ;
            controlCentral.Cajero.AddDenomination("10");

            controlCentral.DisplayControl.ChangeLabelDineroTotalState(controlCentral.MoneyManager.DineroTotal.ToString());
            controlCentral.DisplayControl.RefreshCertainDenomination("10");
        }

        private void btn20b_Click(object sender, EventArgs e)
        {
            controlCentral.MoneyManager.AddDinero(20);
            controlCentral.DisplayControl.ChangeLabelIntroducidoState($"Introducido: {controlCentral.MoneyManager.DineroIntroducido}$");
            controlCentral.Cajero.AddDenomination("20");

            controlCentral.DisplayControl.ChangeLabelDineroTotalState(controlCentral.MoneyManager.DineroTotal.ToString());
            controlCentral.DisplayControl.RefreshCertainDenomination("20");
        }

        private void btn50b_Click(object sender, EventArgs e)
        {
            controlCentral.MoneyManager.AddDinero(50);
            controlCentral.DisplayControl.ChangeLabelIntroducidoState($"Introducido: {controlCentral.MoneyManager.DineroIntroducido}$");
            controlCentral.Cajero.AddDenomination("50");

            controlCentral.DisplayControl.ChangeLabelDineroTotalState(controlCentral.MoneyManager.DineroTotal.ToString());
            controlCentral.DisplayControl.RefreshCertainDenomination("50");
        }

        private void btn100b_Click(object sender, EventArgs e)
        {
            controlCentral.MoneyManager.AddDinero(100);
            controlCentral.DisplayControl.ChangeLabelIntroducidoState($"Introducido: {controlCentral.MoneyManager.DineroIntroducido}$");
            controlCentral.Cajero.AddDenomination("100");

            controlCentral.DisplayControl.ChangeLabelDineroTotalState(controlCentral.MoneyManager.DineroTotal.ToString());
            controlCentral.DisplayControl.RefreshCertainDenomination("100");
        }

        private void btn200b_Click(object sender, EventArgs e)
        {
            controlCentral.MoneyManager.AddDinero(200);
            controlCentral.DisplayControl.ChangeLabelIntroducidoState($"Introducido: {controlCentral.MoneyManager.DineroIntroducido}$");
            controlCentral.Cajero.AddDenomination("200");

            controlCentral.DisplayControl.ChangeLabelDineroTotalState(controlCentral.MoneyManager.DineroTotal.ToString());
            controlCentral.DisplayControl.RefreshCertainDenomination("200");
        }

        private void btn500b_Click(object sender, EventArgs e)
        {
            controlCentral.MoneyManager.AddDinero(500);
            controlCentral.DisplayControl.ChangeLabelIntroducidoState($"Introducido: {controlCentral.MoneyManager.DineroIntroducido}$");
            controlCentral.Cajero.AddDenomination("500");

            controlCentral.DisplayControl.ChangeLabelDineroTotalState(controlCentral.MoneyManager.DineroTotal.ToString());
            controlCentral.DisplayControl.RefreshCertainDenomination("500");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controlCentral.DisplayControl.ChangeTxtDisplayState("A");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            controlCentral.DisplayControl.ChangeTxtDisplayState("B");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            controlCentral.DisplayControl.ChangeTxtDisplayState("C");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controlCentral.DisplayControl.ChangeTxtDisplayState("D");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            controlCentral.DisplayControl.ChangeTxtDisplayState("E");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            controlCentral.DisplayControl.ChangeTxtDisplayState("F");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            controlCentral.DisplayControl.ChangeTxtDisplayState("1");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            controlCentral.DisplayControl.ChangeTxtDisplayState("2");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            controlCentral.DisplayControl.ChangeTxtDisplayState("3");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            controlCentral.DisplayControl.ChangeTxtDisplayState("4");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            controlCentral.DisplayControl.ChangeTxtDisplayState("5");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            controlCentral.DisplayControl.ChangeTxtDisplayState("6");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            controlCentral.DisplayControl.ChangeTxtDisplayState("7");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            controlCentral.DisplayControl.ChangeTxtDisplayState("8");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            controlCentral.DisplayControl.ChangeTxtDisplayState("9");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            controlCentral.DisplayControl.ChangeTxtDisplayState("0");
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            controlCentral.GetChange();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            controlCentral.DisplayControl.DisplayMessage("");
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            controlCentral.GetProduct();
        }

        private void LoadContent()
        {
            LoadImages();

            controlCentral.MoneyManager.GetDineroTotal();

            Producto coca = controlCentral.Inventario.Productos[0];
            Producto sprite = controlCentral.Inventario.Productos[1];
            Producto drPepper = controlCentral.Inventario.Productos[2];

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

            labelDineroTotal.Text = controlCentral.MoneyManager.DineroTotal.ToString();
        }

        private void LoadImages()
        {
            imgCoca.Load(controlCentral.Inventario.Productos[0].Imagen);
            imgSprite.Load(controlCentral.Inventario.Productos[1].Imagen);
            imgDrPepper.Load(controlCentral.Inventario.Productos[2].Imagen);
        }
    }
}
