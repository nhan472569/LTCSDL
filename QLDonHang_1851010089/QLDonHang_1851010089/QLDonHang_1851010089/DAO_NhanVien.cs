using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLDonHang_1851010089
{
    class DAO_NhanVien
    {
        NWDataContext db;

        public DAO_NhanVien()
        {
            db = new NWDataContext();
        }

        public dynamic LayDSVN()
        {
            dynamic ds = db.Employees.Select(s => new
            {
                s.EmployeeID,
                Name = s.FirstName +' '+ s.LastName,
                s.BirthDate,
                s.HomePhone,
                s.Address
            }).ToList();

            return ds;
        }

        public void ThemNV(Employee em)
        {
            db.Employees.InsertOnSubmit(em);
            db.SubmitChanges();
        }

        public bool XoaNV(int maNV)
        {
            bool trangThai = false;

            try
            {
                Employee em = db.Employees.First(s => s.EmployeeID == maNV);
                trangThai = true;
                db.Employees.DeleteOnSubmit(em);
                db.SubmitChanges();
            }
            catch (Exception)
            {
                trangThai = false;
            }
            return trangThai;
        }

        public bool SuaTTNV(Employee em)
        {
            bool trangThai = false;
            Employee o = new Employee();

            try
            {
                o = db.Employees.First(s => s.EmployeeID == em.EmployeeID);
                trangThai = true;
                o.FirstName = em.FirstName;
                o.LastName = em.LastName;
                o.BirthDate = em.BirthDate;
                o.HomePhone = em.HomePhone;
                o.Address = em.Address;
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
