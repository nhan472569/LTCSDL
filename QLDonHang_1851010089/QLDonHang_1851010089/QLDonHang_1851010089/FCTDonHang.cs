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
    public partial class FCTDonHang : Form
    {

        BUS_CTDH bus;
        public int maDH;
        public FCTDonHang()
        {
            InitializeComponent();
            bus = new BUS_CTDH();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CTDonHang_Load(object sender, EventArgs e)
        {
            txtMaDH.Enabled = false;
            txtMaDH.Text = maDH.ToString();
            bus.LayDSDH_Detail(gVCTDH, maDH);
            gVCTDH.Columns[0].Width = (int)(0.2 * gVCTDH.Width);
            gVCTDH.Columns[1].Width = (int)(0.2 * gVCTDH.Width);
            gVCTDH.Columns[2].Width = (int)(0.25 * gVCTDH.Width);
            gVCTDH.Columns[3].Width = (int)(0.25 * gVCTDH.Width);
        }

        private void gVCTDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.RowIndex < gVCTDH.RowCount)
            {
                txtMaSP.Text = gVCTDH.Rows[e.RowIndex].Cells["ProductID"].Value.ToString();
                txtDonGia.Text = gVCTDH.Rows[e.RowIndex].Cells["UnitPrice"].Value.ToString();
                txtSoLuong.Text = gVCTDH.Rows[e.RowIndex].Cells["Quantity"].Value.ToString();
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            Order_Detail od = new Order_Detail();
            od.OrderID = int.Parse(txtMaDH.Text);
            od.ProductID = int.Parse(txtMaSP.Text);
            od.UnitPrice = decimal.Parse(txtDonGia.Text);
            od.Quantity = short.Parse(txtSoLuong.Text);

            int maDH = int.Parse(txtMaDH.Text);
            int maSP = int.Parse(txtMaSP.Text);

            bus.ThemCTDH(od, maDH, maSP);
            bus.LayDSDH_Detail(gVCTDH, maDH);
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            int maDH = int.Parse(txtMaDH.Text);
            int maSP = int.Parse(txtMaSP.Text);

            bus.XoaCTDH(maDH, maSP);
            bus.LayDSDH_Detail(gVCTDH, maDH);
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            Order_Detail chiTietDonHang = new Order_Detail();

            chiTietDonHang.OrderID = int.Parse(txtMaDH.Text);
            chiTietDonHang.ProductID = int.Parse(txtMaSP.Text);
            chiTietDonHang.UnitPrice = decimal.Parse(txtDonGia.Text);
            chiTietDonHang.Quantity = short.Parse(txtSoLuong.Text);

            bus.SuaCTDH(chiTietDonHang);
            bus.LayDSDH_Detail(gVCTDH, maDH);
        }
    }
}
