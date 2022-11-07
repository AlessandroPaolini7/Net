﻿using System;
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
            if (this.Session["UserID"] != null)
            {
                string id_usuario = this.Session["UserID"].ToString();
                UsuarioLogic ua = new UsuarioLogic();
                Business.Entities.Usuario usuario = ua.GetOne(Convert.ToInt32(id_usuario));
                if (usuario.Persona.TipoPersona != Business.Entities.Personas.TipoPersonas.Administrador)
                {
                    Response.Redirect("Default.aspx");

                }
                else if (!this.IsPostBack)
                {
                    this.LoadGrid();
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var row = gridView.SelectedRow;
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        private void LoadForm(int id)
        {
            this.Entity = this.Planlogic.GetOne(id);
            this.descripcionTextBox.Text = this.Entity.Descripcion;

            this.EspecialidadDDLPlan.Items.Clear();
            EspecialidadLogic especialidadLogic = new EspecialidadLogic();
            List<Especialidad> especialidades = especialidadLogic.GetAll();
            foreach (Especialidad especialidad in especialidades)
            {
                ListItem i = new ListItem(especialidad.Descripcion, especialidad.IDEspecialidad.ToString());
                if (!EspecialidadDDLPlan.Items.Contains(i))
                {
                    EspecialidadDDLPlan.Items.Add(i);
                }
            }
            EspecialidadDDLPlan.SelectedValue = Entity.Especialidad.IDEspecialidad.ToString();

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

        private void LoadEntity()
        {
            Entity.Descripcion = this.descripcionTextBox.Text;
            EspecialidadLogic especialidadLogic = new EspecialidadLogic();
            Entity.Especialidad = especialidadLogic.GetOne(Convert.ToInt32(this.EspecialidadDDLPlan.SelectedValue));
        }

        private void SaveEntity()
        {
            this.Planlogic.Save(Entity);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {

        }

        private void EnableForm(bool enable){
            this.descripcionTextBox.Enabled = enable;
            this.EspecialidadDDLPlan.Enabled = enable;
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {

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

        }

        private void ClearForm()
        {
            this.descripcionTextBox.Text = string.Empty;

            this.EspecialidadDDLPlan.Items.Clear();
            EspecialidadLogic especialidadLogic = new EspecialidadLogic();
            List<Especialidad> especialidades = especialidadLogic.GetAll();
            foreach (Especialidad especialidad in especialidades)
            {
                ListItem i = new ListItem(especialidad.Descripcion, especialidad.IDEspecialidad.ToString());
                if (!EspecialidadDDLPlan.Items.Contains(i))
                {
                    EspecialidadDDLPlan.Items.Add(i);
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
                        this.Entity.State = BusinessEntity.States.New;
                        this.LoadEntity();
                        this.SaveEntity();
                        this.LoadGrid();
                        break;
                    }
                case FormModes.Modificacion:
                    {
                        this.Entity = new Plan();
                        this.Entity.IDPlan = this.SelectedID;
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