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
    public partial class FrmArizaDetayListesi : Form
    {
        public FrmArizaDetayListesi()
        {
            InitializeComponent();
        }
        DBTeknıkServısEntities db = new DBTeknıkServısEntities();
        private void FrmArizaDetayListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TBLURUNTAKIP
                                      select new
                                      {
                                          x.TAKIPID,
                                          x.SERINO,
                                          x.TARIH,
                                          x.ACIKLAMA
                                      }).ToList();
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
    }
}
