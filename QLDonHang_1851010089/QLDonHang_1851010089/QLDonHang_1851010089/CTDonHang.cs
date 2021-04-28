using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLDonHang_1851010089
{
    public partial class CTDonHang : Form
    {

        BUS_DonHang bus;
        public int maDH;
        public CTDonHang()
        {
            InitializeComponent();
            bus = new BUS_DonHang();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CTDonHang_Load(object sender, EventArgs e)
        {
            txtMaDH.Text = maDH.ToString();
            bus.LayDSDH_Detail(gVCTDH, maDH);
            gVCTDH.Columns[0].Width = (int)(0.2 * gVCTDH.Width);
            gVCTDH.Columns[1].Width = (int)(0.2 * gVCTDH.Width);
            gVCTDH.Columns[2].Width = (int)(0.25 * gVCTDH.Width);
            gVCTDH.Columns[3].Width = (int)(0.25 * gVCTDH.Width);
        }
    }
}
