using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLDonHang_1851010089
{
    class DAO_CTDH
    {
        NWDataContext db;
        public DAO_CTDH()
        {
            db = new NWDataContext();
        }
        public dynamic LayCTDH(int maDH)
        {
            dynamic ds = db.Order_Details.Where(s => s.OrderID == maDH).Select(s => new
            {
                s.OrderID,
                s.ProductID,
                s.UnitPrice,
                s.Quantity
            });
            return ds;
        }

        public bool ThemCTDH(Order_Detail chiTietDH, int maDH, int maSP)
        {
            bool trangThai = true;

            try
            {
                chiTietDH = db.Order_Details.First(s => s.OrderID == maDH && s.ProductID == maSP);
                trangThai = false;
            }
            catch (Exception)
            {
                trangThai = true;
            }

            if (trangThai)
            {
                db.Order_Details.InsertOnSubmit(chiTietDH);
                db.SubmitChanges();
            }

            return trangThai;

        }

        public bool XoaCTDH(int maDH, int maSP)
        {
            bool trangThai = false;

            try
            {
                Order_Detail od = db.Order_Details.First(s => s.OrderID == maDH && s.ProductID == maSP);
                trangThai = true;
                db.Order_Details.DeleteOnSubmit(od);
                db.SubmitChanges();
            }
            catch (Exception)
            {
                trangThai = false;
            }
            return trangThai;
        }

        public bool SuaCTDH(Order_Detail chiTietDH)
        {
            bool trangThai = false;
            Order_Detail od = new Order_Detail();

            try
            {
                od = db.Order_Details.First(s => s.OrderID == chiTietDH.OrderID && s.ProductID == chiTietDH.ProductID);
                trangThai = true;
                od.UnitPrice = chiTietDH.UnitPrice;
                od.Quantity = chiTietDH.Quantity;
                db.SubmitChanges();
            }
            catch (Exception)
            {
                trangThai = false;
            }

            return trangThai;
        }

    }
}
