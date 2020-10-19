﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroClases
{
    public class ControlCentral
    {
        Cajero cajero;
        MoneyManager moneyManager;
        Inventario inventario;
        DisplayControl displayControl;

        public ControlCentral()
        {
            cajero = new Cajero();
            moneyManager = new MoneyManager();
            inventario = new Inventario();
            displayControl = new DisplayControl();
            displayControl.Cajero = cajero;
            moneyManager.Cajero = cajero;
            moneyManager.Cajero.Denominaciones.ForEach(e => e[1] += 3);
        }

        public Cajero Cajero { get => cajero; set => cajero = value; }
        public MoneyManager MoneyManager { get => moneyManager; set => moneyManager = value; }
        public Inventario Inventario { get => inventario; set => inventario = value; }
        public DisplayControl DisplayControl { get => displayControl; set => displayControl = value; }

        public void GetChange()
        {
            if (inventario.ProductoElegido != null)
            {
                if (moneyManager.DineroIntroducido - moneyManager.DineroPorCobrar > 0)
                {
                    try
                    {
                        List<int> cambio = cajero.ReturnChange(moneyManager.DineroIntroducido - moneyManager.DineroPorCobrar);

                        displayControl.RefreshTxtDenominations();
                        displayControl.ChangeLabelPantallaState($"Compra realizada de manera correcta. Cambio: {moneyManager.DineroIntroducido - moneyManager.DineroPorCobrar}");

                        string data = string.Join(" pesos, ", cambio);
                        data += " pesos";

                        displayControl.ChangeLabelMonederoState($"Monedas y billetes: {data}");

                        moneyManager.DineroIntroducido = 0;
                        moneyManager.DineroPorCobrar = 0;

                        displayControl.ChangeLabelIntroducidoState($"Introducido: {moneyManager.DineroIntroducido}$");
                        displayControl.ChangeLabelTotalState($"Total: {moneyManager.DineroPorCobrar}$");
                    }
                    catch (Exception error)
                    {
                        displayControl.ChangeLabelPantallaState(error.Message);
                    }

                    moneyManager.GetDineroTotal();
                    
                    displayControl.ChangeLabelDineroTotalState(moneyManager.DineroTotal.ToString());
                    displayControl.DisplayMessage("");
                }
                else if (moneyManager.DineroIntroducido - moneyManager.DineroPorCobrar == 0)
                {
                    displayControl.ChangeLabelPantallaState("Gracias por su compra!!");
                }
                else
                {
                    displayControl.ChangeLabelPantallaState("Lo introducido es menor al total");
                }

            } else {
                displayControl.ChangeLabelPantallaState("Sin producto a elegir");
            }
        }
    
        public void GetProduct()
        {
            if (displayControl.TxtDisplay.TextLength == 3)
            {
                inventario.ProductoElegido = inventario.Productos.Find(element => element.Codigo == displayControl.TxtDisplay.Text);

                moneyManager.DineroPorCobrar += inventario.ProductoElegido.Precio;

                displayControl.ChangeLabelTotalState($"Total: {moneyManager.DineroPorCobrar}$");
                displayControl.ChangeLabelPantallaState($"Usted ha elegido el producto: {inventario.ProductoElegido.Nombre}");
            }
        }
    }
}