using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;

namespace UI.Web
{
    public partial class Usuarios : formApplication
    {
        UsuarioLogic _logic;
        private UsuarioLogic Logic
        {
            get
            {
                if(_logic == null)
                {
                    _logic = new UsuarioLogic();
                }
                return _logic;
            }
        }

        public FormModes FormMode
        {
            get
            {
                return (FormModes)this.ViewState["FormMode"];
            }
            set
            {
                this.ViewState["FormMode"] = value;
            }
        }

        protected int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null) return (int)this.ViewState["SelectedID"];
                else return 0;
            }
            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }
        protected bool IsEntitySelected
        {
            get { return (this.SelectedID != 0); }
        }


        private Usuario Entity { get; set; }
        
        private void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAll();
            gridView.DataBind();
        }
        protected new void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) this.LoadGrid();
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.nombreTextBox.Text = this.Entity.Nombre;
            this.apellidoTextBox.Text = this.Entity.Apellido;
            this.emailTextBox.Text = this.Entity.Email;
            this.habilitadoCheckBox.Checked = this.Entity.Habilitado;
            this.nombreUsuarioTextBox.Text = this.Entity.NombreUsuario;
            PersonaLogic personaLogic = new PersonaLogic();
            List<Business.Entities.Personas> personas = personaLogic.GetAll();
            foreach (Business.Entities.Personas persona in personas)
            {
                ListItem i = new ListItem(persona.Nombre, persona.IDPersona.ToString());
                if (!PersonaDDLUsuario.Items.Contains(i))
                {
                    PersonaDDLUsuario.Items.Add(i);
                }
            }
            this.PersonaDDLUsuario.SelectedValue = Entity.Persona.IDPersona.ToString();
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            
        }

        private void LoadEntity()
        {
            Entity.Nombre = this.nombreTextBox.Text;
            Entity.Apellido = this.apellidoTextBox.Text;
            Entity.Email = this.emailTextBox.Text;
            Entity.NombreUsuario = this.nombreUsuarioTextBox.Text;
            Entity.Clave = this.claveTextBox.Text;
            Entity.Habilitado = this.habilitadoCheckBox.Checked;
            PersonaLogic personaLogic = new PersonaLogic();
            this.Entity.Persona = personaLogic.GetOne(Convert.ToInt32(this.PersonaDDLUsuario.SelectedValue));
        }

        private void SaveEntity()
        {
            this.Logic.Save(Entity);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            
        }

        protected void repetirClaveTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void EnableForm(bool enable)
        {
            
            this.nombreTextBox.Enabled = enable;
            this.apellidoTextBox.Enabled = enable;
            this.emailTextBox.Enabled = enable;
            this.nombreUsuarioTextBox.Enabled = enable;
            this.claveTextBox.Visible = enable;
            this.claveLabel.Visible = enable;
            this.repetirClaveTextBox.Visible = enable;
            this.repetirClaveLabel.Visible = enable;
            this.PersonaDDLUsuario.Enabled = enable;
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            
        }

        private void DeleteEntity(int id)
        {
            try
            {
                this.Logic.Delete(id);

            }
            catch (Exception ex)
            {

                this.Response.Write(ex.Message);
            }
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            
        }

        private void ClearForm()
        {
            this.nombreTextBox.Text = string.Empty;
            this.apellidoTextBox.Text = string.Empty;
            this.emailTextBox.Text = string.Empty;
            this.habilitadoCheckBox.Checked = false;
            this.nombreUsuarioTextBox.Text = string.Empty;
            PersonaLogic personaLogic = new PersonaLogic();
            List<Business.Entities.Personas> personas = personaLogic.GetAll();
            foreach (Business.Entities.Personas persona in personas)
            {
                ListItem i = new ListItem(persona.Nombre, persona.IDPersona.ToString());
                if (!PersonaDDLUsuario.Items.Contains(i))
                {
                    PersonaDDLUsuario.Items.Add(i);
                }
            }
        }

        protected void editarButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.EnableForm(true);
                this.LoadForm(this.SelectedID);
            }
        }

        protected void eliminarButton_Click(object sender, EventArgs e)
        {

            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        protected void apellidoTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        protected void aceptarButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.Entity = new Usuario();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity();
                    this.SaveEntity();
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Usuario();
                    this.Entity.State = BusinessEntity.States.New;
                    this.LoadEntity();
                    this.SaveEntity();
                    this.LoadGrid();
                    break;
            }

            this.formPanel.Visible = false;
        }
        protected void Validar()
        {

        }
        protected void cancelarButton_Click(object sender, EventArgs e)
        {
           
            formPanel.Visible = false;
            LoadGrid();

        }
    }
}