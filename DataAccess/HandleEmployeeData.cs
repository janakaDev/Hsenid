using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using System.Data;

namespace DataAccess
{

    public class HandleEmployeeData
    {
        private SqlConnection con;

        public bool AddEmployees(Employee employeeModel)
        {
            DbConnection dbConnection = new DbConnection();
            con = dbConnection.Connection(con);
            SqlCommand cmd = new SqlCommand("AddEmployees", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FirstName", employeeModel.FirstName);
            cmd.Parameters.AddWithValue("@LastName", employeeModel.LastName);
            cmd.Parameters.AddWithValue("@Designation", employeeModel.Designation);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i > 1)
                return true;
            else
                return false;

        }

        public List<Employee> GetEmployeeData()
        {
            List<Employee> employeeList = new List<Employee>();
            DbConnection dbConnection = new DbConnection();
            con = dbConnection.Connection(con);

            SqlCommand cmd = new SqlCommand("GetDataEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();

            con.Open();
            dataAdapter.Fill(dataTable);
            con.Close();

            foreach (DataRow dr in dataTable.Rows)
            {

                employeeList.Add(
                    new Employee
                    {
                        Id = Convert.ToInt16(dr["Id"]),
                        FirstName = dr["FirstName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        Designation = dr["Designation"].ToString()
                    }
                    );
            }

            return employeeList;
        }

        public int getEmployeeIWithName(string name)
        {
            DbConnection dbConnection = new DbConnection();
            con = dbConnection.Connection(con);
            SqlCommand cmd = new SqlCommand("select id from employee where FirstName=@FirstName", con);
            cmd.Parameters.AddWithValue("@FirstName", name);
            SqlDataAdapter dataAdater = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();

            con.Open();
            dataAdater.Fill(dataTable);
            con.Close();
            string ids = "";
            ids = dataTable.Rows[0]["Id"].ToString();

            int id = Convert.ToInt16(ids);

            return id;
        }

        public string getEmployeeDesignationWithName(string name)
        {
            string designation = "";
            DbConnection dbConnection = new DbConnection();
            con = dbConnection.Connection(con);
            string name2 = name;
            SqlCommand cmd = new SqlCommand("select * from employee where firstname = @FirstName", con);
            cmd.Parameters.AddWithValue("@FirstName", name);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();

            con.Open();
            dataAdapter.Fill(dataTable);
            con.Close();

            designation = dataTable.Rows[0]["Designation"].ToString();
            return designation;
        }

        public int GetSumOfOtHours(string name)
        {
            int id = getEmployeeIWithName(name);
            DbConnection dbConnection = new DbConnection();
            SqlCommand cmd = new SqlCommand("SELECT OtH from OtHours where EmployeeId=@Id", con);
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();

            con.Open();
            dataAdapter.Fill(dataTable);
            con.Close();

            List<string> listString = new List<string>();
            foreach (DataRow dr in dataTable.Rows)
            {
                listString.Add(dr["OtH"].ToString());
            }

            int i = 0;
            foreach (var item in listString)
            {
                i += Convert.ToInt16(item);
            }

            return i;
        }


        public int DeleteEmployee(int id)
        {
           
                DbConnection db = new DbConnection();
                con = db.Connection(con);
                SqlCommand cmd = new SqlCommand("DeleteEmployee", con);
                cmd.Parameters.AddWithValue("@Id",id);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();

                if (i >= 1)
                    return 1;
                else
                    return 0;

        }


    }


    private string Encrypt(string clearText)
    {
        string EncryptionKey = "MAKV2SPBNI99212";
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                clearText = Convert.ToBase64String(ms.ToArray());
            }
        }
        return clearText;
    }

    private string Decrypt(string cipherText)
    {
        string EncryptionKey = "MAKV2SPBNI99212";
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }
                cipherText = Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        return cipherText;
    }

}
