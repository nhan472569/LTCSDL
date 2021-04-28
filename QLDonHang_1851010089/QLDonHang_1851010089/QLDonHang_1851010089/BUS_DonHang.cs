using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLDonHang_1851010089
{
    
    class BUS_DonHang
    {
        DAO_DonHang da;
        public BUS_DonHang() {
            da = new DAO_DonHang();
        }

        public void LayDSDH(DataGridView dg) {
            dg.DataSource = da.LayDSDH1();
        }

        public void LayDSDH_Detail(DataGridView dg, int maDH)
        {
            dg.DataSource = da.LayCTDH(maDH);
        }

        public void LayDSKH(ComboBox cb) {
            cb.DataSource = da.LayDSKH();
            cb.DisplayMember = "CompanyName";
            cb.ValueMember = "CustomerID";
        }

        public void LayDSNV(ComboBox cb)
        {
            cb.DataSource = da.LayDSNV();
            cb.DisplayMember = "LastName";
            cb.ValueMember = "EmployeeID";
        }

        public void ThemDH(Order donHang)
        {
            da.ThemDH(donHang);
        }
        public void XoaDH(int maDH)
        {
            if (!da.XoaDH(maDH))
            {
                MessageBox.Show("Xoa khong thanh cong");
            }
            else
            {
                MessageBox.Show("Xoa don hang thanh cong");
            }
        }

        public void SuaDH(Order donHang)
        {
            if (!da.SuaDH(donHang))
            {
                MessageBox.Show("Khong tim thay don hang");
            }
            else
            {
                MessageBox.Show("Sua don hang thanh cong");
            }
        }
    }
}
