using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace QLDonHang_1851010089
{
    class DAO_SanPham
    {
        NWDataContext db;
        public DAO_SanPham()
        {
            db = new NWDataContext();
        }

        public dynamic LayDSLoaiSP()
        {
            var ds = db.Categories.Select(s => new { s.CategoryID, s.CategoryName });
            return ds;
            //string query = "select CategoryID, CategoryName from Categories";
            //da = new SqlDataAdapter(query, conn);

            //ds = new DataSet();
            //da.Fill(ds);
            //return ds.Tables[0];
        }

        public dynamic LayDSNCC()
        {
            var ds = db.Suppliers.Select(s => new { s.SupplierID, s.CompanyName });
            return ds;
            //string query = "select SupplierID, CompanyName from Suppliers";
            //da = new SqlDataAdapter(query, conn);

            //ds = new DataSet();
            //da.Fill(ds);
            //return ds.Tables[0];
        }

        public dynamic LayDSSP()
        {
            dynamic ds = db.Products.Select(s => new
            {
                s.ProductID,
                s.ProductName,
                s.UnitsInStock,
                s.UnitPrice,
                s.Category.CategoryName,
                s.Supplier.CompanyName
            }).ToList();

            return ds;
            //string query = "select ProductID, ProductName, UnitsInStock, UnitPrice, Categories.CategoryName, Suppliers.CompanyName" +
            //    " from Products, Categories, Suppliers" +
            //    " where Products.CategoryID = Categories.CategoryID" +
            //    " and Products.SupplierID = Suppliers.SupplierID";
            //da = new SqlDataAdapter(query, conn);

            //ds = new DataSet();
            //da.Fill(ds);
            //return ds.Tables[0];
        }

        public void ThemSP(Product pr)
        {
            db.Products.InsertOnSubmit(pr);
            db.SubmitChanges();
            //SqlCommand cmd;
            //string query = string.Format("insert into Products (ProductName, UnitsInStock, UnitPrice, CategoryID ,SupplierID) " +
            //    "values ('{0}', '{1}', '{2}', '{3}', '{4}')",
            //    tenSP, soLuong, donGia, maLoaiSP, maNCC);

            //cmd = new SqlCommand(query, conn);

            //conn.Open();
            //cmd.ExecuteNonQuery();
            //conn.Close();
        }

        public bool XoaSP(int maSP)
        {
            bool trangThai = false;

            try
            {
                Product pr = db.Products.First(s => s.ProductID == maSP);
                db.Products.DeleteOnSubmit(pr);
                db.SubmitChanges();
                trangThai = true;
            }
            catch (Exception)
            {

                trangThai = false;
            }

            return trangThai;

            //SqlCommand cmd;
            //string query = string.Format("delete from Products where ProductID = '{0}'", maSP);

            //cmd = new SqlCommand(query, conn);

            //conn.Open();
            //cmd.ExecuteNonQuery();
            //conn.Close();
        }

        public bool SuaTTSP(Product sanPham)
        {
            bool trangThai = false;

            try
            {
                Product pr = db.Products.First(s => s.ProductID == sanPham.ProductID);
                pr.ProductName = sanPham.ProductName;
                pr.UnitsInStock = sanPham.UnitsInStock;
                pr.UnitPrice = sanPham.UnitPrice;
                pr.CategoryID = sanPham.CategoryID;
                pr.SupplierID = sanPham.SupplierID;
                trangThai = true;
                db.SubmitChanges();
            }
            catch (Exception)
            {
                trangThai = false;
            }

            return trangThai;
            //SqlCommand cmd;
            //string query = string.Format("update Products set ProductName = '{0}', UnitsInStock = '{1}'," +
            //    " UnitPrice = '{2}', CategoryID = '{3}', SupplierID = '{4}' where ProductID = '{5}'",
            //    tenSP, soLuong, donGia, maLoaiSP, maNCC, maSP);

            //cmd = new SqlCommand(query, conn);

            //conn.Open();
            //cmd.ExecuteNonQuery();
            //conn.Close();
        }
    }
}
