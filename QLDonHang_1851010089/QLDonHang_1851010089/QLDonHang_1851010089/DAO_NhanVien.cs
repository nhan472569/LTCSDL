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

            //string[] nameItems = name.Split(' ');
            //string firstName = nameItems[0];
            //string lastName = nameItems[1];

            //SqlCommand cmd;
            //string query = string.Format("insert into Employees (FirstName, LastName, BirthDate, HomePhone ,Address) " +
            //    "values ('{0}', '{1}', '{2}', '{3}', '{4}')", firstName, lastName, birthDate.ToString("MM / dd / yyyy"), phone, address);

            //cmd = new SqlCommand(query, conn);
            //conn.Open();
            //cmd.ExecuteNonQuery();
            //conn.Close();
        }

        public void XoaSP(Employee em, int maNV)
        {
            db.Employees.DeleteOnSubmit(em);
            db.SubmitChanges();

            //SqlCommand cmd;
            //string query = string.Format("delete from Employees where EmployeeID = {0}", maNV);

            //cmd = new SqlCommand(query, conn);
            //conn.Open();
            //cmd.ExecuteNonQuery();
            //conn.Close();
        }

        //public void SuaTTNV(string name, DateTime birthDate, string phone, string address, int maNV)
        //{
        //    string[] nameItems = name.Split(' ');
        //    string firstName = nameItems[0];
        //    string lastName = nameItems[1];
        //    SqlCommand cmd;
        //    string query = string.Format("update Employees set FirstName = '{0}', LastName = '{1}'," +
        //        " BirthDate = '{2}', HomePhone = '{3}', Address = '{4}' where EmployeeID = '{5}'",
        //        firstName, lastName, birthDate.ToString("MM / dd / yyyy"), phone, address, maNV);

        //    cmd = new SqlCommand(query, conn);

        //    conn.Open();
        //    cmd.ExecuteNonQuery();
        //    conn.Close();
        //}
    }
}
