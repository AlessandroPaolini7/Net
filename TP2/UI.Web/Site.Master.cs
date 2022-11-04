using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;


namespace UI.Web
{
    public partial class Site : System.Web.UI.MasterPage
    {
        Business.Entities.Usuario usuarioActual;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["UserID"] != null)
            {
                string id_usuario = this.Session["UserID"].ToString();
                UsuarioLogic usuarioLogic = new UsuarioLogic();
                usuarioActual = usuarioLogic.GetOne(Convert.ToInt32(id_usuario));
                if (usuarioActual.Persona.TipoPersona == Business.Entities.Personas.TipoPersonas.Alumno)
                {
                    this.mnuPlanes.Visible = false;
                    this.mnuPersonas.Visible = false;
                    this.mnuCursos.Visible = false;
                    this.mnuEspecialidades.Visible = false;
                    this.mnuUsuarios.Visible = false;
                    this.mnuReporteNotas.Visible = false;

                }
                else if(usuarioActual.Persona.TipoPersona == Business.Entities.Personas.TipoPersonas.Docente)
                {
                    this.mnuPlanes.Visible = false;
                    this.mnuPersonas.Visible = false;
                    this.mnuCursos.Visible = false;
                    this.mnuEspecialidades.Visible = false;
                    this.mnuUsuarios.Visible = false;
                }
            }
            
        }
    }
}