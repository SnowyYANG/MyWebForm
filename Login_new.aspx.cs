using SimpleCart.DBManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleCart
{
    public partial class Login_new : System.Web.UI.Page
    {
        DatabaseManagement _manager = new DatabaseManagement();
        DataTable dtResult = new DataTable();
        loginModal _objLogin = new loginModal();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            dtResult.Clear();
            dtResult = _manager.GetDataTable("Select U.ID,Name,Email,Password,R.RoleName as Role from Users U INNER JOIN Roles R ON U.RoleID = R.ID WHERE U.IsActive = 1 AND Email = '" + TxtEmail.Text.Trim() + "' AND Password = '" + TxtPassword.Text.Trim() + "'");
            if (dtResult.Rows.Count > 0)
            {
                _objLogin.LoginUserId = Convert.ToInt32(dtResult.Rows[0]["ID"].ToString());
                _objLogin.UserName = dtResult.Rows[0]["Name"].ToString();
                _objLogin.Email = dtResult.Rows[0]["Email"].ToString();
                _objLogin.Role = dtResult.Rows[0]["Role"].ToString();

                HttpContext.Current.Session["userLogin"] = _objLogin;
                Session["USER_ID"] = dtResult.Rows[0]["ID"].ToString();
                switch (_objLogin.Role)
                {
                    case "User":
                        Response.Redirect("Home.aspx");
                        break;
                    default:
                        Response.Redirect("/Admin/Home");
                        break;
                }

            }
            else
            {
                lblMessage.Text = "Email/Password is incorrect...";
            }
        }

        protected void lnkSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }
    }
}