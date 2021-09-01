using Commonlayer.Models.RequestModel;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Service
{
    public class AdminRL: IAdminRL
    {
        //create new sqlconnection and connection to database by using connection string from web.config file  
        public static readonly string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        SqlConnection con = new SqlConnection(strcon);
        CultureInfo1 cultureInfo1 = new CultureInfo1();

        public void AdminRegistration(Credential credential)
        {
            credential.Role = "Admin";
            SqlCommand com = new SqlCommand("spAdminRegistration", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@UserName", credential.UserName);
            com.Parameters.AddWithValue("@EmailAddress", credential.EmailAddress);
            com.Parameters.AddWithValue("@Password", EncryptionHelper.EncodePasswordToBase64(credential.Password));
            com.Parameters.AddWithValue("@Role", credential.Role);
            var ReturnParameter = com.Parameters.Add("@Result", SqlDbType.Int);
            ReturnParameter.Direction = ParameterDirection.ReturnValue;

            con.Open();
            com.ExecuteNonQuery();
            int result = (int)ReturnParameter.Value;
            con.Close();

            if (result.Equals(1))
            {

            }

        }

        public Credential AdminLogin(Credential credential)
        {
            SqlCommand com = new SqlCommand("spAdminLogin", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmailAddress", credential.EmailAddress);
            com.Parameters.AddWithValue("@Password", EncryptionHelper.EncodePasswordToBase64(credential.Password));
           
            con.Open();
            SqlDataReader dr = com.ExecuteReader();
            Credential result = new Credential();
            while (dr.Read())
            {
                result.Id = Convert.ToInt32(dr["Id"]);
                result.EmailAddress = Convert.ToString(dr["EmailAddress"]);
                result.Role = Convert.ToString(dr["Role"]);
            }
            con.Close();

            if (result.Id == 0)
            {
                result.SnackbarNotification = "fail";
            }
            else
            {
                result.SnackbarNotification = "success";
            }
            return result;
        }
    }
}
