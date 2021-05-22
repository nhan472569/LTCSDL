using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLDonHang_1851010089
{
    class BUS_NhanVien
    {
        DAO_NhanVien da;
        public BUS_NhanVien() {
            da = new DAO_NhanVien();
        }

        public void LayDSVN(DataGridView dg)
        {
            dg.DataSource = da.LayDSVN();
        }

        public void ThemNV(Employee em)
        {
            da.ThemNV(em);
        }

        //public void XoaSP(int maNV)
        //{
        //    da.XoaSP(maNV);
        //}

        //public void SuaTTNV(string name, DateTime birthDate, string phone, string address, int maNV)
        //{
        //    da.SuaTTNV(name, birthDate, phone, address, maNV);
        //}
    }
}
