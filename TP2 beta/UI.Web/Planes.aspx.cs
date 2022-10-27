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
    public partial class Planes : formApplication
    {
        PlanLogic _Planlogic;
        private PlanLogic Planlogic
        {
            get
            {
                if (_Planlogic == null)
                {
                    _Planlogic = new PlanLogic();
                }
                return _Planlogic;
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

        private Plan Entity
        {
            get;
            set;
        }

        private void LoadGrid(){
            this.gridView.DataSource = this.Planlogic.GetAll();
            this.gridView.DataBind();
        }

        protected new void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.LoadGrid();
            }
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var row = gridView.SelectedRow;
            this.SelectedID =  Convert.ToInt32(row.Cells[0].Text);
        }

        private void LoadForm(int id)
        {
            this.Entity = this.Planlogic.GetOne(id);
            this.descripcionTextBox.Text = this.Entity.Descripcion;
            this.idespecialidadTextBox.Text = Convert.ToString(this.Entity.IDEspecialidad);

        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.EnableForm(true);
                this.LoadForm(this.SelectedID);
            }
        }

        private void LoadEntity(Business.Entities.Plan plan)
        {
            plan.Descripcion = this.descripcionTextBox.Text;
            plan.IDEspecialidad = Convert.ToInt32(this.idespecialidadTextBox.Text);
        }

        private void SaveEntity(Business.Entities.Plan plan)
        {
            this.Planlogic.Save(plan);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    {
                        this.Entity = new Plan();
                        this.LoadEntity(this.Entity);
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();
                        break;
                    }
                case FormModes.Modificacion:
                    {
                        this.Entity = new Plan();
                        this.Entity.ID = this.SelectedID;
                        this.Entity.State = BusinessEntity.States.Modified;
                        this.LoadEntity(this.Entity);
                        this.SaveEntity(this.Entity);
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

        private void EnableForm(bool enable){
            this.descripcionTextBox.Enabled = enable;
            this.idespecialidadTextBox.Enabled = enable;
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }

        private void DeleteEntity(int id)
        {
            try
            {
                this.Planlogic.Delete(id);

            }
            catch (Exception ex)
            {

                this.Response.Write(ex.Message);
            }
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        private void ClearForm()
        {
            this.descripcionTextBox.Text = string.Empty;
            this.idespecialidadTextBox.Text = string.Empty;
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
            if(this.IsEntitySelected){
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
                        this.Entity = new Plan();
                        this.LoadEntity(this.Entity);
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();
                        break;
                    }
                case FormModes.Modificacion:
                    {
                        this.Entity = new Plan();
                        this.Entity.ID = this.SelectedID;
                        this.Entity.State = BusinessEntity.States.Modified;
                        this.LoadEntity(this.Entity);
                        this.SaveEntity(this.Entity);
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
    }
}