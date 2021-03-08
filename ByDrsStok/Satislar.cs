using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ByDrsStok
{
    public partial class Satislar : Form
    {
        
        public Satislar()
        {
            InitializeComponent();
        }
        bag bgl = new bag();
        
        void Goster()
        {
            SqlConnection bag = new SqlConnection(bgl.Adres);
            
            bag.Open();
            SqlDataAdapter adp = new SqlDataAdapter("SELECT * FROM tblsat", bag);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            bag.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection bag = new SqlConnection(bgl.Adres);
            int kalanmal = Convert.ToInt32(textBox1.Text) - (Convert.ToInt32(adettxt.Text));
            double toplamadet = Convert.ToDouble(adettxt.Text) * Convert.ToDouble(fyttxt.Text);
            SqlCommand kom = new SqlCommand("Insert into tblsat(marka,model,renk,adet,fiyat,toplam,kalan) VALUES ('"+mrkcombo.Text+"','"+modeltxt.Text+"','"+renkcombo.Text+"','" + adettxt.Text + "','" + fyttxt.Text + "','" + toplamadet +"','"+kalanmal+"')", bag);

            bag.Open();
            kom.ExecuteNonQuery();
            bag.Close();
            Goster();
            adettxt.Clear();
            fyttxt.Clear();
            textBox1.Text = kalanmal.ToString();
            modeltxt.Clear();
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection bag = new SqlConnection(bgl.Adres);
            bag.Open();
            SqlCommand kom = new SqlCommand("delete from tblsat where id=" + idtxt.Text + "", bag);

            kom.ExecuteNonQuery();
            bag.Close();
            Goster();
            adettxt.Clear();
            fyttxt.Clear();
            
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            idtxt.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            mrkcombo.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            modeltxt.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            renkcombo.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();  
            adettxt.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            fyttxt.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection bag = new SqlConnection(bgl.Adres);
            int kalanmal = Convert.ToInt32(textBox1.Text) - (Convert.ToInt32(adettxt.Text));
            double toplamadet = Convert.ToDouble(adettxt.Text) * Convert.ToDouble(fyttxt.Text);
            bag.Open();
            SqlCommand kom = new SqlCommand("update tblsat set marka='"+mrkcombo.Text+"',model='"+modeltxt.Text+"',renk='"+renkcombo.Text+"', adet='" + adettxt.Text + "',fiyat='" + fyttxt.Text + "',toplam='" + toplamadet + "',kalan='"+kalanmal+"' where id=" + idtxt.Text + "", bag);
            kom.ExecuteNonQuery();
            bag.Close();
            Goster();
            adettxt.Clear();
            fyttxt.Clear();
            textBox1.Text = kalanmal.ToString();
        }

        private void Satislar_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(bgl.Adres);
            Goster();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mrkcombo.Text = "";
            renkcombo.Text = "";
            

            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    TextBox tbox = (TextBox)item;
                    tbox.Clear();
                }
            }
        }
    }
}
