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
    public partial class FrmYeniPersonel : Form
    {
        public FrmYeniPersonel()
        {
            InitializeComponent();
        }
        DBTeknıkServısEntities db = new DBTeknıkServısEntities();
        private void FrmYeniPersonel_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.DataSource = (from x in db.TBLDEPARTMAN
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.AD,
                                                 }).ToList();
        }

        private void TxtUrunAd_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLPERSONEL t = new TBLPERSONEL();
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
            t.TELEFON = TxtTel.Text;
            db.TBLPERSONEL.Add(t);
            db.SaveChanges();
            MessageBox.Show("Başarılı Bir Şekilde Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnIptal_Click(object sender, EventArgs e)
        {
            FrmYeniPersonel fr = new FrmYeniPersonel();
            this.Close();
        }
    }
}
