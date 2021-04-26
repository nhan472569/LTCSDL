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
    }
}
