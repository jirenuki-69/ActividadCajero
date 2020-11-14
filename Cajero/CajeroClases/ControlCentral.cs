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
        string numeroTelefonico = string.Empty;

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
            displayControl.MoneyManager = this.moneyManager;
            timer = new Timer(1000);
            timerProducto = new Timer(2000);
        }

        public Cajero Cajero { get => cajero; set => cajero = value; }
        public MoneyManager MoneyManager { get => moneyManager; set => moneyManager = value; }
        public Inventario Inventario { get => inventario; set => inventario = value; }
        public DisplayControl DisplayControl { get => displayControl; set => displayControl = value; }
        public DBManager DBManager { get => dbManager; set => dbManager = value; }
        public InputControl InputControl { get => inputControl; set => inputControl = value; }
        public string NumeroTelefonico { get => numeroTelefonico; set => numeroTelefonico = value; }
        public Timer Timer { get => timer; }
        public Timer TimerProducto { get => timerProducto; set => timerProducto = value; }

        public void SaveNumber(string number) 
        { 
            numeroTelefonico = number;
            displayControl.NumeroTelefonico = this.numeroTelefonico;
            displayControl.RefreshSaldo();
        }

        public void GetChange()
        {
            if (inventario.ExperienciaElegida != null)
            {
                moneyManager.ReturnChange();

                if (inventario.HayProducto)
                {
                    timerProducto.Elapsed += TimerProducto_Elapsed;
                    timerProducto.Start();
                    inventario.HayProducto = false;
                }
            } 
            else 
            {
                displayControl.ChangeLabelPantallaState("Sin experiencia a elegir");
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
                inventario.ExperienciaElegida = inventario.Experiencias.Find(element => (element as Producto).Codigo == displayControl.TxtDisplay.Text);

                if (inventario.ExperienciaElegida != null && (inventario.ExperienciaElegida as Producto).Categoria == Categoria.Producto)
                {
                    moneyManager.DineroPorCobrar += (inventario.ExperienciaElegida as Producto).Precio;
                }
                else
                {
                    displayControl.ChangeLabelPantallaState($"No existe un producto con ese código");
                    return;
                }

                displayControl.ChangeLabelTotalState($"Total: {moneyManager.DineroPorCobrar}$");
                displayControl.ChangeLabelPantallaState($"Usted ha elegido el producto: {(inventario.ExperienciaElegida as Producto).Nombre}");
                inventario.HayProducto = true;
            }
        }

        public void SelectTiempo()
        {
            if (numeroTelefonico != string.Empty)
            {
                System.Windows.Forms.ListView.SelectedListViewItemCollection collection = displayControl.LVTiempoAire1.SelectedItems;
                System.Windows.Forms.ListViewItem listViewItem = collection[0];

                inventario.ExperienciaElegida = inventario.Experiencias.Find(e => e.Nombre == listViewItem.Text.ToString() && e.Categoria == Categoria.Servicio);

                if (inventario.ExperienciaElegida != null)
                {
                    displayControl.ChangeLabelPantallaState($"Usted a elegido el plan de: {inventario.ExperienciaElegida.Nombre}");
                    moneyManager.GetPrecioServicio();
                }
            }
            else
            {
                displayControl.ChangeLabelPantallaState("Necesita ingresar un número para contratar\r\nun plan de tiempo aire");
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
            displayControl.ChangeLabelPantallaState("Usted ya puede pagar la experiencia");
        }
    }
}
