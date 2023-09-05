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
    public partial class FrmArizaliUrunKaydi : Form
    {
        public FrmArizaliUrunKaydi()
        {
            InitializeComponent();
        }
        DBTeknıkServısEntities db = new DBTeknıkServısEntities();
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLURUNKABUL t = new TBLURUNKABUL();
            try
            {
                t.CARI = int.Parse(lookUpEdit1.EditValue.ToString());
                t.GELISTARIH = DateTime.Parse(TxtTarih.Text);
                t.PERSONEL = short.Parse(lookUpEdit2.EditValue.ToString());
                t.URUNSERINO =TxtSeriNo.Text;
                t.URUNDURUM = true;
                db.TBLURUNKABUL.Add(t);
                db.SaveChanges();
                MessageBox.Show("Arızalı Ürün Başarılı Bir Şekilde Kaydedildi.");
            }
            catch (Exception)
            {

                MessageBox.Show("Arızalı Ürün Kaydı Başarısız Lütfen Tekrar Deneyiniz.");
            }
            
        }

        private void BtnIptal_Click(object sender, EventArgs e)
        {
            FrmArizaliUrunKaydi fr = new FrmArizaliUrunKaydi();
            this.Close();
        }

        private void FrmArizaliUrunKaydi_Load(object sender, EventArgs e)
        {
            //MÜŞTERİ
            lookUpEdit1.Properties.DataSource = (from x in db.TBLCARI
                                                 select new
                                                 {
                                                     x.ID,
                                                     AD= x.AD + " " +x.SOYAD,
                                                 }).ToList();
            //PERSONEL
            lookUpEdit2.Properties.DataSource = (from x in db.TBLPERSONEL
                                                 select new
                                                 {
                                                     x.ID,
                                                     AD= x.AD + " " +x.SOYAD,
                                                 }).ToList();
            //SERİ NO
            /*lookUpEdit3.Properties.DataSource = (from x in db.TBLURUNHAREKET
                                                 select new
                                                 {
                                                     x.URUNSERINO,
                                                     //x.PERSONEL,
                                                     //x.MUSTERI
                                                 }).ToList();*/

        }

        private void TxtTarih_Click(object sender, EventArgs e)
        {
            TxtTarih.Text = DateTime.Now.ToShortDateString();
        }
    }
}
