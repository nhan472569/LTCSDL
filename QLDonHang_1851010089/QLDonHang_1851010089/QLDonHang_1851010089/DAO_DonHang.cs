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
    }
}
