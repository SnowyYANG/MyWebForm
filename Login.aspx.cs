using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
                SqlCommand cmd = new SqlCommand("select Id,Password from users WHERE Email=@email AND Password = @password", connection);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@password", My.GetEncryptedString(txtPassword.Text));

                connection.Open();
                SqlDataAdapter sdp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sdp.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    lblMessage.Visible = false;
                    Session["UserId"] = Convert.ToInt32(dt.Rows[0]["Id"]);
                    //var password = dt.Rows[0]["Password"];
                    Response.Redirect("My.aspx");

                }
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Email/Password is incorrect.";
                }
                //using (var reader = cmd.ExecuteReader())
                //{
                //    if (reader.Read())
                //    {
                //        var encrypted = reader.GetString(1);
                //        if (encrypted != null && My.GetDecryptedString(encrypted) == txtPassword.Text)
                //        {
                //            Session["UserId"] =reader.GetString(1).ToString();
                //            Response.Redirect("My.aspx");
                //        }
                //    }
                //}
            }
        }
    }
}