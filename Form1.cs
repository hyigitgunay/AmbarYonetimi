using System.Security.Cryptography;

namespace ambarYonetimDurmazlar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtAd.Text == "admin" && txtSifre.Text == "admin"){
                
                adminPanel frm = new adminPanel();
                frm.Show();
               
            }
            else
            {
                MessageBox.Show("Kullanýcý Adý veya Þifre Hatalý !");
            }
        }
    }
}
