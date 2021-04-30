using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLDonHang_1851010089
{
    public partial class FQLNhanVien : Form
    {
        SqlConnection conn;
        SqlDataAdapter da;
        DataSet ds;
        public FQLNhanVien()
        {
            InitializeComponent();
            string query = ConfigurationManager.ConnectionStrings["QLDonHang_1851010089.Properties.Settings.NorthwindConnectionString"].ConnectionString;
            conn = new SqlConnection(query);
        }

        public void LayDSVN(DataGridView dg)
        {
            string query = "select EmployeeID,FirstName + ' ' + LastName as Name, BirthDate, HomePhone, Address from Employees";
            da = new SqlDataAdapter(query, conn);

            ds = new DataSet();
            da.Fill(ds);

            dg.DataSource = ds.Tables[0];
        }

        public void ThemNV()
        {
            string[] nameItems = txtHoten.Text.Split(' ');
            string firstName = nameItems[0];
            string lastName = nameItems[1];

            SqlCommand cmd;
            string query = string.Format("insert into Employees (FirstName, LastName, BirthDate, HomePhone ,Address) " +
                "values ('{0}', '{1}', '{2}', '{3}', '{4}')", firstName, lastName, dtpNgaySinh.Value.ToString("MM / dd / yyyy"), txtDienThoai.Text, txtDiaChi.Text);

            cmd = new SqlCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void XoaSP()
        {
            int maNV = int.Parse(dGNhanVien.CurrentRow.Cells[0].Value.ToString());
            SqlCommand cmd;
            string query = string.Format("delete from Employees where EmployeeID = {0}", maNV);

            cmd = new SqlCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void SuaTTNV()
        {
            int maNV = int.Parse(dGNhanVien.CurrentRow.Cells[0].Value.ToString());
            string[] nameItems = txtHoten.Text.Split(' ');
            string firstName = nameItems[0];
            string lastName = nameItems[1];
            SqlCommand cmd;
            string query = string.Format("update Employees set FirstName = '{0}', LastName = '{1}'," +
                " BirthDate = '{2}', HomePhone = '{3}', Address = '{4}' where EmployeeID = '{5}'",
                firstName, lastName, dtpNgaySinh.Value.ToString("MM / dd / yyyy"), txtDienThoai.Text, txtDiaChi.Text, maNV);

            cmd = new SqlCommand(query, conn);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void FQLNhanVien_Load(object sender, EventArgs e)
        {
            LayDSVN(dGNhanVien);
            dGNhanVien.Columns[0].Width = (int)(0.1 * dGNhanVien.Width);
            dGNhanVien.Columns[1].Width = (int)(0.2 * dGNhanVien.Width);
            dGNhanVien.Columns[2].Width = (int)(0.2 * dGNhanVien.Width);
            dGNhanVien.Columns[3].Width = (int)(0.2 * dGNhanVien.Width);
            dGNhanVien.Columns[4].Width = (int)(0.25 * dGNhanVien.Width);
        }

        private void dGNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dGNhanVien.Rows.Count)
            {
                txtHoten.Text = dGNhanVien.Rows[e.RowIndex].Cells[1].Value.ToString();
                dtpNgaySinh.Text = dGNhanVien.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtDienThoai.Text = dGNhanVien.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtDiaChi.Text = dGNhanVien.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            ThemNV();
            LayDSVN(dGNhanVien);
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            XoaSP();
            LayDSVN(dGNhanVien);
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            SuaTTNV();
            LayDSVN(dGNhanVien);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
