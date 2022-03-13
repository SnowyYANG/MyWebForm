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
    public partial class MyCart : System.Web.UI.Page
    {
        DataTable dtResult = new DataTable();
        DatabaseManagement _manager = new DatabaseManagement();
        public static loginModal objLogin = new loginModal();
        protected void Page_Load(object sender, EventArgs e)
        {
            objLogin = (loginModal)HttpContext.Current.Session["userLogin"];
            if (!IsPostBack)
            {
                if(objLogin != null)
                {
                    GetAllProducts();
                }
                else
                {
                    Response.Redirect("Products.aspx");
                }
            }
        }

        private void GetAllProducts()
        {
            dtResult.Clear();
            if (objLogin.LoginUserId > 0 && objLogin.Role == "User")
            {
                dtResult = _manager.GetDataTable("SELECT A.ID,P.ProductName,P.Prices,P.Description,P.Photo FROM AddToCart A JOIN Product_New P ON A.ProductId= P.ID WHERE A.IsDeleted <> 1 AND A.UserId =" + objLogin.LoginUserId + "");

                if (dtResult.Rows.Count > 0)
                {
                    GDCartList.DataSource = dtResult;
                    GDCartList.DataBind();
                }
                else
                {
                    GDCartList.DataSource = dtResult;
                    GDCartList.DataBind();
                }
            }
               
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            LinkButton linkbutton = (LinkButton)sender;
            var row = (GridViewRow)linkbutton.NamingContainer;
            int productId = Convert.ToInt32(row.Cells[0].Text);
            _RemoveCartProductFromDB(productId);
        }
        private void _RemoveCartProductFromDB(int cartId)
        {
            _manager.ExecuteSQL("UPDATE AddToCart Set IsDeleted = 1 WHERE ID =" + cartId + "");
            GetAllProducts();
            Response.Redirect("MyCart.aspx");
        }

        protected void GDCartList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
        }
    }
}