using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace U5.Lab1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnIngresar.Attributes.Add("OnClick", "javascript:return btnIngresar_ClickJs();");
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if(txtUsuario.Text.ToLower() == "admin" & txtClave.Text == "admin")
            {
                Page.Response.Write("Ingreso OK");
            }
            else
            {
                Page.Response.Write("Usuario y/o clave incorrectos");
            }
        }

        protected void lnkRecordarClave_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/OlvidoClave.aspx?msj=Es usted un usuario muy descuidado, haga memoria");
        }
    }
}