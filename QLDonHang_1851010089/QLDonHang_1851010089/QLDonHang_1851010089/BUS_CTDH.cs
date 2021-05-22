using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLDonHang_1851010089
{
    class BUS_CTDH
    {
        DAO_CTDH da;
        public BUS_CTDH()
        {
            da = new DAO_CTDH();
        }

        public void LayDSDH_Detail(DataGridView dg, int maDH)
        {
            dg.DataSource = da.LayCTDH(maDH);
        }

        public void ThemCTDH(Order_Detail chiTietDonHang, int maDH, int maSP)
        {
            if (da.ThemCTDH(chiTietDonHang, maDH, maSP))
            {
                MessageBox.Show("Thêm CT đơn hàng thành công.");
            }
            else
            {
                MessageBox.Show("Thêm không thành công.");
            }
        }

        public void XoaCTDH(int maDH, int maSP)
        {
            if (!da.XoaCTDH(maDH, maSP))
            {
                MessageBox.Show("Xóa chi tiết đơn hàng không thành công!!");
            }
            else
            {
                MessageBox.Show("Xóa chi tiết đơn hàng thành công!!");
            }
        }

        public void SuaCTDH(Order_Detail chiTietDonHang)
        {
            if (!da.SuaCTDH(chiTietDonHang))
            {
                MessageBox.Show("Không thể sửa mã SP.");
            }
            else
            {
                MessageBox.Show("Sửa chi tiết đơn hàng thành công!!");
            }
        }

    }
}
