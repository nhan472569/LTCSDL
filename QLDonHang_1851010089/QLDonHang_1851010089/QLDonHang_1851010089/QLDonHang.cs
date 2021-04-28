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
    public partial class QLDonHang : Form
    {
        BUS_DonHang bus;
        public QLDonHang()
        {
            InitializeComponent();
            bus = new BUS_DonHang();
            txtMaDH.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bus.LayDSNV(cbNhanVien);
            bus.LayDSKH(cbKhachHang);
            bus.LayDSDH(gVDH);
            gVDH.Columns[0].Width = (int)(0.2 * gVDH.Width);
            gVDH.Columns[1].Width = (int)(0.2 * gVDH.Width);
            gVDH.Columns[2].Width = (int)(0.25 * gVDH.Width);
            gVDH.Columns[3].Width = (int)(0.25 * gVDH.Width);
        }

        private void gVDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gVDH.Rows.Count)
            {
                txtMaDH.Text = gVDH.Rows[e.RowIndex].Cells["OrderID"].Value.ToString();
                dtpNgayDH.Text = gVDH.Rows[e.RowIndex].Cells[1].Value.ToString();
                cbKhachHang.Text = gVDH.Rows[e.RowIndex].Cells[2].Value.ToString();
                cbNhanVien.Text = gVDH.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            Order o = new Order();
            o.CustomerID = cbKhachHang.SelectedValue.ToString();
            o.EmployeeID = int.Parse(cbNhanVien.SelectedValue.ToString());
            o.OrderDate = dtpNgayDH.Value;

            bus.ThemDH(o);
            bus.LayDSDH(gVDH);
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            int maDH = int.Parse(txtMaDH.Text);

            bus.XoaDH(maDH);
            bus.LayDSDH(gVDH);
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            Order donHang = new Order();

            donHang.OrderID = int.Parse(txtMaDH.Text);
            donHang.OrderDate = dtpNgayDH.Value;
            donHang.CustomerID = cbKhachHang.SelectedValue.ToString();
            donHang.EmployeeID = int.Parse(cbNhanVien.SelectedValue.ToString());

            bus.SuaDH(donHang);
            bus.LayDSDH(gVDH);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gVDH_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CTDonHang detail = new CTDonHang();
            detail.maDH = int.Parse(txtMaDH.Text);
            detail.ShowDialog();
        }
    }
}
