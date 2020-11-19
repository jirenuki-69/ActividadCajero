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

        public ControlCentral ControlCentral { get => controlCentral; }

        public Form1()
        {
            InitializeComponent();

            Control.CheckForIllegalCrossThreadCalls = false;

            controlCentral.DisplayControl.InitializeDisplayControlTextBoxes(
                txtInput, txt1peso, txt2pesos, txt5pesos, txt10pesos, txt20pesos, txt50pesos,
                txt100pesos, txt200pesos, txt500pesos, txtHora
            );

            controlCentral.DisplayControl.InitializeDisplayControlLabels(
                labelPantalla, labelDineroTotal, labelMonedero, labelIntroducido, labelTotal,
                labelSaldo
            );

            controlCentral.DisplayControl.InitializeDisplayControlLV(listViewProductos, listViewTiempoAire);

            controlCentral.DisplayControl.InitButton(btnSELECT, btnTELEFONO);

            controlCentral.DisplayControl.GetListView();

            controlCentral.DisplayControl.RefreshTxtDenominations();

            controlCentral.MoneyManager.GetDineroTotal();

            controlCentral.InitTimer();

            controlCentral.ControlPaidProduct();
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
            controlCentral.InputControl.GetPressedButton("A");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            controlCentral.InputControl.GetPressedButton("B");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            controlCentral.InputControl.GetPressedButton("C");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controlCentral.InputControl.GetPressedButton("D");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            controlCentral.InputControl.GetPressedButton("E");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            controlCentral.InputControl.GetPressedButton("F");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            controlCentral.InputControl.GetPressedButton("1");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            controlCentral.InputControl.GetPressedButton("2");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            controlCentral.InputControl.GetPressedButton("3");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            controlCentral.InputControl.GetPressedButton("4");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            controlCentral.InputControl.GetPressedButton("5");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            controlCentral.InputControl.GetPressedButton("6");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            controlCentral.InputControl.GetPressedButton("7");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            controlCentral.InputControl.GetPressedButton("8");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            controlCentral.InputControl.GetPressedButton("9");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            controlCentral.InputControl.GetPressedButton("0");
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            controlCentral.GetChange();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            controlCentral.InputControl.GetPressedButton("");
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            controlCentral.GetProduct();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            controlCentral.DisplayControl.SwapListViews();
        }

        private void btnSELECT_Click(object sender, EventArgs e)
        {
            controlCentral.SelectTiempo();
        }

        private void btnTELEFONO_Click(object sender, EventArgs e)
        {
            Telefono telefono = new Telefono(this);
            telefono.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            controlCentral.Timer.Dispose();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Transacciones transacciones = new Transacciones(this);
            transacciones.Show();
        }
    }
}
