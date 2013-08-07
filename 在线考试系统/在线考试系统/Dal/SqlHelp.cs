using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace 在线考试系统.Dal
{
    class SqlHelp
    {
        SqlConnection cn = new SqlConnection(Comm.getConnectionStr());
        SqlCommand com;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommandBuilder cmb;
        public void SqlENQ()
        {
            cn.Open();
            com.ExecuteNonQuery();
            cn.Close();
        }

        public void SqlUpdate()
        {
            cmb = new SqlCommandBuilder(da);
            da.Update(ds.GetChanges());
            ds.AcceptChanges();
        }

        public void SqlPar(string str0, string str1)
        {
            com.Parameters.Add(new SqlParameter(str0, str1));
        }
        public void SqlPar(string[] str0, string[] str1)
        {
            for (int i = 0; i < str0.Length; i++)
            {
                com.Parameters.Add(new SqlParameter(str0[i], str1[i]));
            }
        }
        public void SqlCom(string str, CommandType ct)
        {
            com = new SqlCommand(str, cn);
            com.CommandType = ct;
        }

        public object SqlES()
        {
            cn.Open();
            object obj = com.ExecuteScalar();
            cn.Close();
            return obj;
        }
        public DataSet SqlFillDs()
        {

            da = new SqlDataAdapter(com);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet SqlFillDs(string str)
        {

            da = new SqlDataAdapter(com);
            ds = new DataSet();
            da.Fill(ds,str);
            return ds;
        }
    }
}
