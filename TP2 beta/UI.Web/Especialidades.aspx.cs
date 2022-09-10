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
    public partial class Especialidades : formApplication
    {
        EspecialidadLogic _Esplogic;
        private EspecialidadLogic Esplogic
        {
            get
            {
                if (_Esplogic == null)
                {
                    _Esplogic = new EspecialidadLogic();
                }
                return _Esplogic;
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


        private Especialidad Entity { get; set; }

        private void LoadGrid()
        {
            this.gridViewEsp.DataSource = this.Esplogic.GetAll();
            gridViewEsp.DataBind();
        }
        protected new void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) this.LoadGrid();
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var row = gridViewEsp.SelectedRow;
            this.SelectedID =  Convert.ToInt32(row.Cells[0].Text);
            // this.SelectedID = (int)this.gridViewEsp.SelectedValue;
        }

        private void LoadForm(int id)
        {
            this.Entity = this.Esplogic.GetOne(id);
            this.descripcionTextBox.Text = this.Entity.Descripcion;
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

        private void LoadEntity(Especialidad especialidad)
        {
            especialidad.Descripcion = this.descripcionTextBox.Text;
        }

        private void SaveEntity(Especialidad especialidad)
        {
            this.Esplogic.Save(especialidad);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.Entity = new Especialidad();
                    this.Entity.IDEspecialidad = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Especialidad();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
            }

            this.formPanel.Visible = false;
        }

        private void EnableForm(bool enable)
        {
            this.descripcionTextBox.Enabled = enable;
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
            this.Esplogic.Delete(id);
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
        }
    }
}