using SimpleCart.DBManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleCart.Admin
{
    public partial class AddProduct : System.Web.UI.Page
    {
        public static loginModal objLogin = new loginModal();
        DatabaseManagement _manager = new DatabaseManagement();
        DataTable dtResult = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userLogin"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            if (!IsPostBack)
            {
                objLogin = (loginModal)HttpContext.Current.Session["userLogin"];

                FillCategoryDDL();

                GetAllProducts();

            }
        }
        private void FillCategoryDDL()
        {
            dtResult = GetCategories();
            if (dtResult.Rows.Count > 0)
            {
                ddlCategoryName.DataSource = dtResult;
                ddlCategoryName.DataValueField = "ID";
                ddlCategoryName.DataTextField = "CategoryName";
                ddlCategoryName.DataBind();

            }
        }
        private void FillModalCategoryDDL()
        {
            dtResult = GetCategories();
            if (dtResult.Rows.Count > 0)
            {
                ddlUCategory.DataSource = dtResult;
                ddlUCategory.DataValueField = "ID";
                ddlUCategory.DataTextField = "CategoryName";
                ddlUCategory.DataBind();

            }
        }
        private DataTable GetCategories()
        {
            dtResult.Clear();
            dtResult = _manager.GetDataTable("SELECT ID,CategoryName FROM Category where IsDeleted <> 1 order by CategoryName desc");

            return dtResult;
        }
        private void GetAllProducts()
        {
            int categoryId = 0;
            if (ddlCategoryName.SelectedValue != "")
            {
                categoryId = Convert.ToInt32(ddlCategoryName.SelectedValue);
            }
            dtResult.Clear();
            dtResult = _manager.GetDataTable("Select * from Product_New where IsDeleted <> 1 AND CategoryID = " + categoryId + " order by ID desc");

            if (dtResult.Rows.Count > 0)
            {
                GridProducts.DataSource = dtResult;
                GridProducts.DataBind();
            }
            else
            {
                GridProducts.DataSource = dtResult;
                GridProducts.DataBind();
            }
        }
        protected void btnSaveProduct_Click(object sender, EventArgs e)
        {
            int id = 0;
            var fName = "";
            var fileName = "";
            fName = productImageFile.FileName.ToString();
            if (fName != "")
            {
                string fileType = System.IO.Path.GetExtension(fName).ToLower();
                if (fileType == ".jpg" || fileType == ".jpeg" || fileType == ".png" || fileType == ".mp4" || fileType == ".mp3")
                {
                    fileName = fName;
                    string _imagepath = "~/ProductImages/" + fileName;
                    System.IO.File.Delete(Server.MapPath(_imagepath));
                    productImageFile.PostedFile.SaveAs(Server.MapPath("~/ProductImages/") + fileName);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Disclaimer", "alert('Only required format are supported.');", true);
                }



            }
            id = _manager.ExecuteSQL("INSERT INTO Product_New (ProductName,Prices,Description,Photo,CategoryID,AddedDate) VALUES ('" + txtProductName.Text.Trim() + "','" + txtPrice.Text.Trim() + "','" + txtDescription.Text.Trim() + "','" + (fileName != "" ? fileName : "NULL") + "','" + Convert.ToInt32(ddlCategoryName.SelectedValue) + "','" + System.DateTime.Now + "')");
            GetAllProducts();
            txtProductName.Text = "";
            txtPrice.Text = "";
            txtDescription.Text = "";
        }

        protected void ddlCategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAllProducts();
        }

        protected void chkAccessTo_CheckedChanged(object sender, EventArgs e)
        {
            int id = 0;
            //int quizId = Convert.ToInt32(ddlQuiz.SelectedValue);
            int CreatedByUserId = objLogin.LoginUserId;
            foreach (GridViewRow row in this.GridProducts.Rows)
            {
                if (row.RowType != DataControlRowType.DataRow) continue;
                int _productId = Convert.ToInt32(row.Cells[0].Text);
                CheckBox chk = (CheckBox)row.FindControl("chkAccessTo");
                bool IsProductAvailable = false;
                if (chk.Checked)
                {
                    IsProductAvailable = true;
                }
                else
                {
                    IsProductAvailable = false;
                }
                _manager.ExecuteSQL("UPDATE PRODUCT_New SET IsAvailable = '" + IsProductAvailable + "' WHERE ID = " + _productId + "");
                GetAllProducts();
            }
        }

        protected void editLink_Click(object sender, EventArgs e)
        {
            LinkButton linkbutton = (LinkButton)sender;  // get the link button which trigger the event
            var row = (GridViewRow)linkbutton.NamingContainer; // get the GridViewRow that contains the linkbutton
            FillModalCategoryDDL();
            int _ProductId = Convert.ToInt32(row.Cells[0].Text);
            hfProductId.Value = _ProductId.ToString();
            ddlUCategory.SelectedValue = row.Cells[2].Text;
            txtUProduct.Text = row.Cells[3].Text;
            txtUPrice.Text = row.Cells[4].Text;
            txtUDescription.Text = row.Cells[5].Text;
            //txtUProduct.Text = row.Cells[2].Text;

            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "$('#myProductModal').modal()", true);
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            int id = 0;
            LinkButton linkbutton = (LinkButton)sender;  // get the link button which trigger the event
            var row = (GridViewRow)linkbutton.NamingContainer; // get the GridViewRow that contains the linkbutton
            int _productId = Convert.ToInt32(row.Cells[0].Text);
            _manager.ExecuteSQL("DELETE FROM PRODUCT_New WHERE ID = " + _productId + "");
            GetAllProducts();

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var fName = "";
            var fileName = "";
            fName = productUImageFile.FileName.ToString();
            if (fName != "")
            {
                string fileType = System.IO.Path.GetExtension(fName).ToLower();
                if (fileType == ".jpg" || fileType == ".jpeg" || fileType == ".png" || fileType == ".mp4" || fileType == ".mp3")
                {
                    fileName = fName;
                    string _imagepath = "~/ProductImages/" + fileName;
                    System.IO.File.Delete(Server.MapPath(_imagepath));
                    productUImageFile.PostedFile.SaveAs(Server.MapPath("~/ProductImages/") + fileName);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Disclaimer", "alert('Only required format are supported.');", true);
                }



            }
            _manager.ExecuteSQL("UPDATE Product_New SET ProductName ='" + txtUProduct.Text.Trim() + "',Prices='" + txtUPrice.Text.Trim() + "',Description='" + txtUDescription.Text.Trim() + "',Photo='" + fileName + "',CategoryID =" + ddlUCategory.SelectedValue + " WHERE ID =" + Convert.ToInt32(hfProductId.Value) + " ");
            GetAllProducts();
        }
    }
}