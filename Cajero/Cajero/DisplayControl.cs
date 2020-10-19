using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CajeroClases
{
    public class DisplayControl
    {
        TextBox txtDisplay, txt1p, txt2p, txt5p, txt10p, txt20p, txt50p, txt100p, txt200p, txt500p;
        Label labelPantalla, labelDineroTotal, labelMonedero, labelIntroducido, labelTotal;
        Cajero cajero = new Cajero();

        public TextBox TxtDisplay { get => txtDisplay; set => txtDisplay = value; }
        public Cajero Cajero { set => cajero = value; }

        public void InitializeDisplayControlTextBoxes(params TextBox[] otherTextBoxes)
        {
            TxtDisplay = otherTextBoxes[0];
            txt1p = otherTextBoxes[1];
            txt2p = otherTextBoxes[2];
            txt5p = otherTextBoxes[3];
            txt10p = otherTextBoxes[4];
            txt20p = otherTextBoxes[5];
            txt50p = otherTextBoxes[6];
            txt100p = otherTextBoxes[7];
            txt200p = otherTextBoxes[8];
            txt500p = otherTextBoxes[9];
        }

        public void InitializeDisplayControlLabels(params Label[] otherLabels)
        {
            labelPantalla = otherLabels[0];
            labelDineroTotal = otherLabels[1];
            labelMonedero = otherLabels[2];
            labelIntroducido = otherLabels[3];
            labelTotal = otherLabels[4];
        }

        public void DisplayMessage(string message)
        {
            TxtDisplay.Text = message;
        }

        public void RefreshTxtDenominations()
        {
            txt1p.Text = cajero.Denominaciones[0][1].ToString();
            txt2p.Text = cajero.Denominaciones[1][1].ToString();
            txt5p.Text = cajero.Denominaciones[2][1].ToString();
            txt10p.Text = cajero.Denominaciones[3][1].ToString();
            txt20p.Text = cajero.Denominaciones[4][1].ToString();
            txt50p.Text = cajero.Denominaciones[5][1].ToString();
            txt100p.Text = cajero.Denominaciones[6][1].ToString();
            txt200p.Text = cajero.Denominaciones[7][1].ToString();
            txt500p.Text = cajero.Denominaciones[8][1].ToString();
        }

        public void RefreshCertainDenomination(string denomination)
        {
            switch (denomination)
            {
                case "1":
                    txt1p.Text = cajero.Denominaciones[0][1].ToString();
                    return;
                case "2":
                    txt2p.Text = cajero.Denominaciones[1][1].ToString();
                    return;
                case "5":
                    txt5p.Text = cajero.Denominaciones[2][1].ToString();
                    return;
                case "10":
                    txt10p.Text = cajero.Denominaciones[3][1].ToString();
                    return;
                case "20":
                    txt20p.Text = cajero.Denominaciones[4][1].ToString();
                    return;
                case "50":
                    txt50p.Text = cajero.Denominaciones[5][1].ToString();
                    return;
                case "100":
                    txt100p.Text = cajero.Denominaciones[6][1].ToString();
                    return;
                case "200":
                    txt200p.Text = cajero.Denominaciones[7][1].ToString();
                    return;
                case "500":
                    txt500p.Text = cajero.Denominaciones[8][1].ToString();
                    return;
            }
        }

        public void ChangeLabelPantallaState(string text)
        {
            labelPantalla.Text = text;
        }

        public void ChangeLabelDineroTotalState(string text)
        {
            labelDineroTotal.Text = text;
        }

        public void ChangeLabelMonederoState(string text)
        {
            labelMonedero.Text = text;
        }

        public void ChangeLabelIntroducidoState(string text)
        {
            labelIntroducido.Text = text;
        }

        public void ChangeLabelTotalState(string text)
        {
            labelTotal.Text = text;
        }

        public void ChangeTxtDisplayState(string buttonText)
        {
            txtDisplay.Text += buttonText;
        }    
    }
}
