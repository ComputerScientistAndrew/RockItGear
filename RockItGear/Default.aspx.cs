using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RockItGear
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedOut"] == null)
            {
                Session["LoggedOut"] = "false";
            }
            else if (Session["LoggedOut"].ToString() == "true")
            {
                LogoutMessage.Visible = true;
            }
            else
            {
                LogoutMessage.Visible = false;
            }
        }
    }
}