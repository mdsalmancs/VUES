using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;



namespace DatabaseLayer
{
    public class DBConnection
    {
        public SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ArNob\Desktop\demo_2\VUES_1.mdf;Integrated Security=True;Connect Timeout=30");
        public SqlDataAdapter dt;
        public SqlDataReader dr;
        public SqlCommand sql;


        public void GetQuery(string query)
        {
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();

            con.Open();

            sql = new SqlCommand(query, con);
            dr = sql.ExecuteReader();
            dt = new SqlDataAdapter(query, con);
        }
    }
}
