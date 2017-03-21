using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ASPDatabase
{
    /// <summary>
    /// Summary description for AndroidWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AndroidWebService : System.Web.Services.WebService
    {

        [WebMethod(MessageName = "OpenAccount", Description = "This method to create new account in the database")]
        [System.Xml.Serialization.XmlInclude(typeof(ContactResult))]

        public ContactResult OpenAccount(int ID, string FullName, string Phone)
        {
            ContactResult cr = new ContactResult();

            try
            {
                SqlConnection openCon = new SqlConnection();
                // using (SqlConnection openCon = new SqlConnection("Data Source=pc-0999;Initial Catalog=TEST;Integrated Security=True"))
                openCon.ConnectionString = "Data Source=pc-0999;Initial Catalog=TEST;Integrated Security=True";
                string saveAccount = "INSERT INTO AndroidContact (AndroidID,AndroidContactName,AndroidContactPhone) VALUES (@Android1, @Android2, @Android3)";
                using (SqlCommand querySaveAccount = new SqlCommand(saveAccount))
                    
                {
                    querySaveAccount.Connection = openCon;
                    querySaveAccount.Parameters.Add("@Android1", SqlDbType.Int, 30).Value = ID;
                    querySaveAccount.Parameters.Add("@Android2", SqlDbType.NVarChar, 30).Value = FullName;
                    querySaveAccount.Parameters.Add("@Android3", SqlDbType.NVarChar, 30).Value = Phone;

                    openCon.Open();
                    querySaveAccount.ExecuteNonQuery();
                    openCon.Close();
                }


                cr.ErrorID = 0;
                cr.ErrorMessage = "Contact is Added";
                return cr;
            }
            catch (Exception ex)
            {
                cr.ErrorID = 1;
                cr.ErrorMessage = ex.Message;
                return cr;
            }
        }
    }
}

        
    

