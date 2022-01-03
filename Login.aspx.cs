using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleCart
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                //Pass password
                SqlCommand cmd = new SqlCommand("select Id,Password from users WHERE Email=@email", connection);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);

                connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var encrypted = reader.GetString(1);
                        if (encrypted != null && My.GetDecryptedString(encrypted) == txtPassword.Text)
                        {
                            Session["UserId"] = reader.GetString(0);
                            Response.Redirect("/");
                        }
                    }
                }
            }
        }
    }
}