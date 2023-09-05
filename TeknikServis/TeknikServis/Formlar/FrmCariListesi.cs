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
    public partial class FrmCariListesi : Form
    {
        int secilen;
        public FrmCariListesi()
        {
            InitializeComponent();
        }

        private void TxtAlisFiyat_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }
        void liste()
        {
            var degerler = from x in db.TBLCARI
                           select new
                           {
                               x.ID,
                               x.AD,
                               x.SOYAD,
                               x.IL,
                               x.ILCE
                           };
            gridControl1.DataSource = degerler.ToList();
        }
        DBTeknıkServısEntities db = new DBTeknıkServısEntities();
        private void FrmCariListesi_Load(object sender, EventArgs e)
        {
            liste();
            labelControl12.Text = db.TBLCARI.Count().ToString();
            labelControl16.Text = db.TBLCARI.Select(x => x.IL).Distinct().Count().ToString();
            labelControl18.Text = db.TBLCARI.Select(x => x.ILCE).Distinct().Count().ToString();
            lookUpEdit1.Properties.DataSource = (from x in db.TBLILLER
                                                 select new
                                                 {
                                                     x.id,
                                                     x.sehir
                                                 }).ToList();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelControl18_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textEdit6_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLCARI t = new TBLCARI();
            t.AD = TxtAd.Text;
            t.SOYAD = TxtSoyad.Text;
            t.IL = lookUpEdit1.Text;
            t.ILCE = lookUpEdit2.Text;
            //t.TELEFON = TxtTel.Text;
            //t.MAIL = TxtMail.Text;
            //t.BANKA = TxtBank.Text;
            //t.VERGIDAIRESI = TxtVergiDaire.Text;
            //t.VERGINO = TxtVergiNo.Text;
            //t.STATU = TxtStatu.Text;
            //t.ADRES = TxtAdres.Text;
            db.TBLCARI.Add(t);
            db.SaveChanges();
            MessageBox.Show("Cariler kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            liste();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLCARI.Find(id);
            try
            {
                db.TBLCARI.Remove(deger);
                db.SaveChanges();
                MessageBox.Show("Başarıyla Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception)
            {

                MessageBox.Show("HATA");
            }
            db.TBLCARI.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Başarıyla Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            TxtSoyad.Text = gridView1.GetFocusedRowCellValue("SOYAD").ToString();
            lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("IL").ToString();
            lookUpEdit2.Text = gridView1.GetFocusedRowCellValue("ILCE").ToString();
            //TxtMail.Text = gridView1.GetFocusedRowCellValue("MAIL").ToString();
            //TxtStatu.Text = gridView1.GetFocusedRowCellValue("STATU").ToString();
            //TxtTel.Text = gridView1.GetFocusedRowCellValue("TELEFON").ToString();
            //TxtVergiDaire.Text = gridView1.GetFocusedRowCellValue("VERGIDAIRESI").ToString();
            //TxtVergiNo.Text = gridView1.GetFocusedRowCellValue("VERGINO").ToString();
            //TxtAdres.Text = gridView1.GetFocusedRowCellValue("ADRES").ToString();
            //TxtBank.Text = gridView1.GetFocusedRowCellValue("BANKA").ToString();
        }
        
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLCARI.Find(id);
            deger.AD = TxtAd.Text;
            //deger.ADRES = TxtAdres.Text;
            deger.IL = lookUpEdit1.Text;
            deger.ILCE = lookUpEdit2.Text;
            //deger.BANKA = TxtBank.Text;
            //deger.MAIL = TxtMail.Text;
            deger.SOYAD = TxtSoyad.Text;
           // deger.STATU = TxtStatu.Text;
            db.SaveChanges();
            MessageBox.Show("Başarılı Bir Şekilde Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            var degerler = db.TBLCARI.ToList();
            gridControl1.DataSource = degerler;
        }

        private void TxtVergiDaire_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl8_Click(object sender, EventArgs e)
        {

        }

        private void labelControl11_Click(object sender, EventArgs e)
        {

        }

        private void TxtVergiNo_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl10_Click(object sender, EventArgs e)
        {

        }

        private void TxtStatu_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl9_Click(object sender, EventArgs e)
        {

        }

        private void TxtAdres_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void TxtBank_EditValueChanged(object sender, EventArgs e)
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

        private void lookUpEdit2_EditValueChanged_1(object sender, EventArgs e)
        {

        }
    }
}
