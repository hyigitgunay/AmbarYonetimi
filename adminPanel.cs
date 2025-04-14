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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ambarYonetimDurmazlar
{
    public partial class adminPanel : Form
    {
        public adminPanel()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();
        private void adminPanel_Load(object sender, EventArgs e)
        {
            DataSet1TableAdapters.Table_AmbarTableAdapter ds = new DataSet1TableAdapters.Table_AmbarTableAdapter();
            dataGridView1.DataSource = ds.GetData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Malzeme Bilgilerin Kaydetme
            SqlCommand komut = new SqlCommand("Insert Into Table_Ambar (IdMalzeme,MalzemeAd ,MalzemeGirisTarihi  ,MalzemeAdedi) Values (@p1,@p2,@p3,@p5)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox4.Text);
            komut.Parameters.AddWithValue("@p3", textBox2.Text);
            komut.Parameters.AddWithValue("@p5", textBox5.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Malzeme Verileri Eklenmiştir !", "Information", MessageBoxButtons.OK);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //temizle Butonu
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Verileri Düzenle
            SqlCommand komut3 = new SqlCommand("Update Table_Ambar Set MalzemeAd=@p2 , MalzemeGirisTarihi=@p3 ,MalzemeCıkısTarihi=@p4 , MalzemeAdedi=@p5 where IdMalzeme = @p1", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", textBox1.Text);
            komut3.Parameters.AddWithValue("@p2", textBox4.Text);
            komut3.Parameters.AddWithValue("@p3", textBox2.Text);
            komut3.Parameters.AddWithValue("@p4", textBox3.Text);
            komut3.Parameters.AddWithValue("@p5", textBox5.Text);
            komut3.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Malzeme Bilgileri Güncellendi. ", "Information", MessageBoxButtons.OK);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Malzeme Çıkış Tarihi Butonu
            SqlCommand kmt = new SqlCommand("Update Table_Ambar Set MalzemeCıkısTarihi=@p2 where IdMalzeme = @p1", bgl.baglanti());
            kmt.Parameters.AddWithValue("@p1", textBox1.Text);
            kmt.Parameters.AddWithValue("@p2", textBox3.Text);
            kmt.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Malzemenin Çıkış Tarihi Girildi.", "Information", MessageBoxButtons.OK);
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
