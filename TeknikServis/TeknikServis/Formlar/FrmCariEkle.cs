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
    public partial class FrmCariEkle : Form
    {
        public FrmCariEkle()
        {
            InitializeComponent();
        }

        private void BtnIptal_Click(object sender, EventArgs e)
        {
            FrmCariEkle fr = new FrmCariEkle();
            this.Close();
        }
        DBTeknıkServısEntities db = new DBTeknıkServısEntities();
        private void FrmCariEkle_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.DataSource = (from x in db.TBLILLER
                                                 select new
                                                 {
                                                     x.id,
                                                     x.sehir
                                                 }).ToList();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLCARI t = new TBLCARI();
            t.AD = TxtAd.Text;
            t.SOYAD = TxtSoyad.Text;
            t.IL = lookUpEdit1.Text;
            t.ILCE = lookUpEdit2.Text;
            /*t.TELEFON = TxtTel.Text;
            t.MAIL = TxtMail.Text;
            t.BANKA = TxtBank.Text;
            t.VERGIDAIRESI = TxtVergiDaire.Text;
            t.VERGINO = TxtVergiNo.Text;
            t.STATU = TxtStatu.Text;
            t.ADRES = TxtAdres.Text;*/
            db.TBLCARI.Add(t);
            db.SaveChanges();
            MessageBox.Show("Cariler kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        int secilen;
        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            secilen = int.Parse(lookUpEdit1.EditValue.ToString());
            lookUpEdit2.Properties.DataSource = (from y in db.TBLILCELER
                                                 select new
                                                 {
                                                     y.id,
                                                     y.ilce,
                                                     y.sehir
                                                 }).Where(z => z.sehir == secilen).ToList();
        }

        private void TxtSoyad_Click(object sender, EventArgs e)
        {
            TxtSoyad.Text = "";
        }

        private void TxtAd_Click(object sender, EventArgs e)
        {
            TxtAd.Text = "";
        }
    }
}
