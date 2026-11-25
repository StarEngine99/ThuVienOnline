using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThuVienOnline
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool isLoggedIn = Session["MaNguoiDung"] != null;
            LoginNav.Visible = !isLoggedIn;
            RegisterNav.Visible = !isLoggedIn;
            WelcomeLabel.Visible = isLoggedIn;
            LogoutLink.Visible = isLoggedIn;

            if (isLoggedIn)
            {
                WelcomeLabel.Text = "Xin chào, " + Server.HtmlEncode(Convert.ToString(Session["HoTen"]));
            }
        }

        protected void LogoutLink_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/GiaoDien/Default.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}