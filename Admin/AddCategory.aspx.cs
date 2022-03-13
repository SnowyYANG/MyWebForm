using SimpleCart.DBManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SimpleCart.Admin
{
    public partial class AddCategory : System.Web.UI.Page
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
                FillCategory();

            }
        }

        protected void btnSaveCategory_Click(object sender, EventArgs e)
        {
            int id = 0;
            id = _manager.ExecuteSQL("INSERT INTO Category (CategoryName,AddedDate) VALUES('" + txtCategory.Text.Trim() + "','" + System.DateTime.Now + "')");
            FillCategory();
            txtCategory.Text = "";
        }

        private void FillCategory()
        {
            dtResult.Clear();
            dtResult = _manager.GetDataTable("SELECT ID,CategoryName FROM Category where IsDeleted <> 1 order by ID desc");

            if (dtResult.Rows.Count > 0)
            {
                GridCategory.DataSource = dtResult;
                GridCategory.DataBind();
            }
            else
            {
                GridCategory.DataSource = null;
                GridCategory.DataBind();
            }
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            int id = 0;
            LinkButton linkbutton = (LinkButton)sender;  // get the link button which trigger the event
            var row = (GridViewRow)linkbutton.NamingContainer; // get the GridViewRow that contains the linkbutton
            int _CategoryId = Convert.ToInt32(row.Cells[0].Text);
            _manager.ExecuteSQL("Update Category Set IsDeleted = 1 WHERE ID = " + _CategoryId + "");
            FillCategory();
        }

        protected void editLink_Click(object sender, EventArgs e)
        {
            int id = 0;
            LinkButton linkbutton = (LinkButton)sender;  // get the link button which trigger the event
            var row = (GridViewRow)linkbutton.NamingContainer; // get the GridViewRow that contains the linkbutton
            int _CategoryId = Convert.ToInt32(row.Cells[0].Text);
            hfCategoryId.Value = _CategoryId.ToString();
            txtUCategoryName.Text = row.Cells[2].Text;
            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "$('#myModal').modal()", true);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int categoryId = hfCategoryId.Value != "" ? Convert.ToInt32(hfCategoryId.Value) : 0;
            _manager.ExecuteSQL("Update Category Set CategoryName = '"+txtUCategoryName.Text.Trim()+"' WHERE ID = " + categoryId + "");
            FillCategory();
            txtUCategoryName.Text = "";
        }

        protected void GridCategory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
        }
    }
}