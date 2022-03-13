using SimpleCart.DBManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleCart.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        public loginModal objLogin = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userLogin"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            objLogin = (loginModal)HttpContext.Current.Session["userLogin"];
            if (objLogin.Role == "User")
            {
                Response.Redirect("../Login.aspx");
            }

            lblName.Text = objLogin.UserName + ' '+'(' + objLogin.Role + ')';

        }
    }
}