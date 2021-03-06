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
    public partial class FSanPham : Form
    {
        BUS_SanPham busSP;
        public FSanPham()
        {
            InitializeComponent();
            busSP = new BUS_SanPham();
        }

        private void FSanPham_Load(object sender, EventArgs e)
        {
            busSP.LayDSLoaiSP(cbLoaiSP);
            busSP.LayDSNCC(cbNCC);
            busSP.LayDSSP(dGSP);
        }

        private void dGSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dGSP.RowCount)
            {
                txtTenSP.Text = dGSP.Rows[e.RowIndex].Cells["ProductName"].Value.ToString();
                txtSoLuong.Text = dGSP.Rows[e.RowIndex].Cells["UnitsInStock"].Value.ToString();
                txtDonGia.Text = dGSP.Rows[e.RowIndex].Cells["UnitPrice"].Value.ToString();
                cbLoaiSP.Text = dGSP.Rows[e.RowIndex].Cells["CategoryName"].Value.ToString();
                cbNCC.Text = dGSP.Rows[e.RowIndex].Cells["CompanyName"].Value.ToString(); 
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            Product pr = new Product();

            pr.ProductName = txtTenSP.Text;
            pr.UnitsInStock = short.Parse(txtSoLuong.Text);
            pr.UnitPrice = decimal.Parse(txtDonGia.Text);
            pr.CategoryID = int.Parse(cbLoaiSP.SelectedValue.ToString());
            pr.SupplierID = int.Parse(cbNCC.SelectedValue.ToString());

            busSP.ThemSP(pr);
            busSP.LayDSSP(dGSP);
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            int maSP = int.Parse(dGSP.CurrentRow.Cells[0].Value.ToString());

            busSP.XoaSP(maSP);
            busSP.LayDSSP(dGSP);
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            Product pr = new Product();

            pr.ProductID = int.Parse(dGSP.CurrentRow.Cells[0].Value.ToString());
            pr.ProductName = txtTenSP.Text;
            pr.UnitsInStock = short.Parse(txtSoLuong.Text);
            pr.UnitPrice = decimal.Parse(txtDonGia.Text);
            pr.CategoryID = int.Parse(cbLoaiSP.SelectedValue.ToString());
            pr.SupplierID = int.Parse(cbNCC.SelectedValue.ToString());

            busSP.SuaTTSP(pr);
            busSP.LayDSSP(dGSP);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            FMain main = new FMain();
            main.Show();
            this.Close();
        }
    }
}
