using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Login : System.Web.UI.Page
    {
        Business.Logic.UsuarioLogic UsuarioNegocio;
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioNegocio = new Business.Logic.UsuarioLogic();
            this.Session["UserID"] = null;
        }
                

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            var user = UsuarioNegocio.BuscarPorNombre(txtUsuario.Text);
            if (user is null) Page.Response.Write("Usuario incorrecto.");
            else if (user.Clave != txtClave.Text)
            {
                Page.Response.Write("Clave incorrecta");
            }
            else
            {
                this.Session["UserID"] = user.ID.ToString();
                Page.Response.Write("Ingreso OK");
                Response.Redirect("Default.aspx");
            }
        }

        protected void lnkRecordarClave_Click(object sender, EventArgs e)
        {
           
        }
    }
}