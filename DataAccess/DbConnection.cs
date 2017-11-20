using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DbConnection
    {
        public SqlConnection Connection(SqlConnection con)
        {
            string constring = ConfigurationManager.ConnectionStrings["FunDbEntities"].ToString();
            con = new SqlConnection(constring);
            return con;
        }
    }
}
