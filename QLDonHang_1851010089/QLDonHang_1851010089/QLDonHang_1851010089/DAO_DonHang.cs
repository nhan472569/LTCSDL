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

        public IEnumerable<Order> LayDSDH(){
            var ds = from i in db.Orders select i;
            return ds;
        }

        public dynamic LayDSDH1() {
            dynamic ds = db.Orders.Select(s => new
            {
                s.OrderID,
                s.OrderDate,
                s.Customer.CompanyName,
                s.Employee.LastName
            }).ToList();
            return ds;
        }

        public dynamic LayCTDH(int maDH)
        {
            dynamic ds = db.Order_Details.Where(s => s.OrderID == maDH).Select(s => new
            {
                s.OrderID,
                s.Product.ProductName,
                s.UnitPrice,
                s.Quantity
            });
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

        public void ThemDH(Order donHang) {
            db.Orders.InsertOnSubmit(donHang);
            db.SubmitChanges();
        }
        public bool XoaDH(int maDH)
        {
            bool trangThai = false;
            Order o = db.Orders.First(s => s.OrderID == maDH);

            try
            {
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

    }
}
