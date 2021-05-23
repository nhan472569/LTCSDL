using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLDonHang_1851010089
{
    public partial class FQLNhanVien : Form
    {

        BUS_NhanVien busNV;
        public FQLNhanVien()
        {
            InitializeComponent();
            busNV = new BUS_NhanVien();
        }

        private void FQLNhanVien_Load(object sender, EventArgs e)
        {
            busNV.LayDSVN(dGNhanVien);
            dGNhanVien.Columns[0].Width = (int)(0.1 * dGNhanVien.Width);
            dGNhanVien.Columns[1].Width = (int)(0.2 * dGNhanVien.Width);
            dGNhanVien.Columns[2].Width = (int)(0.2 * dGNhanVien.Width);
            dGNhanVien.Columns[3].Width = (int)(0.2 * dGNhanVien.Width);
            dGNhanVien.Columns[4].Width = (int)(0.3 * dGNhanVien.Width);
        }

        private void dGNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dGNhanVien.Rows.Count)
            {
                txtHoten.Text = dGNhanVien.Rows[e.RowIndex].Cells[1].Value.ToString();
                dtpNgaySinh.Text = dGNhanVien.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtDienThoai.Text = dGNhanVien.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtDiaChi.Text = dGNhanVien.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            Employee em = new Employee();

            string name = txtHoten.Text;
            string[] nameItems = name.Split(' ');
            em.FirstName = nameItems[0];
            em.LastName = nameItems[1];
            em.BirthDate = dtpNgaySinh.Value;
            em.HomePhone = txtDienThoai.Text;
            em.Address = txtDiaChi.Text;

            busNV.ThemNV(em);
            busNV.LayDSVN(dGNhanVien);
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            int maNV = int.Parse(dGNhanVien.CurrentRow.Cells[0].Value.ToString());
            busNV.XoaNV(maNV);
            busNV.LayDSVN(dGNhanVien);
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            Employee em = new Employee();

            em.EmployeeID = int.Parse(dGNhanVien.CurrentRow.Cells[0].Value.ToString());
            string name = txtHoten.Text;
            string[] nameItems = name.Split(' ');
            em.FirstName = nameItems[0];
            em.LastName = nameItems[1];
            em.BirthDate = dtpNgaySinh.Value;
            em.HomePhone = txtDienThoai.Text;
            em.Address = txtDiaChi.Text;

            busNV.SuaTTNV(em);
            busNV.LayDSVN(dGNhanVien);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            FMain main = new FMain();
            main.Show();
            this.Close();
        }
    }
}
