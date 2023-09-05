using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace TeknikServis.Formlar
{
    public partial class FrmMarkalar : Form
    {
        public FrmMarkalar()
        {
            InitializeComponent();
        }
        DBTeknıkServısEntities db = new DBTeknıkServısEntities();
        private void FrmMarkalar_Load(object sender, EventArgs e)
        {
            /*var degerler = db.TBLURUN.OrderBy(x => x.MARKA).GroupBy(y => y.MARKA).Select(z => new
            {
                //Marka = z.Key,
                Toplam = z.Count()

            });
            gridControl1.DataSource = degerler.ToList();*/
            labelControl2.Text = db.TBLURUN.Count().ToString();
            /*labelControl3.Text = (from x in db.TBLURUN
                                   select x.MARKA).Distinct().Count().ToString();
            labelControl7.Text = (from x in db.TBLURUN
                                   orderby x.SATISFIYAT descending
                                   select x.MARKA).FirstOrDefault();
            chartControl1.Series["Series 1"].Points.AddPoint("Siemens", 3);
            chartControl1.Series["Series 1"].Points.AddPoint("Acer", 1);
            chartControl1.Series["Series 1"].Points.AddPoint("Arçelik", 3);
            chartControl1.Series["Series 1"].Points.AddPoint("Beko", 1);
            chartControl1.Series["Series 1"].Points.AddPoint("Casper", 1);
            chartControl1.Series["Series 1"].Points.AddPoint("HP", 1);
            chartControl1.Series["Series 1"].Points.AddPoint("Lenovo", 1);
            chartControl1.Series["Series 1"].Points.AddPoint("LG", 1);
            chartControl1.Series["Series 1"].Points.AddPoint("Monster", 1);
            chartControl1.Series["Series 1"].Points.AddPoint("MSI", 1);*/

            /*chartControl2.Series["Kategoriler"].Points.AddPoint("Beyaz Eşya", 4);
            chartControl2.Series["Kategoriler"].Points.AddPoint("Bilgisayar", 3);
            chartControl2.Series["Kategoriler"].Points.AddPoint("Küçük Ev Aletleri", 6);
            chartControl2.Series["Kategoriler"].Points.AddPoint("TV", 1);
            chartControl2.Series["Kategoriler"].Points.AddPoint("Telefon", 0);
            chartControl2.Series["Kategoriler"].Points.AddPoint("Çanta", 0);*/

            SqlConnection baglanti = new SqlConnection(@"Data Source=FURKANY\SQLEXPRESS;Initial Catalog=DBTeknıkServıs;Integrated Security=True");

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("SELECT TBLKATEGORI.AD, COUNT(*) FROM TBLURUN  INNER JOIN TBLKATEGORI ON TBLKATEGORI.ID = TBLURUN.KATEGORİ GROUP BY TBLKATEGORI.AD", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chartControl2.Series["Kategoriler"].Points.AddPoint(Convert.ToString(dr2[0]), int.Parse(dr2[1].ToString()));
            }
            baglanti.Close();
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnAnaSayfa_Click(object sender, EventArgs e)
        {
            Formlar.FrmAnaSayfa fr = new Formlar.FrmAnaSayfa();
            //fr.MdiParent = this;
            fr.Show();
            this.Hide();
        }

        private void BtnKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
