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
    public partial class Comisiones : formApplication
    {

        ComisionLogic _Comlogic;
        private ComisionLogic Comlogic
        {
            get
            {
                if (_Comlogic == null)
                {
                    _Comlogic = new ComisionLogic();
                }
                return _Comlogic;
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

        private Comision Entity { get; set; }

        private void LoadGrid(){
            this.gridView.DataSource = this.Comlogic.GetAll();
            this.gridView.DataBind();
        }

        protected new void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.LoadGrid();
            }
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var row = gridView.SelectedRow;
            this.SelectedID = Convert.ToInt32(row.Cells[0].Text);
        }

        private void LoadForm(int id){
            this.Entity = this.Comlogic.GetOne(id);
            this.descripcionTextBox.Text = this.Entity.Descripcion;
            this.anioespecialidadTextBox.Text = Convert.ToString(this.Entity.AnioEspecialidad);
            this.idplanTextBox.Text = Convert.ToString(this.Entity.IDPlan);
        }



        private void LoadEntity(Business.Entities.Comision comision)
        {
            comision.Descripcion = this.descripcionTextBox.Text;
            comision.AnioEspecialidad = Convert.ToInt32(this.anioespecialidadTextBox.Text);
            comision.IDPlan = Convert.ToInt32(this.idplanTextBox.Text);
        }

        private void SaveEntity(Business.Entities.Comision comision)
        {
            this.Comlogic.Save(comision);
        }


        private void EnableForm(bool enable){
            this.descripcionTextBox.Enabled = enable;
            this.anioespecialidadTextBox.Enabled = enable;
            this.idplanTextBox.Enabled = enable;
        }


        private void DeleteEntity(int id)
        {
            this.Comlogic.Delete(id);
        }


        private void ClearForm()
        {
            this.descripcionTextBox.Text = string.Empty;
            this.anioespecialidadTextBox.Text = string.Empty;
            this.idplanTextBox.Text = string.Empty;
        }

        protected void editarButton_Click(object sender, EventArgs e)
        {
            if(this.IsEntitySelected){
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
                        this.Entity = new Comision();
                        this.LoadEntity(this.Entity);
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();
                        break;
                    }
                case FormModes.Modificacion:
                    {
                        this.Entity = new Comision();
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


        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
        }

        protected void cancelarButton_Click(object sender, EventArgs e)
        {
            formPanel.Visible = false;
            LoadGrid();
        }
    }
}