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
    public partial class Transacciones : Form
    {
        public Transacciones(Form1 form)
        {
            InitializeComponent();

            
            dataGridView1.DataSource = form.ControlCentral.DBManager.Transacciones;
            dataGridView1.Columns[0].Width = 273;
            dataGridView1.Columns[1].Width = 273;
            dataGridView1.Columns[2].Width = 273;
        }
    }
}
