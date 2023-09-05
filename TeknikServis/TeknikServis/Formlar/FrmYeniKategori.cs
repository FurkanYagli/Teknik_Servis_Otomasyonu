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
    public partial class FrmYeniKategori : Form
    {
        public FrmYeniKategori()
        {
            InitializeComponent();
        }

        private void FrmYeniKategori_Load(object sender, EventArgs e)
        {

        }
        DBTeknıkServısEntities db = new DBTeknıkServısEntities();
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtKategoriAd.Text != "" && TxtKategoriAd.Text.Length <= 30)
            {
                TBLKATEGORI t = new TBLKATEGORI();
                t.AD = TxtKategoriAd.Text;
                db.TBLKATEGORI.Add(t);
                db.SaveChanges();
                MessageBox.Show("Kategori Başarılı Bir Şekilde kaydedildi");
                FrmYeniKategori fr = new FrmYeniKategori();
                this.Close();
            }
            else
            {
                MessageBox.Show("Kategori kaydedilemedi lütfen kategori adını doldurunuz veya 30 karakeri aşmayınız");
            }
        }

        private void BtnIptal_Click(object sender, EventArgs e)
        {
            FrmYeniKategori fr = new FrmYeniKategori();
            this.Close();
        }
    }
}
