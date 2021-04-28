using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLDonHang_1851010089
{
    class DAO_DonHang
    {
        NWDataContext db;
        public DAO_DonHang() {
            db = new NWDataContext();
        }

        //----------Khoi tao-----------
        //Don hang
        public dynamic LayDSDH() {
            dynamic ds = db.Orders.Select(s => new
            {
                s.OrderID,
                s.OrderDate,
                s.Customer.CompanyName,
                s.Employee.LastName
            }).ToList();
            return ds;
        }
        public dynamic LayDSKH() {
            var ds = db.Customers.Select(s => new { s.CustomerID, s.CompanyName });
            return ds;
        }

        public dynamic LayDSNV()
        {
            var ds = db.Employees.Select(s => new { s.EmployeeID, s.LastName});
            return ds;
        }

        //Chi tiet don hang
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


        // ---------Them---------
        //Don hang
        public void ThemDH(Order donHang) {
            db.Orders.InsertOnSubmit(donHang);
            db.SubmitChanges();
        }
        //Chi tiet don hang
        public bool ThemCTDH(Order_Detail chiTietDH)
        {
            bool trangThai = true;

            Order_Detail od = db.Order_Details.First(s => s.OrderID == chiTietDH.OrderID && s.ProductID == chiTietDH.ProductID);
            try
            {
                db.Order_Details.InsertOnSubmit(od);
                db.SubmitChanges();
                trangThai = false;
            }
            catch (Exception)
            {
                trangThai = true;
            }
            return trangThai;

        }


        // ------------Xoa---------
        //Don hang
        public bool XoaDH(int maDH)
        {
            bool trangThai = false;

            try
            {
                Order o = db.Orders.First(s => s.OrderID == maDH);
                trangThai = true;
                db.Orders.DeleteOnSubmit(o);
                db.SubmitChanges();
            }
            catch (Exception)
            {
                trangThai = false;
            }
            return trangThai;
        }
        //Chi tiet don hang
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

        // ---------Sua---------
        //Don hang
        public bool SuaDH(Order donHang)
        {
            bool trangThai = false;
            Order o = new Order();

            try
            {
                o = db.Orders.First(s => s.OrderID == donHang.OrderID);
                trangThai = true;
                o.OrderDate = donHang.OrderDate;
                o.CustomerID = donHang.CustomerID;
                o.EmployeeID = donHang.EmployeeID;
                db.SubmitChanges();
            }
            catch (Exception)
            {
                trangThai = false;
            }

            return trangThai;
        }
        //Chi tiet don hang
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
