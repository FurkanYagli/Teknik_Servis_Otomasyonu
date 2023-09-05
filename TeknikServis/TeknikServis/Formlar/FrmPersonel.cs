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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl14_Click(object sender, EventArgs e)
        {

        }
        DBTeknıkServısEntities db = new DBTeknıkServısEntities();
        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            var degerler = from u in db.TBLPERSONEL
                           select new
                           {
                               u.ID,
                               u.AD,
                               u.SOYAD,
                               u.MAIL,
                               u.TELEFON,
                           };
            gridControl1.DataSource = degerler.ToList();
            lookUpEdit1.Properties.DataSource = (from x in db.TBLDEPARTMAN
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.AD,
                                                 }).ToList();

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            TxtSoyad.Text = gridView1.GetFocusedRowCellValue("SOYAD").ToString();
            TxtMail.Text = gridView1.GetFocusedRowCellValue("MAIL").ToString();
            TxtTelefon.Text = gridView1.GetFocusedRowCellValue("TELEFON").ToString();
            try
            {
                lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("DEPARTMAN").ToString();
                TxtMail.Text = gridView1.GetFocusedRowCellValue("MAIL").ToString();
                TxtTelefon.Text = gridView1.GetFocusedRowCellValue("TELEFON").ToString();
            }
            catch (Exception)
            {

                
            }
            /*lookUpEdit1.Text= gridView1.GetFocusedRowCellValue("DEPARTMAN").ToString();
            TxtMail.Text = gridView1.GetFocusedRowCellValue("MAIL").ToString();
            TxtTelefon.Text = gridView1.GetFocusedRowCellValue("TELEFON").ToString();*/
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

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

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLPERSONEL t = new TBLPERSONEL();
            
            if(TxtSoyad.Text != "" && TxtAd.Text!="" && TxtMail.Text != "" && TxtTelefon.Text != "")
            {
                t.AD = TxtAd.Text;
                try
                {
                    t.DEPARTMAN = byte.Parse(lookUpEdit1.EditValue.ToString());
                }
                catch (Exception)
                {

                    //MessageBox.Show("Departman Seçiniz");
                }
                t.SOYAD = TxtSoyad.Text;
                t.MAIL = TxtMail.Text;
                t.TELEFON = TxtTelefon.Text;
                db.TBLPERSONEL.Add(t);
                db.SaveChanges();
                MessageBox.Show("Başarılı Bir Şekilde Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Boş Alan Bırakmadığınızdan Emin Olun");
            }
            
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLPERSONEL.Find(id);
            if (TxtSoyad.Text != "" && TxtAd.Text != "" && TxtMail.Text != "" && TxtTelefon.Text != "")
            {
                deger.AD = TxtAd.Text;
                deger.SOYAD = TxtSoyad.Text;
                deger.MAIL = TxtMail.Text;
                deger.TELEFON = TxtTelefon.Text;
                try
                {
                    deger.DEPARTMAN = byte.Parse(lookUpEdit1.EditValue.ToString());
                }
                catch (Exception)
                {

                    //MessageBox.Show("Departman Seçiniz");
                }
                db.SaveChanges();
                MessageBox.Show("Personel Başarılı Bir Şekilde Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Boş Alan Bırakmadığınızdan Emin Olun");
            }
                
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLPERSONEL.Find(id);
            try
            {
                db.TBLPERSONEL.Remove(deger);
                db.SaveChanges();
                MessageBox.Show("Personel Başarılı Bir Şekilde Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception)
            {

                MessageBox.Show("HATA");
            }
            
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            var degerler = from k in db.TBLPERSONEL
                           select new
                           {
                               k.ID,
                               k.AD,
                               k.SOYAD,
                               k.MAIL,
                               k.TELEFON
                           };
            gridControl1.DataSource = degerler.ToList();
        }
    }
}
