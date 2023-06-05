using Dominio;
using Negocio;
using System;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarritoWeb
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        public int countItems { get; set; } = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(!IsPostBack)
                {
                    if (Session["countCarrito"] != null)
                        countItems = (int)Session["countCarrito"];
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }

        }
    }
}