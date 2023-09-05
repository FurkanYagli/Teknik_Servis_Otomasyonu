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
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }

        private void simpleButton18_Click(object sender, EventArgs e)
        {
            Formlar.FrmYeniPersonel fr = new Formlar.FrmYeniPersonel();
            //fr.MdiParent = this;
            fr.Show();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Formlar.FRMUrunListesi fr = new Formlar.FRMUrunListesi();
            //fr.MdiParent = this;
            fr.Show();
            this.Hide();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Formlar.Frmİstatistik fr = new Formlar.Frmİstatistik();
            //fr.MdiParent = this;
            fr.Show();
            this.Hide();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            Formlar.FrmMarkalar fr = new Formlar.FrmMarkalar();
            //fr.MdiParent = this;
            fr.Show();
            this.Hide();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            Formlar.FrmKategori fr = new Formlar.FrmKategori();
            //fr.MdiParent = this;
            fr.Show();
            this.Hide();
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            Formlar.FrmCariEkle fr = new Formlar.FrmCariEkle();
            //fr.MdiParent = this;
            fr.Show();
            
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            Formlar.FrmCariListesi fr = new Formlar.FrmCariListesi();
            //fr.MdiParent = this;
            fr.Show();
            this.Hide();
        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            Formlar.FrmArizaDetay fr = new Formlar.FrmArizaDetay();
            //fr.MdiParent = this;
            fr.Show();
            //this.Hide();
        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            Formlar.FrmArizaListesi fr = new Formlar.FrmArizaListesi();
            //fr.MdiParent = this;
            fr.Show();
            this.Hide();
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            Formlar.FrmSatisListesi fr = new Formlar.FrmSatisListesi();
            //fr.MdiParent = this;
            fr.Show();
            this.Hide();
        }

        private void BtnUrunAra_Click(object sender, EventArgs e)
        {

        }
        DBTeknıkServısEntities db = new DBTeknıkServısEntities();
        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TBLURUN
                                       select new
                                       {
                                           x.AD,
                                           x.STOK
                                       }).Where(x => x.STOK < 10).ToList();
        }

        private void BtnYeniUrun_Click(object sender, EventArgs e)
        {
            Formlar.FrmYeniUrun fr = new Formlar.FrmYeniUrun();
            fr.Show();
            
        }

        private void BtnYeniKategori_Click(object sender, EventArgs e)
        {
            Formlar.FrmYeniKategori fr = new Formlar.FrmYeniKategori();
            //fr.MdiParent = this;
            fr.Show();
            
        }

        private void BtnCariIlIstatistiği_Click(object sender, EventArgs e)
        {
            Formlar.FrmCariiller fr = new Formlar.FrmCariiller();
            //fr.MdiParent = this;
            fr.Show();
            this.Hide();
        }

        private void BtnYeniArizaliUrun_Click(object sender, EventArgs e)
        {
            Formlar.FrmArizaliUrunKaydi fr = new Formlar.FrmArizaliUrunKaydi();
            //fr.MdiParent = this;
            fr.Show();
        }

        private void BtnArizaliUrunDetay_Click(object sender, EventArgs e)
        {
            Formlar.FrmArizaDetayListesi fr = new Formlar.FrmArizaDetayListesi();
            //fr.MdiParent = this;
            fr.Show();
            this.Hide();
        }

        private void BtnUrunSatis_Click(object sender, EventArgs e)
        {
            Formlar.FrmUrunSatis fr = new Formlar.FrmUrunSatis();
            //fr.MdiParent = this;
            fr.Show();
        }

        private void BtnDepartmanListesi_Click(object sender, EventArgs e)
        {
            Formlar.FrmDepartman fr = new Formlar.FrmDepartman();
            //fr.MdiParent = this;
            fr.Show();
            this.Hide();
        }

        private void BtnYeniDepartman_Click(object sender, EventArgs e)
        {
            Formlar.FrmYeniDepartman fr = new Formlar.FrmYeniDepartman();
            //fr.MdiParent = this;
            fr.Show();
        }

        private void BtnPersonelListesi_Click(object sender, EventArgs e)
        {
            Formlar.FrmPersonel fr = new Formlar.FrmPersonel();
            //fr.MdiParent = this;
            fr.Show();
            this.Hide();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
