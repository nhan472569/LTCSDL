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
            try
            {
                da.ThemNV(em);
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm nhân viên không thành công");
            }
            finally
            {
                MessageBox.Show("Thêm nhân viên thành công");
            }
            
        }

        public void XoaNV(int maNV)
        {
            if (!da.XoaNV(maNV))
            {
                MessageBox.Show("Xóa nhân viên không thành công!!");
            }
            else
            {
                MessageBox.Show("Xóa nhân viên thành công!!");
            }
        }

        //public void SuaTTNV(string name, DateTime birthDate, string phone, string address, int maNV)
        //{
        //    da.SuaTTNV(name, birthDate, phone, address, maNV);
        //}

        public void SuaTTNV(Employee em)
        {
            if (!da.SuaTTNV(em))
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
