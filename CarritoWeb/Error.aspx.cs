using System;

namespace CarritoWeb
{
    public partial class Error : System.Web.UI.Page
    {
        private string msj { get; set; } = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["error"] != null)
            {
                var err = (Exception)Session["error"];
                msj = err.Message;
                lblMsj.Text = err.Message;
                lblPath.Text = err.Source;
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