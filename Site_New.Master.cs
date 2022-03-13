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
    public partial class Site_New : System.Web.UI.MasterPage
    {
        DataTable dtResult = new DataTable();
        DatabaseManagement _manager = new DatabaseManagement();
        public static loginModal objLogin = new loginModal();

        protected void Page_Load(object sender, EventArgs e)
        {
            objLogin = (loginModal)HttpContext.Current.Session["userLogin"];
            if (objLogin != null)
            {
                lblName.Text = objLogin.UserName;
            }

            //if (!IsPostBack)
            //{
            GetCartCount();
            //}


        }
        private void GetCartCount()
        {
            lblCartCount.Text = "";
            dtResult.Clear();
            if (objLogin != null)
            {
                if (objLogin.LoginUserId > 0 && objLogin.Role == "User")
                {
                    dtResult = _manager.GetDataTable("Select Count(ProductId) as Total from AddToCart Where UserId = " + objLogin.LoginUserId + " AND IsDeleted <> 1;");

                    if (dtResult.Rows.Count > 0)
                    {
                        int CartCount = Convert.ToInt32(dtResult.Rows[0]["Total"].ToString());
                        if (CartCount > 0)
                        {
                            lblCartCount.Text = dtResult.Rows[0]["Total"].ToString();
                        }
                        else
                        {
                            lblCartCount.Visible = false;
                        }

                    }
                    else
                    {
                        lblCartCount.Visible = false;
                    }
                }
            }
        }
    }
}