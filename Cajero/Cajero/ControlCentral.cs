using Cajero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CajeroClases
{
    public class ControlCentral
    {
        Cajero cajero;
        MoneyManager moneyManager;
        Inventario inventario;
        DisplayControl displayControl;
        InputControl inputControl;
        DBManager dbManager;
        Timer timer, timerProducto;

        public ControlCentral()
        {
            cajero = new Cajero();
            moneyManager = new MoneyManager();
            inventario = new Inventario();
            displayControl = new DisplayControl();
            inputControl = new InputControl();
            dbManager = new DBManager();
            inputControl.DisplayControl = this.displayControl;
            moneyManager.DisplayControl = this.displayControl;
            displayControl.Cajero = this.cajero;
            moneyManager.Cajero = this.cajero;
            moneyManager.Cajero.Denominaciones.ForEach(e => e[1] += 3);
            moneyManager.Inventario = this.inventario;
            inventario.DBManager = this.dbManager;
            displayControl.DBManagerData = this.inventario.DBManagerData;
            displayControl.Inventario = this.inventario;
            timer = new Timer(1000);
            timerProducto = new Timer(2000);
        }

        public Cajero Cajero { get => cajero; set => cajero = value; }
        public MoneyManager MoneyManager { get => moneyManager; set => moneyManager = value; }
        public Inventario Inventario { get => inventario; set => inventario = value; }
        public DisplayControl DisplayControl { get => displayControl; set => displayControl = value; }
        public DBManager DBManager { get => dbManager; set => dbManager = value; }
        public InputControl InputControl { get => inputControl; set => inputControl = value; }

        public void GetChange()
        {
            if (inventario.ProductoElegido != null)
            {
                moneyManager.ReturnChange();
                timerProducto.Elapsed += TimerProducto_Elapsed;
                timerProducto.Start();
            } 
            else 
            {
                displayControl.ChangeLabelPantallaState("Sin producto a elegir");
            }
        }

        private void TimerProducto_Elapsed(object sender, ElapsedEventArgs e)
        {
            displayControl.ChangeLabelPantallaState("Retiro de producto");
            timerProducto.Close();
        }

        public void GetProduct()
        {
            if (displayControl.TxtDisplay.TextLength == 3)
            {
                inventario.ProductoElegido = inventario.Productos.Find(element => element.Codigo == displayControl.TxtDisplay.Text);

                if (inventario.ProductoElegido != null)
                {
                    moneyManager.DineroPorCobrar += inventario.ProductoElegido.Precio;
                }
                else
                {
                    displayControl.ChangeLabelPantallaState($"No existe un producto con ese código");
                    return;
                }

                displayControl.ChangeLabelTotalState($"Total: {moneyManager.DineroPorCobrar}$");
                displayControl.ChangeLabelPantallaState($"Usted ha elegido el producto: {inventario.ProductoElegido.Nombre}");
            }
        }

        public void InitTimer()
        {
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            displayControl.ChangeTxtHoraState(DateTime.Now.ToString());
        }

        public void ControlPaidProduct()
        {
            moneyManager.PaidProductEvent += MoneyManager_PaidProductEvent;
        }

        private void MoneyManager_PaidProductEvent()
        {
            displayControl.ChangeLabelPantallaState("Usted ya puede pagar el producto");
        }
    }
}
