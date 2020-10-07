using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace HairSalonRoyalDoan.Models.Common
{
    public class DataProvider
    {
        //desktop viettel
        string chuoikn = @"Data Source=DESKTOP-C5LNGFV\SQLEXPRESS;Initial Catalog=HairSalonRoyalDoan;Integrated Security=True";
        //desktop btanh
        //string chuoikn = @"Data Source=DESKTOP-2FL7VEI;Initial Catalog=HairSalonRoyalDoan;Integrated Security=True";
        //macbook btanh

        public SqlConnection conn = new SqlConnection();
        public void kn_csdl()
        {
            conn.ConnectionString = chuoikn;
            conn.Open();
        }
        public string ExecuteScalar(string procName, object[] para = null, List<string> listpara = null)
        {
            string kq = "";
            using (SqlConnection conn = new SqlConnection(chuoikn))
            {
                try
                {
                    conn.Open();
                    DataTable table = new DataTable();
                    SqlCommand command = new SqlCommand(procName, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    if (para != null)
                    {
                        for (int i = 0; i < para.Length; i++)
                        {
                            command.Parameters.AddWithValue(listpara[i], para[i]);
                        }
                    }
                    kq = command.ExecuteScalar().ToString();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    kq = "";
                }

                return kq;
            }
        }

        public void dongketnoi()
        {
            if (conn.State == ConnectionState.Open)
            { conn.Close(); }
        }
        public DataTable SelectTable(string query)
        {
            DataTable bangdulieu = new DataTable();
            try
            {
                kn_csdl();
                SqlDataAdapter Adapter = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();

                Adapter.Fill(bangdulieu);
            }
            catch (System.Exception)
            {
                bangdulieu = null;
            }
            finally
            {
                dongketnoi();
            }

            return bangdulieu;
        }
        public DataTable ExecuteQuery(string procName, object[] para = null, List<string> listpara = null)
        {
            
            using (SqlConnection conn = new SqlConnection(chuoikn))
            {
                DataTable table = new DataTable();
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand(procName, conn);
                    command.CommandType = CommandType.StoredProcedure;


                    if (para != null)
                    {
                        for (int i = 0; i < para.Length; i++)
                        {
                            command.Parameters.AddWithValue(listpara[i], para[i]);
                        }


                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(table);
                }
                catch (Exception ex)
                {
                    table = null;
                }

                return table;
            }
        }






    }
}