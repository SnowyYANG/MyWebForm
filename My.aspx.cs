using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleCart
{
    public partial class My : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //************To add new user these code should be commented because it's take records from user table
            //and fill email all textbox. to add new entry textbox must be empty...




            //var table = GetUserData();
            //if (table != null)
            //{
            //    txtUserName.Text = table.Rows[0]["Name"].ToString();
            //    txtEmail.Text = table.Rows[0]["Email"].ToString();
            //    txtAddress.Text = table.Rows[0]["Address"].ToString();
            //    txtMobile.Text = table.Rows[0]["Mobile"].ToString();
            //}



            //******call following function on page load to display already exist records of User table in asp.net Gridview

            GetUserData();
        }

        private DataTable GetUserData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                //Pass password
                SqlCommand cmd = new SqlCommand("select * from users", connection);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds);

                //Display Decripted password in Gridview....................


                //Declare datatable with user defined columns and fill(by foreach loop) from already filled dataset table of User

                DataTable _dt = new DataTable();
                _dt.Columns.Add("UserId");
                _dt.Columns.Add("UserEmail");
                _dt.Columns.Add("EncriptedPassword");
                _dt.Columns.Add("DecriptedPassword");
                _dt.Columns.Add("UserName");
                _dt.Columns.Add("UserAddress");
                _dt.Columns.Add("UserMobile");
                foreach (DataRow drRow in ds.Tables[0].Rows)
                {
                    DataRow dr = _dt.NewRow();
                    dr["UserId"] = Convert.ToInt32(drRow["Id"].ToString());
                    dr["UserEmail"] = drRow["Email"].ToString();
                    dr["EncriptedPassword"] = drRow["Password"].ToString();
                    dr["DecriptedPassword"] = My.GetDecryptedString(drRow["Password"].ToString());
                    dr["UserName"] = drRow["Name"].ToString();
                    dr["UserAddress"] = drRow["Address"].ToString();
                    dr["UserMobile"] = drRow["Mobile"].ToString();
                    _dt.Rows.Add(dr);

                }
                _gridUser.DataSource = _dt;
                _gridUser.DataBind();
                return _dt;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                //Pass password
                var encriptedPassword = GetEncryptedString(txtPassword.Text);
                SqlCommand cmd = new SqlCommand("Insert into Users (Email,Password,Name,Address,Mobile ) values(@_email, @password, @_name, @_address,@_mobile)", connection);
                cmd.Parameters.AddWithValue("@_email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@password", encriptedPassword);
                cmd.Parameters.AddWithValue("@_name", txtUserName.Text);
                cmd.Parameters.AddWithValue("@_address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@_mobile", txtMobile.Text);
                connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                //Display Save records
                GetUserData();
            }
        }

        // This function generate encripted password
        public static string GetEncryptedString(string textToEncrypt)
        {
            string EncryptionKey = "SIMPLECARTT00991";
            byte[] clearBytes = Encoding.Unicode.GetBytes(textToEncrypt);
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
                        //cs.Close();
                    }
                    textToEncrypt = Convert.ToBase64String(ms.ToArray());
                }
            }
            return textToEncrypt;
        }
        public static string GetDecryptedString(string encryptedText)
        {
            string EncryptionKey = "SIMPLECARTT00991";
            encryptedText = encryptedText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(encryptedText);
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
                        //cs.Close();
                    }
                    encryptedText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }

            return encryptedText;
        }
    }
}