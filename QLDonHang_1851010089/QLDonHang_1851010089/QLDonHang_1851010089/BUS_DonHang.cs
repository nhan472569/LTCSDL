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

        // -------Khoi tao---------
        //Don Hang
        public void LayDSDH(DataGridView dg) {
            dg.DataSource = da.LayDSDH();
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

        // -----------Them----------
        //Don hang
        public void ThemDH(Order donHang)
        {
            try
            {
                da.ThemDH(donHang);
            }
            catch (Exception)
            {

                MessageBox.Show("Thêm đơn hàng không thành công!!");
            }
            finally
            {
                MessageBox.Show("Thêm đơn hàng thành công!!");
            }
        }
        
        //-------------Xoa---------
        //Don hang
        public void XoaDH(int maDH)
        {
            if (!da.XoaDH(maDH))
            {
                MessageBox.Show("Xóa đơn hàng không thành công!!");
            }
            else
            {
                MessageBox.Show("Xóa đơn hàng thành công!!");
            }
        }
        
        //------------Sua-----------
        //Don hang
        public void SuaDH(Order donHang)
        {
            if (!da.SuaDH(donHang))
            {
                MessageBox.Show("Sửa đơn hàng không thành công!!");
            }
            else
            {
                MessageBox.Show("Sửa đơn hàng thành công!!");
            }
        }
       
    }
}
