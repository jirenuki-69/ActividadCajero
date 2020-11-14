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
    public partial class Telefono : Form
    {
        Form1 mainForm;
        public Telefono(Form1 form)
        {
            mainForm = form;
            InitializeComponent();
        }

        private void txtNUM_TextChanged(object sender, EventArgs e)
        {
            if (txtNUM.Text.Length > 10)
            {
                MessageBox.Show("Ingresé un número válido de 10 dígitos");
            }
        }

        private void btn5p_Click(object sender, EventArgs e)
        {
            if (txtNUM.Text.Length != 10)
            {
                MessageBox.Show("Ingresé un número válido de 10 dígitos");
                return;
            }

            mainForm.ControlCentral.SaveNumber(txtNUM.Text);
            this.Close();
        }
    }
}
