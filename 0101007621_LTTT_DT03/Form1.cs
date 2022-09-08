using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0101007621_LTTT_DT03
{
    public partial class Form1 : Form
    {
        DSNguonTin TINS = new DSNguonTin();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nhập vô làm j?");
        }

        private void testDữLiệuCóSẵnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TINS.nhap("../../XML folder/NguonMaHoaKhongThuTu.xml");
            TINS.sapXepTTTin();
            TINS.tinhTiLeTungTIN();
            TINS.tinhDoDaiTuMa();
            TINS.bdNhiPhan();
            TINS.layTuMaWi();
        }

        private void đưaThôngTinVàoBảngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(TIN t in TINS.A)
            {
                dataGridView1.Rows.Add("",t.STenTin, t.DXacSuatTin, t.DTiLeXS, t.DDayNhiPhan, t.IDoDaiTuMa, t.STuMaWi);
            }    
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void kếtQuảTổngQuátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            averagLengthBox.Text = TINS.tinhDDTBTuMa().ToString();
            codePerformBox.Text = TINS.tinhHieuSuatLapMa().ToString();
            entropyBox.Text = TINS.tinhEntropy().ToString();
        }
    }
}
