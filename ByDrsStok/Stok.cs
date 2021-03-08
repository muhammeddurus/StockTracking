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
    public partial class Stok : Form
    {
        public Stok()
        {
            InitializeComponent();
        }
        bag bgl = new bag();
        void Goster()
        {
            SqlConnection bag = new SqlConnection(bgl.Adres);

            bag.Open();
            SqlDataAdapter adp = new SqlDataAdapter("SELECT * FROM tblstok", bag);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            bag.Close();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            SqlConnection bag = new SqlConnection(bgl.Adres);
            int toplamadet = Convert.ToInt32(adet1txt.Text) + Convert.ToInt32(adet2txt.Text) + Convert.ToInt32(adet3txt.Text) + Convert.ToInt32(adet4txt.Text) + Convert.ToInt32(adet5txt.Text) + Convert.ToInt32(adet6txt.Text);
            SqlCommand kom = new SqlCommand("Insert into tblstok(aciklama,marka,renk1,adet1,renk2,adet2,renk3,adet3,renk4,adet4,renk5,adet5,renk6,adet6,toplam) VALUES ('" + aciklamatxt.Text + "','" + comboBox7.Text + "','" + comboBox1.SelectedItem + "','" + int.Parse(adet1txt.Text) + "','" + comboBox2.SelectedItem + "','" + int.Parse(adet2txt.Text) + "','" + comboBox3.SelectedItem + "','" + int.Parse(adet3txt.Text) + "','" + comboBox4.SelectedItem + "','" + int.Parse(adet4txt.Text) + "','" + comboBox5.SelectedItem + "','" + int.Parse(adet5txt.Text) + "','" + comboBox6.SelectedItem + "','" + int.Parse(adet6txt.Text) + "','" + toplamadet + "')", bag);

            bag.Open();
            kom.ExecuteNonQuery();
            bag.Close();
            Goster();
            

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Stok_Load(object sender, EventArgs e)
        {
            Goster();
        }

        private void btngnc_Click(object sender, EventArgs e)
        {
            SqlConnection bag = new SqlConnection(bgl.Adres);
            int toplamadet = Convert.ToInt32(adet1txt.Text) + Convert.ToInt32(adet2txt.Text) + Convert.ToInt32(adet3txt.Text) + Convert.ToInt32(adet4txt.Text) + Convert.ToInt32(adet5txt.Text) + Convert.ToInt32(adet6txt.Text);
            bag.Open();
            SqlCommand kom = new SqlCommand("update tblstok set adet1='" + adet1txt.Text + "',adet2='" + adet2txt.Text + "',adet3='" + adet3txt.Text + "',adet4='" + adet4txt.Text + "',adet5='" + adet5txt.Text + "',adet6='" + adet6txt.Text + "',toplam='" + toplamadet + "' where id=" + idtxt.Text + "", bag);


            kom.ExecuteNonQuery();
            bag.Close();
            Goster();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            idtxt.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            aciklamatxt.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox7.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            adet1txt.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            adet2txt.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            adet3txt.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            comboBox4.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            adet4txt.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            comboBox5.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            adet5txt.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            comboBox6.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            adet6txt.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlConnection bag = new SqlConnection(bgl.Adres);
            bag.Open();
            SqlCommand kom = new SqlCommand("delete from tblstok where id=" + idtxt.Text + "", bag);

            kom.ExecuteNonQuery();
            bag.Close();
            Goster();
        }

        private void btngoster_Click(object sender, EventArgs e)
        {
            Goster();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
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

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            comboBox6.Text = "";
            comboBox7.Text = "";
            
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    TextBox tbox = (TextBox)item;
                    tbox.Clear();
                }
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
