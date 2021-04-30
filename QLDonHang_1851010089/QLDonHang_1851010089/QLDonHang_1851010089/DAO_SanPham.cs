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
        SqlConnection conn;
        SqlDataAdapter da;
        DataSet ds;
        public DAO_SanPham()
        {
            string query = ConfigurationManager.ConnectionStrings["QLDonHang_1851010089.Properties.Settings.NorthwindConnectionString"].ConnectionString;
            conn = new SqlConnection(query);
        }

        public DataTable LayDSLoaiSP()
        {
            string query = "select CategoryID, CategoryName from Categories";
            da = new SqlDataAdapter(query, conn);

            ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

        public DataTable LayDSNCC()
        {
            string query = "select SupplierID, CompanyName from Suppliers";
            da = new SqlDataAdapter(query, conn);

            ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

        public DataTable LayDSSP()
        {
            string query = "select ProductID, ProductName, UnitsInStock, UnitPrice, Categories.CategoryName, Suppliers.CompanyName" +
                " from Products, Categories, Suppliers" +
                " where Products.CategoryID = Categories.CategoryID" +
                " and Products.SupplierID = Suppliers.SupplierID";
            da = new SqlDataAdapter(query, conn);

            ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

        public void ThemSP(string tenSP, int soLuong, double donGia, int maLoaiSP, int maNCC)
        {
            SqlCommand cmd;
            string query = string.Format("insert into Products (ProductName, UnitsInStock, UnitPrice, CategoryID ,SupplierID) " +
                "values ('{0}', '{1}', '{2}', '{3}', '{4}')",
                tenSP, soLuong, donGia, maLoaiSP, maNCC);

            cmd = new SqlCommand(query, conn);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void XoaSP(int maSP)
        {
            SqlCommand cmd;
            string query = string.Format("delete from Products where ProductID = '{0}'", maSP);

            cmd = new SqlCommand(query, conn);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void SuaTTSP(int maSP, string tenSP, int soLuong, double donGia, int maLoaiSP, int maNCC)
        {
            SqlCommand cmd;
            string query = string.Format("update Products set ProductName = '{0}', UnitsInStock = '{1}'," +
                " UnitPrice = '{2}', CategoryID = '{3}', SupplierID = '{4}' where ProductID = '{5}'",
                tenSP, soLuong, donGia, maLoaiSP, maNCC, maSP);

            cmd = new SqlCommand(query, conn);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
