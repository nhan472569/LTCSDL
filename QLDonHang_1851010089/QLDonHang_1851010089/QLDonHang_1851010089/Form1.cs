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
    public partial class Form1 : Form
    {
        BUS_DonHang bus;
        public Form1()
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

        private void btThem_Click(object sender, EventArgs e)
        {
            Order o = new Order();
            o.CustomerID = cbKhachHang.SelectedValue.ToString();
            o.EmployeeID = int.Parse(cbNhanVien.SelectedValue.ToString());
            o.OrderDate = dtpNgayDH.Value;

            bus.ThemDH(o);
            bus.LayDSDH(gVDH);
        }

        private void gVDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gVDH.Rows.Count -1 )
            {
                txtMaDH.Text = gVDH.Rows[e.RowIndex].Cells["OrderID"].Value.ToString();
                dtpNgayDH.Text = gVDH.Rows[e.RowIndex].Cells[1].Value.ToString();
                cbKhachHang.Text = gVDH.Rows[e.RowIndex].Cells[2].Value.ToString();
                cbNhanVien.Text = gVDH.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }
    }
}
