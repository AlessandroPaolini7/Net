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
    public partial class Materias : formApplication
    {
        MateriaLogic _MateriaLogic;
        private MateriaLogic MateriaLogic
        {
            get
            {
                if (_MateriaLogic == null)
                {
                    _MateriaLogic = new MateriaLogic();
                }
                return _MateriaLogic;
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

        private Materia Entity
        {
            get;
            set;
        }

        private void LoadGrid()
        {
            this.gridView.DataSource = this.MateriaLogic.GetAll();
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
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        private void LoadForm(int id)
        {
            this.Entity = this.MateriaLogic.GetOne(id);
            this.descripcionTextBox.Text = this.Entity.Descripcion;
            this.hsSemanalesTextBox.Text = this.Entity.HorasSemanales.ToString();
            this.hsTotalesTextBox.Text = this.Entity.HorasTotales.ToString();
            this.PlanDDL.Items.Clear();
            PlanLogic planLogic = new PlanLogic();
            List<Plan> planes = planLogic.GetAll();
            foreach (Plan plan in planes)
            {
                ListItem i = new ListItem(plan.Descripcion, plan.IDPlan.ToString());
                if (!PlanDDL.Items.Contains(i))
                {
                    PlanDDL.Items.Add(i);
                }
            }
            PlanDDL.SelectedValue = Entity.Plan.IDPlan.ToString();


        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
           
        }

        private void LoadEntity()
        {
            Entity.Descripcion = this.descripcionTextBox.Text;
            Entity.HorasSemanales = Convert.ToInt32(this.hsSemanalesTextBox.Text);
            Entity.HorasTotales = Convert.ToInt32(this.hsTotalesTextBox.Text);
            PlanLogic planLogic = new PlanLogic();
            Entity.Plan = planLogic.GetOne(Convert.ToInt32(this.PlanDDL.SelectedValue));
        }

        private void SaveEntity()
        {
            this.MateriaLogic.Save(this.Entity);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            
        }

        private void EnableForm(bool enable)
        {
            this.descripcionTextBox.Enabled = enable;
            this.hsSemanalesTextBox.Enabled = enable;
            this.hsTotalesTextBox.Enabled = enable;
            this.PlanDDL.Enabled = enable;

        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            
        }

        private void DeleteEntity(int id)
        {
            this.MateriaLogic.Delete(id);
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {

        }

        private void ClearForm()
        {
            this.descripcionTextBox.Text = string.Empty;
            this.hsSemanalesTextBox.Text = string.Empty;
            this.hsTotalesTextBox.Text = string.Empty;

            this.PlanDDL.Items.Clear();
            PlanLogic planLogic = new PlanLogic();
            List<Plan> planes = planLogic.GetAll();
            foreach (Plan plan in planes)
            {
                ListItem i = new ListItem(plan.Descripcion, plan.IDPlan.ToString());
                if (!PlanDDL.Items.Contains(i))
                {
                    PlanDDL.Items.Add(i);
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
                        this.Entity = new Materia();
                        this.Entity.State = BusinessEntity.States.New;
                        this.LoadEntity();
                        this.SaveEntity();
                        this.LoadGrid();
                        break;
                    }
                case FormModes.Modificacion:
                    {
                        this.Entity = new Materia();
                        this.Entity.IDMateria = this.SelectedID;
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