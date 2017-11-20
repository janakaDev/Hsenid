using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class HandleUserData
    {
        public SqlConnection con;

        public bool AddUserData(Users user)
        {
            DbConnection dbConnection = new DbConnection();
            con = dbConnection.Connection(con);
            SqlCommand cmd = new SqlCommand("AddUsers", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@Password", user.Password);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }


        public string[] GetUserWithId(string email,string password)
        {
            string[] name = new string[2];
            try {

                Users userModel = new Users();
                DbConnection conection = new DbConnection();
                con = conection.Connection(con);
                SqlCommand cmd = new SqlCommand("select * from users where Email=@Email and Password=@Password", con);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dta = new DataTable();
                con.Open();
                da.Fill(dta);
                con.Close();

                foreach(DataRow dr in dta.Rows)
                {
                    name[0] = dr["Name"].ToString();
                    name[1] = dr["Id"].ToString();
                }

                       
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return name;
        }
    }
}




