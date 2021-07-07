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

        public void ThemSP(Product pr)
        {
            try
            {
                da.ThemSP(pr);
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm sản phẩm không thành công");
            }
            finally {
                MessageBox.Show("Thêm sản phẩm thành công");
            }
        }

        public void XoaSP(int maSP)
        {
            if (!da.XoaSP(maSP))
            {
                MessageBox.Show("Xóa sản phẩm không thành công!!");
            }
            else
            {
                MessageBox.Show("Xóa sản phẩm thành công!!");
            }
        }

        public void SuaTTSP(Product pr)
        {
            if (!da.SuaTTSP(pr))
            {
                MessageBox.Show("Sửa thông tin không thành công!!");
            }
            else
            {
                MessageBox.Show("Sửa thông tin thành công!!");
            }
        }
    }
}
