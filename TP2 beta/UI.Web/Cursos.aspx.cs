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
    public partial class Cursos : formApplication
    {
        CursoLogic _CursoLogic;
        private CursoLogic CursoLogic
        {
            get
            {
                if (_CursoLogic == null)
                {
                    _CursoLogic = new CursoLogic();
                }
                return _CursoLogic;
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

        private Curso Entity
        {
            get;
            set;
        }

        private void LoadGrid()
        {
            this.gridView.DataSource = this.CursoLogic.GetAll();
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
            this.Entity = this.CursoLogic.GetOne(id);
            this.anioCalendarioTextBox.Text = this.Entity.AnioCalendario.ToString();
            this.cupoTextBox.Text = this.Entity.Cupo.ToString();

            this.MateriaDDL.Items.Clear();
            MateriaLogic materiaLogic = new MateriaLogic();
            List<Materia> materias = materiaLogic.GetAll();
            foreach (Materia materia in materias)
            {
                ListItem i = new ListItem(materia.Descripcion, materia.IDMateria.ToString());
                if (!MateriaDDL.Items.Contains(i))
                {
                    MateriaDDL.Items.Add(i);
                }
            }
            MateriaDDL.SelectedValue = Entity.Materia.IDMateria.ToString();

            this.ComisionDDL.Items.Clear();
            ComisionLogic comisionLogic = new ComisionLogic();
            List<Comision> comisiones = comisionLogic.GetAll();
            foreach (Comision comision in comisiones)
            {
                ListItem i = new ListItem(comision.Descripcion, comision.IDComision.ToString());
                if (!ComisionDDL.Items.Contains(i))
                {
                    ComisionDDL.Items.Add(i);
                }
            }
            ComisionDDL.SelectedValue = Entity.Comision.IDComision.ToString();


        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {

        }

        private void LoadEntity()
        {
            this.Entity.AnioCalendario = Convert.ToInt32(this.anioCalendarioTextBox.Text);
            this.Entity.Cupo = Convert.ToInt32(this.cupoTextBox.Text);

            MateriaLogic materiaLogic = new MateriaLogic();
            this.Entity.Materia = materiaLogic.GetOne(Convert.ToInt32(this.MateriaDDL.SelectedValue));

            ComisionLogic comisionLogic = new ComisionLogic();
            this.Entity.Comision =  comisionLogic.GetOne(Convert.ToInt32(this.ComisionDDL.SelectedValue));
        }

        private void SaveEntity()
        {
            this.CursoLogic.Save(this.Entity);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {

        }

        private void EnableForm(bool enable)
        {
            this.anioCalendarioTextBox.Enabled = enable;
            this.cupoTextBox.Enabled = enable;
            this.MateriaDDL.Enabled = enable;
            this.ComisionDDL.Enabled = enable;

        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {

        }

        private void DeleteEntity(int id)
        {
            this.CursoLogic.Delete(id);
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {

        }

        private void ClearForm()
        {
            this.anioCalendarioTextBox.Text = string.Empty;
            this.cupoTextBox.Text = string.Empty;

            this.MateriaDDL.Items.Clear();
            MateriaLogic materiaLogic = new MateriaLogic();
            List<Materia> materias = materiaLogic.GetAll();
            foreach (Materia materia in materias)
            {
                ListItem i = new ListItem(materia.Descripcion, materia.IDMateria.ToString());
                if (!MateriaDDL.Items.Contains(i))
                {
                    MateriaDDL.Items.Add(i);
                }
            }

            this.ComisionDDL.Items.Clear();
            ComisionLogic comisionLogic = new ComisionLogic();
            List<Comision> comisiones = comisionLogic.GetAll();
            foreach (Comision comision in comisiones)
            {
                ListItem i = new ListItem(comision.Descripcion, comision.IDComision.ToString());
                if (!ComisionDDL.Items.Contains(i))
                {
                    ComisionDDL.Items.Add(i);
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
                        this.Entity = new Curso();
                        this.Entity.State = BusinessEntity.States.New;
                        this.LoadEntity();
                        this.SaveEntity();
                        this.LoadGrid();
                        break;
                    }
                case FormModes.Modificacion:
                    {
                        this.Entity = new Curso();
                        this.Entity.IDCurso = this.SelectedID;
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
    }
}