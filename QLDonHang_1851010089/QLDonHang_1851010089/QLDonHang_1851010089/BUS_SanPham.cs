using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLDonHang_1851010089
{
    class BUS_SanPham
    {
        DAO_SanPham da;
        public BUS_SanPham()
        {
            da = new DAO_SanPham();
        }

        public void LayDSLoaiSP(ComboBox cb)
        {
            cb.DataSource = da.LayDSLoaiSP();
            cb.ValueMember = "CategoryID";
            cb.DisplayMember = "CategoryName";
        }

        public void LayDSNCC(ComboBox cb)
        {
            cb.DataSource = da.LayDSNCC();
            cb.ValueMember = "SupplierID";
            cb.DisplayMember = "CompanyName";
        }

        public void LayDSSP(DataGridView dg)
        {
            dg.DataSource = da.LayDSSP();
        }

        public void ThemSP(string tenSP, int soLuong, double donGia, int maLoaiSP, int maNCC)
        {
            da.ThemSP(tenSP, soLuong, donGia, maLoaiSP, maNCC);
        }

        public void XoaSP(int maSP)
        {
            da.XoaSP(maSP);
        }

        public void SuaTTSP(int maSP, string tenSP, int soLuong, double donGia, int maLoaiSP, int maNCC)
        {
            da.SuaTTSP(maSP, tenSP, soLuong, donGia, maLoaiSP, maNCC);
        }
    }
}
