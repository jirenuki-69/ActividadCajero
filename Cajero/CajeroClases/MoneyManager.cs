using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroClases
{
    public class MoneyManager
    {
        private int dineroTotal, dineroIntroducido, dineroPorCobrar, saldo, saldoPorGanar;
        Cajero cajero = new Cajero();
        DisplayControl displayControl = new DisplayControl();
        Inventario inventario = new Inventario();

        public int DineroTotal { get => dineroTotal; }
        public int DineroIntroducido { get => dineroIntroducido; set => dineroIntroducido = value; }
        public int DineroPorCobrar { get => dineroPorCobrar; set => dineroPorCobrar = value; }
        public Cajero Cajero { get => cajero; set => cajero = value; }
        public DisplayControl DisplayControl { get => displayControl; set => displayControl = value; }
        public Inventario Inventario { get => inventario; set => inventario = value; }
        public int Saldo { get => saldo; set => saldo = value; }
        public int SaldoPorGanar { get => saldoPorGanar; set => saldoPorGanar = value; }

        public void GetDineroTotal()
        {
            dineroTotal = 0;
            for (int i = 0; i < Cajero.Denominaciones.Count; i++)
            {
                dineroTotal += Cajero.Denominaciones[i][0] * Cajero.Denominaciones[i][1];
            }

            displayControl.ChangeLabelDineroTotalState(dineroTotal.ToString());
        }

        public void AddSaldo(int dinero) => saldo += dinero;

        public void AddDinero(int dinero)
        {
            dineroIntroducido += dinero;
            dineroTotal += dinero;

            if (inventario.ExperienciaElegida != null)
            {
                if (dineroIntroducido >= inventario.ExperienciaElegida.Precio)
                {
                    PaidProductEvent();
                }
                else
                {
                    System.Diagnostics.Debug.Print("Dinero insuficiente");
                }
            }
        }

        public void AddCobro(int dinero)
        {
            dineroPorCobrar += dinero;
        }

        public void ReturnChange()
        {
            if (dineroIntroducido - dineroPorCobrar > 0)
            {
                try
                {
                    List<int> cambio = cajero.ReturnChange(dineroIntroducido - dineroPorCobrar);

                    DisplayControl.RefreshTxtDenominations();
                    DisplayControl.ChangeLabelPantallaState($"Compra realizada de manera correcta. Cambio: {dineroIntroducido - dineroPorCobrar}");

                    string data = string.Join(" pesos, ", cambio);
                    data += " pesos";

                    DisplayControl.ChangeLabelMonederoState($"Monedas y billetes: {data}");

                    if (saldoPorGanar != 0)
                        saldo += saldoPorGanar;

                    dineroIntroducido = 0;
                    dineroPorCobrar = 0;
                    saldoPorGanar = 0;

                    DisplayControl.RefreshSaldo();
                    DisplayControl.ChangeLabelIntroducidoState($"Introducido: {dineroIntroducido}$");
                    DisplayControl.ChangeLabelTotalState($"Total: {dineroPorCobrar}$");
                }
                catch (Exception error)
                {
                    DisplayControl.ChangeLabelPantallaState(error.Message);
                }

                GetDineroTotal();

                DisplayControl.DisplayMessage("");
            }
            else if (dineroIntroducido - dineroPorCobrar == 0)
            {
                DisplayControl.ChangeLabelPantallaState("Gracias por su compra!!");

                if (saldoPorGanar != 0)
                    saldo += saldoPorGanar;

                dineroIntroducido = 0;
                dineroPorCobrar = 0;
                saldoPorGanar = 0;

                DisplayControl.RefreshSaldo();
                DisplayControl.ChangeLabelIntroducidoState($"Introducido: {dineroIntroducido}$");
                DisplayControl.ChangeLabelTotalState($"Total: {dineroPorCobrar}$");
            }
            else
            {
                DisplayControl.ChangeLabelPantallaState("Lo introducido es menor al total");
            }
        }

        public void GetPrecioServicio()
        {
            dineroPorCobrar += inventario.ExperienciaElegida.Precio;
            saldoPorGanar += inventario.ExperienciaElegida.Precio;
            displayControl.ChangeLabelTotalState($"Total: {dineroPorCobrar}$");
        }

        public delegate void PaidProduct(); //Referencia al evento

        public event PaidProduct PaidProductEvent; //Evento al pagar un producto
    }
}
