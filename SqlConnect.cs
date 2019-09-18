using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    class SqlConnect
    {
        private const String sql_con_string = @"Data source = DESKTOP-0BBABDI;Initial Catalog = SOCAR_DB; Integrated security = true";
        private SqlConnection con = new SqlConnection(sql_con_string);
        public SqlConnection connect()
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();

            }
            return con;             
        }

        public void close()
        {
            con.Close();
        }
    }
}
