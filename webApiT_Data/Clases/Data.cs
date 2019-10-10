using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace webApiT_Data.Clases
{
    public class Data:Interfaces.IData
    {
        private readonly IConfiguration _conf;

        public Data(IConfiguration Iconf)
        {
            _conf = Iconf;
        }

        public DataTable ObtenerPedidos(int id)
        {
            DataTable dt = new DataTable();
            using(SqlConnection con = new SqlConnection(_conf["conexion"]))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("MantenimientoPedidos",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@options", 3);
                cmd.Parameters.AddWithValue("@cantidad", 0);
                cmd.Parameters.AddWithValue("@inventarioId", id);
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);                
            }

            return dt;
        }

        public DataTable ObtenerPedidos()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(_conf["conexion"]))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("MantenimientoPedidos", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@options", 3);
                cmd.Parameters.AddWithValue("@cantidad", 0);
                cmd.Parameters.AddWithValue("@inventarioId", 0);
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
            }

            return dt;
        }

        public string AgregarPedidos(int options, int cantidad, int inventarioId)
        {
            string message;
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(_conf["conexion"]))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("MantenimientoPedidos", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@options", options);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Parameters.AddWithValue("@inventarioId", inventarioId);
                int rows = cmd.ExecuteNonQuery();
                if(rows > 0)
                {
                    message = "200"; 
                } else
                {
                    message = "400";
                }
            }
            return message;
        }

        public bool testConection()
        {
            string connection = _conf["conexion"];
            string algo = "";
            using (SqlConnection con = new SqlConnection(_conf["conexion"]))
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
        }
    }
}
