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

namespace TeknikServis.Formlar
{
    public partial class FrmCariiller : Form
    {
        public FrmCariiller()
        {
            InitializeComponent();
        }
        DBTeknıkServısEntities DB = new DBTeknıkServısEntities();

        SqlConnection baglanti = new SqlConnection(@"Data Source=FURKANY\SQLEXPRESS;Initial Catalog=DBTeknıkServıs;Integrated Security=True");
        private void FrmCariiller_Load(object sender, EventArgs e)
        {
            /*chartControl1.Series["Series 1"].Points.AddPoint("Ankara", 28);
            chartControl1.Series["Series 1"].Points.AddPoint("İstanbul", 22);
            chartControl1.Series["Series 1"].Points.AddPoint("İzmir", 17);
            chartControl1.Series["Series 1"].Points.AddPoint("Bursa", 21);*/

            gridControl1.DataSource = DB.TBLCARI.OrderBy(x => x.IL).
                GroupBy(y => y.IL).
                Select(z => new { İL = z.Key, TOPLAM = z.Count() }).ToList();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT IL, COUNT(*) from TBLCARI group by IL", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]),int.Parse( dr[1].ToString()));
            }
        }

        private void BtnKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnAnaSayfa_Click(object sender, EventArgs e)
        {
            Formlar.FrmAnaSayfa fr = new Formlar.FrmAnaSayfa();
            //fr.MdiParent = this;
            fr.Show();
            this.Hide();

        }
    }
}
