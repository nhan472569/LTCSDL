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
    public partial class FMain : Form
    {
        public FMain()
        {
            InitializeComponent();
        }

        private void FMain_Load(object sender, EventArgs e)
        {
        }

        private void btDonHang_Click(object sender, EventArgs e)
        {
            FQLDonHang donHang = new FQLDonHang();
            donHang.Show();
            this.Hide();
        }

        private void btSP_Click(object sender, EventArgs e)
        {
            FSanPham sp = new FSanPham();
            sp.Show();
            this.Hide();
        }

        private void btNV_Click(object sender, EventArgs e)
        {
            FQLNhanVien nv = new FQLNhanVien();
            nv.Show();
            this.Hide();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
