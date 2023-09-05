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
    public partial class FrmYeniDepartman : Form
    {
        DBTeknıkServısEntities db = new DBTeknıkServısEntities();
        public FrmYeniDepartman()
        {
            InitializeComponent();
        }

        private void BtnIptal_Click(object sender, EventArgs e)
        {
            FrmYeniDepartman fr = new FrmYeniDepartman();
            this.Close();
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtAd.Text.Length <= 50 && TxtAd.Text != "")
            {
                TBLDEPARTMAN t = new TBLDEPARTMAN();
                t.AD = TxtAd.Text;
                db.TBLDEPARTMAN.Add(t);
                db.SaveChanges();
                MessageBox.Show("Departman Kaydedildi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Departman Kaydedilemedi", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
