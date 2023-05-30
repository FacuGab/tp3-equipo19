using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarritoWeb
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                dgvCarrito.DataSource = Session["selected"];
                dgvCarrito.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }

        }
    }
}