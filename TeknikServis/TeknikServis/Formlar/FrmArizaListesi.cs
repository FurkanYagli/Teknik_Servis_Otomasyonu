using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmArizaListesi : Form
    {
        public FrmArizaListesi()
        {
            InitializeComponent();
        }
        DBTeknıkServısEntities db = new DBTeknıkServısEntities();
        private void FrmArizaListesi_Load(object sender, EventArgs e)
        {
            var degerler = from x in db.TBLURUNKABUL
                           select new
                           {
                               x.ISLEMID,
                               CARİ = x.TBLCARI.AD +" " +  x.TBLCARI.SOYAD,
                               PERSONEL = x.TBLPERSONEL.AD + " " + x.TBLPERSONEL.SOYAD,
                               x.GELISTARIH,
                               x.CIKISTARIHI,
                               x.URUNSERINO
                           };
            gridControl1.DataSource = degerler.ToList();
            labelControl3.Text = db.TBLURUNKABUL.Count(x => x.URUNDURUM == true).ToString();
            //labelControl5.Text = db.TBLURUNKABUL.Count(x => x.URUNDURUM == false).ToString();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
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
