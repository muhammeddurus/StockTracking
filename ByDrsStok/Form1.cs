using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ByDrsStok
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stok form2 = new Stok();
            form2.Show();  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Satislar form3 = new Satislar();
            form3.Show();  
        }

        private void button3_Click(object sender, EventArgs e)
        {
            odeme form4 = new odeme();
            form4.Show();
        }
    }
}
