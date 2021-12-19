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
            GetUserData();
        }

        private void GetUserData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["_myCartConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                //Pass password
                var encriptedPassword = GetDecryptedString(txtPassword.Text);
                SqlCommand cmd = new SqlCommand("select * from users", connection);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                if (ds.Tables.Count > 0)
                {
                  
                    adp.Fill(ds);
                    _gridUser.DataSource = ds;
                    _gridUser.DataBind();
                }

            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["_myCartConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                //Pass password
                var encriptedPassword = GetEncryptedString(txtPassword.Text);
                SqlCommand cmd = new SqlCommand("Insert into Users (Email,Password,Name,Address,Mobile ) values(@_email, @password, @_name, @_address,@_mobile)", connection);
                cmd.Parameters.AddWithValue("@_email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@password", encriptedPassword);
                cmd.Parameters.AddWithValue("@_name", txtUserName.Text);
                cmd.Parameters.AddWithValue("@_address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@_mobile", txtMobile.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                //Display Save records
                GetUserData();
            }
        }

        // This function generate encripted password
        public string GetEncryptedString(string textToEncrypt)
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
        public string GetDecryptedString(string encryptedText)
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