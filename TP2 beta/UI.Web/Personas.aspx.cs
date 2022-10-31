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
    public partial class Personas : formApplication
    {

        PersonaLogic _PersonaLogic;
        private PersonaLogic PersonaLogic
        {
            get
            {
                if (_PersonaLogic == null)
                {
                    _PersonaLogic = new PersonaLogic();
                }
                return _PersonaLogic;
            }
        }

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        protected int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set { this.ViewState["SelectedID"] = value; }
        }

        protected bool IsEntitySelected
        {
            get { return (this.SelectedID != 0); }
        }

        private Business.Entities.Personas Entity
        {
            get;
            set;
        }

        private void LoadGrid()
        {
            this.gridView.DataSource = this.PersonaLogic.GetAll();
            this.gridView.DataBind();


        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.LoadGrid();
            }
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var row = gridView.SelectedRow;
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        private void LoadForm(int id)
        {
            this.Entity = this.PersonaLogic.GetOne(id);
            this.nombreTextBox.Text = this.Entity.Nombre;
            this.apellidoTextBox.Text = this.Entity.Apellido;
            this.direccionTextBox.Text = this.Entity.Direccion;
            this.emailTextBox.Text = this.Entity.Email;
            this.telefonoTextBox.Text = this.Entity.Telefono.ToString();
            this.fechaNacimientoTextBox.Text = this.Entity.FechaNacimiento.ToString();
            this.legajoTextBox.Text = this.Entity.Legajo.ToString();
            this.PlanDDLPersonas.Items.Clear();
            PlanLogic planLogic = new PlanLogic();
            List<Plan> planes = planLogic.GetAll();
            foreach (Plan plan in planes)
            {
                ListItem i = new ListItem(plan.Descripcion, plan.IDPlan.ToString());
                if (!PlanDDLPersonas.Items.Contains(i))
                {
                    PlanDDLPersonas.Items.Add(i);
                }
            }
            PlanDDLPersonas.SelectedValue = Entity.Plan.IDPlan.ToString();


        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {

        }

        private void LoadEntity()
        {
            Entity.Nombre = this.nombreTextBox.Text;
            Entity.Apellido = this.apellidoTextBox.Text;
            Entity.Direccion = this.direccionTextBox.Text;
            Entity.Email = this.emailTextBox.Text;
            Entity.Telefono = this.telefonoTextBox.Text;
            Entity.FechaNacimiento = Convert.ToDateTime(this.fechaNacimientoTextBox.Text);
            Entity.Legajo = Convert.ToInt32(this.legajoTextBox.Text);
            PlanLogic planLogic = new PlanLogic();
            Entity.Plan = planLogic.GetOne(Convert.ToInt32(this.PlanDDLPersonas.SelectedValue));
        }

        private void SaveEntity()
        {
            this.PersonaLogic.Save(this.Entity);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {

        }

        private void EnableForm(bool enable)
        {
            this.nombreTextBox.Enabled = enable;
            this.apellidoTextBox.Enabled = enable;
            this.emailTextBox.Enabled = enable;
            this.telefonoTextBox.Enabled = enable;
            this.fechaNacimientoTextBox.Enabled = enable;
            this.legajoTextBox.Enabled = enable;
            this.PlanDDLPersonas.Enabled = enable;

        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {

        }

        private void DeleteEntity(int id)
        {
            try
            {
                this.PersonaLogic.Delete(id);

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
            this.direccionTextBox.Text = string.Empty;
            this.emailTextBox.Text = string.Empty;
            this.telefonoTextBox.Text = string.Empty;
            this.telefonoTextBox.Text = string.Empty;
            this.fechaNacimientoTextBox.Text = string.Empty;
            this.legajoTextBox.Text = string.Empty;
            this.PlanDDLPersonas.Items.Clear();
            PlanLogic planLogic = new PlanLogic();
            List<Plan> planes = planLogic.GetAll();
            foreach (Plan plan in planes)
            {
                ListItem i = new ListItem(plan.Descripcion, plan.IDPlan.ToString());
                if (!PlanDDLPersonas.Items.Contains(i))
                {
                    PlanDDLPersonas.Items.Add(i);
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

        protected void aceptarButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    {
                        this.Entity = new Business.Entities.Personas();
                        this.Entity.State = BusinessEntity.States.New;
                        this.LoadEntity();
                        this.SaveEntity();
                        this.LoadGrid();
                        break;
                    }
                case FormModes.Modificacion:
                    {
                        this.Entity = new Business.Entities.Personas();
                        this.Entity.IDPersona = this.SelectedID;
                        this.Entity.State = BusinessEntity.States.Modified;
                        this.LoadEntity();
                        this.SaveEntity();
                        this.LoadGrid();
                        break;
                    }
                case FormModes.Baja:
                    {
                        this.DeleteEntity(this.SelectedID);
                        this.LoadGrid();
                        break;
                    }
                default:
                    break;
            }
            this.formPanel.Visible = false;
        }

        protected void cancelarButton_Click(object sender, EventArgs e)
        {
            formPanel.Visible = false;
            LoadGrid();
        }

        protected void PlanDDL_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}