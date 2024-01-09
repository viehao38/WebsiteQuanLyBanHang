using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangTraSuaHKT
{
    internal class DataProviders
    {
        static string chuoiKetNoi = @"Data Source=.;Initial Catalog=QuanLyCuaHangTraSua_HKT;Integrated Security=True";
        static SqlConnection conn = new SqlConnection(chuoiKetNoi);
        static SqlDataAdapter da = new SqlDataAdapter();
        public static SqlConnection OpenConnecttion()
        {
            if (conn.State == System.Data.ConnectionState.Closed || conn.State == System.Data.ConnectionState.Broken)
            {
                conn.Open();
            }
            return conn;
        }

        public static DataTable ExecuteQuery(string query)
        {

            DataTable tbl = new DataTable();

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Connection = OpenConnecttion();

            da = new SqlDataAdapter(cmd);

            da.Fill(tbl);

            conn.Close();

            return tbl;
        }

        public static DataView ExecuteDataView(string query)
        {
            DataView dv = new DataView();

            DataSet ds = new DataSet();

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Connection = OpenConnecttion();

            da = new SqlDataAdapter(cmd);

            da.Fill(ds, "tbl");

            dv = ds.Tables["tbl"].DefaultView;


            conn.Close();

            return dv;
        }

        public static DataTable ExcuteSelectCommand(string query, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(query);

            DataTable tbl = new DataTable();
            cmd.Connection = OpenConnecttion();

            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }

            da.SelectCommand = cmd;

            da.Fill(tbl);

            conn.Close();

            return tbl;
        }

        public static int inSertIntoCommand(string query, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(query);

            int rows = 0;

            cmd.Connection = OpenConnecttion();

            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }

            rows = cmd.ExecuteNonQuery();

            return rows;
        }

        public static int deleteCommand(string query, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(query);

            int rows = 0;

            cmd.Connection = OpenConnecttion();

            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }

            rows = cmd.ExecuteNonQuery();

            return rows;
        }

        public static int UpdateCommand(string query, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(query);

            int rows = 0;

            cmd.Connection = OpenConnecttion();

            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }

            rows = cmd.ExecuteNonQuery();

            return rows;
        }

        public static int SelectCommand(string query, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(query);

            int rows = 0;

            cmd.Connection = OpenConnecttion();

            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }

            rows = Convert.ToInt32(cmd.ExecuteScalar());

            return rows;
        }

        public static int SelectCommand(string query)
        {
            SqlCommand cmd = new SqlCommand(query);

            int rows = 0;

            cmd.Connection = OpenConnecttion();

            rows = Convert.ToInt32(cmd.ExecuteScalar());

            return rows;
        }


        public static string Name(string query)
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(ExecuteQuery(query));
            string tennv = "";
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                tennv = dr["TenNV"].ToString();
            }
            return tennv;
        }
    }
}
