using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroClases
{
    public class MoneyManager
    {
        private int dineroTotal, dineroIntroducido, dineroPorCobrar;
        Cajero cajero = new Cajero();

        public int DineroTotal { get => dineroTotal; }
        public int DineroIntroducido { get => dineroIntroducido; set => dineroIntroducido = value; }
        public int DineroPorCobrar { get => dineroPorCobrar; set => dineroPorCobrar = value; }
        public Cajero Cajero { get => cajero; set => cajero = value; }

        public void GetDineroTotal()
        {
            dineroTotal = 0;
            for (int i = 0; i < Cajero.Denominaciones.Count; i++)
            {
                dineroTotal += Cajero.Denominaciones[i][0] * Cajero.Denominaciones[i][1];
            }
        }

        public void AddDinero(int dinero)
        {
            dineroIntroducido += dinero;
            dineroTotal += dinero;
        }

        public void AddCobro(int dinero)
        {
            dineroPorCobrar += dinero;
        }
    }
}
