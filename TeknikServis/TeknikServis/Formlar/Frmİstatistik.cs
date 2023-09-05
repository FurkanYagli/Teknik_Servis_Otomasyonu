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
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureEdit5_EditValueChanged(object sender, EventArgs e)
        {

        }
        DBTeknıkServısEntities db = new DBTeknıkServısEntities();
        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
            labelControl2.Text = db.TBLURUN.Count().ToString();
            labelControl3.Text = db.TBLKATEGORI.Count().ToString();
            labelControl5.Text = db.TBLURUN.Sum(x => x.STOK).ToString();
            labelControl7.Text = ("10");
            labelControl19.Text = (from x in db.TBLURUN
                                   orderby x.STOK descending
                                   select x.AD).FirstOrDefault();
            labelControl18.Text = (from x in db.TBLURUN
                                   orderby x.STOK ascending
                                   select x.AD).FirstOrDefault();
            labelControl13.Text = (from x in db.TBLURUN
                                   orderby x.SATISFIYAT descending
                                   select x.AD).FirstOrDefault();
            labelControl12.Text = (from x in db.TBLURUN
                                   orderby x.SATISFIYAT ascending
                                   select x.AD).FirstOrDefault();
            //labelControl25.Text = db.TBLURUN.Count(x=>x.KATEGORİ==4).ToString();
            //labelControl27.Text = db.TBLURUN.Count(x=>x.KATEGORİ==1).ToString();
            //labelControl29.Text = db.TBLURUN.Count(x=>x.KATEGORİ==3).ToString();
            //labelControl35.Text = (from x in db.TBLURUN
            //select x.MARKA).Distinct().Count().ToString();
            labelControl33.Text = db.TBLURUNKABUL.Count().ToString();
            var deger = (from d in db.TBLURUN.GroupBy(u => u.KATEGORİ)

                         select new

                         {

                             d.Key,

                             Toplam = d.Count()

                         }).Select(d => d.Key).FirstOrDefault();

            var kategori = db.TBLKATEGORI.Find(deger);

            labelControl16.Text = kategori.AD.ToString();

        }

        private void labelControl13_Click(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void pictureEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl33_Click(object sender, EventArgs e)
        {

        }
    }
}
