using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ByDrsStok
{
    public partial class odeme : Form
    {
        public odeme()
        {
            InitializeComponent();
        }
        bag bgl = new bag();
        void Goster()
        {
            SqlConnection bag = new SqlConnection(bgl.Adres);
            
            bag.Open();
            SqlDataAdapter adp = new SqlDataAdapter("SELECT * FROM tblodeme", bag);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            bag.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection bag = new SqlConnection(bgl.Adres);
            SqlCommand kom = new SqlCommand("Insert into tblodeme(kime,odeme) VALUES ('" + kimtxt.Text + "','" + odemetxt.Text + "')", bag);

            bag.Open();
            kom.ExecuteNonQuery();
            bag.Close();
            Goster();
            kimtxt.Clear();
            odemetxt.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection bag = new SqlConnection(bgl.Adres);
            bag.Open();
            SqlCommand kom = new SqlCommand("delete from tblodeme where id=" + idtxt.Text + "", bag);

            kom.ExecuteNonQuery();
            bag.Close();
            Goster();
            kimtxt.Clear();
            odemetxt.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection bag = new SqlConnection(bgl.Adres);
            bag.Open();
            SqlCommand kom = new SqlCommand("update tblodeme set kime='" + kimtxt.Text + "',odeme='" + odemetxt.Text + "' where id=" + idtxt.Text + "", bag);


            kom.ExecuteNonQuery();
            bag.Close();
            Goster();
            kimtxt.Clear();
            odemetxt.Clear();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            idtxt.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            kimtxt.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            odemetxt.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void odeme_Load(object sender, EventArgs e)
        {
            Goster();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           

            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    TextBox tbox = (TextBox)item;
                    tbox.Clear();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
