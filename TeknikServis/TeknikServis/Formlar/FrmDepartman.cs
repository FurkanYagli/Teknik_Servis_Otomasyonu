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
    public partial class FrmDepartman : Form
    {
        public FrmDepartman()
        {
            InitializeComponent();
        }
        DBTeknıkServısEntities db = new DBTeknıkServısEntities();
        private void FrmDepartman_Load(object sender, EventArgs e)
        {
            var degerler = from u in db.TBLDEPARTMAN
                           select new
                           {
                               u.ID,
                               u.AD,
                           };
            gridControl1.DataSource = degerler.ToList();
            labelControl12.Text = db.TBLDEPARTMAN.Count().ToString();
            labelControl14.Text = db.TBLPERSONEL.Count().ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtAd.Text.Length <= 50 && TxtAd.Text != "")
            {
                TBLDEPARTMAN t = new TBLDEPARTMAN();
                t.AD = TxtAd.Text;
                //t.ACIKLAMA = richTextBox1.Text;
                db.TBLDEPARTMAN.Add(t);
                db.SaveChanges();
                MessageBox.Show("Departman Kaydedildi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Departman Kaydedilemedi", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            var degerler = from u in db.TBLDEPARTMAN
                             select new
                             {
                                 u.ID,
                                 u.AD,
                             };
            gridControl1.DataSource = degerler.ToList();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLDEPARTMAN.Find(id);
            try
            {
                db.TBLDEPARTMAN.Remove(deger);
                db.SaveChanges();
                MessageBox.Show("Departman Başarıyla Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception)
            {

                
            }
            
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLDEPARTMAN.Find(id);
            deger.AD = TxtAd.Text;
            db.SaveChanges();
            MessageBox.Show("Departman Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
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

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
