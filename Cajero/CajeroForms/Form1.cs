using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CajeroForms
{
    public partial class Form1 : Form
    {
        double total = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void imgCoca_Click(object sender, EventArgs e)
        {
            total += 13.50;
            labelTotal.Text = $"Total: {total}$";
        }

        private void imgSprite_Click(object sender, EventArgs e)
        {
            total += 11.50;
            labelTotal.Text = $"Total: {total}$";
        }

        private void imgDrPepper_Click(object sender, EventArgs e)
        {
            total += 12.00;
            labelTotal.Text = $"Total: {total}$";
        }
    }
}
