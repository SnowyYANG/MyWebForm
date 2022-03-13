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
    public partial class Products : System.Web.UI.Page
    {
        DatabaseManagement _manager = new DatabaseManagement();
        DataTable dtResult = new DataTable();
        public static loginModal objLogin = new loginModal();
        protected void Page_Load(object sender, EventArgs e)
        {
            objLogin = (loginModal)HttpContext.Current.Session["userLogin"];
            if (!IsPostBack)
            {
                FillCategory();
                GetAllProducts();
            }
        }
        private void FillCategory()
        {
            dtResult.Clear();
            dtResult = _manager.GetDataTable("SELECT ID,CategoryName FROM Category where IsDeleted <> 1 order by CategoryName desc");

            if (dtResult.Rows.Count > 0)
            {
                ddlCategory.DataSource = dtResult;
                ddlCategory.DataValueField = "ID";
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataBind();
            }
        }
        private void GetAllProducts()
        {
            int categoryId = 0;
            if (ddlCategory.SelectedValue != "")
            {
                categoryId = Convert.ToInt32(ddlCategory.SelectedValue);
            }
            dtResult.Clear();
            dtResult = _manager.GetDataTable("Select * from Product_New where IsDeleted <> 1 AND IsAvailable <> 0 AND CategoryID = " + categoryId + " order by ID desc");

            if (dtResult.Rows.Count > 0)
            {
                DLProduct.DataSource = dtResult;
                DLProduct.DataBind();
            }
            else
            {
                DLProduct.DataSource = dtResult;
                DLProduct.DataBind();
            }
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAllProducts();
        }

        protected void lnkAddToCart_Click(object sender, EventArgs e)
        {
            LinkButton linkbutton = (LinkButton)sender;
            DataListItem item = (DataListItem)linkbutton.NamingContainer;
            Label lblItemId = (Label)item.FindControl("LblID");
            //int itemId = Convert.ToInt32(row.Cells[1].Text);
            int productId = Convert.ToInt32(lblItemId.Text);
            _AddCartItemsToDB(productId);
            Response.Redirect("Products.aspx");
        }
        private void _AddCartItemsToDB(int productId)
        {
            _manager.ExecuteSQL("INSERT INTO AddToCart (ProductID,UserId,DateAdded)VALUES(" + productId + "," + objLogin.LoginUserId + ",'" + System.DateTime.Now + "')");
        }

        protected void ViewDetail_Click(object sender, EventArgs e)
        {
            LinkButton linkbutton = (LinkButton)sender;
            DataListItem item = (DataListItem)linkbutton.NamingContainer;
            Label lblProductId = (Label)item.FindControl("LblID");
            //Image imageURL = (Image)item.FindControl("ImageModal");
            int productId = Convert.ToInt32(lblProductId.Text);
            dtResult.Clear();
            dtResult = _manager.GetDataTable("SELECT ProductName,Prices,Description,Photo from Product Where ID = "+ productId + " AND IsDeleted <> 1");
            if (dtResult.Rows.Count > 0)
            {
                lblName.Text = dtResult.Rows[0]["ProductName"].ToString();
                lblPrice.Text = dtResult.Rows[0]["Prices"].ToString();
                lblDescription.Text = dtResult.Rows[0]["Description"].ToString();
                ImageModal.ImageUrl = "";
                ImageModal.ImageUrl = "./ProductImages/" + (dtResult.Rows[0]["Photo"].ToString() !=null ? dtResult.Rows[0]["Photo"].ToString(): "default1.jpg");
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "$('#myImageModal').modal()", true);
            }
            //int itemId = Convert.ToInt32(row.Cells[1].Text);


        }
    }
}