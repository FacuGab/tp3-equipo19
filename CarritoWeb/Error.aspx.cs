using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarritoWeb
{
    public partial class Error : System.Web.UI.Page
    {
        private string msj { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["error"] != null)
            {
                var err = (Exception)Session["error"];
                msj = err.Message;
                lblMsj.Text = err.Message;
            }
            else
            {
                lblMsj.Text = "Error inesperado";
            }
        }
        public string MessegError()
        {
            return msj;
        }
    }
}