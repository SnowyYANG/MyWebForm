
using SimpleCart.DBManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleCart
{
    public partial class SignUp : System.Web.UI.Page
    {
        DatabaseManagement _manager = new DatabaseManagement();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _manager.ExecuteSQL("INSERT INTO Users (Name,Gender,Address,Email,Password) VALUES('" + TxtName.Text.Trim() + "','" + RBGender.SelectedValue + "','" + TxtAddress.Text.Trim() + "','" + TxtEmail.Text.Trim() + "','" + TxtPassword.Text.Trim() + "')");

               

                TxtName.Text = "";
                TxtEmail.Text = "";
                TxtPassword.Text = "";
                TxtAddress.Text = "";
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void lnkSignIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login_new.aspx");
        }
    }
}