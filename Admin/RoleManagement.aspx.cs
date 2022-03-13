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
    public partial class RoleManagement : System.Web.UI.Page
    {
        DatabaseManagement _manager = new DatabaseManagement();
        DataTable dtResult = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAdminUser();
            }
        }

        private void GetAdminUser()
        {
            dtResult.Clear();
            dtResult = _manager.GetDataTable("Select U.ID,U.Name,U.Gender,U.Email,u.Password,R.RoleName,U.IsActive from Users U INNER JOIN Roles R ON U.RoleID = R.ID WHERE U.IsDeleted <> 1 and U.RoleID = 1;");
            if (dtResult.Rows.Count > 0)
            {
                GridAllUsers.DataSource = dtResult;
                GridAllUsers.DataBind();
            }
            else
            {
                GridAllUsers.DataSource = dtResult;
                GridAllUsers.DataBind();
            }
        }

        protected void chkAccessTo_CheckedChanged(object sender, EventArgs e)
        {
            int id = 0;
            //int quizId = Convert.ToInt32(ddlQuiz.SelectedValue);

            foreach (GridViewRow row in this.GridAllUsers.Rows)
            {
                if (row.RowType != DataControlRowType.DataRow) continue;
                int _Userid = Convert.ToInt32(row.Cells[0].Text);
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
                _manager.ExecuteSQL("UPDATE Users SET IsActive = '" + IsProductAvailable + "' Where ID =" + _Userid + "");
                GetAdminUser();

            }
        }

        protected void GridAllUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = true;
        }

        protected void editLink_Click(object sender, EventArgs e)
        {
            LinkButton linkbutton = (LinkButton)sender;  // get the link button which trigger the event
            var row = (GridViewRow)linkbutton.NamingContainer; // get the GridViewRow that contains the linkbutton
            //FillModalCategoryDDL();
            int _userId = Convert.ToInt32(row.Cells[0].Text);
            hfUserId.Value = _userId.ToString();
            TxtName.Text = row.Cells[3].Text;
            TxtEmail.Text = row.Cells[4].Text;
            TxtPassword.Text = row.Cells[5].Text;
            ddlRole.SelectedValue = row.Cells[2].Text;
          
            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "$('#userModal').modal()", true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "$('#userModal').modal()", true);
        }
    }
}