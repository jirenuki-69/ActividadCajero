﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace CajeroClases
{
    public class DisplayControl
    {
        TextBox txtDisplay, txt1p, txt2p, txt5p, txt10p, txt20p, txt50p, txt100p, txt200p, txt500p, txtHora;
        Label labelPantalla, labelDineroTotal, labelMonedero, labelIntroducido, labelTotal, labelSaldo;
        ListView LVProductos, LVTiempoAire;
        ListView LVTransacciones = new ListView();
        Button btnSELECT, btnTELEFONO;
        Cajero cajero = new Cajero();
        Inventario inventario;
        MoneyManager moneyManager;
        string numeroTelefonico = string.Empty;

        public TextBox TxtDisplay { get => txtDisplay; set => txtDisplay = value; }
        public Cajero Cajero { set => cajero = value; }
        public Inventario Inventario { get => inventario; set => inventario = value; }
        public ListView LVTiempoAire1 { get => LVTiempoAire; set => LVTiempoAire = value; }
        public string NumeroTelefonico { get => numeroTelefonico; set => numeroTelefonico = value; }
        public MoneyManager MoneyManager { get => moneyManager; set => moneyManager = value; }
        public ListView LVTransacciones1 { get => LVTransacciones; set => LVTransacciones = value; }

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
            txtHora = otherTextBoxes[10];
        }

        public void InitializeDisplayControlLabels(params Label[] otherLabels)
        {
            labelPantalla = otherLabels[0];
            labelDineroTotal = otherLabels[1];
            labelMonedero = otherLabels[2];
            labelIntroducido = otherLabels[3];
            labelTotal = otherLabels[4];
            labelSaldo = otherLabels[5];
        }

        public void InitializeDisplayControlLV(params ListView[] listViews)
        {
            LVProductos = listViews[0];
            LVTiempoAire1 = listViews[1];
        }

        public void InitButton(params Button[] buttons)
        {
            btnSELECT = buttons[0];
            btnTELEFONO = buttons[1];
        }

        public void SwapListViews()
        {
            LVProductos.Visible = !LVProductos.Visible;
            LVTiempoAire1.Visible = !LVTiempoAire1.Visible;
            btnSELECT.Visible = !btnSELECT.Visible;
        }
        public void RefreshSaldo() => ChangeLabelSaldoState($"Saldo del número {numeroTelefonico}: {moneyManager.Saldo}");

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

        public void ChangeLabelSaldoState(string text)
        {
            labelSaldo.Text = text;
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

        public void ChangeTxtHoraState(string text)
        {
            txtHora.Text = text;
        }

        public void GetListView()
        {
            LVProductos.View = View.Details;

            for (int i = 0; i < inventario.Index; ++i)
            {
                ListViewItem listViewItem = new ListViewItem(
                    $"{(inventario.Experiencias[i] as Producto).Nombre}"
                );

                listViewItem.ImageIndex = i;

                listViewItem.SubItems.Add($"{(inventario.Experiencias[i] as Producto).Precio}");
                listViewItem.SubItems.Add($"{(inventario.Experiencias[i] as Producto).Existencia}");
                listViewItem.SubItems.Add($"{(inventario.Experiencias[i] as Producto).Codigo}");

                LVProductos.Items.Add(listViewItem);
            }

            LVTiempoAire1.View = View.Details;

            for (int i = inventario.Index; i < inventario.Index + inventario.Index2; ++i)
            {
                ListViewItem listViewItem = new ListViewItem(
                    $"{(inventario.Experiencias[i] as Servicio).Nombre}"
                );
                
                listViewItem.SubItems.Add($"{(inventario.Experiencias[i] as Servicio).TiempoAire}");
                listViewItem.SubItems.Add($"{(inventario.Experiencias[i] as Servicio).Company}");
                listViewItem.SubItems.Add($"{(inventario.Experiencias[i] as Servicio).Descripcion}");

                LVTiempoAire1.Items.Add(listViewItem);
            }
        }

        public ListView GetListViewTransactions()
        {
            LVTransacciones.Columns.Add("ID").Width = 273;
            LVTransacciones.Columns.Add("ID_EXPERIENCIA").Width = 273;
            LVTransacciones.Columns.Add("FECHA").Width = 273;

            LVTransacciones.Columns[0].TextAlign = HorizontalAlignment.Center;
            LVTransacciones.Columns[1].TextAlign = HorizontalAlignment.Center;
            LVTransacciones.Columns[2].TextAlign = HorizontalAlignment.Center;

            LVTransacciones.View = View.Details;

            for (int i = 0; i < inventario.Transacciones.Count; ++i)
            {
                ListViewItem listViewItem = new ListViewItem(
                    $"{inventario.Transacciones[i][0]}"
                );

                listViewItem.SubItems.Add($"{inventario.Transacciones[i][1]}");
                listViewItem.SubItems.Add($"{inventario.Transacciones[i][2]}");

                LVTransacciones.Items.Add(listViewItem);
            }

            return LVTransacciones;
        }
    }
}
