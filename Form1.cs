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
using Npgsql;

namespace database
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=Odev; user ID=postgres; password=12345");
        //Listele butonu
        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from musteri";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //Ekle butonu
        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into musteri (kullanicino,ad,soyad,email,telefonno,ilKodu,ilceKodu) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut1.Parameters.AddWithValue("@p2", textBox2.Text);
            komut1.Parameters.AddWithValue("@p3", textBox3.Text);
            komut1.Parameters.AddWithValue("@p4", textBox4.Text);
            komut1.Parameters.AddWithValue("@p5", int.Parse(textBox5.Text));
            komut1.Parameters.AddWithValue("@p6", int.Parse(textBox6.Text));
            komut1.Parameters.AddWithValue("@p7", int.Parse(textBox7.Text));
            komut1.ExecuteNonQuery();
            baglanti.Close();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //Silme butonu
        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete From musteri where kullanicino=@p1 ",baglanti);
            komut2.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut2.ExecuteNonQuery();
            baglanti.Close();
        }
        //Guncelle butonu
        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("UPDATE \"musteri\" SET \"ad\"=@p1, \"soyad\"=@p2, \"email\"=@p3, \"telefonno\"=@p4 WHERE \"kullanicino\"=@p5 ", baglanti);
            komut3.Parameters.AddWithValue("@p1",textBox2.Text);
            komut3.Parameters.AddWithValue("@p2", textBox3.Text);
            komut3.Parameters.AddWithValue("@p3", textBox4.Text);
            komut3.Parameters.AddWithValue("@p4", int.Parse(textBox5.Text));

            komut3.Parameters.AddWithValue("@p5", int.Parse(textBox1.Text));
            komut3.ExecuteNonQuery();
            baglanti.Close();
        }
        //Arama textboxu
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = ("SELECT * FROM \"musteri\" WHERE \"ad\" LIKE '%" + textBox8.Text + "%' ");
            DataTable dt = new DataTable();
            NpgsqlDataAdapter ara = new NpgsqlDataAdapter(sorgu, baglanti);
            ara.Fill(dt);
            baglanti.Close();
            dataGridView1.DataSource = dt;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
